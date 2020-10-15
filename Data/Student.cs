using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDatabase.Data
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student Number is required.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 10 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 10 characters.")]
        public string LastName { get; set; }
    }
}