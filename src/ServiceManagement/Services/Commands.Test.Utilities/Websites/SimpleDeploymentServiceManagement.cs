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
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Websites
{
    /// <summary>
    /// Simple implementation of the <see cref="IDeploymentServiceManagement"/> interface that can be
    /// used for mocking basic interactions without involving Azure directly.
    /// </summary>
    public class SimpleDeploymentServiceManagement : IDeploymentServiceManagement
    {
        /// <summary>
        /// Gets or sets a value indicating whether the thunk wrappers will
        /// throw an exception if the thunk is not implemented.  This is useful
        /// when debugging a test.
        /// </summary>
        public bool ThrowsIfNotImplemented { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleDeploymentServiceManagement"/> class.
        /// </summary>
        public SimpleDeploymentServiceManagement()
        {
            ThrowsIfNotImplemented = true;
        }

        #region Implementation Thunks

        #region GetDeployments

        public Func<SimpleServiceManagementAsyncResult, List<DeployResult>> GetDeploymentsThunk { get; set; }

        public IAsyncResult BeginGetDeployments(int maxItems, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["maxItems"] = maxItems;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public List<DeployResult> EndGetDeployments(IAsyncResult asyncResult)
        {
            if (GetDeploymentsThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                return GetDeploymentsThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetDeploymentsThunk is not implemented!");
            }

            return default(List<DeployResult>);
        }

        #endregion

        #region Deploy

        public Action<SimpleServiceManagementAsyncResult> DeployThunk { get; set; }

        public IAsyncResult BeginDeploy(string commitId, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["commitId"] = commitId;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndDeploy(IAsyncResult asyncResult)
        {
            if (DeployThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");
                DeployThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("DeployThunk is not implemented!");
            }
        }

        #endregion

        #region GetDeploymentLogs

        public Func<SimpleServiceManagementAsyncResult, List<LogEntry>> GetDeploymentLogsThunk { get; set; }

        public IAsyncResult BeginGetDeploymentLogs(string commitId, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["commitId"] = commitId;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public List<LogEntry> EndGetDeploymentLogs(IAsyncResult asyncResult)
        {
            if (GetDeploymentLogsThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                return GetDeploymentLogsThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetDeploymentLogs is not implemented!");
            }

            return default(List<LogEntry>);
        }

        #endregion

        #region GetDeploymentLog

        public Func<SimpleServiceManagementAsyncResult, LogEntry> GetDeploymentLogThunk { get; set; }

        public IAsyncResult BeginGetDeploymentLog(string commitId, string logId, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["commitId"] = commitId;
            result.Values["logId"] = logId;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public LogEntry EndGetDeploymentLog(IAsyncResult asyncResult)
        {
            if (GetDeploymentLogThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                return GetDeploymentLogThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetDeploymentLog is not implemented!");
            }

            return default(LogEntry);
        }

        #endregion

        #region DownloadLogs

        public Func<SimpleServiceManagementAsyncResult, Stream> DownloadLogsThunk { get; set; }

        public IAsyncResult BeginDownloadLogs(AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public Stream EndDownloadLogs(IAsyncResult asyncResult)
        {
            if (DownloadLogsThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                return DownloadLogsThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetDeploymentLog is not implemented!");
            }

            return default(Stream);
        }

        #endregion

        #endregion

        public IAsyncResult BeginGetDiagnosticsSettings(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public DiagnosticsSettings EndGetDiagnosticsSettings(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginSetDiagnosticsSettings(DiagnosticsSettings diagnosticsSettings, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndSetDiagnosticsSettings(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }
    }
}

