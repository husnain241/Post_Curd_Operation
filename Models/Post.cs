using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Post_Crud.Models
{
    public class Post
    {
        [Key]
        public int Post_Id { get; set; }

        [Required]
        [Column("Post_Name", TypeName = "varchar(30)")]
        public string Post_Name { get; set; }

        [Required]
        [Column("Post_Description", TypeName = "varchar(100)")]
        public string Post_Description { get; set; }
    }
}
