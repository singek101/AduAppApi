using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Models
{
    public class WishListItem
    {
        [Key]
        public string WishListItemId { get; set; }

        public virtual Product Product { get; set; }

        public string ProductId { get; set; }

        public virtual WishList WishList { get; set; }

        
        public string WishListId { get; set; }
    }
}
