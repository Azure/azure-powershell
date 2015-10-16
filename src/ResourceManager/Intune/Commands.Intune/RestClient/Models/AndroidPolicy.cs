// Copyright (c) Microsoft Corporation.  All rights reserved.

namespace Commands.Intune.RestClient.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// Android Policy entity for Intune MAM.
    /// </summary>
    public partial class AndroidPolicy : Resource
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public AndroidPolicyProperties Properties { get; set; }

    }
}
