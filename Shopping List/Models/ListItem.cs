using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public enum Priority
    {
        Need,
        Want,
        Later
    }

    //Changed from "ShoppingListItem" to "ListItem" because 'ShoppingList' is in the namespace and couldn't be used
    public class ListItem
    {
        public int Id { get; set; }

        public int ShoppingListId { get; set; }

        public string Contents { get; set; }

        [DefaultValue(false)]
        public bool IsChecked { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

        public virtual ICollection<List> List { get; set; }
    }
}