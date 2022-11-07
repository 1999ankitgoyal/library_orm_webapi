using LibraryApi.EFcore;

namespace LibraryApi.Model
{
    public class authormodel
    {
        public string? name { get; set; }
        public DateOnly? DOB { get; set; }
        public string? country { get; set; }
        public List<string?> title { get; set; } = new List<string?>();

    }
}
