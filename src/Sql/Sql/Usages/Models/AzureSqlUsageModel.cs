using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.Usages.Models
{
    public class AzureSqlUsageModel
    {
        /// <summary>
        /// Gets or sets the usage id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the usage current value
        /// </summary>
        public int? CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the usage limit
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the usage requested limit
        /// </summary>
        public int? RequestedLimit { get; set; }

        /// <summary>
        /// Gets or sets the usage unit
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the usage name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the usage type
        /// </summary>
        public string Type { get; set; }
    }
}
