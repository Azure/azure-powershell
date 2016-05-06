using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Azure.Management.Batch.Models;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class PSApplication
    {
        public bool AllowUpdates { get; set; }

        public IList<PSApplicationPackage> ApplicationPackages { get; set; }

        public string Id { get; set; }

        public string DefaultVersion { get; set; }

        public string DisplayName { get; set; }
    }
}