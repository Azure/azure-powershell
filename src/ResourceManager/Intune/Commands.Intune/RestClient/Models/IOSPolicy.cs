// Copyright (c) Microsoft Corporation. All rights reserved.

namespace Commands.Intune.RestClient.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// iOS Policy entity for Intune MAM.
    /// </summary>
    public partial class IOSPolicy : Resource
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public IOSPolicyProperties Properties { get; set; }

    }
}
