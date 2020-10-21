namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class SelectItem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISelectItem,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISelectItemInternal
    {

        /// <summary>Creates an new <see cref="SelectItem" /> instance.</summary>
        public SelectItem()
        {

        }
    }
    public partial interface ISelectItem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {

    }
    internal partial interface ISelectItemInternal

    {

    }
}