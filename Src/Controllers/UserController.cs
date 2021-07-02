using Aduaba.DTO;
using Aduaba.DTO.Account;
using Aduaba.Services;
using Aduaba.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServices _userServices;      
        private readonly IMailServices _mailservices;
        private readonly IConfiguration _configuration;
        public UserController(IUserServices userServices, IConfiguration configuration, IMailServices mailservices)
        {
            _userServices = userServices;         
            _mailservices = mailservices;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginRequest model)
        {
            if (ModelState.IsValid)
            {

                var result = await _userServices.LoginUserAsync(model);
                
                if (result.IsSuccess)
                {
                    SetRefreshTokenInCookie(result.RefreshToken);

                    await _mailservices.SendEmailAsync(model.Email, "New Login", "<h1> Hey! new login to your account noticed</h1><p>New login to your account at" + DateTime.Now + "</p>");
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUserAsync([FromBody]RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userServices.RegisterUserAsync(model);
                if (result.IsSuccess)
                    return Ok(result);
                return BadRequest(result);
            }
            return BadRequest("Some fields are invalid");
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))

                return NotFound();

            var result = await _mailservices.ConfirmEmailAsync(userId, token);
            if (result.IsSuccess)
            {
                //if email is confirmed successfully, return user to a static html page wwwroot
                return Redirect($"{_configuration["AppUrl"]}/ConfirmEmail.html");

            }
            return BadRequest(result);

        }

        [HttpPost("ForgetPassword")]

        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return NotFound();
            var result = await _userServices.ForgetPasswordAsync(email);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);

        }

        [HttpPost("ResetPassword")]

        public async Task<IActionResult> ResetPassword([FromForm] ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userServices.ResetPasswordAsync(model);
                if (result.IsSuccess)
                    return Ok(result);
                return BadRequest(result);

            }
            return BadRequest("Some fields are invalid");
        }




        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10),
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }


       

        [HttpPost("refresh-t")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _userServices.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRefreshTokenInCookie(response.RefreshToken);
            return Ok(response);
        }

        [HttpPost("revoke-token")]
        public IActionResult RevokeToken()
        {
            // accept token from request body or cookie
            var token =  Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });
            var response = _userServices.RevokeRefreshToken(token);
            if (!response)
                return NotFound(new { message = "Token not found" });
            return Ok(new { message = "Token revoked" });
        }

        //[HttpDelete("Logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    var result=await _userServices.LogoutAsync();
        //    // accept token from request body or cookie
        //    var token = Request.Cookies["refreshToken"];
        //    var response = _userServices.RevokeRefreshToken(token);
        //    if (result== "Signed out successfully")
        //    {  
        //        if (string.IsNullOrEmpty(token))
        //            return BadRequest(new { message = "Token is required" }); 
        //        if (!response)
        //            return NotFound(new { message = "Token not found" });
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
               
            
        //}
        
    }
}
