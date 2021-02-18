namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Performance tier properties</summary>
    public partial class PerformanceTierProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPerformanceTierProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPerformanceTierPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ID of the performance tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="ServiceLevelObjective" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPerformanceTierServiceLevelObjectives[] _serviceLevelObjective;

        /// <summary>Service level objectives associated with the performance tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPerformanceTierServiceLevelObjectives[] ServiceLevelObjective { get => this._serviceLevelObjective; set => this._serviceLevelObjective = value; }

        /// <summary>Creates an new <see cref="PerformanceTierProperties" /> instance.</summary>
        public PerformanceTierProperties()
        {

        }
    }
    /// Performance tier properties
    public partial interface IPerformanceTierProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>ID of the performance tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ID of the performance tier.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Service level objectives associated with the performance tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service level objectives associated with the performance tier",
        SerializedName = @"serviceLevelObjectives",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPerformanceTierServiceLevelObjectives) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPerformanceTierServiceLevelObjectives[] ServiceLevelObjective { get; set; }

    }
    /// Performance tier properties
    internal partial interface IPerformanceTierPropertiesInternal

    {
        /// <summary>ID of the performance tier.</summary>
        string Id { get; set; }
        /// <summary>Service level objectives associated with the performance tier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IPerformanceTierServiceLevelObjectives[] ServiceLevelObjective { get; set; }

    }
}