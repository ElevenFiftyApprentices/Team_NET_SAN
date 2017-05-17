using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping_List.Models
{
    public enum Priority
    {
        Need,
        Want,
        Later
    }
    public class ShoppingListItem
    {
        public int Id { get; set; }

        public int ShoppingListId { get; set; }

        public string Contents { get; set; }

        [DefaultValue(false)]
        public bool IsChecked { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

        public virtual ICollection<ShoppingList> ShoppingList { get; set; }
    }
}