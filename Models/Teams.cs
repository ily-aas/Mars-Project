using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mars_Project_1.Models
{
    public class Teams
    {

        //Primary key properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teamID { get; set; }

        //Team information properties
        public String teamName { get; set; }
        public DateTime teamdateCreated { get; set; }
        public Boolean teamIsActive { get; set; }

        // Foreign key property
        //public int? UserId { get; set; }

        //// Navigation property
        //[ForeignKey("UserId")]
        //public virtual Users User { get; set; }

    }
}
