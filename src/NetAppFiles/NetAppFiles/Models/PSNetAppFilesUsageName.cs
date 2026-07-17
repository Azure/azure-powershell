using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSNetAppFilesUsageName
    {
        /// <summary>
        /// Gets or sets the name of the usage.
        /// </summary>        
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the localized name of the usage.
        /// </summary>        -
        public string LocalizedValue { get; set; }
    }
}
