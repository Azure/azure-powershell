namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Tags field of the resource.</summary>
    public partial class Tags1 :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ITags1,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ITags1Internal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ITags _tag;

        /// <summary>Tags field of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ITags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.Tags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="Tags1" /> instance.</summary>
        public Tags1()
        {

        }
    }
    /// Tags field of the resource.
    public partial interface ITags1 :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>Tags field of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tags field of the resource.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ITags) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ITags Tag { get; set; }

    }
    /// Tags field of the resource.
    internal partial interface ITags1Internal

    {
        /// <summary>Tags field of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ITags Tag { get; set; }

    }
}