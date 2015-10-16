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
    public partial class IOSPolicyProperties : MAMPolicyProperties
    {
        /// <summary>
        /// Possible values for this property include: 'deviceLocked',
        /// 'deviceLockedExceptFilesOpen', 'afterDeviceRestart',
        /// 'useDeviceSettings'.
        /// </summary>
        [JsonProperty(PropertyName = "fileEncryptionLevel")]
        public string FileEncryptionLevel { get; set; }

        /// <summary>
        /// Possible values for this property include: 'enable', 'disable'.
        /// </summary>
        [JsonProperty(PropertyName = "touchId")]
        public string TouchId { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
