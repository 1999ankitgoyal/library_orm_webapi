using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.EFcore
{
    [Table("authors")]
    public class authors
    {
        [Key,Required]
        public string? name { get; set; }
        public DateOnly? DOB { get; set; }
        public string? country  { get; set; } 

    }
}
