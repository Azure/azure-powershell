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
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.Insights.OutputClasses;
    using Microsoft.Azure.Management.Monitor.Models;

    public class ActionGroupsUtilities
    {
        public const string emptyString = "";
        public const bool defaultBoolValue = false;
        public static EmailReceiver CreateEmailReceiver(
            string name,
            string emailAddress,
            bool useCommonAlertSchema = defaultBoolValue)   // not a mandatory field in powershell commandlet - defaults to false if not mentioned
        {
            return new EmailReceiver { Name = name, EmailAddress = emailAddress, UseCommonAlertSchema = useCommonAlertSchema };
        }

        public static SmsReceiver CreateSmsReceiver(
            string name,
            string phoneNumber)
        {
            return new SmsReceiver { Name = name, CountryCode = "1", PhoneNumber = phoneNumber };
        }

        public static WebhookReceiver CreateWebhookReceiver(
            string name,
            string serviceUri,
            bool useCommonAlertSchema = defaultBoolValue,
            bool? useAadAuth = defaultBoolValue,
            string objectId = emptyString,
            string identifierUri = emptyString,
            string tenantId = emptyString
            )
        {
            if(useAadAuth?? true)  // if aad auth is enabled , then following fields are mandatory.
            {
                if((string.IsNullOrWhiteSpace(objectId))
                    ||(string.IsNullOrWhiteSpace(identifierUri))
                        || (string.IsNullOrWhiteSpace(tenantId)))
                    {
                        throw new ArgumentException("When use AadAuth is set for web hook receiverm then objectid ,identifierUri and tenantId are expected ");
                    }
            }
            return new WebhookReceiver {
                                Name = name,
                                ServiceUri = serviceUri,
                                UseCommonAlertSchema = useCommonAlertSchema,
                                UseAadAuth = useAadAuth,
                                ObjectId = objectId,
                                IdentifierUri = identifierUri,
                                TenantId = tenantId
                                
            };
        }

        public static ItsmReceiver CreateItsmReceiver(
            string name,
            string workspaceId, 
            string connectionId,
            string ticketConfiguration,
            string region
            )
        {
            return new ItsmReceiver
            {
                Name = name,
                WorkspaceId = workspaceId,
                ConnectionId = connectionId,
                TicketConfiguration = ticketConfiguration,
                Region = region
            };
        }

        public static VoiceReceiver CreateVoiceReceiver(
            string name, 
            string countryCode,
            string phoneNumber)
        {
            return new VoiceReceiver
            {
                Name = name,
                CountryCode = countryCode,
                PhoneNumber = phoneNumber
            }; 
        }

        public static ArmRoleReceiver CreateArmRoleReceiver(
            string name,
            string roleId, 
            bool useCommonAlertSchema = defaultBoolValue)
        {
            return new ArmRoleReceiver
            {
                Name = name,
                RoleId = roleId,
                UseCommonAlertSchema = useCommonAlertSchema
            };
        }

        public static AzureFunctionReceiver CreateAzureFunctionReceiver(
            string name,
            string functionAppResourceId,
            string functionName,
            string httpTriggerUrl,
            bool useCommonAlertSchema = defaultBoolValue)
        {
            return new AzureFunctionReceiver
            {
                Name = name,
                FunctionAppResourceId = functionAppResourceId,
                FunctionName = functionName,
                HttpTriggerUrl = httpTriggerUrl,
                UseCommonAlertSchema = useCommonAlertSchema
            };
        }

        public static LogicAppReceiver CreateLogicAppReceiver(
            string name , 
            string resourceId,
            string callbackUrl,
            bool useCommonAlertSchema = defaultBoolValue)
        {
            return new LogicAppReceiver
            {
                Name = name,
                ResourceId = resourceId,
                CallbackUrl = callbackUrl,
                UseCommonAlertSchema = useCommonAlertSchema
            };
        }

        public static AutomationRunbookReceiver CreateAutomationRunbookReceiver(
            string name , 
            string automationAccountId,
            string runbookName,
            string webhookResourceId,
            bool isGlobalRunBook,
            string serviceUri,
            bool useCommonAlertSchema = defaultBoolValue)
        {
            return new AutomationRunbookReceiver
            {
                Name = name,
                AutomationAccountId = automationAccountId,
                RunbookName = runbookName,
                WebhookResourceId = webhookResourceId,
                IsGlobalRunbook = isGlobalRunBook,
                UseCommonAlertSchema = useCommonAlertSchema,
                ServiceUri = serviceUri
            };
        }

        public static AzureAppPushReceiver CreateAzureAppPushReceiver(
            string name,
            string emailAddress
            )
        {
            return new AzureAppPushReceiver
            {
                Name = name,
                EmailAddress = emailAddress
            };
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

                emailReceivers: new List<EmailReceiver>
                {
                    CreateEmailReceiver("email", "test@email.com") ,
                    CreateEmailReceiver("email1", "email1@email1.com", true) ,
                    CreateEmailReceiver("email2", "email2@email2.com", false)
                },

                smsReceivers: new List<SmsReceiver> { CreateSmsReceiver("sms", "4254251234") },

                webhookReceivers: new List<WebhookReceiver>
                {
                    CreateWebhookReceiver("webhook", "http://test.com"),
                    CreateWebhookReceiver("webhook1", "http://test1.com", true),
                    CreateWebhookReceiver("webhook2", "http://test2.com", true,false),
                    CreateWebhookReceiver("webhook3", "http://test3.com", true,true,"someObjectId","someIdentifierId", "someTenantId" )
                },

                itsmReceivers: new List<ItsmReceiver>
                { CreateItsmReceiver("itsm", "someWorkspaceId", "someConnectionId", "sometickerConfiguration", "someRegion") },

                voiceReceivers: new List<VoiceReceiver>
                { CreateVoiceReceiver("voice", "someCountryCode", "somePhoeNumber") },

                armRoleReceivers: new List<ArmRoleReceiver>
                {
                    CreateArmRoleReceiver("armRole", "someRoleId"),
                    CreateArmRoleReceiver("armRole1", "someRoleId1", true)
                },
                
                azureFunctionReceivers: new List<AzureFunctionReceiver>
                {
                    CreateAzureFunctionReceiver("azureFunctionReceiver","somefuncappresourceId","somefunctionName","some trigeerURl"),
                    CreateAzureFunctionReceiver("azureFunctionReceiver1","somefuncappresourceId1","somefunctionName2","some trigeerURl2",true)
                },

                logicAppReceivers: new List<LogicAppReceiver>
                {
                    CreateLogicAppReceiver("logicAppReceveir","someresourceId","someCallback"),
                     CreateLogicAppReceiver("logicAppReceveir1","someresourceId1","someCallback1",true),
                },

                automationRunbookReceivers: new List<AutomationRunbookReceiver>
                {
                    CreateAutomationRunbookReceiver("runbookReceiver","someAutomationId","someRunbook","somewebhookresourceId",false,"someServiceUri"),
                    CreateAutomationRunbookReceiver("runbookReceiver1","someAutomationId1","someRunbook1","somewebhookresourceId1",true,"someServiceUri1",true),
                },

                 azureAppPushReceivers: new List<AzureAppPushReceiver>
                 {
                    CreateAzureAppPushReceiver("apppushreceiver","someEmailAddress")
                 }
                );
        }
    }
}