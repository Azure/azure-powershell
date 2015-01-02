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
using System.IO;
using System.Net;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Runbook = Microsoft.Azure.Commands.Automation.Model.Runbook;
using Schedule = Microsoft.Azure.Commands.Automation.Model.Schedule;

namespace Microsoft.Azure.Commands.Automation.Common
{
    using AutomationManagement = Management.Automation;

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
                        automationAccountName,skipToken);
                    return new ResponseWithSkipToken<AutomationManagement.Models.Schedule>(
                        response, response.Schedules);
                });

            return scheduleModels.Select(this.CreateScheduleFromScheduleModel);
        }

        #endregion

        #region RunbookOperations
        public Runbook GetRunbook(string automationAccountName, string runbookName) 
        {
            var runbookModel = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbookModel == null)
            {
                throw new ResourceCommonException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
            }

            return new Runbook(automationAccountName, runbookModel);
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
            var runbookModel = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbookModel != null)
            {
                throw new ResourceCommonException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyExists, runbookName));
            }

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

            var runbookModel = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbookModel != null)
            {
                throw new ResourceCommonException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyExists, runbookName));
            }

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
            var runbook = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbook == null)
            {
                throw new ResourceNotFoundException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
            }

            if ((0 == String.Compare(runbook.Properties.State, RunbookState.Edit, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase) && overwrite == false))
            {
                throw new ResourceCommonException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyHasDraft, runbookName));
            }

            this.automationManagementClient.RunbookDraft.Update(automationAccountName, new RunbookDraftUpdateParameters { Name = runbookName, Stream = File.ReadAllText(runbookPath)});

            var content = this.automationManagementClient.RunbookDraft.Content(automationAccountName, runbookName).Stream;

            return new RunbookDefinition(automationAccountName, runbook, content, Constants.Draft);
        }

        public IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookName(string automationAccountName, string runbookName, bool? isDraft)
        {
            var ret = new List<RunbookDefinition>();

            var runbook = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbook == null)
            {
                throw new ResourceNotFoundException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName)); 
            }

            if (0 != String.Compare(runbook.Properties.State, RunbookState.Published, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase) && isDraft != null && isDraft.Value == true )
            {
                var draftContent = this.automationManagementClient.RunbookDraft.Content(automationAccountName, runbookName).Stream;
                ret.Add(new RunbookDefinition(automationAccountName, runbook, draftContent, Constants.Draft));
            }
            else 
            {
                var publishedContent = this.automationManagementClient.Runbooks.Content(automationAccountName, runbookName).Stream;
                ret.Add(new RunbookDefinition(automationAccountName, runbook, publishedContent, Constants.Published));
            }

            return ret;
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

        private Management.Automation.Models.Runbook TryGetRunbookModel(string automationAccountName, string runbookName)
        {
            Management.Automation.Models.Runbook runbook = null;
            try
            {
                runbook = this.automationManagementClient.Runbooks.Get(automationAccountName, runbookName).Runbook;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    runbook = null;
                }
                else
                {
                    throw;
                }
            }
            return runbook;
        }

        private string FormatDateTime(DateTime dateTime)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:O}", dateTime.ToUniversalTime());
        }

        #endregion
    }
}