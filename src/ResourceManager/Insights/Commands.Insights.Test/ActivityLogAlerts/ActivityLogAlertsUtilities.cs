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

using System.Collections.Generic;
using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.Test.ActivityLogAlerts
{
    public static class ActivityLogAlertsUtilities
    {
        public static ActivityLogAlertActionGroup CreateActionGroup(string id, Dictionary<string, string> webhooks)
        {
            return new ActivityLogAlertActionGroup
            {
                ActionGroupId = id,
                WebhookProperties = webhooks
            };
        }

        public static ActivityLogAlertLeafCondition CreateLeafCondition(string field, string equals)
        {
            return new ActivityLogAlertLeafCondition
            {
                Field = field,
                Equals = equals
            };
        }

        public static ActivityLogAlertResource CreateActivityLogAlertResource(string location, string name)
        {
            return new ActivityLogAlertResource(
                location: location,
                name: name,
                condition: new ActivityLogAlertAllOfCondition(
                    new List<ActivityLogAlertLeafCondition>
                    {
                        CreateLeafCondition("field", "equals")
                    }),
                scopes: new List<string> { "scope1" },
                actions: new ActivityLogAlertActionList(
                    new List<ActivityLogAlertActionGroup>
                    {
                        CreateActionGroup(
                            id: "actionGrp1",
                            webhooks: new Dictionary<string, string>())
                    }));
        }
    }
}
