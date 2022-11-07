using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.EFcore
{
    [Table("books")]
    public class books
    {
        [Key,Required]
        public string? title { get; set; }
        public string? DOP { get; set; } 
        public string? language { get; set; }
            
    }
}
