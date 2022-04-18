using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class PSSkuCapability
    {
        /// <summary>
        /// Initializes a new instance of the SkuCapability class.
        /// </summary>
        /// <param name="name">The name of the feature.</param>
        /// <param name="value">The value of the feature.</param>
        public PSSkuCapability(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets the name of the feature.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the value of the feature.
        /// </summary>
        public string Value { get; private set; }
    }
}
