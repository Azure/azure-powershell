namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Object with a list of the resources that need to be moved and the resource group they should be moved to.
    /// </summary>
    public partial class CsmMoveResourceEnvelope :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmMoveResourceEnvelope,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmMoveResourceEnvelopeInternal
    {

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private string[] _resource;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Resource { get => this._resource; set => this._resource = value; }

        /// <summary>Backing field for <see cref="TargetResourceGroup" /> property.</summary>
        private string _targetResourceGroup;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TargetResourceGroup { get => this._targetResourceGroup; set => this._targetResourceGroup = value; }

        /// <summary>Creates an new <see cref="CsmMoveResourceEnvelope" /> instance.</summary>
        public CsmMoveResourceEnvelope()
        {

        }
    }
    /// Object with a list of the resources that need to be moved and the resource group they should be moved to.
    public partial interface ICsmMoveResourceEnvelope :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resources",
        PossibleTypes = new [] { typeof(string) })]
        string[] Resource { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"targetResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceGroup { get; set; }

    }
    /// Object with a list of the resources that need to be moved and the resource group they should be moved to.
    internal partial interface ICsmMoveResourceEnvelopeInternal

    {
        string[] Resource { get; set; }

        string TargetResourceGroup { get; set; }

    }
}