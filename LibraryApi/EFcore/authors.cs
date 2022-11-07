using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.EFcore
{
    [Table("authors")]
    public class authors
    {
        [Key,Required]
        public string? name { get; set; }
        public string? DOB { get; set; }
        public string? country  { get; set; } 

    }
}
