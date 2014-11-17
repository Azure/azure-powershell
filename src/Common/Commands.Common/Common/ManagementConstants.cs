// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Net.Http.Headers;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class ApiConstants
    {
        public const string AuthorizationHeaderName = "Authorization";

        public const string BasicAuthorization = "Basic";

        public const string UserAgentHeaderName = "User-Agent";

        public const string UserAgentHeaderValue = "AzurePowershell/v" + AzurePowerShell.AssemblyVersion;

        public static ProductInfoHeaderValue UserAgentValue = new ProductInfoHeaderValue(
            "AzurePowershell",
            string.Format("v{0}", AzurePowerShell.AssemblyVersion));

        public const string VSDebuggerCausalityDataHeaderName = "VSDebuggerCausalityData";

        public const string OperationTrackingIdHeader = "x-ms-request-id";

        public const string VersionHeaderContentLatest = "2013-08-01";

        public const string VersionHeaderName = "x-ms-version";
        
    }

    public class SDKVersion
    {
        public const string Version180 = "1.8.0";

        public const string Version200 = "2.0.0";

        public const string Version220 = "2.2.0";

        public const string Version230 = "2.3.0";

        public const string Version240 = "2.4.0";
    }

    public enum DevEnv
    {
        Local,
        Cloud
    }

    public enum RoleType
    {
        WebRole,
        WorkerRole
    }

    public enum RuntimeType
    {
        IISNode,
        Node,
        PHP,
        Cache,
        Null
    }

    public static class EnvironmentName
    {
        public const string AzureCloud = "AzureCloud";

        public const string AzureChinaCloud = "AzureChinaCloud";
    }

    public static class AzureEnvironmentConstants
    {
        public const string AzureServiceEndpoint = "https://management.core.windows.net/";

        public const string ChinaServiceEndpoint = "https://management.core.chinacloudapi.cn/";

        public const string AzureResourceManagerEndpoint = "https://management.azure.com/";

        public const string GalleryEndpoint = "https://gallery.azure.com/";

        public const string AzurePublishSettingsFileUrl = "http://go.microsoft.com/fwlink/?LinkID=301775";

        public const string ChinaPublishSettingsFileUrl = "http://go.microsoft.com/fwlink/?LinkID=301776";

        public const string AzureManagementPortalUrl = "http://go.microsoft.com/fwlink/?LinkId=254433";

        public const string ChinaManagementPortalUrl = "http://go.microsoft.com/fwlink/?LinkId=301902";

        public const string AzureStorageEndpointSuffix = "core.windows.net";

        public const string ChinaStorageEndpointSuffix = "core.chinacloudapi.cn";

        public const string AzureSqlDatabaseDnsSuffix = ".database.windows.net";

        public const string ChinaSqlDatabaseDnsSuffix = ".database.chinacloudapi.cn";

        public const string AzureActiveDirectoryEndpoint = "https://login.windows.net/";

        public const string ChinaActiveDirectoryEndpoint = "https://login.chinacloudapi.cn/";

        public const string AzureGraphEndpoint = "https://graph.windows.net/";

        public const string AzureTrafficManagerDnsSuffix = "trafficmanager.net";

        public const string ChinaTrafficManagerDnsSuffix = "trafficmanager.cn";
    }
}