namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The properties of an ImmutabilityPolicy of a blob container.</summary>
    public partial class ImmutabilityPolicyProperty :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperty,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertyInternal
    {

        /// <summary>Backing field for <see cref="ImmutabilityPeriodSinceCreationInDay" /> property.</summary>
        private int _immutabilityPeriodSinceCreationInDay;

        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int ImmutabilityPeriodSinceCreationInDay { get => this._immutabilityPeriodSinceCreationInDay; set => this._immutabilityPeriodSinceCreationInDay = value; }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertyInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? _state;

        /// <summary>
        /// The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? State { get => this._state; }

        /// <summary>Creates an new <see cref="ImmutabilityPolicyProperty" /> instance.</summary>
        public ImmutabilityPolicyProperty()
        {

        }
    }
    /// The properties of an ImmutabilityPolicy of a blob container.
    public partial interface IImmutabilityPolicyProperty :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The immutability period for the blobs in the container since the policy creation, in days.",
        SerializedName = @"immutabilityPeriodSinceCreationInDays",
        PossibleTypes = new [] { typeof(int) })]
        int ImmutabilityPeriodSinceCreationInDay { get; set; }
        /// <summary>
        /// The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? State { get;  }

    }
    /// The properties of an ImmutabilityPolicy of a blob container.
    internal partial interface IImmutabilityPolicyPropertyInternal

    {
        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        int ImmutabilityPeriodSinceCreationInDay { get; set; }
        /// <summary>
        /// The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? State { get; set; }

    }
}