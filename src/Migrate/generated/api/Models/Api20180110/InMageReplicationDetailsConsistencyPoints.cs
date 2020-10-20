namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The collection of Consistency points.</summary>
    public partial class InMageReplicationDetailsConsistencyPoints :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsConsistencyPoints,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReplicationDetailsConsistencyPointsInternal
    {

        /// <summary>
        /// Creates an new <see cref="InMageReplicationDetailsConsistencyPoints" /> instance.
        /// </summary>
        public InMageReplicationDetailsConsistencyPoints()
        {

        }
    }
    /// The collection of Consistency points.
    public partial interface IInMageReplicationDetailsConsistencyPoints :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<global::System.DateTime>
    {

    }
    /// The collection of Consistency points.
    internal partial interface IInMageReplicationDetailsConsistencyPointsInternal

    {

    }
}