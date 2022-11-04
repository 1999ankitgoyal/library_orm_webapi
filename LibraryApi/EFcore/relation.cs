using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.EFcore
{
    [Table("relation")]

    public class relation
    {
        [Key, Required]
        public string? name { get; set; }
        public string? title { get; set; }
    }
}
