

using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
