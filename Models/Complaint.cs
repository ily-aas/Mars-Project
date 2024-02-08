using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mars_Project_1.Models
{
    public class Complaint
    {
        // Primary key property
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Comaplaint information properties
        public string complaintFname { get; set; }
        public string complaintLname { get; set; }
        public string complaintEmail { get; set; }
        public string complaintMnumber { get; set; }
        public string complaintDetails { get; set; }
        public string complaintIP { get; set; }
        public DateTime complaintDateCreated { get; set; }


    }
}
