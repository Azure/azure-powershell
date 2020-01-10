namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Service Community Properties.</summary>
    public partial class BgpServiceCommunity :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunity,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Resource();

        /// <summary>Get a list of bgp communities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpCommunity[] BgpCommunity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityPropertiesFormatInternal)Property).BgpCommunity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityPropertiesFormatInternal)Property).BgpCommunity = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BgpServiceCommunityPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityPropertiesFormat _property;

        /// <summary>Properties of Service Community.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BgpServiceCommunityPropertiesFormat()); set => this._property = value; }

        /// <summary>The name of the bgp community. e.g. Skype.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ServiceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityPropertiesFormatInternal)Property).ServiceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityPropertiesFormatInternal)Property).ServiceName = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="BgpServiceCommunity" /> instance.</summary>
        public BgpServiceCommunity()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Service Community Properties.
    public partial interface IBgpServiceCommunity :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource
    {
        /// <summary>Get a list of bgp communities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Get a list of bgp communities.",
        SerializedName = @"bgpCommunities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpCommunity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpCommunity[] BgpCommunity { get; set; }
        /// <summary>The name of the bgp community. e.g. Skype.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the bgp community. e.g. Skype.",
        SerializedName = @"serviceName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceName { get; set; }

    }
    /// Service Community Properties.
    internal partial interface IBgpServiceCommunityInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal
    {
        /// <summary>Get a list of bgp communities.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpCommunity[] BgpCommunity { get; set; }
        /// <summary>Properties of Service Community.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityPropertiesFormat Property { get; set; }
        /// <summary>The name of the bgp community. e.g. Skype.</summary>
        string ServiceName { get; set; }

    }
}