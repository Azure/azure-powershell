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

        Schedule GetSchedule(string automationAccountName, string scheduleName);

        IEnumerable<Schedule> ListSchedules(string automationAccountName);

        Runbook GetRunbook(string automationAccountName, string runbookName);

        IEnumerable<Runbook> ListRunbooks(string automationAccountName);

        Runbook CreateRunbookByName(string automationAccountName, string runbookName, string description, IDictionary<string, string> tags);

        Runbook CreateRunbookByPath(string automationAccountName, string runbookPath, string description, IDictionary<string, string> tags);
        
        void DeleteRunbook(string automationAccountName, string runbookName);

        Runbook PublishRunbook(string automationAccountName, string runbookName);

        Runbook UpdateRunbook(string automationAccountName, string runbookName, string description, IDictionary<string, string> tags, bool? logProgress, bool? logVerbose);

        RunbookDefinition UpdateRunbookDefinition(string automationAccountName, string runbookName, string runbookPath, bool overwrite);

        IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookName(string automationAccountName, string runbookName, bool? isDraft);
    }
}