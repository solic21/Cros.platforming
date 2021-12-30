using System.ComponentModel.DataAnnotations;

namespace EbolaApi.Core
{
    public class DatabaseOptions
    {
        public string Type { get; set; }

        [Required]
        public string ConnectionString { get; set; }

        public bool RunMigration { get; set; }
    }
}
