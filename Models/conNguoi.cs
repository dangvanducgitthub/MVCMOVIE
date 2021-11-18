using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System;
namespace MvcMovie.Models
{
    [Table("conNguoi")]
    public class conNguoi
    {
        [Key]
        public string PersonId { get; set; }
        public string PersonName { get; set; }

    }
}