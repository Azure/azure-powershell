// Copyright (c) Microsoft Corporation. All rights reserved.

namespace Commands.Intune.RestClient.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// Android Policy request body for Intune MAM.
    /// </summary>
    public partial class AndroidPolicyRequestBody
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public AndroidPolicyProperties Properties { get; set; }

    }
}
