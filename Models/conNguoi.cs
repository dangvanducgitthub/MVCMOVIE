using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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