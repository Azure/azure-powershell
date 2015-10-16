// Copyright (c) Microsoft Corporation.  All rights reserved.

namespace Commands.Intune.RestClient.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// Intune MAM iOS Policy Properties.
    /// </summary>
    public partial class AndroidPolicyProperties : MAMPolicyProperties
    {
        /// <summary>
        /// Possible values for this property include: 'allow', 'block'.
        /// </summary>
        [JsonProperty(PropertyName = "screenCapture")]
        public string ScreenCapture { get; set; }

        /// <summary>
        /// Possible values for this property include: 'required',
        /// 'notRequired '.
        /// </summary>
        [JsonProperty(PropertyName = "fileEncryption")]
        public string FileEncryption { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
