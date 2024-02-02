using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Mars_Project_1.Models
{
    public class Users 
    {

        // Primary key property
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }

        // User information properties
        public String userUsername { get; set; }
        public String userPassword { get; set; }
    }
}
