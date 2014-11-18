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
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Hash functions which can be used to calculate CIK HMAC.
    /// </summary>
    public enum CikSupportedHashFunctions
    {
        /// <summary>
        /// Represents a HMACSHA256 hash function.
        /// </summary>
        HMACSHA256,

        /// <summary>
        /// Represents a HMACSHA384 hash function.
        /// </summary>
        HMACSHA384,

        /// <summary>
        /// Represents a HMACSHA512 hash function.
        /// </summary>
        HMACSHA512
    }

    /// <summary>
    /// Error contract returned when some exception occurs in ASR REST API.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error" /> class.
        /// </summary>
        public Error()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Error" /> class with required parameters.
        /// </summary>
        /// <param name="se">Service Error</param>
        public Error(ServiceError se)
        {
            this.ClientRequestId = se.ActivityId;
            this.Code = se.Code;
            this.Message = se.Message;
            this.PossibleCauses = se.PossibleCauses;
            this.RecommendedAction = se.RecommendedAction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Error" /> class.
        /// </summary>
        /// <param name="errorCode">Service generated error code.</param>
        /// <param name="message">Error message.</param>
        /// <param name="possibleCauses">Possible causes of the error.</param>
        /// <param name="recommendedAction">Recommended action to resolve the error.</param>
        /// <param name="activityId">ActivityId in which error occurred.</param>
        public Error(
            string errorCode,
            string message,
            string possibleCauses,
            string recommendedAction,
            string activityId)
        {
            this.Code = errorCode;
            this.Message = message;
            this.PossibleCauses = possibleCauses;
            this.RecommendedAction = recommendedAction;
            this.ClientRequestId = activityId;
        }

        /// <summary>
        /// Gets or sets error code.
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets error message.
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets possible causes of error.
        /// </summary>
        [DataMember]
        public string PossibleCauses { get; set; }

        /// <summary>
        /// Gets or sets recommended action to resolve error.
        /// </summary>
        [DataMember]
        public string RecommendedAction { get; set; }

        /// <summary>
        /// Gets or sets client request Id.
        /// </summary>
        [DataMember(Name = "ActivityId")]
        public string ClientRequestId { get; set; }
    }

    /// <summary>
    /// CIK token details.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract]
    public class CikTokenDetails
    {
        /// <summary>
        /// Gets or sets the timestamp before which the token is not valid.
        /// </summary>
        [DataMember]
        public DateTime NotBeforeTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the timestamp after which the token is not valid.
        /// </summary>
        [DataMember]
        public DateTime NotAfterTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the client request Id for the operation linked with this CIK token.
        /// </summary>
        [DataMember]
        public string ClientRequestId { get; set; }

        /// <summary>
        /// Gets or sets Hash function used to calculate the HMAC.
        /// </summary>
        [DataMember]
        public string HashFunction { get; set; }

        /// <summary>
        /// Gets or sets the HMAC generated using the CIK key.
        /// </summary>
        [DataMember]
        public string Hmac { get; set; }

        /// <summary>
        /// Gets or sets Data contract version.
        /// </summary>
        [DataMember(Name = "Version")]
        public Version Version { get; set; }

        /// <summary>
        /// Gets or sets property bag. This property bag is introduced to support addition of any 
        /// new property in data contract without breaking the existing clients.
        /// If any new property needs to be introduced in the contract, 
        /// add a key value pair for it in this dictionary. 
        /// </summary>
        [DataMember]
        public Dictionary<string, object> PropertyBag { get; set; }

        /// <summary>
        /// Converts the object into string.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NotBeforeTimestamp: " + this.NotBeforeTimestamp);
            sb.AppendLine("NotAfterTimestamp: " + this.NotAfterTimestamp);
            sb.AppendLine("ClientRequestId: " + this.ClientRequestId);
            sb.AppendLine("Hmac: " + this.Hmac);
            return sb.ToString();
        }
    }

    /// <summary>
    /// Possible states of the Job.
    /// </summary>
    public class JobStatus : TaskStatus
    {
    }

    /// <summary>
    /// Possible states of the Task.
    /// </summary>
    public class TaskStatus
    {
        /// <summary>
        /// TaskStatus NotStarted value.
        /// </summary>
        public static readonly string NotStarted = "NotStarted";

        /// <summary>
        /// Status InProgress value. 
        /// </summary>
        public static readonly string InProgress = "InProgress";

        /// <summary>
        /// Status Succeeded value.
        /// </summary>
        public static readonly string Succeeded = "Succeeded";

        /// <summary>
        /// Status Other value.
        /// </summary>
        public static readonly string Other = "Other";

        /// <summary>
        /// Status Failed value.
        /// </summary>
        public static readonly string Failed = "Failed";

        /// <summary>
        /// Status Cancelled value.
        /// </summary>
        public static readonly string Cancelled = "Cancelled";

        /// <summary>
        /// Status Suspended value.
        /// </summary>
        public static readonly string Suspended = "Suspended";
    }
}

namespace Microsoft.Azure.Portal.RecoveryServices.Models.Common
{
    /// <summary>
    /// Class to define Vault credentials
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract]
    public class VaultCreds
    {
        #region Properties
        /// <summary>
        /// Gets or sets the key name for Namespace entry
        /// </summary>
        [DataMember(Order = 0)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the key name for Namespace entry
        /// </summary>
        [DataMember(Order = 1)]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the key name for Namespace entry
        /// </summary>
        [DataMember(Order = 2)]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the key name for Namespace entry
        /// </summary>
        [DataMember(Order = 3)]
        public string ManagementCert { get; set; }

        /// <summary>
        /// Gets or sets the key name for HostName entry
        /// </summary>
        [DataMember(Order = 4)]
        public AcsNamespace AcsNamespace { get; set; }
        #endregion
    }

    /// <summary>
    /// Class to define ASR Vault credentials
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public class ASRVaultCreds : VaultCreds
    {
        #region Properties
        /// <summary>
        /// Gets or sets the value for ACIK
        /// </summary>
        [DataMember(Order = 0)]
        public string ChannelIntegrityKey { get; set; }

        /// <summary>
        /// Gets or sets the value for cloud service name
        /// </summary>
        [DataMember(Order = 1)]
        public string CloudServiceName { get; set; }

        /// <summary>
        /// Gets or sets the values for the version of the credentials
        /// </summary>
        [DataMember(Order = 2)]
        public string Version { get; set; }
        #endregion
    }

    /// <summary>
    /// Class to define ACS name space
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public class AcsNamespace
    {
        /// <summary>
        /// Gets or sets Host name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets Name space
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets Resource provider realm
        /// </summary>
        public string ResourceProviderRealm { get; set; }
    }
}