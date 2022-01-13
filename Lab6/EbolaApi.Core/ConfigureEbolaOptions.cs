using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core
{
    /// <summary>
    /// BaGet's options configuration, specific to the default BaGet application.
    /// Don't use this if you are embedding BaGet into your own custom ASP.NET Core application.
    /// </summary>
    public class ConfigureEbolaOptions :  
        IValidateOptions<EbolaOptions>
    {
        private static readonly HashSet<string> ValidDatabaseTypes
            = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "MySql",
                "PostgreSql",
                "Sqlite",
                "SqlServer",
                "InMemory"
            };

        public ValidateOptionsResult Validate(string name, EbolaOptions options)
        {
            var failures = new List<string>();

            if (options.Database == null) failures.Add($"The '{nameof(EbolaOptions.Database)}' config is required");

            if (!ValidDatabaseTypes.Contains(options.Database?.Type))
            {
                failures.Add(
                    $"The '{nameof(EbolaOptions.Database)}:{nameof(DatabaseOptions.Type)}' config is invalid. " +
                    $"Allowed values: {string.Join(", ", ValidDatabaseTypes)}");
            } 

            if (failures.Any()) return ValidateOptionsResult.Fail(failures);

            return ValidateOptionsResult.Success;
        }
    }
}
