using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace C4rzf0rs4le
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace VideoUploadAPI
    {
        public class userslisting
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            public string Phone_number { get; set; }

            [Required]
            public string Make { get; set; }

            [Required]
            public string Model { get; set; }

            [Required]
            public string Color { get; set; }

            [Required]
            public int Make_year { get; set; }

            [Required]
            public string Horsepower { get; set; }

            [Required]
            public string Mileage { get; set; }

            public string Video_path { get; set; }

            public string Price { get; set; }
        }

        public class usersdatas
        {
            [Key]
            public string Username { get; set; }

            [Required]
            public string Userphone { get; set; }

            public string User_Email { get; set; }

            public string Userpasswd { get; set; }
        }
    }

}