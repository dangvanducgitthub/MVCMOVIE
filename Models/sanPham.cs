using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace MvcMovie.Models
{
    [Table("sanPham")]
    public class sanPham
    {
        [Key]
        public string sanPhamId { get; set; }
        public string sanPhamName { get; set; }
        public string CategoryId { get; set; }
        public Category Categories {get;set;}
    }
}