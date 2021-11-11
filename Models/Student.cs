using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public string StudentId { get; set; }
        [DisplayName("Tên")]
        public string StudentName { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
    }
}