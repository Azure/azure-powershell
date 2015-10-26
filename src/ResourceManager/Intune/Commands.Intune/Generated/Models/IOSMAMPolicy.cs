// Copyright (c) Microsoft Corporation. All rights reserved.

namespace Microsoft.Azure.Commands.Intune.RestClient.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// iOS Policy entity for Intune MAM.
    /// </summary>
    public partial class IOSMAMPolicy : Resource
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public IOSMAMPolicyProperties Properties { get; set; }

    }
}
