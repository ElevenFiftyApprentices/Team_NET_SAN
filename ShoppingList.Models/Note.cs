using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping_List.Models
{
    public class Note
    {
        public int Id { get; set; }

        public int ShoppingListId { get; set; }

        public string Body { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

        public virtual ICollection<ShoppingList> ShoppingList { get; set; }
    }
}