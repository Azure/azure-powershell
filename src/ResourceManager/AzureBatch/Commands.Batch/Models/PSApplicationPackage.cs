using System;
using System.Linq;

using Microsoft.Azure.Management.Batch.Models;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class PSApplicationPackage
    {
        public string Format { get; set; }

        public PackageState State { get; set; }

        public string Version { get; set; }

        public DateTime? LastActivationTime { get; set; }

        public string StorageUrl { get; set; }

        public DateTime StorageUrlExpiry { get; set; }

        public string Id { get; set; }
    }
}