
namespace ADV.Web.Models
{
    public sealed class SectionModel
    {
        public string SectionClass { get; set; }
        public string InternalViewName { get; set; }
        public string Id { get; set; }
        public string ClassId { get; set; }
        public bool NeedTitle { get; set; }
        public string Title { get; set; }
    }
}