using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    public class Platform
    {
        public Platform()
        {
            Commands = new List<Command>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; }
    }
}
