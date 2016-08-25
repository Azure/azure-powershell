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

using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public interface IAutomationClient
    {
        AzureSubscription Subscription { get; }

        #region Accounts

        IEnumerable<AutomationAccount> ListAutomationAccounts(string resourceGroupName, ref string nextLink);

        AutomationAccount GetAutomationAccount(string resourceGroupName, string automationAccountName);

        AutomationAccount CreateAutomationAccount(string resourceGroupName, string automationAccountName, string location, string plan, IDictionary tags);

        AutomationAccount UpdateAutomationAccount(string resourceGroupName, string automationAccountName, string plan, IDictionary tags);

        void DeleteAutomationAccount(string resourceGroupName, string automationAccountName);

        #endregion

        #region Compilationjobs

        CompilationJob GetCompilationJob(string resourceGroupName, string automationAccountName, Guid id);

        IEnumerable<CompilationJob> ListCompilationJobsByConfigurationName(string resourceGroupName, string automationAccountName, string configurationName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus);

        IEnumerable<CompilationJob> ListCompilationJobs(string resourceGroupName, string automationAccountName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus);

        CompilationJob StartCompilationJob(string resourceGroupName, string automationAccountName, string configurationName, IDictionary parameters, IDictionary configurationData);

        IEnumerable<JobStream> GetDscCompilationJobStream(string resourceGroupName, string automationAccountname, Guid jobId, DateTimeOffset? time, string streamType);
        #endregion

        #region NodeConfiguration
        NodeConfiguration GetNodeConfiguration(string resourceGroupName, string automationAccountName, string nodeConfigurationName, string rollupStatus);

        IEnumerable<NodeConfiguration> ListNodeConfigurationsByConfigurationName(string resourceGroupName, string automationAccountName, string configurationName, string rollupStatus);

        IEnumerable<NodeConfiguration> ListNodeConfigurations(string resourceGroupName, string automationAccountName, string rollupStatus);

        NodeConfiguration CreateNodeConfiguration(string resourceGroupName, string automationAccountName, string sourcePath, string nodeConfiguraionName, bool overWrite);

        void DeleteNodeConfiguration(string resourceGroupName, string automationAccountName, string name, bool ignoreNodeMappings);
        #endregion

        #region Configurations

        IEnumerable<DscConfiguration> ListDscConfigurations(string resourceGroupName, string automationAccountName);

        DscConfiguration GetConfiguration(string resourceGroupName, string automationAccountName, string configurationName);

        DscConfiguration CreateConfiguration(string resourceGroupName, string automationAccountName, string sourcePath, IDictionary tags, string description, bool? logVerbose, bool published, bool overWrite);

        DirectoryInfo GetConfigurationContent(string resourceGroupName, string automationAccountName, string configurationName, bool? isDraft, string outputFolder, bool overwriteExistingFile);

        void DeleteConfiguration(string resourceGroupName, string automationAccountName, string name);

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

        void RegisterDscNode(string resourceGroupName, string automationAccountName, string azureVMName, string nodeconfigurationName, string configurationMode, int configurationModeFrequencyMins, int refreshFrequencyMins, bool rebootFlag, string actionAfterReboot, bool moduleOverwriteFlag, string azureVmResourceGroup, string azureVmLocation);

        #endregion

        #region Modules

        Module CreateModule(string resourceGroupName, string automationAccountName, Uri contentLink, string moduleName);

        Module GetModule(string resourceGroupName, string automationAccountName, string name);

        Module UpdateModule(string resourceGroupName, string automationAccountName, string name, Uri contentLink, string contentLinkVersion);

        IEnumerable<Module> ListModules(string resourceGroupName, string automationAccountName, ref string nextLink);

        void DeleteModule(string resourceGroupName, string automationAccountName, string name);

        #endregion

        #region dscreports

        DscNodeReport GetLatestDscNodeReport(string resourceGroupName, string automationAccountName, Guid nodeId);

        IEnumerable<DscNodeReport> ListDscNodeReports(string resourceGroupName, string automationAccountName, Guid nodeId, DateTimeOffset? startTime, DateTimeOffset? endTime);

        DscNodeReport GetDscNodeReportByReportId(string resourceGroupName, string automationAccountName, Guid nodeId, Guid reportId);

        DirectoryInfo GetDscNodeReportContent(string resourceGroupName, string automationAccountName, Guid nodeId, Guid reportId, string outputFolder, bool overwriteExistingFile);
        #endregion

        #region Webhooks

        Model.Webhook CreateWebhook(
            string resourceGroupName,
            string automationAccountName,
            string name,
            string runbookName,
            bool isEnabled,
            DateTimeOffset expiryTime,
            IDictionary parameters);

        Model.Webhook GetWebhook(string resourceGroupName, string automationAccountName, string name);

        IEnumerable<Model.Webhook> ListWebhooks(string resourceGroupName, string automationAccountName, string runbooName, ref string nextLink);

        Model.Webhook UpdateWebhook(string resourceGroupName, string automationAccountName, string name, IDictionary parameters, bool? isEnabled);

        void DeleteWebhook(string resourceGroupName, string automationAccountName, string name);

        #endregion

        #region Variables

        Variable GetVariable(string resourceGroupName, string automationAccountName, string variableName);

        IEnumerable<Variable> ListVariables(string resourceGroupName, string automationAccountName, ref string nextLink);

        Variable CreateVariable(Variable variable);

        void DeleteVariable(string resourceGroupName, string automationAccountName, string variableName);

        Variable UpdateVariable(Variable variable, VariableUpdateFields updateFields);

        #endregion

        #region Schedules

        Schedule CreateSchedule(string resourceGroupName, string automationAccountName, Schedule schedule);

        void DeleteSchedule(string resourceGroupName, string automationAccountName, string scheduleName);

        Schedule GetSchedule(string resourceGroupName, string automationAccountName, string scheduleName);

        IEnumerable<Schedule> ListSchedules(string resourceGroupName, string automationAccountName, ref string nextLink);

        Schedule UpdateSchedule(string resourceGroupName, string automationAccountName, string scheduleName, bool? isEnabled, string description);

        #endregion

        #region Runbooks

        Runbook GetRunbook(string resourceGroupName, string automationAccountName, string runbookName);

        IEnumerable<Runbook> ListRunbooks(string resourceGroupName, string automationAccountName, ref string nextLink);

        Runbook CreateRunbookByName(string resourceGroupName, string automationAccountName, string runbookName, string description, IDictionary tags, string type, bool? logProgress, bool? logVerbose, bool overwrite);

        Runbook ImportRunbook(string resourceGroupName, string automationAccountName, string runbookPath, string description, IDictionary tags, string type, bool? logProgress, bool? logVerbose, bool published, bool overwrite, string runbookName);

        void DeleteRunbook(string resourceGroupName, string automationAccountName, string runbookName);

        Runbook PublishRunbook(string resourceGroupName, string automationAccountName, string runbookName);

        Runbook UpdateRunbook(string resourceGroupName, string automationAccountName, string runbookName, string description, IDictionary tags, bool? logProgress, bool? logVerbose);

        DirectoryInfo ExportRunbook(string resourceGroupName, string automationAccountName, string runbookName, bool? isDraft, string sourcePath, bool overwrite);

        Job StartRunbook(string resourceGroupName, string automationAccountName, string runbookName, IDictionary parameters, string runOn);

        #endregion

        #region HybridrunbookWorker
        HybridRunbookWorkerGroup GetHybridRunbookWorkerGroup(string resourceGroupName, string automationAccountName, string hybridRunbookWorkerGroupName);

        IEnumerable<HybridRunbookWorkerGroup> ListHybridRunbookWorkerGroups(string resourceGroupName, string automationAccountName, ref string nextLink);
        #endregion

        #region Credentials

        CredentialInfo CreateCredential(string resourceGroupName, string automationAccountName, string name, string userName, string password, string description);

        CredentialInfo UpdateCredential(string resourceGroupName, string automationAccountName, string name, string userName, string password, string description);

        CredentialInfo GetCredential(string resourceGroupName, string automationAccountName, string name);

        IEnumerable<CredentialInfo> ListCredentials(string resourceGroupName, string automationAccountName, ref string nextLink);

        void DeleteCredential(string resourceGroupName, string automationAccountName, string name);

        #endregion

        #region Jobs

        Job GetJob(string resourceGroupName, string automationAccountName, Guid id);

        IEnumerable<Job> ListJobsByRunbookName(string resourceGroupName, string automationAccountName, string runbookName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink);

        IEnumerable<Job> ListJobs(string resourceGroupName, string automationAccountName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink);

        void ResumeJob(string resourceGroupName, string automationAccountName, Guid id);

        void StopJob(string resourceGroupName, string automationAccountName, Guid id);

        void SuspendJob(string resourceGroupName, string automationAccountName, Guid id);

        IEnumerable<JobStream> GetJobStream(string resourceGroupName, string automationAccountName, Guid jobId,
            DateTimeOffset? time, string streamType, ref string nextLink);

        JobStreamRecord GetJobStreamRecord(string resourceGroupName, string automationAccountName, Guid jobId, string jobStreamId);

        object GetJobStreamRecordAsPsObject(string resourceGroupName, string automationAccountName, Guid jobId, string jobStreamId);

        #endregion

        #region Certificates

        CertificateInfo CreateCertificate(string resourceGroupName, string automationAccountName, string name, string path, SecureString password, string description, bool exportable);

        CertificateInfo UpdateCertificate(string resourceGroupName, string automationAccountName, string name, string path, SecureString password, string description, bool? exportable);

        CertificateInfo GetCertificate(string resourceGroupName, string automationAccountName, string name);

        IEnumerable<CertificateInfo> ListCertificates(string resourceGroupName, string automationAccountName, ref string nextLink);

        void DeleteCertificate(string resourceGroupName, string automationAccountName, string name);

        #endregion

        #region Connection

        Connection CreateConnection(string resourceGroupName, string automationAccountName, string name, string connectionTypeName, IDictionary connectionFieldValues, string description);

        Connection UpdateConnectionFieldValue(string resourceGroupName, string automationAccountName, string name, string connectionFieldName, object value);

        Connection GetConnection(string resourceGroupName, string automationAccountName, string name);

        IEnumerable<Connection> ListConnectionsByType(string resourceGroupName, string automationAccountName, string name);

        IEnumerable<Connection> ListConnections(string resourceGroupName, string automationAccountName, ref string nextLink);

        void DeleteConnection(string resourceGroupName, string automationAccountName, string name);

        #endregion

        #region JobSchedules

        JobSchedule GetJobSchedule(string resourceGroupName, string automationAccountName, Guid jobScheduleId);

        JobSchedule GetJobSchedule(string resourceGroupName, string automationAccountName, string runbookName, string scheduleName);

        IEnumerable<JobSchedule> ListJobSchedules(string resourceGroupName, string automationAccountName, ref string nextLink);

        IEnumerable<JobSchedule> ListJobSchedulesByRunbookName(string resourceGroupName, string automationAccountName, string runbookName);

        IEnumerable<JobSchedule> ListJobSchedulesByScheduleName(string resourceGroupName, string automationAccountName, string scheduleName);

        JobSchedule RegisterScheduledRunbook(string resourceGroupName, string automationAccountName, string runbookName, string scheduleName, IDictionary parameters);

        void UnregisterScheduledRunbook(string resourceGroupName, string automationAccountName, Guid jobScheduleId);

        void UnregisterScheduledRunbook(string resourceGroupName, string automationAccountName, string runbookName, string scheduleName);


        #endregion

        #region ConnectionType

        void DeleteConnectionType(string resourceGroupName, string automationAccountName, string name);

        #endregion
    }
}