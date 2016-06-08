
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services
{
    /// <summary>
    /// Provides the Microsoft Azure Service Management Api for Microsoft Azure Websites Deployment. 
    /// </summary>
    [ServiceContract]
    public interface IDeploymentServiceManagement
    {
        [Description("Gets all deployments for a given repository")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "deployments?%24orderby=ReceivedTime%20desc&%24top={maxItems}")]
        IAsyncResult BeginGetDeployments(int maxItems, AsyncCallback callback, object state);
        List<DeployResult> EndGetDeployments(IAsyncResult asyncResult);

        [Description("Gets all deployment logs for a given commit")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "deployments/{commitId}/log")]
        IAsyncResult BeginGetDeploymentLogs(string commitId, AsyncCallback callback, object state);
        List<LogEntry> EndGetDeploymentLogs(IAsyncResult asyncResult);

        [Description("Gets a deployment log for a given commit")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "deployments/{commitId}/log/{logId}")]
        IAsyncResult BeginGetDeploymentLog(string commitId, string logId, AsyncCallback callback, object state);
        LogEntry EndGetDeploymentLog(IAsyncResult asyncResult);

        [Description("Redeploys a specific commit")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "PUT", UriTemplate = "deployments/{commitId}")]
        IAsyncResult BeginDeploy(string commitId, AsyncCallback callback, object state);
        void EndDeploy(IAsyncResult asyncResult);

        [Description("Downloads the website logs")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "dump")]
        IAsyncResult BeginDownloadLogs(AsyncCallback callback, object state);
        Stream EndDownloadLogs(IAsyncResult asyncResult);
    }
}
