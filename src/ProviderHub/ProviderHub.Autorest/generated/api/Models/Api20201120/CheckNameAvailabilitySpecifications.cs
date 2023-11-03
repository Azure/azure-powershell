namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class CheckNameAvailabilitySpecifications :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecifications,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecificationsInternal
    {

        /// <summary>Backing field for <see cref="EnableDefaultValidation" /> property.</summary>
        private bool? _enableDefaultValidation;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool? EnableDefaultValidation { get => this._enableDefaultValidation; set => this._enableDefaultValidation = value; }

        /// <summary>Backing field for <see cref="ResourceTypesWithCustomValidation" /> property.</summary>
        private string[] _resourceTypesWithCustomValidation;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] ResourceTypesWithCustomValidation { get => this._resourceTypesWithCustomValidation; set => this._resourceTypesWithCustomValidation = value; }

        /// <summary>Creates an new <see cref="CheckNameAvailabilitySpecifications" /> instance.</summary>
        public CheckNameAvailabilitySpecifications()
        {

        }
    }
    public partial interface ICheckNameAvailabilitySpecifications :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enableDefaultValidation",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableDefaultValidation { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceTypesWithCustomValidation",
        PossibleTypes = new [] { typeof(string) })]
        string[] ResourceTypesWithCustomValidation { get; set; }

    }
    internal partial interface ICheckNameAvailabilitySpecificationsInternal

    {
        bool? EnableDefaultValidation { get; set; }

        string[] ResourceTypesWithCustomValidation { get; set; }

    }
}