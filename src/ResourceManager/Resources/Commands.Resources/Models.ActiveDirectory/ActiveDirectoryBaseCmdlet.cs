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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Models;
using System;
using System.Management.Automation;
using System.Net;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.ActiveDirectory.Models
{
    public abstract class ActiveDirectoryBaseCmdlet : AzureRMCmdlet
    {
        private ActiveDirectoryClient activeDirectoryClient;

        public ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (activeDirectoryClient == null)
                {
                    activeDirectoryClient = new ActiveDirectoryClient(DefaultProfile.Context);
                }

                return activeDirectoryClient;
            }

            set { activeDirectoryClient = value; }
        }

        /// <summary>
        /// Handles graph exceptions thrown by client
        /// </summary>
        /// <param name="exception"></param>
        private void HandleException(Exception exception)
        {
            Exception targetEx = exception;
            string targetErrorId = String.Empty;
            ErrorCategory targetErrorCategory = ErrorCategory.NotSpecified;
            var graphEx = exception as GraphErrorException;

            if (graphEx != null)
            {
                if (graphEx.Body != null)
                {
                    WriteDebug(String.Format(ProjectResources.GraphException, graphEx.Body.Code, graphEx.Body.Message));
                    targetEx = new Exception(graphEx.Body.Message);
                    targetErrorId = graphEx.Body.Code;
                }

                if (graphEx.Response != null && graphEx.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    targetErrorCategory = ErrorCategory.InvalidArgument;
                }
                else
                {
                    targetErrorCategory = ErrorCategory.InvalidOperation;
                }

                var errorRecord = new ErrorRecord(targetEx, targetErrorId, targetErrorCategory, null);
                WriteError(errorRecord);
            }
            else
            {
                throw exception;
            }
        }

        protected void ExecutionBlock(Action execAction)
        {
            try
            {
                execAction();
            }
            catch (Exception exception)
            {
                WriteDebug(String.Format(ProjectResources.ExceptionInExecution, exception.GetType()));
                HandleException(exception);
            }
        }
    }
}
