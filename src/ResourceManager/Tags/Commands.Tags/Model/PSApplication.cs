using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Management.Batch.Models;

namespace Microsoft.Azure.Commands.Tags.Model
{
    public class PSApplication
    {
        public bool AllowUpdates { get; set; }

        public IList<ApplicationPackage> ApplicationPackages { get; set; }

        public string Id { get; set; }

        public string DefaultVersion { get; set; }

        public string DisplayName { get; set; }
    }
}
