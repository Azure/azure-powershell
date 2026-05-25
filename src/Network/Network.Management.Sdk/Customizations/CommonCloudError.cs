// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Models
{
    /// <summary>
    /// Backward-compatible error response type used by generated operation code.
    /// </summary>
    public partial class CommonCloudError
    {
        /// <summary>
        /// Initializes a new instance of the CommonCloudError class.
        /// </summary>
        public CommonCloudError()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CommonCloudError class.
        /// </summary>
        /// <param name="error">The error object.</param>
        public CommonCloudError(CommonErrorDetail error = default(CommonErrorDetail))
        {
            this.Error = error;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults.
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the error object.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "error")]
        public CommonErrorDetail Error { get; set; }
    }
}
