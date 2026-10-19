// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Promote replica request properties.</summary>
    public partial class PromoteReplicaRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPromoteReplicaRequest,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPromoteReplicaRequestInternal
    {

        /// <summary>Internal Acessors for PromoteOption</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPromoteReplicaRequestInternal.PromoteOption { get => this._promoteOption; set { {_promoteOption = value;} } }

        /// <summary>Backing field for <see cref="Mode" /> property.</summary>
        private string _mode;

        /// <summary>
        /// The mode to apply to the promote operation. Value is optional and default value is 'Switchover'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string Mode { get => this._mode; set => this._mode = value; }

        /// <summary>Backing field for <see cref="PromoteOption" /> property.</summary>
        private string _promoteOption= @"Forced";

        /// <summary>The promote option to apply to the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string PromoteOption { get => this._promoteOption; }

        /// <summary>Creates an new <see cref="PromoteReplicaRequest" /> instance.</summary>
        public PromoteReplicaRequest()
        {

        }
    }
    /// Promote replica request properties.
    public partial interface IPromoteReplicaRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The mode to apply to the promote operation. Value is optional and default value is 'Switchover'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The mode to apply to the promote operation. Value is optional and default value is 'Switchover'.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Switchover")]
        string Mode { get; set; }
        /// <summary>The promote option to apply to the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The promote option to apply to the operation.",
        SerializedName = @"promoteOption",
        PossibleTypes = new [] { typeof(string) })]
        string PromoteOption { get;  }

    }
    /// Promote replica request properties.
    internal partial interface IPromoteReplicaRequestInternal

    {
        /// <summary>
        /// The mode to apply to the promote operation. Value is optional and default value is 'Switchover'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Switchover")]
        string Mode { get; set; }
        /// <summary>The promote option to apply to the operation.</summary>
        string PromoteOption { get; set; }

    }
}