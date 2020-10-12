namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    /// <summary>The API entity reference.</summary>
    public partial class ApiEntityReference :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IApiEntityReference,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IApiEntityReferenceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="ApiEntityReference" /> instance.</summary>
        public ApiEntityReference()
        {

        }
    }
    /// The API entity reference.
    public partial interface IApiEntityReference :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// The API entity reference.
    internal partial interface IApiEntityReferenceInternal

    {
        /// <summary>
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        string Id { get; set; }

    }
}