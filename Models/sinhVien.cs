using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models
{
    public class sinhVien :conNguoi
    {
        public string StudentID { get; set; }
        public string Address { get; set; }
        public string University{get;set;}
    }
}