using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Models
{
    public class WebAppAzureStoragePath
    {
        public string UniqueId { get; set; }

        public AzureStorageType? Type { get; set; }

        public string AccountName { get; set; }

        public string ShareName { get; set; }

        public string AccessKey { get; set; }

        public string MountPath { get; set; }
    }
}
