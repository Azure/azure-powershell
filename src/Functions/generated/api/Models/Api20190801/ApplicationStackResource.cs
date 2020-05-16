namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ARM resource for a ApplicationStack.</summary>
    public partial class ApplicationStackResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Application stack dependency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Dependency { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)Property).Dependency; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)Property).Dependency = value; }

        /// <summary>Application stack display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Display { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)Property).Display; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)Property).Display = value; }

        /// <summary>List of frameworks associated with application stack.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack[] Framework { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)Property).Framework; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)Property).Framework = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>List of major versions available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion[] MajorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)Property).MajorVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)Property).MajorVersion = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationStack()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Application stack name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PropertiesName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)Property).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)Property).Name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack _property;

        /// <summary>Core resource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationStack()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="ApplicationStackResource" /> instance.</summary>
        public ApplicationStackResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// ARM resource for a ApplicationStack.
    public partial interface IApplicationStackResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Application stack dependency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application stack dependency.",
        SerializedName = @"dependency",
        PossibleTypes = new [] { typeof(string) })]
        string Dependency { get; set; }
        /// <summary>Application stack display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application stack display name.",
        SerializedName = @"display",
        PossibleTypes = new [] { typeof(string) })]
        string Display { get; set; }
        /// <summary>List of frameworks associated with application stack.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of frameworks associated with application stack.",
        SerializedName = @"frameworks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack[] Framework { get; set; }
        /// <summary>List of major versions available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of major versions available.",
        SerializedName = @"majorVersions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion[] MajorVersion { get; set; }
        /// <summary>Application stack name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application stack name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesName { get; set; }

    }
    /// ARM resource for a ApplicationStack.
    internal partial interface IApplicationStackResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Application stack dependency.</summary>
        string Dependency { get; set; }
        /// <summary>Application stack display name.</summary>
        string Display { get; set; }
        /// <summary>List of frameworks associated with application stack.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack[] Framework { get; set; }
        /// <summary>List of major versions available.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion[] MajorVersion { get; set; }
        /// <summary>Application stack name.</summary>
        string PropertiesName { get; set; }
        /// <summary>Core resource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack Property { get; set; }

    }
}