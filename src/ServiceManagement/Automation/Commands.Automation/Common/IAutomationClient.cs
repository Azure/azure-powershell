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

        Schedule CreateSchedule(string automationAccountName, Schedule schedule);

        void DeleteSchedule(string automationAccountName, string scheduleName);

        Schedule GetSchedule(string automationAccountName, string scheduleName);

        IEnumerable<Schedule> ListSchedules(string automationAccountName);

        Schedule UpdateSchedule(string automationAccountName, string scheduleName, bool? isEnabled, string description);

        Runbook GetRunbook(string automationAccountName, string runbookName);

        IEnumerable<Runbook> ListRunbooks(string automationAccountName);
    }
}