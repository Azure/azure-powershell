// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataBoxEdge.Models
{
    using System.Linq;

    /// <summary>
    /// The job error information containing the list of job errors.
    /// </summary>
    public partial class JobErrorDetails
    {
        /// <summary>
        /// Initializes a new instance of the JobErrorDetails class.
        /// </summary>
        public JobErrorDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the JobErrorDetails class.
        /// </summary>

        /// <param name="errorDetails">The error details.
        /// </param>

        /// <param name="code">The code intended for programmatic access.
        /// </param>

        /// <param name="message">The message that describes the error in detail.
        /// </param>
        public JobErrorDetails(System.Collections.Generic.IList<JobErrorItem> errorDetails = default(System.Collections.Generic.IList<JobErrorItem>), string code = default(string), string message = default(string))

        {
            this.ErrorDetails = errorDetails;
            this.Code = code;
            this.Message = message;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets the error details.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "errorDetails")]
        public System.Collections.Generic.IList<JobErrorItem> ErrorDetails {get; private set; }

        /// <summary>
        /// Gets the code intended for programmatic access.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "code")]
        public string Code {get; private set; }

        /// <summary>
        /// Gets the message that describes the error in detail.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "message")]
        public string Message {get; private set; }
    }
}