using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace MvcMovie.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<sanPham> sanPhams {get;set;}
    }
}