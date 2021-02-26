namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Trigger context</summary>
    public partial class TriggerContext :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContext,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITriggerContextInternal
    {

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Creates an new <see cref="TriggerContext" /> instance.</summary>
        public TriggerContext()
        {

        }
    }
    /// Trigger context
    public partial interface ITriggerContext :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of the specific object - used for deserializing",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }

    }
    /// Trigger context
    internal partial interface ITriggerContextInternal

    {
        /// <summary>Type of the specific object - used for deserializing</summary>
        string ObjectType { get; set; }

    }
}