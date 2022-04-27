using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    [GraphQLDescription("Represents any software or service that has a command line interface.")]
    public class Platform
    {
        public Platform()
        {
            Commands = new List<Command>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [GraphQLDescription("Represents the purchased, valid license for the platform." )]
        public string LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; }
    }
}
