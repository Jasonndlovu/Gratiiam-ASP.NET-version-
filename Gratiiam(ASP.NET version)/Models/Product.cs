namespace Gratiiam_ASP.NET_version_.Models
{
    using System;
    using System.Collections.Generic;

    namespace Gratiiam_ASP.NET_version_.Models
    {
        public class Product
        {
            public string _id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string richDescription { get; set; }
            public string image { get; set; }
            public List<string> images { get; set; }
            public string brand { get; set; }
            public int price { get; set; }
            public Category category { get; set; }
            public int countInStock { get; set; }
            public int rating { get; set; }
            public int numReviews { get; set; }
            public bool isFeatured { get; set; }
            public DateTime dateCreated { get; set; }
            public int __v { get; set; }
            public string id { get; set; }
        }

        public class Category
        {
            public string _id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public string color { get; set; }
            public int __v { get; set; }
            public string id { get; set; }
        }
    }

}
