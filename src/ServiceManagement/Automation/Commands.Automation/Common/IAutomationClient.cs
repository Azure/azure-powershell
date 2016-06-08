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
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public interface IAutomationClient
    {
        AzureSubscription Subscription { get; }

        #region JobStreams

        IEnumerable<JobStream> GetJobStream(string automationAccountname, Guid jobId, DateTimeOffset? time, string streamType, ref string nextLink);

        #endregion

        #region Variables

        Variable GetVariable(string automationAccountName, string variableName);

        IEnumerable<Variable> ListVariables(string automationAccountName, ref string nextLink);

        Variable CreateVariable(Variable variable);

        void DeleteVariable(string automationAccountName, string variableName);

        Variable UpdateVariable(Variable variable, VariableUpdateFields updateFields);

        #endregion

        #region Schedules

        Schedule CreateSchedule(string automationAccountName, Schedule schedule);

        void DeleteSchedule(string automationAccountName, string scheduleName);

        Schedule GetSchedule(string automationAccountName, string scheduleName);

        IEnumerable<Schedule> ListSchedules(string automationAccountName, ref string nextLink);

        Schedule UpdateSchedule(string automationAccountName, string scheduleName, bool? isEnabled, string description);

        #endregion

        #region Runbooks

        Runbook GetRunbook(string automationAccountName, string runbookName);

        IEnumerable<Runbook> ListRunbooks(string automationAccountName, ref string nextLink);

        Runbook CreateRunbookByName(string automationAccountName, string runbookName, string description, string[] tags);

        Runbook CreateRunbookByPath(string automationAccountName, string runbookPath, string description, string[] tags);
        
        void DeleteRunbook(string automationAccountName, string runbookName);

        Runbook PublishRunbook(string automationAccountName, string runbookName);

        Runbook UpdateRunbook(string automationAccountName, string runbookName, string description, string[] tags, bool? logProgress, bool? logVerbose);

        RunbookDefinition UpdateRunbookDefinition(string automationAccountName, string runbookName, string runbookPath, bool overwrite);

        IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookName(string automationAccountName, string runbookName, bool? isDraft);

        Job StartRunbook(string automationAccountName, string runbookName, IDictionary parameters, string runOn);

        #endregion

        #region Credentials

        CredentialInfo CreateCredential(string automationAccountName, string name, string userName, string password, string description);

        CredentialInfo UpdateCredential(string automationAccountName, string name, string userName, string password, string description);

        CredentialInfo GetCredential(string automationAccountName, string name);

        IEnumerable<CredentialInfo> ListCredentials(string automationAccountName, ref string nextLink);

        void DeleteCredential(string automationAccountName, string name);

        #endregion

        #region Modules

        Module CreateModule(string automationAccountName, Uri contentLink, string moduleName, IDictionary tags);

        Module GetModule(string automationAccountName, string name);

        Module UpdateModule(string automationAccountName, IDictionary tags, string name, Uri contentLink, string contentLinkVersion);

        IEnumerable<Module> ListModules(string automationAccountName, ref string nextLink);

        void DeleteModule(string automationAccountName, string name);
        
        #endregion

        #region Jobs

        Job GetJob(string automationAccountName, Guid id);

        IEnumerable<Job> ListJobsByRunbookName(string automationAccountName, string runbookName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink);

        IEnumerable<Job> ListJobs(string automationAccountName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink);

        void ResumeJob(string automationAccountName, Guid id);

        void StopJob(string automationAccountName, Guid id);

        void SuspendJob(string automationAccountName, Guid id);

        #endregion
        
        #region Accounts

        IEnumerable<AutomationAccount> ListAutomationAccounts(string automationAccountName, string location);

        AutomationAccount CreateAutomationAccount(string automationAccountName, string location);

        void DeleteAutomationAccount(string automationAccountName);
        
        #endregion

        #region Certificates

        CertificateInfo CreateCertificate(string automationAccountName, string name, string path, SecureString password, string description, bool exportable);

        CertificateInfo UpdateCertificate(string automationAccountName, string name, string path, SecureString password, string description, bool? exportable);

        CertificateInfo GetCertificate(string automationAccountName, string name);

        IEnumerable<CertificateInfo> ListCertificates(string automationAccountName, ref string nextLink);

        void DeleteCertificate(string automationAccountName, string name);

        #endregion

        #region Connection

        Connection CreateConnection(string automationAccountName, string name, string connectionTypeName, IDictionary connectionFieldValues, string description);

        Connection UpdateConnectionFieldValue(string automationAccountName, string name, string connectionFieldName, object value);

        Connection GetConnection(string automationAccountName, string name);

        IEnumerable<Connection> ListConnectionsByType(string automationAccountName, string name);

        IEnumerable<Connection> ListConnections(string automationAccountName, ref string nextLink);

        void DeleteConnection(string automationAccountName, string name);

        #endregion

        #region JobSchedules

        JobSchedule GetJobSchedule(string automationAccountName, Guid jobScheduleId);

        JobSchedule GetJobSchedule(string automationAccountName, string runbookName, string scheduleName);

        IEnumerable<JobSchedule> ListJobSchedules(string automationAccountName, ref string nextLink);

        IEnumerable<JobSchedule> ListJobSchedulesByRunbookName(string automationAccountName, string runbookName);

        IEnumerable<JobSchedule> ListJobSchedulesByScheduleName(string automationAccountName, string scheduleName);

        JobSchedule RegisterScheduledRunbook(string automationAccountName, string runbookName, string scheduleName, IDictionary parameters);

        void UnregisterScheduledRunbook(string automationAccountName, Guid jobScheduleId);

        void UnregisterScheduledRunbook(string automationAccountName, string runbookName, string scheduleName);


        #endregion

        #region ConnectionType

        void DeleteConnectionType(string automationAccountName, string name);

        #endregion
    }
}