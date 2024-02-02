using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mars_Project_1.Models
{
    public class Players
    {

        // Primary key property
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Player information properties
        public string playerFname { get; set; }
        public string playerLname { get; set; }
        public int playerAge { get; set; }
        public int playerIdNumber { get; set; }
        public string playerAddress { get; set; }
        public string playerDesiredTeam { get; set; }

        //// Foreign key property
        //public int? UserId { get; set; }
        //public int? TeamId { get; set; }


        //// Navigation property
        //[ForeignKey("UserId")]
        //public virtual Users User { get; set; }

        //[ForeignKey("TeamId")]
        //public virtual Teams Team { get; set; }


    }
}
