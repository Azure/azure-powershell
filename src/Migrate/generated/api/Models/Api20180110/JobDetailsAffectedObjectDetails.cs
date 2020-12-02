namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// The affected object properties like source server, source cloud, target server, target cloud etc. based on the workflow
    /// object details.
    /// </summary>
    public partial class JobDetailsAffectedObjectDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetailsInternal
    {

        /// <summary>Creates an new <see cref="JobDetailsAffectedObjectDetails" /> instance.</summary>
        public JobDetailsAffectedObjectDetails()
        {

        }
    }
    /// The affected object properties like source server, source cloud, target server, target cloud etc. based on the workflow
    /// object details.
    public partial interface IJobDetailsAffectedObjectDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IAssociativeArray<string>
    {

    }
    /// The affected object properties like source server, source cloud, target server, target cloud etc. based on the workflow
    /// object details.
    internal partial interface IJobDetailsAffectedObjectDetailsInternal

    {

    }
}