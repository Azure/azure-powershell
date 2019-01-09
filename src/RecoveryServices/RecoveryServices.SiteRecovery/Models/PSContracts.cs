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
using System.Text;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    public class PSSiteRecoveryLongRunningOperation
    {
        public string ClientRequestId { get; set; }

        public string CorrelationRequestId { get; set; }

        public string Date { get; set; }

        public string ContentType { get; set; }

        public string Location { get; set; }

        public string RetryAfter { get; set; }

        public string AsyncOperation { get; set; }

        public OperationStatus Status { get; set; }

        public string Culture { get; set; }
    }

    /// <summary>
    ///     Hash functions which can be used to calculate CIK HMAC.
    /// </summary>
    public enum CikSupportedHashFunctions
    {
        /// <summary>
        ///     Represents a HMACSHA256 hash function.
        /// </summary>
        HMACSHA256,

        /// <summary>
        ///     Represents a HMACSHA384 hash function.
        /// </summary>
        HMACSHA384,

        /// <summary>
        ///     Represents a HMACSHA512 hash function.
        /// </summary>
        HMACSHA512
    }

    /// <summary>
    ///     The types of crypto algorithms
    /// </summary>
    public enum CryptoAlgorithm
    {
        /// <summary>
        ///     The asymmetric key based RSA 2048 algorithm.
        /// </summary>
        RSAPKCS1V17,

        /// <summary>
        ///     The asymmetric key based RSA 2048 algorithm.
        /// </summary>
        RSAPKCS1V15,

        /// <summary>
        ///     The symmetric key based AES algorithm with key size 256 bits.
        /// </summary>
        AES256,

        /// <summary>
        ///     The symmetric key based SHA 256 Algorithm
        /// </summary>
        HMACSHA256,

        /// <summary>
        ///     When no algorithm is used.
        /// </summary>
        None
    }

    /// <summary>
    ///     Fabric type class.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public class FabricProviders
    {
        /// <summary>
        ///     Azure fabric type.
        /// </summary>
        public const string Azure = "Azure";

        /// <summary>
        ///     HyperVSite server type.
        /// </summary>
        public const string HyperVSite = "HyperVSite";

        /// <summary>
        ///     Unknown type.
        /// </summary>
        public const string Other = "Other";

        /// <summary>
        ///     InMage server type.
        /// </summary>
        public const string vCenter = "vCenter";

        /// <summary>
        ///     VMM server type.
        /// </summary>
        public const string VMM = "VMM";
    }

    /// <summary>
    ///     The RP service error code that needs to be handled by portal.
    /// </summary>
    public enum RpErrorCode
    {
        /// <summary>
        ///     The error code sent by RP if the Resource extended info doesn't exists.
        /// </summary>
        ResourceExtendedInfoNotFound
    }

    /// <summary>
    ///     ARM specified Error
    /// </summary>
    public class ARMError
    {
        /// <summary>
        ///     Gets ARM formatted exception.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public ARMException Error { get; private set; }
    }

    /// <summary>
    ///     ARM exception class.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related classes together.")]
    public class ARMException
    {
        /// <summary>
        ///     Gets HTTP status code for the error.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string ErrorCode { get; private set; }

        /// <summary>
        ///     Gets exception message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; private set; }

        /// <summary>
        ///     Gets exception target.
        /// </summary>
        [JsonProperty(
            PropertyName = "target",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Target { get; private set; }

        /// <summary>
        ///     Gets service based error details.
        /// </summary>
        [JsonProperty(PropertyName = "details")]
        public List<ARMExceptionDetails> Details { get; private set; }
    }

    /// <summary>
    ///     Service based exception details.
    /// </summary>
    public class ARMExceptionDetails
    {
        /// <summary>
        ///     Gets service error code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string ErrorCode { get; private set; }

        /// <summary>
        ///     Gets error message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; private set; }

        /// <summary>
        ///     Gets possible cause for error.
        /// </summary>
        [JsonProperty(
            PropertyName = "possibleCauses",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PossibleCauses { get; private set; }

        /// <summary>
        ///     Gets recommended action for the error.
        /// </summary>
        [JsonProperty(
            PropertyName = "recommendedAction",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string RecommendedAction { get; private set; }

        /// <summary>
        ///     Gets the client request Id for the session.
        /// </summary>
        [JsonProperty(
            PropertyName = "clientRequestId",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ClientRequestId { get; private set; }

        /// <summary>
        ///     Gets the activity Id for the session.
        /// </summary>
        [JsonProperty(PropertyName = "activityId")]
        public string ActivityId { get; private set; }

        /// <summary>
        ///     Gets exception target.
        /// </summary>
        [JsonProperty(
            PropertyName = "target",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Target { get; private set; }
    }

    /// <summary>
    ///     Error contract returned when some exception occurs in ASR REST API.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class Error
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Error" /> class.
        /// </summary>
        public Error()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Error" /> class with required parameters.
        /// </summary>
        /// <param name="se">Service Error</param>
        public Error(
            ServiceError se)
        {
            this.ClientRequestId = se.ActivityId;
            this.Code = se.Code;
            this.Message = se.Message;
            this.PossibleCauses = se.PossibleCauses;
            this.RecommendedAction = se.RecommendedAction;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Error" /> class.
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
        ///     Gets or sets error code.
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets error message.
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets possible causes of error.
        /// </summary>
        [DataMember]
        public string PossibleCauses { get; set; }

        /// <summary>
        ///     Gets or sets recommended action to resolve error.
        /// </summary>
        [DataMember]
        public string RecommendedAction { get; set; }

        /// <summary>
        ///     Gets or sets client request Id.
        /// </summary>
        [DataMember(Name = "ActivityId")]
        public string ClientRequestId { get; set; }
    }

    /// <summary>
    ///     CIK token details.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract]
    public class CikTokenDetails
    {
        /// <summary>
        ///     Gets or sets the timestamp before which the token is not valid.
        /// </summary>
        [DataMember]
        public DateTime NotBeforeTimestamp { get; set; }

        /// <summary>
        ///     Gets or sets the timestamp after which the token is not valid.
        /// </summary>
        [DataMember]
        public DateTime NotAfterTimestamp { get; set; }

        /// <summary>
        ///     Gets or sets the client request Id for the operation linked with this CIK token.
        /// </summary>
        [DataMember]
        public string ClientRequestId { get; set; }

        /// <summary>
        ///     Gets or sets Hash function used to calculate the HMAC.
        /// </summary>
        [DataMember]
        public string HashFunction { get; set; }

        /// <summary>
        ///     Gets or sets the HMAC generated using the CIK key.
        /// </summary>
        [DataMember]
        public string Hmac { get; set; }

        /// <summary>
        ///     Gets or sets Data contract version.
        /// </summary>
        [DataMember(Name = "Version")]
        public Version Version { get; set; }

        /// <summary>
        ///     Gets or sets property bag. This property bag is introduced to support addition of any
        ///     new property in data contract without breaking the existing clients.
        ///     If any new property needs to be introduced in the contract,
        ///     add a key value pair for it in this dictionary.
        /// </summary>
        [DataMember]
        public Dictionary<string, object> PropertyBag { get; set; }

        /// <summary>
        ///     Converts the object into string.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("NotBeforeTimestamp: " + this.NotBeforeTimestamp);
            sb.AppendLine("NotAfterTimestamp: " + this.NotAfterTimestamp);
            sb.AppendLine("ClientRequestId: " + this.ClientRequestId);
            sb.AppendLine("Hmac: " + this.Hmac);
            return sb.ToString();
        }
    }

    /// <summary>
    ///     Possible states of the Job.
    /// </summary>
    public class JobStatus : TaskStatus
    {
    }

    /// <summary>
    ///     Possible states of the Task.
    /// </summary>
    public class TaskStatus
    {
        /// <summary>
        ///     Status Cancelled value.
        /// </summary>
        public static readonly string Cancelled = "Cancelled";

        /// <summary>
        ///     Status Failed value.
        /// </summary>
        public static readonly string Failed = "Failed";

        /// <summary>
        ///     Status InProgress value.
        /// </summary>
        public static readonly string InProgress = "InProgress";

        /// <summary>
        ///     TaskStatus NotStarted value.
        /// </summary>
        public static readonly string NotStarted = "NotStarted";

        /// <summary>
        ///     Status Other value.
        /// </summary>
        public static readonly string Other = "Other";

        /// <summary>
        ///     Status Succeeded value.
        /// </summary>
        public static readonly string Succeeded = "Succeeded";

        /// <summary>
        ///     Status Suspended value.
        /// </summary>
        public static readonly string Suspended = "Suspended";
    }
}
