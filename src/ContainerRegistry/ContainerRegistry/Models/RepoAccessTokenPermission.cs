using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class RepoAccessTokenPermission
    {
        public const string METADATA_READ = "metadata_read"; 
        public const string METADATA_WRITE = "metadata_write";
        public const string DELETE = "delete";
        public const string META_WRITE_META_READ = "metadata_write,metadata_read";
        public const string DELETE_META_READ = "delete,metadata_read";
    }
}
