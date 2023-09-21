namespace TestingWebApp.DTOs
{
    public class OrganisationListDTO
    {
        public int CurrentPage { get; set; } = 1;
        public int TotalPage { get; set; }
        public List<Organisation> Data { get; set; } = new List<Organisation>();
    }
}
