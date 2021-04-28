namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Class to contain criteria for item level restore</summary>
    public partial class ItemLevelRestoreCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteria,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteriaInternal
    {

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Creates an new <see cref="ItemLevelRestoreCriteria" /> instance.</summary>
        public ItemLevelRestoreCriteria()
        {

        }
    }
    /// Class to contain criteria for item level restore
    public partial interface IItemLevelRestoreCriteria :
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
    /// Class to contain criteria for item level restore
    internal partial interface IItemLevelRestoreCriteriaInternal

    {
        /// <summary>Type of the specific object - used for deserializing</summary>
        string ObjectType { get; set; }

    }
}