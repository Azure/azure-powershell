namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Contains the IpTag associated with the object</summary>
    public partial class IPTag :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTagInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private string _tag;

        /// <summary>
        /// Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Tag { get => this._tag; set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Gets or sets the ipTag type: Example FirstPartyUsage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="IPTag" /> instance.</summary>
        public IPTag()
        {

        }
    }
    /// Contains the IpTag associated with the object
    public partial interface IIPTag :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc",
        SerializedName = @"tag",
        PossibleTypes = new [] { typeof(string) })]
        string Tag { get; set; }
        /// <summary>Gets or sets the ipTag type: Example FirstPartyUsage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the ipTag type: Example FirstPartyUsage.",
        SerializedName = @"ipTagType",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Contains the IpTag associated with the object
    internal partial interface IIPTagInternal

    {
        /// <summary>
        /// Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
        /// </summary>
        string Tag { get; set; }
        /// <summary>Gets or sets the ipTag type: Example FirstPartyUsage.</summary>
        string Type { get; set; }

    }
}