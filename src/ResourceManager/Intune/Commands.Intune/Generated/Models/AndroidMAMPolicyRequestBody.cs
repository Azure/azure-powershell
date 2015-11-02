// Copyright (c) Microsoft Corporation. All rights reserved.

namespace Microsoft.Azure.Commands.Intune.RestClient.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Android Policy request body for Intune MAM.
    /// </summary>
    public partial class AndroidMAMPolicyRequestBody
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public AndroidMAMPolicyProperties Properties { get; set; }

    }
}
