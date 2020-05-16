namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Definition of Analysis</summary>
    public partial class AnalysisDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinitionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Description of the Analysis</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinitionPropertiesInternal)Property).Description; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinitionInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinitionPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinitionPropertiesInternal)Property).Description = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinitionProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinitionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AnalysisDefinitionProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinitionProperties _property;

        /// <summary>AnalysisDefinition resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinitionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AnalysisDefinitionProperties()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="AnalysisDefinition" /> instance.</summary>
        public AnalysisDefinition()
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
    /// Definition of Analysis
    public partial interface IAnalysisDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Description of the Analysis</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Description of the Analysis",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }

    }
    /// Definition of Analysis
    internal partial interface IAnalysisDefinitionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Description of the Analysis</summary>
        string Description { get; set; }
        /// <summary>AnalysisDefinition resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDefinitionProperties Property { get; set; }

    }
}