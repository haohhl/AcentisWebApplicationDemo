using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApplicationDemo.Models
{
    public class MemberModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        [JsonProperty("email")]
        [Required(ErrorMessage = "Email is required")]
        [Key]
        public string Email { get; set; }

        [Column(TypeName = "varchar(200)")]
        [JsonProperty("password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Mobile Number is required")]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Column(TypeName = "DateTime")]
        [Required(ErrorMessage = "Date Of Birth is required")]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "varchar(200)")]
        [DisplayName("Email Opt-In")]
        public string EmailOptIn { get; set; }

        public string Token { get; set; }
    }
}
