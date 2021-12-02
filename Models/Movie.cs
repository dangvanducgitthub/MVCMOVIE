using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Tựa đề")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Ngày khởi chiếu")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Thể loại")]
        public string Genre { get; set; }
        [DisplayName("Giá bán")]
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}