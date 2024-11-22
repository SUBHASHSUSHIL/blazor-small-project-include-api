using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.Library
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your FatherName.")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Please enter your Number. ")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Please enter your Semester.")]
        [Range(1,8, ErrorMessage = "Please enter valid Semester 1 - 8")]
        public string Semester { get; set; }

        [Required(ErrorMessage = "Please enter your Email.")]
        [EmailAddress(ErrorMessage = "Please enter valid Email Address.")]
        public string Email {  get; set; }

        [Required(ErrorMessage = "Please enter your RollNo.")]
        public int RollNo { get; set; }

    }
}
