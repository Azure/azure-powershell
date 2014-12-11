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