using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopping_List.Models
{
    public enum Priority
    {
        [Display(Name = "If you have time.")]
        Low = 0,
        [Display(Name = "If it's on sale...")]
        Moderate = 1,
        [Display(Name = "I MUST HAVE!")]
        High = 2
    }
    public class ShoppingListItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ShoppingList")]
        public int ShoppingListId { get; set; }

        public string Contents { get; set; }

        [DefaultValue(false)]
        public bool IsChecked { get; set; }


        public Priority Priority { get; set; }

        [MinLength(2)]
        [MaxLength(25)]
        public string Note { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

        public override string ToString()
        {
            return $"[{Id}]";
        }

        public virtual ICollection<ShoppingList> ShoppingList { get; set; }
    }
}