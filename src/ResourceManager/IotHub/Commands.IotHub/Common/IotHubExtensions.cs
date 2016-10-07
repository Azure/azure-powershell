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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.IotHub.Models;

    public static class IotHubExtensions
    {
        
        public static PSIotHub ToPSIotHub(this IotHubDescription iotHubDescription)
        {
            return new PSIotHub()
            {
                Subscriptionid = iotHubDescription.Subscriptionid,
                Resourcegroup = iotHubDescription.Resourcegroup,
                Etag = iotHubDescription.Etag,
                Sku = new PSIotHubSkuInfo()
                {
                    Name = (PSIotHubSku)Enum.Parse(typeof(PSIotHubSku), iotHubDescription.Sku.Name),
                    Capacity = (long)iotHubDescription.Sku.Capacity
                },
                Properties = new PSIotHubProperties()
                {
                    AuthorizationPolicies = ToPSSharedAccessSignatureAuthorizationRule(iotHubDescription.Properties.AuthorizationPolicies),
                    HostName = iotHubDescription.Properties.HostName,
                    EventHubEndpoints = ToPSEventHubEndpoints(iotHubDescription.Properties.EventHubEndpoints),
                    StorageEndpoints = ToPSStorageEndpoints(iotHubDescription.Properties.StorageEndpoints),
                    MessagingEndpoints = ToPSMessagingEndpoints(iotHubDescription.Properties.MessagingEndpoints),
                    EnableFileUploadNotifications = iotHubDescription.Properties.EnableFileUploadNotifications,
                    CloudToDevice = new PSCloudToDeviceProperties()
                    {
                        DefaultTtlAsIso8601 = iotHubDescription.Properties.CloudToDevice.DefaultTtlAsIso8601,
                        Feedback = new PSFeedbackProperties()
                        {
                            LockDurationAsIso8601 = iotHubDescription.Properties.CloudToDevice.Feedback.LockDurationAsIso8601,
                            MaxDeliveryCount = iotHubDescription.Properties.CloudToDevice.Feedback.MaxDeliveryCount,
                            TtlAsIso8601 = iotHubDescription.Properties.CloudToDevice.Feedback.TtlAsIso8601
                        },
                        MaxDeliveryCount = iotHubDescription.Properties.CloudToDevice.MaxDeliveryCount
                    },
                    Comments = iotHubDescription.Properties.Comments,
                    OperationsMonitoringProperties = new PSOperationsMonitoringProperties()
                    {
                        OperationMonitoringEvents = ToPSOperationMonitoringEvents(iotHubDescription.Properties.OperationsMonitoringProperties.Events)
                    },
                    Features = (PSCapabilities)Enum.Parse(typeof(PSCapabilities), iotHubDescription.Properties.Features),
                }
            };
        }

        public static IList<PSSharedAccessSignatureAuthorizationRule> ToPSSharedAccessSignatureAuthorizationRule(IList<SharedAccessSignatureAuthorizationRule> authorizationPolicies)
        {
            var psAuthorizationPolicies = new List<PSSharedAccessSignatureAuthorizationRule>();

            foreach (var authorizationPolicy in authorizationPolicies)
            {
                psAuthorizationPolicies.Add(
                    new PSSharedAccessSignatureAuthorizationRule()
                    {
                        KeyName = authorizationPolicy.KeyName,
                        PrimaryKey = authorizationPolicy.PrimaryKey,
                        SecondaryKey = authorizationPolicy.SecondaryKey,
                        Rights = ToPSAccessRights((AccessRights)authorizationPolicy.Rights)
                    });
            }

            return psAuthorizationPolicies;
        }

        public static IDictionary<string, PSEventHubProperties> ToPSEventHubEndpoints(IDictionary<string, EventHubProperties> eventHubEndpoints)
        {
            var psEventHubEndpoints = new Dictionary<string, PSEventHubProperties>();

            foreach (var eventHubEndpoint in eventHubEndpoints)
            {
                var eventHubProperties = (EventHubProperties)eventHubEndpoint.Value;

                psEventHubEndpoints.Add(
                    eventHubEndpoint.Key,
                    new PSEventHubProperties()
                    {
                        RetentionTimeInDays = eventHubProperties.RetentionTimeInDays,
                        PartitionCount = eventHubProperties.PartitionCount,
                        PartitionIds = eventHubProperties.PartitionIds,
                        Path = eventHubProperties.Path,
                        Endpoint = eventHubProperties.Endpoint,
                        InternalAuthorizationPolicies = ToPSSharedAccessAuthorizationRule(eventHubProperties.InternalAuthorizationPolicies),
                        AuthorizationPolicies = ToPSSharedAccessAuthorizationRule(eventHubProperties.AuthorizationPolicies)
                    });
            }

            return psEventHubEndpoints;
        }

        public static IList<PSSharedAccessAuthorizationRule> ToPSSharedAccessAuthorizationRule(IList<SharedAccessAuthorizationRule> authPolicies)
        {
            var psAuthPolicies = new List<PSSharedAccessAuthorizationRule>();

            foreach (var authPolicy in authPolicies)
            {
                psAuthPolicies.Add(
                    new PSSharedAccessAuthorizationRule()
                    {
                        KeyName = authPolicy.KeyName,
                        PrimaryKey = authPolicy.PrimaryKey,
                        IssuerName = authPolicy.IssuerName,
                        SecondaryKey = authPolicy.SecondaryKey,
                        ClaimType = authPolicy.ClaimType,
                        ClaimValue = authPolicy.ClaimValue,
                        Rights = ToPSSBAccessRights(authPolicy.Rights),
                        CreatedTime = authPolicy.CreatedTime,
                        ModifiedTime = authPolicy.ModifiedTime,
                        Revision = authPolicy.Revision
                    });
            }

            return psAuthPolicies;
        }

        public static IList<PSSBAccessRights> ToPSSBAccessRights(IList<SBAccessRights?> sbAccessRights)
        {
            var psSBAccessRights = new List<PSSBAccessRights>();

            foreach (var sbAccessRight in sbAccessRights)
            {
                psSBAccessRights.Add((PSSBAccessRights)Enum.Parse(typeof(PSSBAccessRights), sbAccessRight.ToString()));
            }

            return psSBAccessRights;
        }

        public static IDictionary<string, PSStorageEndpointProperties> ToPSStorageEndpoints(IDictionary<string, StorageEndpointProperties> storageEndpoints)
        {
            var psStorageEndpoints = new Dictionary<string, PSStorageEndpointProperties>();

            foreach (var storageEndpoint in storageEndpoints)
            {
                var storageEndpointProperty = storageEndpoint.Value;

                psStorageEndpoints.Add(
                    storageEndpoint.Key,
                    new PSStorageEndpointProperties()
                    {
                        SasTtlAsIso8601 = storageEndpointProperty.SasTtlAsIso8601,
                        ConnectionString = storageEndpointProperty.ConnectionString,
                        ContainerName = storageEndpointProperty.ContainerName
                    });
            }

            return psStorageEndpoints;
        }

        public static IDictionary<string, PSMessagingEndpointProperties> ToPSMessagingEndpoints(IDictionary<string, MessagingEndpointProperties> messagingEndpoints)
        {
            var psMessagingEndpoints = new Dictionary<string, PSMessagingEndpointProperties>();

            foreach (var messagingEndpoint in messagingEndpoints)
            {
                var messagingEndpointProperties = messagingEndpoint.Value;
                psMessagingEndpoints.Add(
                    messagingEndpoint.Key,
                    new PSMessagingEndpointProperties()
                    {
                        LockDurationAsIso8601 = messagingEndpointProperties.LockDurationAsIso8601,
                        MaxDeliveryCount = messagingEndpointProperties.MaxDeliveryCount,
                        TtlAsIso8601 = messagingEndpointProperties.TtlAsIso8601
                    });
            }

            return psMessagingEndpoints;
        }

        public static IDictionary<PSDiagnosticCategory, PSOperationMonitoringLevel> ToPSOperationMonitoringEvents(IDictionary<string, string> operationMonitoringEvents)
        {
            var psOperationMonitoringEvents = new Dictionary<PSDiagnosticCategory, PSOperationMonitoringLevel>();
            
            foreach (var operationMonitoringEvent in operationMonitoringEvents)
            {
                PSDiagnosticCategory key = (PSDiagnosticCategory)Enum.Parse(typeof(PSDiagnosticCategory), operationMonitoringEvent.Key);
                PSOperationMonitoringLevel value = (PSOperationMonitoringLevel)Enum.Parse(typeof(PSOperationMonitoringLevel), operationMonitoringEvent.Value);
                psOperationMonitoringEvents.Add(key, value);
            }

            return psOperationMonitoringEvents;
        }

        public static PSAccessRights ToPSAccessRights(AccessRights rights)
        {
            switch (rights)
            {
                case AccessRights.RegistryRead:
                    return PSAccessRights.RegistryRead;
                case AccessRights.RegistryWrite:
                    return PSAccessRights.RegistryWrite;
                case AccessRights.ServiceConnect:
                    return PSAccessRights.ServiceConnect;
                case AccessRights.DeviceConnect:
                    return PSAccessRights.DeviceConnect;
                case AccessRights.RegistryReadRegistryWrite:
                    return PSAccessRights.RegistryRead | PSAccessRights.RegistryWrite;
                case AccessRights.RegistryReadServiceConnect:
                    return PSAccessRights.RegistryRead | PSAccessRights.ServiceConnect;
                case AccessRights.RegistryReadDeviceConnect:
                    return PSAccessRights.RegistryRead | PSAccessRights.DeviceConnect;
                case AccessRights.RegistryWriteServiceConnect:
                    return PSAccessRights.RegistryWrite | PSAccessRights.ServiceConnect;
                case AccessRights.RegistryWriteDeviceConnect:
                    return PSAccessRights.RegistryWrite | PSAccessRights.DeviceConnect;
                case AccessRights.ServiceConnectDeviceConnect:
                    return PSAccessRights.ServiceConnect | PSAccessRights.DeviceConnect;
                case AccessRights.RegistryReadRegistryWriteServiceConnect:
                    return PSAccessRights.RegistryRead | PSAccessRights.RegistryWrite | PSAccessRights.ServiceConnect;
                case AccessRights.RegistryReadRegistryWriteDeviceConnect:
                    return PSAccessRights.RegistryRead | PSAccessRights.RegistryWrite | PSAccessRights.DeviceConnect;
                case AccessRights.RegistryReadServiceConnectDeviceConnect:
                    return PSAccessRights.RegistryRead | PSAccessRights.ServiceConnect | PSAccessRights.DeviceConnect;
                case AccessRights.RegistryWriteServiceConnectDeviceConnect:
                    return PSAccessRights.RegistryWrite | PSAccessRights.ServiceConnect | PSAccessRights.DeviceConnect;
                case AccessRights.RegistryReadRegistryWriteServiceConnectDeviceConnect:
                    return PSAccessRights.RegistryRead | PSAccessRights.RegistryWrite | PSAccessRights.ServiceConnect | PSAccessRights.DeviceConnect;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
