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
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public interface IAutomationClient
    {
        AzureSubscription Subscription { get; }

        #region Accounts

        IEnumerable<AutomationAccount> ListAutomationAccounts(string resourceGroupName);

        AutomationAccount GetAutomationAccount(string resourceGroupName, string automationAccountName);

        AutomationAccount CreateAutomationAccount(string resourceGroupName, string automationAccountName, string location, string plan, IDictionary tags);

        AutomationAccount UpdateAutomationAccount(string resourceGroupName, string automationAccountName, string plan, IDictionary tags);

        void DeleteAutomationAccount(string resourceGroupName, string automationAccountName);
        
        #endregion

        #region Compilationjobs

        CompilationJob GetCompilationJob(string resourceGroupName, string automationAccountName, Guid id);

        IEnumerable<CompilationJob> ListCompilationJobsByConfigurationName(string resourceGroupName, string automationAccountName, string configurationName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus);

        IEnumerable<CompilationJob> ListCompilationJobs(string resourceGroupName, string automationAccountName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus);

        CompilationJob StartCompilationJob(string resourceGroupName, string automationAccountName, string configurationName, IDictionary parameters);

        IEnumerable<JobStream> GetDscCompilationJobStream(string resourceGroupName, string automationAccountname, Guid jobId, DateTimeOffset? time, string streamType);
        #endregion

        #region NodeConfiguration
        NodeConfiguration GetNodeConfiguration(string resourceGroupName, string automationAccountName, string nodeConfigurationName, string rollupStatus);

        IEnumerable<NodeConfiguration> ListNodeConfigurationsByConfigurationName(string resourceGroupName, string automationAccountName, string configurationName, string rollupStatus);

        IEnumerable<NodeConfiguration> ListNodeConfigurations(string resourceGroupName, string automationAccountName, string rollupStatus);
        #endregion

        #region Configurations

        IEnumerable<DscConfiguration> ListDscConfigurations(string resourceGroupName, string automationAccountName);

        DscConfiguration GetConfiguration(string resourceGroupName, string automationAccountName, string configurationName);

        DscConfiguration CreateConfiguration(string resourceGroupName, string automationAccountName, string sourcePath, IDictionary tags, string description, bool? logVerbose, bool published, bool overWrite);

        DirectoryInfo GetConfigurationContent(string resourceGroupName, string automationAccountName, string configurationName, bool? isDraft, string outputFolder, bool overwriteExistingFile);

        #endregion

        #region AgentRegistrationInforamtion
        AgentRegistration GetAgentRegistration(string resourceGroupName, string automationAccountName);

        AgentRegistration NewAgentRegistrationKey(string resourceGroupName, string automationAccountName, string keyType);
        #endregion

        #region DscMetaConfiguration
        DirectoryInfo GetDscMetaConfig(string resourceGroupName, string automationAccountName, string outputFolder, string[] computerNames, bool overwriteExistingFile);
        #endregion

        #region DscNode Operations
        
        DscNode GetDscNodeById(string resourceGroupName, string automationAccountName, Guid nodeId);

        IEnumerable<DscNode> ListDscNodes(string resourceGroupName, string automationAccountName, string status);

        IEnumerable<DscNode> ListDscNodesByName(string resourceGroupName, string automationAccountName, string nodeName, string status);
        IEnumerable<DscNode> ListDscNodesByNodeConfiguration(string resourceGroupName, string automationAccountName, string nodeConfigurationName, string status);

        IEnumerable<DscNode> ListDscNodesByConfiguration(
            string resourceGroupName,
            string automationAccountName,
            string configurationName,
            string status);
        DscNode SetDscNodeById(string resourceGroupName, string automationAccountName, Guid nodeId, string nodeConfigurationName);

        void DeleteDscNode(string resourceGroupName, string automationAccountName, Guid nodeId);

        void RegisterDscNode(string resourceGroupName, string automationAccountName, string azureVMName, string nodeconfigurationName, string configurationMode, int configurationModeFrequencyMins, int refreshFrequencyMins, bool rebootFlag, string actionAfterReboot, bool moduleOverwriteFlag);

        #endregion

        #region Modules

        Module CreateModule(string resourceGroupName, string automationAccountName, Uri contentLink, string moduleName);

        Module GetModule(string resourceGroupName, string automationAccountName, string name);

        Module UpdateModule(string resourceGroupName, string automationAccountName, string name, Uri contentLink, string contentLinkVersion);

        IEnumerable<Module> ListModules(string resourceGroupName, string automationAccountName);

        void DeleteModule(string resourceGroupName, string automationAccountName, string name);

        #endregion

        #region dscreports

        DscNodeReport GetLatestDscNodeReport(string resourceGroupName, string automationAccountName, Guid nodeId);

        IEnumerable<DscNodeReport> ListDscNodeReports(string resourceGroupName, string automationAccountName, Guid nodeId, DateTimeOffset? startTime, DateTimeOffset? endTime);

        DscNodeReport GetDscNodeReportByReportId(string resourceGroupName, string automationAccountName, Guid nodeId, Guid reportId);

        DirectoryInfo GetDscNodeReportContent(string resourceGroupName, string automationAccountName, Guid nodeId, Guid reportId, string outputFolder, bool overwriteExistingFile);
        #endregion
    }
}