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

using Hyak.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;
using AutomationManagement = Microsoft.Azure.Management.Automation;
using SourceControl        = Microsoft.Azure.Management.Automation.Models.SourceControl;
using SourceControlSyncJob = Microsoft.Azure.Management.Automation.Models.SourceControlSyncJob;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public partial class AutomationPSClient : IAutomationPSClient
    {
        #region SourceControl

        public Model.SourceControl CreateSourceControl(
            string resourceGroupName,
            string automationAccountName,
            string name,
            string description,
            SecureString accessToken,
            string repoUrl,
            string sourceType,
            string branch,
            string folderPath,
            bool publishRunbook,
            bool autoSync)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("name", name).NotNullOrEmpty();
            Requires.Argument("accessToken", accessToken).NotNullOrEmpty();
            Requires.Argument("repoUrl", repoUrl).NotNullOrEmpty();
            Requires.Argument("sourceType", sourceType).NotNullOrEmpty();
            Requires.Argument("folderPath", folderPath).NotNullOrEmpty();

            if (String.Equals(sourceType, Constants.SupportedSourceType.GitHub.ToString()) ||
                String.Equals(sourceType, Constants.SupportedSourceType.VsoGit.ToString()))
            {
                Requires.Argument("branch", branch).NotNullOrEmpty();
            }

            var decryptedAccessToken = Utils.GetStringFromSecureString(accessToken);

            var createParams = new SourceControlCreateOrUpdateParameters(
                                    repoUrl,
                                    branch,
                                    folderPath,
                                    autoSync,
                                    publishRunbook,
                                    sourceType,
                                    GetAccessTokenProperties(decryptedAccessToken),
                                    description);

            var sdkSourceControl = this.automationManagementClient.SourceControl.CreateOrUpdate(
                                        resourceGroupName,
                                        automationAccountName,
                                        name,
                                        createParams);

            Model.SourceControl result = null;

            if (sdkSourceControl != null)
            {
                result = new Model.SourceControl(sdkSourceControl, automationAccountName, resourceGroupName);
            }

            return result;
        }

        public Model.SourceControl UpdateSourceControl(
            string resourceGroupName,
            string automationAccountName,
            string name,
            string description,
            SecureString accessToken,
            string branch,
            string folderPath,
            bool? publishRunbook,
            bool? autoSync)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("name", name).NotNullOrEmpty();
            
            var updateParams = new AutomationManagement.Models.SourceControlUpdateParameters();

            if (autoSync.HasValue)
            {
                updateParams.AutoSync = autoSync;
            }

            if (publishRunbook.HasValue)
            {
                updateParams.PublishRunbook = publishRunbook;
            }

            if (!string.IsNullOrEmpty(description))
            {
                updateParams.Description = description;
            }

            if (!string.IsNullOrEmpty(branch))
            {
                updateParams.Branch = branch;
            }

            if (!string.IsNullOrEmpty(folderPath))
            {
                updateParams.FolderPath = folderPath;
            }

            if (accessToken != null)
            {
                var decryptedAccessToken = Utils.GetStringFromSecureString(accessToken);
                updateParams.SecurityToken = GetAccessTokenProperties(decryptedAccessToken);
            }

            var sdkSourceControl = this.automationManagementClient.SourceControl.Update(
                                        resourceGroupName,
                                        automationAccountName,
                                        name,
                                        updateParams);

            Model.SourceControl result = null;

            if (sdkSourceControl != null)
            {
                result = new Model.SourceControl(sdkSourceControl, automationAccountName, resourceGroupName);
            }

            return result;
        }

        public void DeleteSourceControl(
            string resourceGroupName,
            string automationAccountName,
            string name)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("name", name).NotNullOrEmpty();

            this.automationManagementClient.SourceControl.Delete(resourceGroupName, automationAccountName, name);
        }

        public Model.SourceControl GetSourceControl(
            string resourceGroupName,
            string automationAccountName,
            string name)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("name", name).NotNullOrEmpty();

            var existingSourceControl = this.automationManagementClient.SourceControl.Get(
                                            resourceGroupName,
                                            automationAccountName,
                                            name);

            Model.SourceControl result = null;

            if (existingSourceControl != null)
            {
                result = new Model.SourceControl(existingSourceControl, automationAccountName, resourceGroupName);
            }

            return result;
        }

        public IEnumerable<Model.SourceControl> ListSourceControl(
            string resourceGroupName,
            string automationAccountName,
            string sourceType,
            ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.SourceControl> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.SourceControl.ListByAutomationAccount(
                                    resourceGroupName,
                                    automationAccountName,
                                    GetSourceControlTypeFilterString(sourceType));
            }
            else
            {
                response = this.automationManagementClient.SourceControl.ListByAutomationAccountNext(nextLink);
            }
            nextLink = response.NextPageLink;
            return response.Select(sc => new Model.SourceControl(sc, automationAccountName, resourceGroupName));
        }

        #endregion

        #region SourceControlSyncJob

        public Model.SourceControlSyncJob StartSourceControlSyncJob(
            string resourceGroupName,
            string automationAccountName,
            string sourceControlName,
            Guid syncJobId)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("sourceControlName", sourceControlName).NotNullOrEmpty();
            Requires.Argument("syncJobId", syncJobId).NotNullOrEmpty();

            var sdkSyncJob = this.automationManagementClient.SourceControlSyncJob.Create(
                                resourceGroupName,
                                automationAccountName,
                                sourceControlName,
                                syncJobId,
                                new SourceControlSyncJobCreateParameters(""));

            Model.SourceControlSyncJob result = null;

            if (sdkSyncJob != null)
            {
                result = new Model.SourceControlSyncJob(resourceGroupName, automationAccountName, sourceControlName, sdkSyncJob);
            }

            return result; 
        }

        public Model.SourceControlSyncJobRecord GetSourceControlSyncJob(
            string resourceGroupName,
            string automationAccountName,
            string sourceControlName,
            Guid syncJobId)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("sourceControlName", sourceControlName).NotNullOrEmpty();
            Requires.Argument("syncJobId", syncJobId).NotNullOrEmpty();

            var existingSyncJob = this.automationManagementClient.SourceControlSyncJob.Get(
                                            resourceGroupName,
                                            automationAccountName,
                                            sourceControlName,
                                            syncJobId);

            Model.SourceControlSyncJobRecord result = null;

            if (existingSyncJob != null)
            {
                result = new Model.SourceControlSyncJobRecord(resourceGroupName, automationAccountName, sourceControlName, existingSyncJob);
            }

            return result;
        }

        public IEnumerable<Model.SourceControlSyncJob> ListSourceControlSyncJobs(
            string resourceGroupName,
            string automationAccountName,
            string sourceControlName,
            ref string nextLink)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("sourceControlName", sourceControlName).NotNullOrEmpty();

            Rest.Azure.IPage<AutomationManagement.Models.SourceControlSyncJob> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.SourceControlSyncJob.ListByAutomationAccount(
                                resourceGroupName,
                                automationAccountName,
                                sourceControlName);
            }
            else
            {
                response = this.automationManagementClient.SourceControlSyncJob.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(
                    sj => new Model.SourceControlSyncJob(resourceGroupName, automationAccountName, sourceControlName, sj));
        }

        public IEnumerable<Model.SourceControlSyncJobStream> GetSourceControlSyncJobStream(
            string resourceGroupName,
            string automationAccountName,
            string sourceControlName,
            Guid syncJobId,
            string streamType,
            ref string nextLink)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("sourceControlName", sourceControlName).NotNullOrEmpty();
            Requires.Argument("syncJobId", syncJobId).NotNullOrEmpty();
            Requires.Argument("streamType", streamType).NotNullOrEmpty();

            Rest.Azure.IPage<AutomationManagement.Models.SourceControlSyncJobStream> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.SourceControlSyncJobStreams.ListBySyncJob(
                                resourceGroupName,
                                automationAccountName,
                                sourceControlName,
                                syncJobId,
                                this.GetSyncJobStreamFilterString(streamType));
            }
            else
            {
                response = this.automationManagementClient.SourceControlSyncJobStreams.ListBySyncJobNext(nextLink);
            }

            nextLink = response.NextPageLink;

            return response.Select(
                        stream => new Model.SourceControlSyncJobStream(stream, resourceGroupName, automationAccountName, sourceControlName, syncJobId));
        }

        public SourceControlSyncJobStreamRecord GetSourceControlSyncJobStreamRecord(
            string resourceGroupName,
            string automationAccountName,
            string sourceControlName,
            Guid syncJobId,
            string syncJobStreamId)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("sourceControlName", sourceControlName).NotNullOrEmpty();
            Requires.Argument("syncJobId", syncJobId).NotNullOrEmpty();
            Requires.Argument("syncJobStreamId", syncJobStreamId).NotNullOrEmpty();

            var response = this.automationManagementClient.SourceControlSyncJobStreams.Get(
                                resourceGroupName,
                                automationAccountName,
                                sourceControlName,
                                syncJobId,
                                syncJobStreamId);

            SourceControlSyncJobStreamRecord result = null;

            if (response != null)
            {
                result = new SourceControlSyncJobStreamRecord(
                            response, resourceGroupName, automationAccountName, sourceControlName, syncJobId);
            }

            return result;
        }

        #region private helper functions

        private string GetSyncJobStreamFilterString(string streamType)
        {
            string filter = null;
            List<string> odataFilter = new List<string>();

            if (!string.IsNullOrWhiteSpace(streamType))
            {
                // By default, to retrieve all the streams, the API does not expect any filters.
                // If streamType is Any, do not add a filter.
                if (!(string.Equals(SourceControlSyncJobStreamType.Any.ToString(), streamType, StringComparison.OrdinalIgnoreCase)))
                {
                    odataFilter.Add("properties/streamType eq '" + Uri.EscapeDataString(streamType) + "'");
                }
            }

            if (odataFilter.Count > 0)
            {
                filter = string.Join(" and ", odataFilter);
            }

            return filter;
        }

        private string GetSourceControlTypeFilterString(string sourceType)
        {
            string filter = null;
            List<string> odataFilter = new List<string>();

            if (!string.IsNullOrWhiteSpace(sourceType))
            {
                odataFilter.Add("properties/sourceType eq '" + Uri.EscapeDataString(sourceType) + "'");
            }

            if (odataFilter.Count > 0)
            {
                filter = string.Join(" and ", odataFilter);
            }

            return filter;
        }

        private SourceControlSecurityTokenProperties GetAccessTokenProperties(string accessToken)
        {
            var securityTokenProperties = new SourceControlSecurityTokenProperties();
            securityTokenProperties.AccessToken = accessToken;
            securityTokenProperties.TokenType = "PersonalAccessToken";

            return securityTokenProperties;
        }

        #endregion

        #endregion

    }
}
