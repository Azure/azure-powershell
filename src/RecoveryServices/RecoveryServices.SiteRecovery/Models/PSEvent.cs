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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Azure Site Recovery events.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASREvent
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASREvent" /> class.
        /// </summary>
        public ASREvent()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASREvent" /> class with required
        ///     parameters.
        /// </summary>
        /// <param name="backendEvent">ASR Event object</param>
        public ASREvent(EventModel backendEvent)
        {
            this.Name = backendEvent.Name;
            this.Id = backendEvent.Id;
            if (backendEvent.Properties != null)
            {
                this.Description = backendEvent.Properties.Description;
                this.EventType = backendEvent.Properties.EventType;
                this.FabricId = backendEvent.Properties.FabricId;
                this.AffectedObjectFriendlyName =
                    backendEvent.Properties.AffectedObjectFriendlyName;
                this.EventCode = backendEvent.Properties.EventCode;
                if (backendEvent.Properties.TimeOfOccurrence != null)
                {
                    this.TimeOfOccurence = backendEvent.Properties.TimeOfOccurrence.Value;
                }
                this.Severity = backendEvent.Properties.Severity;
                this.HealthErrors = this.TranslateHealthErrors(
                    backendEvent.Properties.HealthErrors);
                this.EventSpecificDetails = this.TranslateEventSpecificDetails(
                    backendEvent.Properties.EventSpecificDetails);
                this.ProviderSpecificEventDetails = this.TranslateProviderSpecificEventDetails(
                    backendEvent.Properties.ProviderSpecificDetails);
            }
        }

        /// <summary>
        ///     Gets or sets the event affected object source name.
        /// </summary>
        public string AffectedObjectFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets the event description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets identifier for the type of the event on the source.
        /// </summary>
        public string EventCode { get; set; }

        /// <summary>
        ///     Gets or sets the events specific settings.
        /// </summary>
        public ASREventSpecificDetails EventSpecificDetails { get; set; }

        /// <summary>
        ///     Gets or sets the event type (VmHealth, VMMHealth).
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        ///     Gets or sets the event fabric arm id.
        /// </summary>
        public string FabricId { get; set; }

        /// <summary>
        ///     Gets or sets the errors/warnings associated with the event.
        /// </summary>
        public IList<ASRHealthError> HealthErrors { get; set; }

        /// <summary>
        ///     Gets or sets the event name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the provider specific settings.
        /// </summary>
        public ASREventProviderSpecificDetails ProviderSpecificEventDetails { get; set; }

        /// <summary>
        ///     Gets or sets the severity of the event.
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        ///     Gets or sets the event time.
        /// </summary>
        public DateTime TimeOfOccurence { get; set; }

        /// <summary>
        ///     Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Translate Health errors to Powershell object.
        /// </summary>
        /// <param name="healthErros">Rest API Health error object.</param>
        /// <returns></returns>
        private IList<ASRHealthError> TranslateHealthErrors(IList<HealthError> healthErros)
        {
            IList<ASRHealthError> asrHealthErrors = new List<ASRHealthError>();
            foreach (var healthError in healthErros)
            {
                asrHealthErrors.Add(new ASRHealthError(healthError));
            }

            return asrHealthErrors;
        }

        /// <summary>
        ///     Translate Health errors to Powershell object.
        /// </summary>
        /// <param name="ASREventSpecificDetails">Rest API ASREventSpecificDetails object.</param>
        /// <returns></returns>
        private ASREventSpecificDetails TranslateEventSpecificDetails(
            EventSpecificDetails eventSpecificDetails)
        {
            if (eventSpecificDetails is JobStatusEventDetails)
            {
                return new ASRJobStatusEventDetails((JobStatusEventDetails) eventSpecificDetails);
            }
            return null;
        }

        /// <summary>
        ///     Translate Health errors to Powershell object.
        /// </summary>
        /// <param name="ASREventSpecificDetails">Rest API ASREventSpecificDetails object.</param>
        /// <returns></returns>
        private ASREventProviderSpecificDetails TranslateProviderSpecificEventDetails(
            EventProviderSpecificDetails eventSpecificDetails)
        {
            ASREventProviderSpecificDetails eventProviderDetails = null;
            if (eventSpecificDetails is HyperVReplicaAzureEventDetails)
            {
                eventProviderDetails = new ASRHyperVReplicaAzureEventDetails(
                    (HyperVReplicaAzureEventDetails) eventSpecificDetails);
            }
            else if (eventSpecificDetails is InMageAzureV2EventDetails)
            {
                eventProviderDetails = new ASRInMageAzureV2EventDetails(
                    (InMageAzureV2EventDetails) eventSpecificDetails);
            }
            else if(eventSpecificDetails is HyperVReplica2012EventDetails)
            {
                eventProviderDetails = new ASRHyperVReplica2012EventDetails(
                    (HyperVReplica2012EventDetails) eventSpecificDetails);
            }
            else if(eventSpecificDetails is HyperVReplica2012R2EventDetails)
            {
                eventProviderDetails = new ASRHyperVReplica2012R2EventDetails(
                    (HyperVReplica2012R2EventDetails) eventSpecificDetails);
            }
            else if (eventSpecificDetails is InMageRcmEventDetails)
            {
                eventProviderDetails = new ASRInMageRcmEventDetails(
                    (InMageRcmEventDetails)eventSpecificDetails);
            }
            else if (eventSpecificDetails is InMageRcmFailbackEventDetails)
            {
                eventProviderDetails = new ASRInMageRcmFailbackEventDetails(
                    (InMageRcmFailbackEventDetails)eventSpecificDetails);
            }
            return eventProviderDetails;
        }
    }

    /// <summary>
    ///     The definition of a health object.
    /// </summary>
    public class ASRHealthError
    {
        /// <summary>
        ///     Initializes a new instance of the HealthError class.
        /// </summary>
        /// <param name="healthError">Event health error object.</param>
        public ASRHealthError(HealthError healthError)
        {
            if (healthError.CreationTimeUtc.HasValue)
            {
                this.CreationTimeUtc = healthError.CreationTimeUtc.Value.ToUniversalTime()
                    .ToString("o");
            }

            this.EntityId = healthError.EntityId;
            this.ErrorCode = healthError.ErrorCode;
            this.ErrorLevel = healthError.ErrorLevel;
            this.ErrorMessage = healthError.ErrorMessage;
            this.PossibleCauses = healthError.PossibleCauses;
            this.RecommendedAction = healthError.RecommendedAction;
            this.RecoveryProviderErrorMessage = healthError.RecoveryProviderErrorMessage;
        }

        /// <summary>
        ///     Error creation time (UTC).
        /// </summary>
        public string CreationTimeUtc { get; set; }

        /// <summary>
        ///     ID of the entity.
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        ///     Error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        ///     Level of error.
        /// </summary>
        public string ErrorLevel { get; set; }

        /// <summary>
        ///     Error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Possible causes of error.
        /// </summary>
        public string PossibleCauses { get; set; }

        /// <summary>
        ///     Recommended action to resolve error.
        /// </summary>
        public string RecommendedAction { get; set; }

        /// <summary>
        ///     Recovery Provider error message.
        /// </summary>
        public string RecoveryProviderErrorMessage { get; set; }
    }

    /// <summary>
    ///     Model class for provider specific details for an event.
    /// </summary>
    public abstract class ASREventSpecificDetails
    {
        public ASREventSpecificDetails(EventSpecificDetails eventSpecificDetails)
        {
        }
    }

    /// <summary>
    ///     The definition of a Event Specific Details.
    /// </summary>
    public abstract class ASREventProviderSpecificDetails
    {
        public abstract string ProviderType { get; }
    }

    /// <summary>
    ///     Abstract model class for event details of a HyperVReplica E2E event.
    /// </summary>
    public abstract class ASRHyperVReplicaBaseEventDetails : ASREventProviderSpecificDetails
    {
        /// <summary>
        ///     Gets or sets the container friendly name.
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        ///     Gets or sets the fabric friendly name.
        /// </summary>
        public string FabricName { get; set; }

        /// <summary>
        ///     Gets or sets the remote container name.
        /// </summary>
        public string RemoteContainerName { get; set; }

        /// <summary>
        ///     Gets or sets the remote fabric name.
        /// </summary>
        public string RemoteFabricName { get; set; }
    }

    /// <summary>
    ///     Model class for event details of a HyperVReplica E2A event.
    /// </summary>
    public class ASRHyperVReplicaAzureEventDetails : ASREventProviderSpecificDetails
    {
        /// <summary>
        ///     Converts REST API object to Powershell object.
        /// </summary>
        /// <param name="eventSettings">Internal object for a monitoring event.</param>
        /// <returns>
        ///     REST API object for HyperVReplica E2A event provider specific
        ///     details.
        ///</returns>
        public ASRHyperVReplicaAzureEventDetails(HyperVReplicaAzureEventDetails eventDetails)
        {
            this.ContainerName = eventDetails.ContainerName;
            this.FabricName = eventDetails.FabricName;
            this.RemoteContainerName = eventDetails.RemoteContainerName;
        }

        /// <summary>
        ///     Gets or sets the container friendly name.
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        ///     Gets or sets the fabric friendly name.
        /// </summary>
        public string FabricName { get; set; }

        /// <summary>
        ///     Gets or sets the remote container name.
        /// </summary>
        public string RemoteContainerName { get; set; }

        /// <summary>
        ///     Gets the class type.
        /// </summary>
        public override string ProviderType => "HyperVReplicaAzure";
    }

    /// <summary>
    ///     Model class for event details of a HyperVReplica E2E event.
    /// </summary>
    public class ASRHyperVReplica2012EventDetails : ASRHyperVReplicaBaseEventDetails
    {
        public ASRHyperVReplica2012EventDetails(
            HyperVReplica2012EventDetails eventDetails)
        {
            this.RemoteContainerName = eventDetails.RemoteContainerName;
            this.ContainerName = eventDetails.ContainerName;
            this.FabricName = eventDetails.FabricName;
            this.RemoteFabricName = eventDetails.RemoteFabricName;
        }

        /// <summary>
        ///     Gets the class type.
        /// </summary>
        public override string ProviderType => "HyperVReplica";
    }

    /// <summary>
    ///     Model class for event details of a HyperVReplica blue E2E event.
    /// </summary>
    public class ASRHyperVReplica2012R2EventDetails : ASRHyperVReplicaBaseEventDetails
    {
        public ASRHyperVReplica2012R2EventDetails(
            HyperVReplica2012R2EventDetails eventDetails)
        {
            this.RemoteContainerName = eventDetails.RemoteContainerName;
            this.ContainerName = eventDetails.ContainerName;
            this.FabricName = eventDetails.FabricName;
            this.RemoteFabricName = eventDetails.RemoteFabricName;
        }

        /// <summary>
        ///     Gets the class type.
        /// </summary>
        public override string ProviderType => "HyperVReplicaBlue";
    }

    /// <summary>
    ///     Model class for event details of a VMwareAzureV2 event.
    /// </summary>
    public class ASRInMageAzureV2EventDetails : ASREventProviderSpecificDetails
    {
        /// <summary>
        ///     API object to PowerShell object.
        /// </summary>
        /// <returns>
        ///     REST API object for VMwareAzureV2 event provider specific details.
        ///</returns>
        public ASRInMageAzureV2EventDetails(InMageAzureV2EventDetails inMageAzureV2EventDetails)
        {
            this.Category = inMageAzureV2EventDetails.Category;
            this.Component = inMageAzureV2EventDetails.Component;
            this.CorrectiveAction = inMageAzureV2EventDetails.CorrectiveAction;
            this.Details = inMageAzureV2EventDetails.Details;
            this.EventType = inMageAzureV2EventDetails.EventType;
            this.SiteName = inMageAzureV2EventDetails.SiteName;
            this.Summary = inMageAzureV2EventDetails.Summary;
        }

        /// <summary>
        ///     Gets or sets InMage Event Category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        ///     Gets or sets InMage Event Component.
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        ///     Gets or sets Corrective Action string for the event.
        /// </summary>
        public string CorrectiveAction { get; set; }

        /// <summary>
        ///     Gets or sets InMage Event Details.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        ///     Gets or sets InMage Event type.
        ///     Takes one of the values of <see cref="InMageMonitoringEventType" />.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        ///     Gets or sets VMware Site name.
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        ///     Gets or sets InMage Event Summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        ///     Gets the class type.
        /// </summary>
        public override string ProviderType => "InMageAzureV2";
    }

    /// <summary>
    ///     Model class for event details of an InMageRcm event.
    /// </summary>
    public class ASRInMageRcmEventDetails : ASREventProviderSpecificDetails
    {
        /// <summary>
        ///     API object to PowerShell object.
        /// </summary>
        /// <returns>
        ///     REST API object for InMageRcm event provider specific details.
        ///</returns>
        public ASRInMageRcmEventDetails(InMageRcmEventDetails inMageRcmEventDetails)
        {
            this.ProtectedItemName = inMageRcmEventDetails.ProtectedItemName;
            this.VmName = inMageRcmEventDetails.VmName;
            this.LatestAgentVersion = inMageRcmEventDetails.LatestAgentVersion;
            this.JobId = inMageRcmEventDetails.JobId;
            this.FabricName = inMageRcmEventDetails.FabricName;
            this.ApplianceName = inMageRcmEventDetails.ApplianceName;
            this.ServerType = inMageRcmEventDetails.ServerType;
            this.ComponentDisplayName = inMageRcmEventDetails.ComponentDisplayName;
        }

        /// <summary>
        ///     Gets or sets the protected item name.
        /// </summary>
        public string ProtectedItemName { get; set; }

        /// <summary>
        ///     Gets or sets the VM name.
        /// </summary>
        public string VmName { get; set; }

        /// <summary>
        ///     Gets or sets the latest agent version.
        /// </summary>
        public string LatestAgentVersion { get; set; }

        /// <summary>
        ///     Gets or sets the job Id.
        /// </summary>
        public string JobId { get; set; }

        /// <summary>
        ///     Gets or sets the fabric name.
        /// </summary>
        public string FabricName { get; set; }

        /// <summary>
        ///     Gets or sets the appliance name.
        /// </summary>
        public string ApplianceName { get; set; }

        /// <summary>
        ///     Gets or sets the server type.
        /// </summary>
        public string ServerType { get; set; }

        /// <summary>
        ///     Gets or sets the component display name.
        /// </summary>
        public string ComponentDisplayName { get; set; }

        /// <summary>
        ///     Gets the class type.
        /// </summary>
        public override string ProviderType => "InMageRcm";
    }

    /// <summary>
    ///     Model class for event details of an InMageRcmFailback event.
    /// </summary>
    public class ASRInMageRcmFailbackEventDetails : ASREventProviderSpecificDetails
    {
        /// <summary>
        ///     API object to PowerShell object.
        /// </summary>
        /// <returns>
        ///     REST API object for InMageRcmFailback event provider specific details.
        ///</returns>
        public ASRInMageRcmFailbackEventDetails(InMageRcmFailbackEventDetails inMageRcmFailbackEventDetails)
        {
            this.ProtectedItemName = inMageRcmFailbackEventDetails.ProtectedItemName;
        }

        /// <summary>
        ///     Gets or sets the protected item name.
        /// </summary>
        public string ProtectedItemName { get; set; }

        /// <summary>
        ///     Gets the class type.
        /// </summary>
        public override string ProviderType => "InMageRcmFailback";
    }

    /// <summary>
    ///     Model class for event details of a job status event.
    /// </summary>
    public class ASRJobStatusEventDetails : ASREventSpecificDetails
    {
        /// <summary>
        ///     Converts internal object to REST API object.
        /// </summary>
        /// <param name="jobStatusEventDetails">Internal object for a monitoring event.</param>
        /// <returns>REST API object for Job status event specific details.</returns>
        public ASRJobStatusEventDetails(JobStatusEventDetails jobStatusEventDetails) : base(
            jobStatusEventDetails)
        {
            this.JobId = jobStatusEventDetails.JobId;
            this.JobFriendlyName = jobStatusEventDetails.JobFriendlyName;
            this.JobStatus = jobStatusEventDetails.JobStatus;
            this.AffectedObjectType = jobStatusEventDetails.AffectedObjectType;
        }

        /// <summary>
        ///     Gets or sets AffectedObjectType for the event.
        /// </summary>
        public string AffectedObjectType { get; set; }

        /// <summary>
        ///     Gets or sets JobName for the Event.
        /// </summary>
        public string JobFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets job arm id for the event.
        /// </summary>
        public string JobId { get; set; }

        /// <summary>
        ///     Gets or sets JobStatus for the  Event.
        /// </summary>
        public string JobStatus { get; set; }
    }
}
