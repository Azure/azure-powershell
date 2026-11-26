// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>The authentication configuration for the Mongo cluster.</summary>
    public partial class AuthConfigProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllowedMode" /> property.</summary>
        private System.Collections.Generic.List<string> _allowedMode;

        /// <summary>Allowed authentication modes for data access on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> AllowedMode { get => this._allowedMode; set => this._allowedMode = value; }

        /// <summary>Creates an new <see cref="AuthConfigProperties" /> instance.</summary>
        public AuthConfigProperties()
        {

        }
    }
    /// The authentication configuration for the Mongo cluster.
    public partial interface IAuthConfigProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>Allowed authentication modes for data access on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Allowed authentication modes for data access on the cluster.",
        SerializedName = @"allowedModes",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("NativeAuth", "MicrosoftEntraID")]
        System.Collections.Generic.List<string> AllowedMode { get; set; }

    }
    /// The authentication configuration for the Mongo cluster.
    internal partial interface IAuthConfigPropertiesInternal

    {
        /// <summary>Allowed authentication modes for data access on the cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("NativeAuth", "MicrosoftEntraID")]
        System.Collections.Generic.List<string> AllowedMode { get; set; }

    }
}