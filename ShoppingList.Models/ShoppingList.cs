using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping_List.Models
{
    public class ShoppingList
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Please enter a Hex Value.")]
        public string Color { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }

        public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}