using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public static class DataPlaneConstants
    {
        public const string DefaultGrantType = "access_token";
        public const string DefaultScope = "registry:catalog:*";
        public const string RefreshTokenKey = "AcrRefreshToken";
    }

    public static class RepoAccessTokenPermission
    {
        public const string METADATA_READ = "metadata_read";
        public const string METADATA_WRITE = "metadata_write";
        public const string DELETE = "delete";
        public const string META_WRITE_META_READ = "metadata_write,metadata_read";
        public const string DELETE_META_READ = "delete,metadata_read";
    }

    public static class Constants
    {
        public const string Https = "https://";
    }
}
