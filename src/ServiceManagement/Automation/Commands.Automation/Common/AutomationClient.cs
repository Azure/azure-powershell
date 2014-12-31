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
using System.Net;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Management.Automation;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;

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

        #region Schedule Operations

        public Schedule CreateSchedule(string automationAccountName, Schedule schedule)
        {
            var scheduleCreateParameters = new AutomationManagement.Models.ScheduleCreateParameters
            {
                Name = schedule.Name,
                Properties = new AutomationManagement.Models.ScheduleCreateProperties
                {
                    StartTime = schedule.StartTime,
                    ExpiryTime = schedule.ExpiryTime,
                    Description = schedule.Description,
                    Interval = schedule.Interval,
                    Frequency = schedule.Frequency.ToString()
                }
            };

            var scheduleCreateResponse = this.automationManagementClient.Schedules.Create(
                automationAccountName,
                scheduleCreateParameters);

            return this.GetSchedule(automationAccountName, schedule.Name);
        }

        public void DeleteSchedule(string automationAccountName, string scheduleName)
        {
            try 
            {
                this.automationManagementClient.Schedules.Delete(
                    automationAccountName,
                    scheduleName);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Schedule), string.Format(CultureInfo.CurrentCulture, Resources.ScheduleNotFound, scheduleName));
                }

                throw;
            }
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
                   // var response = this.automationManagementClient.Schedules.List(automationAccountName, skipToken);

                    var response = this.automationManagementClient.Schedules.List(automationAccountName);

                    return new ResponseWithSkipToken<AutomationManagement.Models.Schedule>(
                        response, response.Schedules);
                });

            return scheduleModels.Select(this.CreateScheduleFromScheduleModel);
        }
        
        public Schedule UpdateSchedule(string automationAccountName, string scheduleName, bool? isEnabled, string description)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(automationAccountName, scheduleName);
            return this.UpdateScheduleHelper(automationAccountName, scheduleModel, isEnabled, description);
        }

        #endregion

        public Runbook GetRunbook(string automationAccountName, string name) 
        {
            var sdkRunbook = this.automationManagementClient.Runbooks.Get(
                automationAccountName, name).Runbook;

            if (sdkRunbook == null)
            {
                throw new ResourceNotFoundException(typeof(Runbook), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, name));
            }

            return new Runbook(sdkRunbook);
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
                    }).Select(c => new Runbook(c));
        }

        #region Private Methods

        private Schedule CreateScheduleFromScheduleModel(AutomationManagement.Models.Schedule schedule)
        {
            Requires.Argument("schedule", schedule).NotNull();

            return new Schedule(schedule);
        }

        private AutomationManagement.Models.Schedule GetScheduleModel(string automationAccountName, string scheduleName)
        {
            AutomationManagement.Models.Schedule scheduleModel;

            try
            {
                scheduleModel = this.automationManagementClient.Schedules.Get(
                    automationAccountName,
                    scheduleName)
                    .Schedule;
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Schedule), string.Format(CultureInfo.CurrentCulture, Resources.ScheduleNotFound, scheduleName));
                }

                throw;
            }

            return scheduleModel;
        }

        private string FormatDateTime(DateTime dateTime)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:O}", dateTime.ToUniversalTime());
        }

        private Schedule UpdateScheduleHelper(string automationAccountName, AutomationManagement.Models.Schedule schedule, bool? isEnabled, string description)
        {

            if (isEnabled.HasValue)
            {
                schedule.Properties.IsEnabled = isEnabled.Value;
            }

            if (description != null)
            {
                schedule.Properties.Description = description;
            }

            var scheduleUpdateParameters = new AutomationManagement.Models.ScheduleUpdateParameters
            {
                Name = schedule.Name,
                Properties = new AutomationManagement.Models.ScheduleUpdateProperties
                {
                    Description = schedule.Properties.Description,
                    IsEnabled = schedule.Properties.IsEnabled
                }
            };

            this.automationManagementClient.Schedules.Update(
                automationAccountName,
                scheduleUpdateParameters);

            return this.GetSchedule(automationAccountName, schedule.Name);
        }

        #endregion

        public Credential CreateCredential(string automationAccountName, string name, string userName, string password, string description)
        {
            var credentialCreateParams = new AutomationManagement.Models.CredentialCreateParameters();
            credentialCreateParams.Name = name;
            credentialCreateParams.Properties = new AutomationManagement.Models.CredentialCreateProperties();
            if (description != null) credentialCreateParams.Properties.Description = description;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                new AzureAutomationOperationException(string.Format(Resources.ParameterEmpty, "Username or Password"));
            }

            credentialCreateParams.Properties.UserName = userName;
            credentialCreateParams.Properties.Password = password;

            var createdCredential = this.automationManagementClient.PsCredentials.Create(automationAccountName, credentialCreateParams);

            if (createdCredential == null || createdCredential.StatusCode != HttpStatusCode.Created)
            {
                new AzureAutomationOperationException(string.Format(Resources.AutomationOperationFailed, "Create", "credential", name, automationAccountName));
            }
            return new Credential(automationAccountName, createdCredential.Credential);
        }

        public Credential UpdateCredential(string automationAccountName, string name, string userName, string password, string description)
        {
            var credentialUpdateParams = new AutomationManagement.Models.CredentialUpdateParameters();
            credentialUpdateParams.Name = name;
            credentialUpdateParams.Properties = new AutomationManagement.Models.CredentialUpdateProperties();
            if (description != null) credentialUpdateParams.Properties.Description = description;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                new AzureAutomationOperationException(string.Format(Resources.ParameterEmpty, "Username or Password"));
            }

            credentialUpdateParams.Properties.UserName = userName;
            credentialUpdateParams.Properties.Password = password;

            var credential = this.automationManagementClient.PsCredentials.Update(automationAccountName, credentialUpdateParams);

            if (credential == null || credential.StatusCode != HttpStatusCode.OK)
            {
                new AzureAutomationOperationException(string.Format(Resources.AutomationOperationFailed, "Update", "credential", name, automationAccountName));
            }

            var updatedCredential = this.GetCredential(automationAccountName, name);

            return updatedCredential;
        }

        public Credential GetCredential(string automationAccountName, string name)
        {
            var credential = this.automationManagementClient.PsCredentials.Get(automationAccountName, name).Credential;
            if (credential == null)
            {
                throw new ResourceNotFoundException(typeof(Credential), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, name));
            }

            return new Credential(automationAccountName, credential);
        }

        private Credential CreateCredentialFromCredentialModel(AutomationManagement.Models.Credential credential)
        {
            Requires.Argument("credential", credential).NotNull();

            return new Credential(null, credential);
        }

        public IEnumerable<Credential> ListCredentials(string automationAccountName)
        {
            IList<AutomationManagement.Models.Credential> credentialModels = AutomationManagementClient.ContinuationTokenHandler(
                skipToken =>
                {
                    var response = this.automationManagementClient.PsCredentials.List(automationAccountName);
                    return new ResponseWithSkipToken<AutomationManagement.Models.Credential>(
                        response, response.Credentials);
                });

            return credentialModels.Select(c => new Credential(automationAccountName, c));
        }

        public void DeleteCredential(string automationAccountName, string name)
        {
            var credential = this.automationManagementClient.PsCredentials.Delete(automationAccountName, name);
            if (credential != null && credential.StatusCode != HttpStatusCode.OK)
            {
                new AzureAutomationOperationException(string.Format(Resources.AutomationOperationFailed, "Delete", "Credential", name, automationAccountName));
            }
        }

        public Module CreateModule(string automationAccountName, Uri contentLink, string moduleName, IDictionary<string, string> Tags)
        {
            var createdModule = this.automationManagementClient.Modules.Create(automationAccountName, new AutomationManagement.Models.ModuleCreateParameters()
            {
                Name = moduleName,
                Tags = Tags,
                Properties = new AutomationManagement.Models.ModuleCreateProperties()
                {
                    ContentLink = new AutomationManagement.Models.ContentLink()
                    {
                        Uri = contentLink,
                        ContentHash = null,
                        Version = null
                    }
                },
            });

            if (createdModule == null || createdModule.StatusCode != HttpStatusCode.Created)
            {
                new AzureAutomationOperationException(string.Format(Resources.AutomationOperationFailed, "Create", "Module", moduleName, automationAccountName));
            }

            return new Module(automationAccountName, createdModule.Module);
        }

        public Module GetModule(string automationAccountName, string name)
        {
            var module = this.automationManagementClient.Modules.Get(automationAccountName, name).Module;
            if (module == null)
            {
                throw new ResourceNotFoundException(typeof(Module), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, name));
            }

            return new Module(automationAccountName, module);
        }

        public IEnumerable<Module> ListModules(string automationAccountName)
        {
            IList<AutomationManagement.Models.Module> modulesModels = AutomationManagementClient.ContinuationTokenHandler(
                skipToken =>
                {
                    var response = this.automationManagementClient.Modules.List(automationAccountName, skipToken);
                    return new ResponseWithSkipToken<AutomationManagement.Models.Module>(
                        response, response.Modules);
                });

            return modulesModels.Select(c => new Module(automationAccountName, c));
        }

        public Module UpdateModule(string automationAccountName, IDictionary<string, string> tags, string name, Uri contentLink)
        {
            var existingModule = this.GetModule(automationAccountName, name);

            var moduleUpdateParameters = new AutomationManagement.Models.ModuleUpdateParameters();
            moduleUpdateParameters.Name = name;
            if (tags != null) moduleUpdateParameters.Tags = tags;
            moduleUpdateParameters.Location = existingModule.Location;
            moduleUpdateParameters.Properties = new AutomationManagement.Models.ModuleUpdateProperties()
            {
                ContentLink = new AutomationManagement.Models.ContentLink()
            };

            if (contentLink != null) moduleUpdateParameters.Properties.ContentLink.Uri = contentLink;

            var updatedModule = this.automationManagementClient.Modules.Update(automationAccountName, moduleUpdateParameters);

            if (updatedModule == null || updatedModule.StatusCode != HttpStatusCode.OK)
            {
                new AzureAutomationOperationException(string.Format(Resources.AutomationOperationFailed, "Update", "Module", name, automationAccountName));
            }

            return new Module(automationAccountName, updatedModule.Module);
        }

        public void DeleteModule(string automationAccountName, string name)
        {
            var module = this.automationManagementClient.Modules.Delete(automationAccountName, name);
            if (module != null && module.StatusCode != HttpStatusCode.OK)
            {
                new AzureAutomationOperationException(string.Format(Resources.AutomationOperationFailed, "Delete", "Module", name, automationAccountName));
            }
        }




        public Job GetJob(string automationAccountName, Guid Id)
        {
            var job = this.automationManagementClient.Jobs.Get(automationAccountName, Id).Job;
            if (job == null)
            {
                throw new ResourceNotFoundException(typeof(Job), string.Format(CultureInfo.CurrentCulture, Resources.JobNotFound, Id));
            }

            return new Job(automationAccountName, job);
        }

        public IEnumerable<Job> ListJobsByRunbookName(string automationAccountName, string runbookName, DateTime? startTime, DateTime? endTime)
        {
            IEnumerable<AutomationManagement.Models.Job> jobModels;
            jobModels = AutomationManagementClient.ContinuationTokenHandler(
            skipToken =>
            {
                var response =
                    this.automationManagementClient.Jobs.List(
                        automationAccountName,
                        new AutomationManagement.Models.JobListParameters
                        {
                            StartTime = this.FormatDateTime(startTime.Value),
                            EndTime = this.FormatDateTime(endTime.Value),
                            SkipToken = skipToken,
                            RunbookName = runbookName
                        });
                return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
            });

            return jobModels.Select(jobModel => new Job(automationAccountName, jobModel));
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
                            this.automationManagementClient.Jobs.List(
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
                              this.automationManagementClient.Jobs.List(
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
                            this.automationManagementClient.Jobs.List(
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

            return jobModels.Select(jobModel => new Job(automationAccountName, jobModel));
        }

        public void ResumeJob(string automationAccountName, Guid id)
        {
            this.automationManagementClient.Jobs.Resume(automationAccountName, id);
        }

        public void StopJob(string automationAccountName, Guid id)
        {
            this.automationManagementClient.Jobs.Stop(automationAccountName, id);
        }

        public void SuspendJob(string automationAccountName, Guid id)
        {
            this.automationManagementClient.Jobs.Suspend(automationAccountName, id);
        }
    }
}