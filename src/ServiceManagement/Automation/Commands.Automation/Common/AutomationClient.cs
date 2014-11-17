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
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Newtonsoft.Json;

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

        public AutomationClient(
            AzureSubscription subscription,
            AutomationManagement.IAutomationManagementClient automationManagementClient)
        {
            Requires.Argument("automationManagementClient", automationManagementClient).NotNull();

            this.Subscription = subscription;
            this.automationManagementClient = automationManagementClient;
        }

        public AzureSubscription Subscription { get; private set; }

        #region Account Operations

        public IEnumerable<AutomationAccount> ListAutomationAccounts(string automationAccountName, string location)
        {
            if (automationAccountName != null)
            {
                Requires.Argument("AutomationAccountName", automationAccountName).ValidAutomationAccountName();
            }

            var automationAccounts = new List<AutomationAccount>();
            var cloudServices = new List<AutomationManagement.Models.CloudService>(this.automationManagementClient.CloudServices.List().CloudServices);

            foreach (var cloudService in cloudServices)
            {
                automationAccounts.AddRange(cloudService.Resources.Select(resource => new AutomationAccount(cloudService, resource)));
            }

            // RDFE does not support server-side filtering, hence we filter on the client-side.
            if (automationAccountName != null)
            {
                automationAccounts = automationAccounts.Where(account => string.Equals(account.AutomationAccountName, automationAccountName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (!automationAccounts.Any())
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.AutomationAccountNotFound));
                }
            }

            if (location != null)
            {
                automationAccounts = automationAccounts.Where(account => string.Equals(account.Location, location, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return automationAccounts;
        }

        #endregion

        #region Runbook Operations

        public Runbook CreateRunbookByName(string automationAccountName, string runbookName, string description, string[] tags)
        {
            var runbookScript = string.Format(CultureInfo.InvariantCulture, @"workflow {0}{1}{{{1}}}", runbookName, Environment.NewLine);
            using (var streamReader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(runbookScript), false), Encoding.UTF8))
            {
                Stream runbookStream = streamReader.BaseStream;
                Runbook runbook = this.CreateRunbook(automationAccountName, runbookStream);
                this.UpdateRunbook(automationAccountName, runbook.Id, description, tags, null, null, null);
                return this.GetRunbook(automationAccountName, runbook.Id);
            }
        }

        public Runbook CreateRunbookByPath(string automationAccountName, string runbookPath, string description, string[] tags)
        {
            Runbook runbook = this.CreateRunbook(automationAccountName, File.OpenRead(runbookPath));
            this.UpdateRunbook(automationAccountName, runbook.Id, description, tags, null, null, null);
            return this.GetRunbook(automationAccountName, runbook.Id);
        }

        public void DeleteRunbook(string automationAccountName, Guid runbookId)
        {
            this.automationManagementClient.Runbooks.Delete(
                automationAccountName,
                runbookId.ToString());
        }

        public void DeleteRunbook(string automationAccountName, string runbookName)
        {
            Runbook runbook = this.GetRunbook(automationAccountName, runbookName);
            this.DeleteRunbook(automationAccountName, runbook.Id);
        }

        /// <summary>
        /// Gets the runbook identified by runbookId, with schedule names expanded.
        /// </summary>
        /// <param name="automationAccountName">
        /// The automation account name.
        /// </param>
        /// <param name="runbookId">
        /// The runbook id.
        /// </param>
        /// <returns>
        /// The <see cref="Runbook"/>.
        /// </returns>
        public Runbook GetRunbook(string automationAccountName, Guid runbookId)
        {
            return new Runbook(this.GetRunbookModel(automationAccountName, runbookId, true));
        }

        /// <summary>
        /// Gets the runbook identified by runbookId, with schedule names expanded.
        /// </summary>
        /// <param name="automationAccountName">
        /// The automation account name.
        /// </param>
        /// <param name="runbookName">
        /// The runbook name.
        /// </param>
        /// <returns>
        /// The <see cref="Runbook"/>.
        /// </returns>
        public Runbook GetRunbook(string automationAccountName, string runbookName)
        {
            return new Runbook(this.GetRunbookModel(automationAccountName, runbookName, true));
        }

        public IEnumerable<Runbook> ListRunbooks(string automationAccountName)
        {
            IList<AutomationManagement.Models.Runbook> runbookModels = AutomationManagementClient.ContinuationTokenHandler(
                skipToken =>
                {
                    var listRunbookResponse =
                        this.automationManagementClient.Runbooks.ListWithSchedules(
                        automationAccountName, skipToken);
                    return new ResponseWithSkipToken<AutomationManagement.Models.Runbook>(
                        listRunbookResponse, listRunbookResponse.Runbooks);
                });

            return runbookModels.Select(runbookModel => new Runbook(runbookModel));
        }

        public IEnumerable<Runbook> ListRunbookByScheduleName(string automationAccountName, string scheduleName)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(automationAccountName, scheduleName);
            IList<AutomationManagement.Models.Runbook> runbookModels = AutomationManagementClient.ContinuationTokenHandler(
                skipToken =>
                {
                    var listRunbookResponse =
                        this.automationManagementClient.Runbooks.ListByScheduleNameWithSchedules(
                            automationAccountName,
                            new AutomationManagement.Models.RunbookListByScheduleNameParameters
                            {
                                ScheduleName = scheduleModel.Name,
                                SkipToken = skipToken
                            });
                    return new ResponseWithSkipToken<AutomationManagement.Models.Runbook>(
                        listRunbookResponse, listRunbookResponse.Runbooks);
                });

            IEnumerable<Runbook> runbooks = runbookModels.Select(runbookModel => new Runbook(runbookModel));
            return runbooks.Where(runbook => runbook.ScheduleNames.Any());
        }

        public Runbook PublishRunbook(string automationAccountName, Guid runbookId)
        {
            this.automationManagementClient.Runbooks.Publish(
                automationAccountName,
                new AutomationManagement.Models.RunbookPublishParameters
                {
                    RunbookId = runbookId.ToString(),
                    PublishedBy = Constants.ClientIdentity
                });

            return this.GetRunbook(automationAccountName, runbookId);
        }

        public Runbook PublishRunbook(string automationAccountName, string runbookName)
        {
            Guid runbookId = this.GetRunbookIdByRunbookName(automationAccountName, runbookName);
            return this.PublishRunbook(automationAccountName, runbookId);
        }

        public Job StartRunbook(string automationAccountName, Guid runbookId, IDictionary parameters)
        {
            IEnumerable<AutomationManagement.Models.NameValuePair> processedParameters = this.ProcessRunbookParameters(automationAccountName, runbookId, parameters);
            var startResponse = this.automationManagementClient.Runbooks.Start(
                                    automationAccountName,
                                    new AutomationManagement.Models.RunbookStartParameters
                                    {
                                        RunbookId = runbookId.ToString(),
                                        Parameters = processedParameters.ToList()
                                    });

            return this.GetJob(automationAccountName, new Guid(startResponse.JobId));
        }

        public Job StartRunbook(string automationAccountName, string runbookName, IDictionary parameters)
        {
            Guid runbookId = this.GetRunbookIdByRunbookName(automationAccountName, runbookName);
            return this.StartRunbook(automationAccountName, runbookId, parameters);
        }

        public Runbook RegisterScheduledRunbook(
            string automationAccountName, Guid runbookId, IDictionary parameters, string scheduleName)
        {
            Schedule schedule = this.GetSchedule(automationAccountName, scheduleName);
            IEnumerable<AutomationManagement.Models.NameValuePair> processedParameters = this.ProcessRunbookParameters(automationAccountName, runbookId, parameters);
            this.automationManagementClient.Runbooks.CreateScheduleLink(
                automationAccountName,
                new AutomationManagement.Models.RunbookCreateScheduleLinkParameters
                {
                    RunbookId = runbookId.ToString(),
                    Parameters = processedParameters.ToList(),
                    ScheduleId = schedule.Id.ToString()
                });

            return this.GetRunbook(automationAccountName, runbookId);
        }

        public Runbook RegisterScheduledRunbook(
            string automationAccountName, string runbookName, IDictionary parameters, string scheduleName)
        {
            Guid runbookId = this.GetRunbookIdByRunbookName(automationAccountName, runbookName);
            return this.RegisterScheduledRunbook(automationAccountName, runbookId, parameters, scheduleName);
        }

        public Runbook UpdateRunbook(string automationAccountName, Guid runbookId, string description, string[] tags, bool? logDebug, bool? logProgress, bool? logVerbose)
        {
            AutomationManagement.Models.Runbook runbookModel = this.GetRunbookModel(automationAccountName, runbookId, false);
            return this.UpdateRunbookHelper(automationAccountName, runbookModel, description, tags, logDebug, logProgress, logVerbose);
        }

        public Runbook UpdateRunbook(string automationAccountName, string runbookName, string description, string[] tags, bool? logDebug, bool? logProgress, bool? logVerbose)
        {
            AutomationManagement.Models.Runbook runbookModel = this.GetRunbookModel(automationAccountName, runbookName, false);
            return this.UpdateRunbookHelper(automationAccountName, runbookModel, description, tags, logDebug, logProgress, logVerbose);
        }

        public Runbook UnregisterScheduledRunbook(string automationAccountName, Guid runbookId, string scheduleName)
        {
            Schedule schedule = this.GetSchedule(automationAccountName, scheduleName);
            this.automationManagementClient.Runbooks.DeleteScheduleLink(
                automationAccountName,
                new AutomationManagement.Models.RunbookDeleteScheduleLinkParameters
                {
                    RunbookId = runbookId.ToString(),
                    ScheduleId =
                        schedule.Id.ToString()
                });
            return this.GetRunbook(automationAccountName, runbookId);
        }

        public Runbook UnregisterScheduledRunbook(string automationAccountName, string runbookName, string scheduleName)
        {
            Guid runbookId = this.GetRunbookIdByRunbookName(automationAccountName, runbookName);
            return this.UnregisterScheduledRunbook(automationAccountName, runbookId, scheduleName);
        }

        #endregion

        #region Runbook Definition Operations

        public IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookName(string automationAccountName, string runbookName, bool? isDraft)
        {
            Guid runbookId = this.GetRunbookIdByRunbookName(automationAccountName, runbookName);
            return this.ListRunbookDefinitionsByValidRunbookId(automationAccountName, runbookId, isDraft);
        }

        public IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookId(string automationAccountName, Guid runbookId, bool? isDraft)
        {
            AutomationManagement.Models.Runbook runbookModel = this.GetRunbookModel(automationAccountName, runbookId, false);
            return this.ListRunbookDefinitionsByValidRunbookId(automationAccountName, new Guid(runbookModel.Id), isDraft);
        }

        public IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookVersionId(string automationAccountName, Guid runbookVersionId, bool? isDraft)
        {
            AutomationManagement.Models.RunbookVersion runbookVersionModel = this.GetRunbookVersionModel(automationAccountName, runbookVersionId);
            if (!isDraft.HasValue || isDraft.Value == runbookVersionModel.IsDraft)
            {
                return this.CreateRunbookDefinitionsFromRunbookVersionModels(
                    automationAccountName, new List<AutomationManagement.Models.RunbookVersion> { runbookVersionModel });
            }
            else
            {
                return new List<RunbookDefinition>();
            }
        }

        public RunbookDefinition UpdateRunbookDefinition(string automationAccountName, Guid runbookId, string runbookPath, bool overwrite)
        {
            return this.UpdateRunbookDefinition(automationAccountName, runbookId, File.OpenRead(runbookPath), overwrite);
        }

        public RunbookDefinition UpdateRunbookDefinition(string automationAccountName, string runbookName, string runbookPath, bool overwrite)
        {
            Guid runbookId = this.GetRunbookIdByRunbookName(automationAccountName, runbookName);
            return this.UpdateRunbookDefinition(automationAccountName, runbookId, runbookPath, overwrite);
        }

        #endregion

        #region Job Operations

        public Job GetJob(string automationAccountName, Guid jobId)
        {
            return new Job(this.GetJobModel(automationAccountName, jobId));
        }

        public IEnumerable<Job> ListJobs(string automationAccountName, DateTime? startTime, DateTime? endTime)
        {
            // Assume local time if DateTimeKind.Unspecified
            if (startTime.HasValue && startTime.Value.Kind == DateTimeKind.Unspecified)
            {
                startTime = DateTime.SpecifyKind(startTime.Value, DateTimeKind.Local);
            }

            if (endTime.HasValue && endTime.Value.Kind == DateTimeKind.Unspecified)
            {
                endTime = DateTime.SpecifyKind(endTime.Value, DateTimeKind.Local);
            }

            IEnumerable<AutomationManagement.Models.Job> jobModels;

            if (startTime.HasValue && endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.Jobs.ListFilteredByStartTimeEndTime(
                                automationAccountName,
                                new AutomationManagement.Models.JobListParameters
                                {
                                    StartTime = this.FormatDateTime(startTime.Value),
                                    EndTime = this.FormatDateTime(endTime.Value),
                                    SkipToken = skipToken
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }
            else if (startTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.Jobs.ListFilteredByStartTime(
                                automationAccountName,
                                new AutomationManagement.Models.JobListParameters
                                {
                                    StartTime = this.FormatDateTime(startTime.Value),
                                    SkipToken = skipToken
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }
            else if (endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.Jobs.ListFilteredByStartTime(
                                automationAccountName,
                                new AutomationManagement.Models.JobListParameters
                                {
                                    EndTime = this.FormatDateTime(endTime.Value),
                                    SkipToken = skipToken
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }
            else
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.Jobs.List(
                            automationAccountName,
                            new AutomationManagement.Models.JobListParameters { SkipToken = skipToken, });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }

            return jobModels.Select(jobModel => new Job(jobModel));
        }

        public IEnumerable<Job> ListJobsByRunbookId(string automationAccountName, Guid runbookId, DateTime? startTime, DateTime? endTime)
        {
            AutomationManagement.Models.Runbook runbookModel = this.GetRunbookModel(automationAccountName, runbookId, false);
            return this.ListJobsByValidRunbookId(automationAccountName, new Guid(runbookModel.Id), startTime, endTime);
        }

        public IEnumerable<Job> ListJobsByRunbookName(string automationAccountName, string runbookName, DateTime? startTime, DateTime? endTime)
        {
            Guid runbookId = this.GetRunbookIdByRunbookName(automationAccountName, runbookName);
            return this.ListJobsByValidRunbookId(automationAccountName, runbookId, startTime, endTime);
        }

        public void ResumeJob(string automationAccountName, Guid jobId)
        {
            this.automationManagementClient.Jobs.Resume(
                automationAccountName,
                jobId.ToString());
        }

        public void StopJob(string automationAccountName, Guid jobId)
        {
            this.automationManagementClient.Jobs.Stop(
                automationAccountName,
                jobId.ToString());
        }

        public void SuspendJob(string automationAccountName, Guid jobId)
        {
            this.automationManagementClient.Jobs.Suspend(
                automationAccountName,
                jobId.ToString());
        }

        #endregion

        #region Job Stream Item Operations

        public IEnumerable<JobStreamItem> ListJobStreamItems(string automationAccountName, Guid jobId, DateTime createdSince, string streamTypeName)
        {
            AutomationManagement.Models.Job jobModel = this.GetJobModel(automationAccountName, jobId);
            IList<AutomationManagement.Models.JobStreamItem> jobStreamItemModels = AutomationManagementClient.ContinuationTokenHandler(
                skipToken =>
                {
                    var response = this.automationManagementClient.JobStreams.ListStreamItems(
                        automationAccountName,
                        new AutomationManagement.Models.JobStreamListStreamItemsParameters
                        {
                            JobId = jobModel.Id,
                            StartTime = this.FormatDateTime(createdSince),
                            StreamType = streamTypeName,
                            SkipToken = skipToken
                        });
                    return new ResponseWithSkipToken<AutomationManagement.Models.JobStreamItem>(
                        response, response.JobStreamItems);
                });

            return jobStreamItemModels.Select(jobStreamItemModel => new JobStreamItem(jobStreamItemModel));
        }

        #endregion

        #region Schedule Operations

        public Schedule CreateSchedule(string automationAccountName, OneTimeSchedule schedule)
        {
            this.ValidateScheduleName(automationAccountName, schedule.Name);

            var scheduleModel = new AutomationManagement.Models.Schedule
            {
                Name = schedule.Name,
                StartTime = schedule.StartTime.ToUniversalTime(),
                ExpiryTime = schedule.ExpiryTime.ToUniversalTime(),
                Description = schedule.Description,
                ScheduleType =
                    AutomationManagement.Models.ScheduleType
                                        .OneTimeSchedule
            };

            var scheduleCreateParameters = new AutomationManagement.Models.ScheduleCreateParameters
            {
                Schedule = scheduleModel
            };

            var scheduleCreateResponse = this.automationManagementClient.Schedules.Create(
                automationAccountName,
                scheduleCreateParameters);

            return this.GetSchedule(automationAccountName, new Guid(scheduleCreateResponse.Schedule.Id));
        }

        public Schedule CreateSchedule(string automationAccountName, DailySchedule schedule)
        {
            this.ValidateScheduleName(automationAccountName, schedule.Name);

            var scheduleModel = new AutomationManagement.Models.Schedule
            {
                Name = schedule.Name,
                StartTime = schedule.StartTime.ToUniversalTime(),
                ExpiryTime = schedule.ExpiryTime.ToUniversalTime(),
                Description = schedule.Description,
                DayInterval = schedule.DayInterval,
                ScheduleType =
                    AutomationManagement.Models.ScheduleType
                                        .DailySchedule
            };

            var scheduleCreateParameters = new AutomationManagement.Models.ScheduleCreateParameters
            {
                Schedule = scheduleModel
            };

            var scheduleCreateResponse = this.automationManagementClient.Schedules.Create(
                automationAccountName,
                scheduleCreateParameters);

            return this.GetSchedule(automationAccountName, new Guid(scheduleCreateResponse.Schedule.Id));
        }

        public Schedule CreateSchedule(string automationAccountName, HourlySchedule schedule)
        {
            this.ValidateScheduleName(automationAccountName, schedule.Name);

            var scheduleModel = new AutomationManagement.Models.Schedule
            {
                Name = schedule.Name,
                StartTime = schedule.StartTime.ToUniversalTime(),
                ExpiryTime = schedule.ExpiryTime.ToUniversalTime(),
                Description = schedule.Description,
                HourInterval = schedule.HourInterval,
                ScheduleType =
                    AutomationManagement.Models.ScheduleType
                                        .HourlySchedule
            };

            var scheduleCreateParameters = new AutomationManagement.Models.ScheduleCreateParameters
            {
                Schedule = scheduleModel
            };

            var scheduleCreateResponse = this.automationManagementClient.Schedules.Create(
                automationAccountName,
                scheduleCreateParameters);

            return this.GetSchedule(automationAccountName, new Guid(scheduleCreateResponse.Schedule.Id));
        }

        public void DeleteSchedule(string automationAccountName, Guid scheduleId)
        {
            this.automationManagementClient.Schedules.Delete(
                automationAccountName,
                scheduleId.ToString());
        }

        public void DeleteSchedule(string automationAccountName, string scheduleName)
        {
            Schedule schedule = this.GetSchedule(automationAccountName, scheduleName);
            this.DeleteSchedule(automationAccountName, schedule.Id);
        }

        public Schedule GetSchedule(string automationAccountName, Guid scheduleId)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(automationAccountName, scheduleId);
            return this.CreateScheduleFromScheduleModel(scheduleModel);
        }

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
                        automationAccountName, skipToken);
                    return new ResponseWithSkipToken<AutomationManagement.Models.Schedule>(
                        response, response.Schedules);
                });

            return scheduleModels.Select(this.CreateScheduleFromScheduleModel);
        }

        public Schedule UpdateSchedule(string automationAccountName, Guid scheduleId, bool? isEnabled, string description)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(automationAccountName, scheduleId);
            return this.UpdateScheduleHelper(automationAccountName, scheduleModel, isEnabled, description);
        }

        public Schedule UpdateSchedule(string automationAccountName, string scheduleName, bool? isEnabled, string description)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(automationAccountName, scheduleName);
            return this.UpdateScheduleHelper(automationAccountName, scheduleModel, isEnabled, description);
        }

        #endregion

        #region Private Methods

        private Runbook CreateRunbook(string automationAccountName, Stream runbookStream)
        {
            var createRunbookVersionResponse = this.automationManagementClient.RunbookVersions.Create(
                automationAccountName,
                runbookStream);

            var getRunbookVersionResponse = this.automationManagementClient.RunbookVersions.Get(
                automationAccountName,
                createRunbookVersionResponse.RunbookVersion.Id);

            return this.GetRunbook(automationAccountName, new Guid(getRunbookVersionResponse.RunbookVersion.RunbookId));
        }

        private IEnumerable<RunbookDefinition> CreateRunbookDefinitionsFromRunbookVersionModels(
            string automationAccountName, IEnumerable<Azure.Management.Automation.Models.RunbookVersion> runbookVersionModels)
        {
            foreach (AutomationManagement.Models.RunbookVersion runbookVersionModel in runbookVersionModels)
            {
                var getRunbookDefinitionResponse =
                    this.automationManagementClient.RunbookVersions.GetRunbookDefinition(
                        automationAccountName,
                        runbookVersionModel.Id);

                yield return new RunbookDefinition(runbookVersionModel, getRunbookDefinitionResponse.RunbookDefinition);
            }
        }

        private Schedule CreateScheduleFromScheduleModel(AutomationManagement.Models.Schedule schedule)
        {
            Requires.Argument("schedule", schedule).NotNull();

            if (schedule.ScheduleType == AutomationManagement.Models.ScheduleType.DailySchedule)
            {
                return new DailySchedule(schedule);
            }
            else if (schedule.ScheduleType == AutomationManagement.Models.ScheduleType.HourlySchedule)
            {
                return new HourlySchedule(schedule);
            }
            else
            {
                return new OneTimeSchedule(schedule);
            }
        }

        private Guid EditRunbook(string automationAccountName, Guid runbookId)
        {
            return new Guid(this.automationManagementClient.Runbooks.Edit(
                automationAccountName,
                runbookId.ToString())
                .DraftRunbookVersionId);
        }

        private string FormatDateTime(DateTime dateTime)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:O}", dateTime.ToUniversalTime());
        }

        private AutomationManagement.Models.Job GetJobModel(string automationAccountName, Guid jobId)
        {
            AutomationManagement.Models.Job jobModel = this.automationManagementClient.Jobs.Get(
                automationAccountName,
                jobId.ToString())
                .Job;

            if (jobModel == null)
            {
                throw new ResourceNotFoundException(typeof(Job), string.Format(CultureInfo.CurrentCulture, Resources.JobNotFoundById, jobId));
            }

            return jobModel;
        }

        private IEnumerable<Job> ListJobsByValidRunbookId(string automationAccountName, Guid runbookId, DateTime? startTime, DateTime? endTime)
        {
            // Assume local time if DateTimeKind.Unspecified
            if (startTime.HasValue && startTime.Value.Kind == DateTimeKind.Unspecified)
            {
                startTime = DateTime.SpecifyKind(startTime.Value, DateTimeKind.Local);
            }

            if (endTime.HasValue && endTime.Value.Kind == DateTimeKind.Unspecified)
            {
                endTime = DateTime.SpecifyKind(endTime.Value, DateTimeKind.Local);
            }

            IEnumerable<AutomationManagement.Models.Job> jobModels;

            if (startTime.HasValue && endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.Jobs.ListByRunbookIdFilteredByStartTimeEndTime(
                                automationAccountName,
                                new AutomationManagement.Models.JobListByRunbookIdParameters
                                {
                                    RunbookId = runbookId.ToString(),
                                    StartTime = this.FormatDateTime(startTime.Value),
                                    EndTime = this.FormatDateTime(endTime.Value),
                                    SkipToken = skipToken
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }
            else if (startTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.Jobs.ListByRunbookIdFilteredByStartTime(
                                automationAccountName,
                                new AutomationManagement.Models.JobListByRunbookIdParameters
                                {
                                    RunbookId = runbookId.ToString(),
                                    StartTime = this.FormatDateTime(startTime.Value),
                                    SkipToken = skipToken,
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }
            else if (endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.Jobs.ListByRunbookIdFilteredByStartTime(
                                automationAccountName,
                                new AutomationManagement.Models.JobListByRunbookIdParameters
                                {
                                    RunbookId = runbookId.ToString(),
                                    EndTime = this.FormatDateTime(endTime.Value),
                                    SkipToken = skipToken,
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }
            else
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.Jobs.ListByRunbookId(
                            automationAccountName,
                            new AutomationManagement.Models.JobListByRunbookIdParameters
                            {
                                RunbookId = runbookId.ToString(),
                                SkipToken = skipToken,
                            });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }

            return jobModels.Select(jobModel => new Job(jobModel));
        }

        private Guid GetRunbookIdByRunbookName(string automationAccountName, string runbookName)
        {
            return new Guid(this.GetRunbookModel(automationAccountName, runbookName, false).Id);
        }

        private AutomationManagement.Models.Runbook GetRunbookModel(string automationAccountName, Guid runbookId, bool withSchedules)
        {
            AutomationManagement.Models.Runbook runbookModel = withSchedules
                              ? this.automationManagementClient.Runbooks.GetWithSchedules(
                                  automationAccountName,
                                  runbookId.ToString()).Runbook
                              : this.automationManagementClient.Runbooks.Get(
                                  automationAccountName,
                                  runbookId.ToString()).Runbook;

            if (runbookModel == null)
            {
                throw new ResourceNotFoundException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFoundById, runbookId));
            }

            return runbookModel;
        }

        private AutomationManagement.Models.Runbook GetRunbookModel(string automationAccountName, string runbookName, bool withSchedules)
        {
            IList<AutomationManagement.Models.Runbook> runbookModels = withSchedules
                               ? this.automationManagementClient.Runbooks.ListByNameWithSchedules(
                                   automationAccountName,
                                   runbookName).Runbooks
                               : this.automationManagementClient.Runbooks.ListByName(
                                   automationAccountName,
                                   runbookName).Runbooks;

            if (!runbookModels.Any())
            {
                throw new ResourceNotFoundException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFoundByName, runbookName));
            }

            return runbookModels.First();
        }

        private AutomationManagement.Models.RunbookVersion GetRunbookVersionModel(
            string automationAccountName, Guid runbookVersionId)
        {
            AutomationManagement.Models.RunbookVersion runbookVersionModel =
                this.automationManagementClient.RunbookVersions.Get(
                    automationAccountName,
                    runbookVersionId.ToString()).RunbookVersion;

            if (runbookVersionModel == null)
            {
                throw new ResourceNotFoundException(
                    typeof(RunbookVersion),
                    string.Format(CultureInfo.CurrentCulture, Resources.RunbookVersionNotFoundById, runbookVersionId));
            }

            return runbookVersionModel;
        }

        private IEnumerable<RunbookDefinition> ListRunbookDefinitionsByValidRunbookId(string automationAccountName, Guid runbookId, bool? isDraft)
        {
            IList<AutomationManagement.Models.RunbookVersion> runbookVersionModels = isDraft.HasValue
                                      ? this.automationManagementClient.RunbookVersions.ListLatestByRunbookIdSlot(
                                          automationAccountName,
                                          new AutomationManagement.Models.
                                            RunbookVersionListLatestByRunbookIdSlotParameters
                                          {
                                              RunbookId =
                                                  runbookId.ToString(),
                                              IsDraft =
                                                  isDraft.Value
                                          })
                                            .RunbookVersions
                                      : this.automationManagementClient.RunbookVersions.ListLatestByRunbookId(
                                          automationAccountName,
                                          runbookId.ToString()).RunbookVersions;

            return this.CreateRunbookDefinitionsFromRunbookVersionModels(automationAccountName, runbookVersionModels);
        }

        private AutomationManagement.Models.Schedule GetScheduleModel(string automationAccountName, Guid scheduleId)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.automationManagementClient.Schedules.Get(
                automationAccountName,
                scheduleId.ToString())
                .Schedule;

            if (scheduleModel == null)
            {
                throw new ResourceNotFoundException(typeof(Schedule), string.Format(CultureInfo.CurrentCulture, Resources.ScheduleNotFoundById, scheduleId));
            }

            return scheduleModel;
        }

        private AutomationManagement.Models.Schedule GetScheduleModel(string automationAccountName, string scheduleName)
        {
            IList<AutomationManagement.Models.Schedule> schedules = this.automationManagementClient.Schedules.ListByName(
                automationAccountName,
                scheduleName)
                .Schedules;

            if (!schedules.Any())
            {
                throw new ResourceNotFoundException(typeof(RunbookVersion), string.Format(CultureInfo.CurrentCulture, Resources.ScheduleNotFoundByName, scheduleName));
            }

            return schedules.First();
        }

        private IEnumerable<RunbookParameter> ListRunbookParameters(string automationAccountName, Guid runbookId)
        {
            Runbook runbook = this.GetRunbook(automationAccountName, runbookId);
            if (!runbook.PublishedRunbookVersionId.HasValue)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.RunbookHasNoPublishedVersionById, runbookId));
            }

            return this.automationManagementClient.RunbookParameters.ListByRunbookVersionId(
                automationAccountName,
                runbook.PublishedRunbookVersionId.Value.ToString()).RunbookParameters.Select(runbookParameter => new RunbookParameter(runbookParameter));
        }

        private IEnumerable<AutomationManagement.Models.NameValuePair> ProcessRunbookParameters(string automationAccountName, Guid runbookId, IDictionary parameters)
        {
            parameters = parameters ?? new Dictionary<string, string>();
            IEnumerable<RunbookParameter> runbookParameters = this.ListRunbookParameters(automationAccountName, runbookId);
            var filteredParameters = new List<AutomationManagement.Models.NameValuePair>();

            foreach (var runbookParameter in runbookParameters)
            {
                if (parameters.Contains(runbookParameter.Name))
                {
                    object paramValue = parameters[runbookParameter.Name];
                    try
                    {
                        filteredParameters.Add(
                            new AutomationManagement.Models.NameValuePair
                            {
                                Name = runbookParameter.Name,
                                Value = JsonConvert.SerializeObject(paramValue, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat })
                            });
                    }
                    catch (JsonSerializationException)
                    {
                        throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture, Resources.RunbookParameterCannotBeSerializedToJson, runbookParameter.Name));
                    }
                }
                else if (runbookParameter.IsMandatory)
                {
                    throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture, Resources.RunbookParameterValueRequired, runbookParameter.Name));
                }
            }

            if (filteredParameters.Count != parameters.Count)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, Resources.InvalidRunbookParameters));
            }

            bool hasJobStartedBy = filteredParameters.Any(filteredParameter => filteredParameter.Name == Constants.JobStartedByParameterName);

            if (!hasJobStartedBy)
            {
                filteredParameters.Add(new AutomationManagement.Models.NameValuePair() { Name = Constants.JobStartedByParameterName, Value = Constants.ClientIdentity });
            }

            return filteredParameters;
        }

        private RunbookDefinition UpdateRunbookDefinition(string automationAccountName, Guid runbookId, Stream runbookStream, bool overwrite)
        {
            var runbook = new Runbook(this.GetRunbookModel(automationAccountName, runbookId, false));

            if (runbook.DraftRunbookVersionId.HasValue && overwrite == false)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyHasDraft));
            }

            Guid draftRunbookVersionId = runbook.DraftRunbookVersionId.HasValue
                                ? runbook.DraftRunbookVersionId.Value
                                : this.EditRunbook(automationAccountName, runbook.Id);

            var getRunbookDefinitionResponse = this.automationManagementClient.RunbookVersions.GetRunbookDefinition(
                automationAccountName,
                draftRunbookVersionId.ToString());

            this.automationManagementClient.RunbookVersions.UpdateRunbookDefinition(
                automationAccountName,
                new AutomationManagement.Models.RunbookVersionUpdateRunbookDefinitionParameters
                {
                    ETag = getRunbookDefinitionResponse.ETag,
                    RunbookVersionId = draftRunbookVersionId.ToString(),
                    RunbookStream = runbookStream,
                });

            IEnumerable<RunbookDefinition> runbookDefinitions = this.ListRunbookDefinitionsByRunbookVersionId(automationAccountName, draftRunbookVersionId, true);
            return runbookDefinitions.First();
        }

        private Runbook UpdateRunbookHelper(
            string automationAccountName,
            AutomationManagement.Models.Runbook runbook,
            string description,
            string[] tags,
            bool? logDebug,
            bool? logProgress,
            bool? logVerbose)
        {
            if (description != null)
            {
                runbook.Description = description;
            }

            if (tags != null)
            {
                runbook.Tags = string.Join(Constants.RunbookTagsSeparatorString, tags);
            }

            if (logDebug.HasValue)
            {
                runbook.LogDebug = logDebug.Value;
            }

            if (logProgress.HasValue)
            {
                runbook.LogProgress = logProgress.Value;
            }

            if (logVerbose.HasValue)
            {
                runbook.LogVerbose = logVerbose.Value;
            }

            var runbookUpdateParameters = new AutomationManagement.Models.RunbookUpdateParameters
            {
                Runbook = runbook
            };

            this.automationManagementClient.Runbooks.Update(automationAccountName, runbookUpdateParameters);

            var runbookId = new Guid(runbook.Id);
            return this.GetRunbook(automationAccountName, runbookId);
        }

        private Schedule UpdateScheduleHelper(string automationAccountName, AutomationManagement.Models.Schedule schedule, bool? isEnabled, string description)
        {
            // StartTime and ExpiryTime need to specified as Utc
            schedule.StartTime = DateTime.SpecifyKind(schedule.StartTime, DateTimeKind.Utc);
            schedule.ExpiryTime = DateTime.SpecifyKind(schedule.ExpiryTime, DateTimeKind.Utc);

            if (isEnabled.HasValue)
            {
                schedule.IsEnabled = isEnabled.Value;
            }

            if (description != null)
            {
                schedule.Description = description;
            }

            var scheduleUpdateParameters = new AutomationManagement.Models.ScheduleUpdateParameters
            {
                Schedule =
                    schedule
            };

            this.automationManagementClient.Schedules.Update(
                automationAccountName,
                scheduleUpdateParameters);

            var scheduleId = new Guid(schedule.Id);
            return this.GetSchedule(automationAccountName, scheduleId);
        }

        // TODO: remove the helper which provides client-side schedule name validation once CDM TFS bug 662986 is resolved.
        private void ValidateScheduleName(string automationAccountName, string scheduleName)
        {
            IList<AutomationManagement.Models.Schedule> scheduleModels =
                this.automationManagementClient.Schedules.ListByName(
                    automationAccountName, scheduleName)
                    .Schedules;

            if (scheduleModels.Any())
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ScheduleNameExists, scheduleName));
            }
        }

        #endregion
    }
}