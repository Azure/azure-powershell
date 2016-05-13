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

namespace Microsoft.WindowsAzure.Commands.Common
{
    public static class ApiConstants
    {
        public const string AuthorizationHeaderName = "Authorization";
        public const string BasicAuthorization = "Basic";
        public const string UserAgentHeaderName = "User-Agent";
        public const string UserAgentHeaderValue = "AzurePowershell/v"
            + AzurePowerShell.AssemblyVersion;
        public const string VSDebuggerCausalityDataHeaderName = "VSDebuggerCausalityData";
        public const string OperationTrackingIdHeader = "x-ms-request-id";
        public const string VersionHeaderContentLatest = "2013-08-01";
        public const string VersionHeaderName = "x-ms-version";

    }

    public static class StorSimpleConstants
    {
        public const string DefaultStorageAccountEndpoint = "core.windows.net";
    }

    public class SDKVersion
    {
        public const string Version180 = "1.8.0";
        public const string Version200 = "2.0.0";
        public const string Version220 = "2.2.0";
        public const string Version230 = "2.3.0";
        public const string Version240 = "2.4.0";
        public const string Version250 = "2.5.0";
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
}
