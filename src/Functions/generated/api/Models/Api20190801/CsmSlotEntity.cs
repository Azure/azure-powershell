namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Deployment slot parameters.</summary>
    public partial class CsmSlotEntity :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmSlotEntity,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmSlotEntityInternal
    {

        /// <summary>Backing field for <see cref="PreserveVnet" /> property.</summary>
        private bool _preserveVnet;

        /// <summary>
        /// <code>true</code> to preserve Virtual Network to the slot during swap; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool PreserveVnet { get => this._preserveVnet; set => this._preserveVnet = value; }

        /// <summary>Backing field for <see cref="TargetSlot" /> property.</summary>
        private string _targetSlot;

        /// <summary>Destination deployment slot during swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TargetSlot { get => this._targetSlot; set => this._targetSlot = value; }

        /// <summary>Creates an new <see cref="CsmSlotEntity" /> instance.</summary>
        public CsmSlotEntity()
        {

        }
    }
    /// Deployment slot parameters.
    public partial interface ICsmSlotEntity :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// <code>true</code> to preserve Virtual Network to the slot during swap; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"<code>true</code> to preserve Virtual Network to the slot during swap; otherwise, <code>false</code>.",
        SerializedName = @"preserveVnet",
        PossibleTypes = new [] { typeof(bool) })]
        bool PreserveVnet { get; set; }
        /// <summary>Destination deployment slot during swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Destination deployment slot during swap operation.",
        SerializedName = @"targetSlot",
        PossibleTypes = new [] { typeof(string) })]
        string TargetSlot { get; set; }

    }
    /// Deployment slot parameters.
    internal partial interface ICsmSlotEntityInternal

    {
        /// <summary>
        /// <code>true</code> to preserve Virtual Network to the slot during swap; otherwise, <code>false</code>.
        /// </summary>
        bool PreserveVnet { get; set; }
        /// <summary>Destination deployment slot during swap operation.</summary>
        string TargetSlot { get; set; }

    }
}