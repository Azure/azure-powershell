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
using System.Globalization;
using System.Linq;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Runbook = Microsoft.Azure.Commands.Automation.Model.Runbook;
using Schedule = Microsoft.Azure.Commands.Automation.Model.Schedule;

namespace Microsoft.Azure.Commands.Automation.Common
{
    using AutomationManagement = Management.Automation;
    using System.Text;
    using System.IO;

    public class AutomationClient : IAutomationClient
    {
        private readonly AutomationManagement.IAutomationManagementClient automationManagementClient;

        // Injection point for unit tests
        public AutomationClient()
        {
        }

        public AutomationClient(AzureSubscription subscription)
            : this(subscription,
            AzureSession.ClientFactory.CreateClient<AutomationManagement.AutomationManagementClient>(subscription, AzureEnvironment.Endpoint.ServiceManagement))
        {
        }

        public AutomationClient(AzureSubscription subscription, AutomationManagement.IAutomationManagementClient automationManagementClient)
        {
            Requires.Argument("automationManagementClient", automationManagementClient).NotNull();

            this.Subscription = subscription;
            this.automationManagementClient = automationManagementClient;
        }

        public AzureSubscription Subscription { get; private set; }

        #region Schedule Operations

        public Schedule GetSchedule(string automationAccountName, string scheduleName)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(automationAccountName, scheduleName);
            return this.CreateScheduleFromScheduleModel(scheduleModel);
        }

        public IEnumerable<Schedule> ListSchedules(string automationAccountName)
        {
            IList<AutomationManagement.Models.Schedule> scheduleModels = AutomationManagementClient.ContinuationTokenHandler(
                skipToken =>
                {
                    var response = this.automationManagementClient.Schedules.List(
                        automationAccountName);
                    return new ResponseWithSkipToken<AutomationManagement.Models.Schedule>(
                        response, response.Schedules);
                });

            return scheduleModels.Select(this.CreateScheduleFromScheduleModel);
        }

        #endregion

        #region RunbookOperations
        public Runbook GetRunbook(string automationAccountName, string name) 
        {
            var sdkRunbook = this.automationManagementClient.Runbooks.Get(automationAccountName, name).Runbook;

            if (sdkRunbook == null)
            {
                throw new ResourceNotFoundException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, name));
            }

            return new Runbook(automationAccountName, sdkRunbook);
        }

        public IEnumerable<Runbook> ListRunbooks(string automationAccountName)
        {
            return AutomationManagementClient
                .ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.Runbooks.List(
                            automationAccountName, skipToken);
                        return new ResponseWithSkipToken<AutomationManagement.Models.Runbook>(
                            response, response.Runbooks);
                    }).Select(c => new Runbook(automationAccountName, c));
        }

        public Runbook CreateRunbookByName(string automationAccountName, string runbookName, string description, IDictionary<string, string> tags)
        {
            var rdcprop = new RunbookCreateDraftProperties()
            {
                Description = description,
                RunbookType = RunbookTypeEnum.Script,
                Draft = new RunbookDraft()
            };

            var rdcparam = new RunbookCreateDraftParameters() { Name = runbookName, Properties = rdcprop, Location = "" };

            this.automationManagementClient.Runbooks.CreateWithDraftParameters(automationAccountName, rdcparam);

            return this.GetRunbook(automationAccountName, runbookName);
        }

        public Runbook CreateRunbookByPath(string automationAccountName, string runbookPath, string description, IDictionary<string, string> tags)
        {
            var runbookName = Path.GetFileNameWithoutExtension(runbookPath);

            var runbook = this.CreateRunbookByName(automationAccountName, runbookName, description, tags);

            var rduprop = new RunbookDraftUpdateParameters()
            {
                Name = runbookName,
                Stream = File.ReadAllText(runbookPath)
            };

            this.automationManagementClient.RunbookDraft.Update(automationAccountName, rduprop);

            return runbook;
        }
        
        public void DeleteRunbook(string automationAccountName, string runbookName)
        {
            this.automationManagementClient.Runbooks.Delete(automationAccountName, runbookName);
        }

        public Runbook UpdateRunbook(string automationAccountName, string runbookName, string description, IDictionary<string, string> tags, bool? logProgress, bool? logVerbose)
        {
            var runbookUpdateParameters = new RunbookUpdateParameters();
            runbookUpdateParameters.Name = runbookName;
            if (tags != null) runbookUpdateParameters.Tags = tags;
            if (description != null) runbookUpdateParameters.Properties.Description = description;
            if (logProgress.HasValue) runbookUpdateParameters.Properties.LogProgress = logProgress.Value;
            if (logVerbose.HasValue) runbookUpdateParameters.Properties.LogVerbose = logVerbose.Value;

            var runbook = this.automationManagementClient.Runbooks.Update(automationAccountName, runbookUpdateParameters).Runbook;

            return new Runbook(automationAccountName, runbook);
        }

        public RunbookDefinition UpdateRunbookDefinition(string automationAccountName, string runbookName, string runbookPath, bool overwrite)
        {

            var runbook = this.automationManagementClient.Runbooks.Get(automationAccountName, runbookName).Runbook;
            if (runbook == null)
            {
                throw new ResourceNotFoundException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
            }

            if ((0 == String.Compare(runbook.Properties.State, "InEdit", CultureInfo.InvariantCulture,CompareOptions.IgnoreCase) && overwrite == false))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyHasDraft));
            }

            this.automationManagementClient.RunbookDraft.Update(automationAccountName, new RunbookDraftUpdateParameters { Name = runbookName, Stream = File.ReadAllText(runbookPath)});

            var content = this.automationManagementClient.RunbookDraft.Content(automationAccountName, runbookName).Stream;

            return new RunbookDefinition(automationAccountName, runbook, content, "Draft");
        }

        public IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookName(string automationAccountName, string runbookName, bool? isDraft)
        {
            // Todo will do in next iteration
            ////var ret = new List<RunbookDefinition>(); 
            ////var runbook = this.automationManagementClient.Runbooks.Get(automationAccountName, runbookName).Runbook;

            ////if (0 == String.Compare(runbook.Properties.State, "InEdit", CultureInfo.InvariantCulture, CompareOptions.IgnoreCase) && isDraft.Value)
            ////{
            ////    var draftContent = this.automationManagementClient.RunbookDrafts.Content(automationAccountName, runbookName).Stream;
            ////    ret.Add(new RunbookDefinition(automationAccountName, runbook, draftContent, "Draft")));
            ////}
            ////else if (0 ==
            ////         String.Compare(runbook.Properties.State, "Published", CultureInfo.InvariantCulture, CompareOptions.IgnoreCase))
            ////{
            ////    var publisedContent =
            ////        this.automationManagementClient.Runbooks.Content(automationAccountName, runbookName).Stream;
            ////    ret.Add(
            ////}

            ////return new RunbookDefinition(automationAccountName, runbook, content, "Published");

            return null;
        }

        public Runbook PublishRunbook(string automationAccountName, string runbookName)
        {
            this.automationManagementClient.RunbookDraft.Publish(
                automationAccountName,
                new RunbookDraftPublishParameters
                {
                    Name = runbookName,
                    PublishedBy = Constants.ClientIdentity
                });

            return this.GetRunbook(automationAccountName, runbookName);
        }
        
        #endregion

        #region Private Methods

        private Schedule CreateScheduleFromScheduleModel(AutomationManagement.Models.Schedule schedule)
        {
            Requires.Argument("schedule", schedule).NotNull();

            return new Schedule(schedule);
        }

        private AutomationManagement.Models.Schedule GetScheduleModel(string automationAccountName, string scheduleName)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.automationManagementClient.Schedules.Get(
                automationAccountName,
                scheduleName)
                .Schedule;

            if (scheduleModel == null)
            {
                throw new ResourceNotFoundException(typeof(Schedule), string.Format(CultureInfo.CurrentCulture, Resources.ScheduleNotFound, scheduleName));
            }

            return scheduleModel;
        }

        private string FormatDateTime(DateTime dateTime)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:O}", dateTime.ToUniversalTime());
        }

        #endregion
    }
}