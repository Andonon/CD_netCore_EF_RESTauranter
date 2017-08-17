using System;

namespace RESTauranter.Models
{
    public class Review: BaseEntity
    {
        public int id { get; set; }
        public string reviewer { get; set; }
        public string restaurant { get; set; }
        public string review { get; set; }
        public DateTime dateofvisit { get; set; }
        public string stars { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}