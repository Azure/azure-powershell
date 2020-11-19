namespace Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Extensions;

    /// <summary>The resource tags.</summary>
    public partial class DigitalTwinsResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="DigitalTwinsResourceTags" /> instance.</summary>
        public DigitalTwinsResourceTags()
        {

        }
    }
    /// The resource tags.
    public partial interface IDigitalTwinsResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IAssociativeArray<string>
    {

    }
    /// The resource tags.
    internal partial interface IDigitalTwinsResourceTagsInternal

    {

    }
}