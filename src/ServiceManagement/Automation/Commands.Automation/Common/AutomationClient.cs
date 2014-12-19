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
                    var response = this.automationManagementClient.Schedules.List(
                        automationAccountName, skipToken);
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

        public IEnumerable<JobStream> GetJobStream(string automationAccountName, Guid jobId, DateTime? time, string streamType)
        {
            var listParams = new AutomationManagement.Models.JobStreamListParameters();
            
            if (time.HasValue)
            {
                listParams.Time = time.Value.ToUniversalTime().ToString();
            }

            if (streamType != null)
            {
                listParams.StreamType = streamType;
            }

            var jobStreams = this.automationManagementClient.JobStreams.List(automationAccountName, jobId, listParams).JobStreams;

            return jobStreams.Select(this.CreateJobStreamFromJobStreamModel);
        }

        public Variable SetVariable(string automationAccountName, Variable variable)
        {
            bool variableExists = true;

            try
            {
                this.GetVariable(automationAccountName, variable.Name);
            }
            catch (ResourceNotFoundException)
            {
                variableExists = false;
            }

            if (variableExists)
            {
                if (variable.IsEncrypted)
                {
                    var updateParams = new AutomationManagement.Models.EncryptedVariableUpdateParameters()
                    {
                        Name = variable.Name,
                        Properties = new AutomationManagement.Models.EncryptedVariableUpdateProperties()
                        {
                            Value = variable.Value,
                            Description = variable.Description
                        }
                    };

                    this.automationManagementClient.EncryptedVariables.Update(automationAccountName, updateParams);
                }
                else
                {
                    var updateParams = new AutomationManagement.Models.VariableUpdateParameters()
                    {
                        Name = variable.Name,
                        Properties = new AutomationManagement.Models.VariableUpdateProperties()
                        {
                            Value = variable.Value,
                            Description = variable.Description
                        }
                    };

                    this.automationManagementClient.Variables.Update(automationAccountName, updateParams);
                }

                return this.GetVariable(automationAccountName, variable.Name);
            }
            else
            {
                if (variable.IsEncrypted)
                {
                    var createParams = new AutomationManagement.Models.EncryptedVariableCreateParameters()
                    {
                        Name = variable.Name,
                        Properties = new AutomationManagement.Models.EncryptedVariableCreateProperties()
                        {
                            Value = variable.Value,
                            Description = variable.Description
                        }
                    };

                    var sdkCreatedVariable = this.automationManagementClient.EncryptedVariables.Create(automationAccountName, createParams).EncryptedVariable;

                    if (sdkCreatedVariable == null)
                    {
                        // TODO:  throw the right error here
                        throw new ArgumentNullException();
                    }

                    return new Variable(sdkCreatedVariable);
                }
                else
                {
                    var createParams = new AutomationManagement.Models.VariableCreateParameters()
                    {
                        Name = variable.Name,
                        Properties = new AutomationManagement.Models.VariableCreateProperties()
                        {
                            Value = variable.Value,
                            Description = variable.Description
                        }
                    };

                    var sdkCreatedVariable = this.automationManagementClient.Variables.Create(automationAccountName, createParams).Variable;

                    if (sdkCreatedVariable == null)
                    {
                        // TODO:  throw the right error here
                        throw new ArgumentNullException();
                    }

                    return new Variable(sdkCreatedVariable);
                }
            }
         
        }

        public Variable GetVariable(string automationAccountName, string name)
        {
            var sdkEncryptedVariable = this.automationManagementClient.EncryptedVariables.Get(
                automationAccountName, name).EncryptedVariable;

            if (sdkEncryptedVariable != null)
            {
                return new Variable(sdkEncryptedVariable);
            }
            
            var sdkVarible = this.automationManagementClient.Variables.Get(automationAccountName, name).Variable;

            if (sdkVarible != null)
            {
                return new Variable(sdkVarible);
            }

            throw new ResourceNotFoundException(typeof(Variable), string.Format(CultureInfo.CurrentCulture, Resources.VariableNotFound, name));
        }

        public IEnumerable<Variable> ListVariables(string automationAccountName)
        {
            IList<AutomationManagement.Models.Variable> variables = AutomationManagementClient.ContinuationTokenHandler(
               skipToken =>
               {
                   var response = this.automationManagementClient.Variables.List(
                       automationAccountName);
                   return new ResponseWithSkipToken<AutomationManagement.Models.Variable>(
                       response, response.Variables);
               });

            var result = variables.Select(this.CreateVariableFromVariableModel).ToList();

            IList<AutomationManagement.Models.EncryptedVariable> encryptedVariables = AutomationManagementClient.ContinuationTokenHandler(
               skipToken =>
               {
                   var response = this.automationManagementClient.EncryptedVariables.List(
                       automationAccountName);
                   return new ResponseWithSkipToken<AutomationManagement.Models.EncryptedVariable>(
                       response, response.EncryptedVariables);
               });

            result.AddRange(encryptedVariables.Select(this.CreateVariableFromVariableModel).ToList());

            return result;
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
        private JobStream CreateJobStreamFromJobStreamModel(AutomationManagement.Models.JobStream jobStream)
        {
            Requires.Argument("jobStream", jobStream).NotNull();
            return new JobStream(jobStream);
        }

        private Variable CreateVariableFromVariableModel(AutomationManagement.Models.Variable variable)
        {
            Requires.Argument("variable", variable).NotNull();

            return new Variable(variable);
        }

        private Variable CreateVariableFromVariableModel(AutomationManagement.Models.EncryptedVariable variable)
        {
            Requires.Argument("variable", variable).NotNull();

            return new Variable(variable);
        }


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
    }
}