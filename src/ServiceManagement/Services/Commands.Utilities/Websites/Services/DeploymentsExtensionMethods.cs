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

using System.Collections.Generic;
using System.IO;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services
{
    public static class DeploymentsExtensionMethods
    {
        public static List<DeployResult> GetDeployments(this IDeploymentServiceManagement proxy, int maxItems)
        {
            return proxy.EndGetDeployments(proxy.BeginGetDeployments(maxItems, null, null));
        }

        public static LogEntry GetDeploymentLog(this IDeploymentServiceManagement proxy, string commitId, string logId)
        {
            return proxy.EndGetDeploymentLog(proxy.BeginGetDeploymentLog(commitId, logId, null, null));
        }

        public static List<LogEntry> GetDeploymentLogs(this IDeploymentServiceManagement proxy, string commitId)
        {
            return proxy.EndGetDeploymentLogs(proxy.BeginGetDeploymentLogs(commitId, null, null));
        }

        public static void Deploy(this IDeploymentServiceManagement proxy, string commitId)
        {
            proxy.EndDeploy(proxy.BeginDeploy(commitId, null, null));
        }

        public static Stream DownloadLogs(this IDeploymentServiceManagement proxy)
        {
            return proxy.EndDownloadLogs(proxy.BeginDownloadLogs(null, null));
        }
    }
}