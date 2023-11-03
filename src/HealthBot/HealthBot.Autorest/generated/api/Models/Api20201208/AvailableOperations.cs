namespace Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Extensions;

    /// <summary>Available operations of the service</summary>
    public partial class AvailableOperations :
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IAvailableOperations,
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IAvailableOperationsInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// URL client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IOperationDetail[] _value;

        /// <summary>Collection of available operation details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IOperationDetail[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="AvailableOperations" /> instance.</summary>
        public AvailableOperations()
        {

        }
    }
    /// Available operations of the service
    public partial interface IAvailableOperations :
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.IJsonSerializable
    {
        /// <summary>
        /// URL client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL client should use to fetch the next page (per server side paging).
        It's null for now, added for future use.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Collection of available operation details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of available operation details",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IOperationDetail) })]
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IOperationDetail[] Value { get; set; }

    }
    /// Available operations of the service
    internal partial interface IAvailableOperationsInternal

    {
        /// <summary>
        /// URL client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        string NextLink { get; set; }
        /// <summary>Collection of available operation details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IOperationDetail[] Value { get; set; }

    }
}