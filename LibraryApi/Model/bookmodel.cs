namespace LibraryApi.Model
{
    public class bookmodel
    {
        public string? title { get; set; }
        public DateOnly? DOP { get; set; }
        public string? language { get; set; }
        public List<string?> name { get; set; } = new List<string?>();

    }
}
