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
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.WindowsAzure.Commands.Common.Models;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public interface IAutomationClient
    {
        AzureSubscription Subscription { get; }

        IEnumerable<AutomationAccount> ListAutomationAccounts(string automationAccountName, string location);

        Job GetJob(string automationAccountName, Guid jobId);

        IEnumerable<Job> ListJobs(string automationAccountName, DateTime? startTime, DateTime? endTime);

        IEnumerable<Job> ListJobsByRunbookId(string automationAccountName, Guid runbookId, DateTime? startTime, DateTime? endTime);

        IEnumerable<Job> ListJobsByRunbookName(string automationAccountName, string runbookName, DateTime? startTime, DateTime? endTime);

        IEnumerable<JobStreamItem> ListJobStreamItems(string automationAccountName, Guid jobId, DateTime createdSince, string streamTypeName);

        Runbook GetRunbook(string automationAccountName, Guid runbookId);

        Runbook GetRunbook(string automationAccountName, string runbookName);

        IEnumerable<Runbook> ListRunbooks(string automationAccountName);

        IEnumerable<Runbook> ListRunbookByScheduleName(string automationAccountName, string scheduleName);

        IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookName(string automationAccountName, string runbookName, bool? isDraft);

        IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookId(string automationAccountName, Guid runbookId, bool? isDraft);

        IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookVersionId(string automationAccountName, Guid runbookVersionId, bool? isDraft);

        Schedule GetSchedule(string automationAccountName, Guid scheduleId);

        Schedule GetSchedule(string automationAccountName, string scheduleName);

        IEnumerable<Schedule> ListSchedules(string automationAccountName);

        Runbook CreateRunbookByName(
            string automationAccountName,
            string runbookName,
            string description,
            string[] tags);

        Runbook CreateRunbookByPath(
            string automationAccountName,
            string runbookPath,
            string description,
            string[] tags);

        Schedule CreateSchedule(string automationAccountName, OneTimeSchedule schedule);

        Schedule CreateSchedule(string automationAccountName, DailySchedule schedule);

        Schedule CreateSchedule(string automationAccountName, HourlySchedule schedule);

        Runbook PublishRunbook(string automationAccountName, Guid runbookId);

        Runbook PublishRunbook(string automationAccountName, string runbookName);

        Runbook RegisterScheduledRunbook(string automationAccountName, Guid runbookId, IDictionary parameters, string scheduleName);

        Runbook RegisterScheduledRunbook(string automationAccountName, string runbookName, IDictionary parameters, string scheduleName);

        void DeleteRunbook(string automationAccountName, Guid runbookId);

        void DeleteRunbook(string automationAccountName, string runbookName);

        void DeleteSchedule(string automationAccountName, Guid scheduleId);

        void DeleteSchedule(string automationAccountName, string scheduleName);

        void ResumeJob(string automationAccountName, Guid jobId);

        Runbook UpdateRunbook(string automationAccountName, Guid runbookId, string description, string[] tags, bool? logDebug, bool? logProgress, bool? logVerbose);

        Runbook UpdateRunbook(string automationAccountName, string runbookName, string description, string[] tags, bool? logDebug, bool? logProgress, bool? logVerbose);

        RunbookDefinition UpdateRunbookDefinition(string automationAccountName, Guid runbookId, string runbookPath, bool overwrite);

        RunbookDefinition UpdateRunbookDefinition(string automationAccountName, string runbookName, string runbookPath, bool overwrite);
        
        Schedule UpdateSchedule(string automationAccountName, Guid scheduleId, bool? isEnabled, string description);

        Schedule UpdateSchedule(string automationAccountName, string scheduleName, bool? isEnabled, string description);
        
        Job StartRunbook(string automationAccountName, Guid runbookId, IDictionary parameters);

        Job StartRunbook(string automationAccountName, string runbookName, IDictionary parameters);

        void StopJob(string automationAccountName, Guid jobId);

        void SuspendJob(string automationAccountName, Guid jobId);

        Runbook UnregisterScheduledRunbook(string automationAccountName, Guid runbookId, string scheduleName);

        Runbook UnregisterScheduledRunbook(string automationAccountName, string runbookName, string scheduleName);
    }
}