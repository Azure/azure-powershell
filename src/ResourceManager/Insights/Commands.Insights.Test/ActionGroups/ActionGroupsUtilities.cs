// ---------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Insights.Test.ActionGroups
{
    using System.Collections.Generic;

    using Microsoft.Azure.Management.Monitor.Management.Models;

    public class ActionGroupsUtilities
    {
        public static EmailReceiver CreateEmailReceiver(
            string name,
            string emailAddress)
        {
            return new EmailReceiver { Name = name, EmailAddress = emailAddress };
        }

        public static SmsReceiver CreateSmsReceiver(
            string name,
            string phoneNumber)
        {
            return new SmsReceiver { Name = name, CountryCode = "1", PhoneNumber = phoneNumber };
        }

        public static WebhookReceiver CreateWebhookReceiver(
            string name,
            string serviceUri)
        {
            return new WebhookReceiver { Name = name, ServiceUri = serviceUri };
        }

        public static ActionGroupResource CreateActionGroupResource(
            string name,
            string shortName)
        {
            return new ActionGroupResource(
                location: "Global",
                enabled: true,
                name: name,
                groupShortName: shortName,
                id:
                    $"/subscriptions/7de05d20-f39f-44d8-83ca-e7d2f12118b0/resourceGroups/testResourceGroup/providers/microsoft.insights/actionGroups/{name}",
                emailReceivers: new List<EmailReceiver> { CreateEmailReceiver("email", "test@email.com") },
                smsReceivers: new List<SmsReceiver> { CreateSmsReceiver("sms", "4254251234") },
                webhookReceivers: new List<WebhookReceiver> { CreateWebhookReceiver("webhook", "http://test.com") });
        }
    }
}