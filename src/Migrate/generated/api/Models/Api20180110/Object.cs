namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Base of all objects.</summary>
    public partial class Object :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IObject,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IObjectInternal
    {

        /// <summary>Creates an new <see cref="Object" /> instance.</summary>
        public Object()
        {

        }
    }
    /// Base of all objects.
    public partial interface IObject :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {

    }
    /// Base of all objects.
    internal partial interface IObjectInternal

    {

    }
}