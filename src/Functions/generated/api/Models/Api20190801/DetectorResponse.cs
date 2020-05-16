namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Class representing Response from Detector</summary>
    public partial class DetectorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Data Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData[] Dataset { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).Dataset; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).Dataset = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Support Category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MetadataCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataCategory; }

        /// <summary>Short description of the detector and its purpose</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MetadataDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataDescription; }

        /// <summary>Support Sub Category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MetadataSubCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataSubCategory; }

        /// <summary>Support Topic Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MetadataSupportTopicId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataSupportTopicId; }

        /// <summary>Internal Acessors for Metadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfo Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseInternal.Metadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).Metadata = value; }

        /// <summary>Internal Acessors for MetadataCategory</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseInternal.MetadataCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataCategory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataCategory = value; }

        /// <summary>Internal Acessors for MetadataDescription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseInternal.MetadataDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataDescription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataDescription = value; }

        /// <summary>Internal Acessors for MetadataSubCategory</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseInternal.MetadataSubCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataSubCategory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataSubCategory = value; }

        /// <summary>Internal Acessors for MetadataSupportTopicId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseInternal.MetadataSupportTopicId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataSupportTopicId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)Property).MetadataSupportTopicId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorResponseProperties()); set { {_property = value;} } }

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
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseProperties _property;

        /// <summary>DetectorResponse resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorResponseProperties()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="DetectorResponse" /> instance.</summary>
        public DetectorResponse()
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
    /// Class representing Response from Detector
    public partial interface IDetectorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Data Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Data Set",
        SerializedName = @"dataset",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData[] Dataset { get; set; }
        /// <summary>Support Category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Support Category",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string MetadataCategory { get;  }
        /// <summary>Short description of the detector and its purpose</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Short description of the detector and its purpose",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string MetadataDescription { get;  }
        /// <summary>Support Sub Category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Support Sub Category",
        SerializedName = @"subCategory",
        PossibleTypes = new [] { typeof(string) })]
        string MetadataSubCategory { get;  }
        /// <summary>Support Topic Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Support Topic Id",
        SerializedName = @"supportTopicId",
        PossibleTypes = new [] { typeof(string) })]
        string MetadataSupportTopicId { get;  }

    }
    /// Class representing Response from Detector
    internal partial interface IDetectorResponseInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Data Set</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData[] Dataset { get; set; }
        /// <summary>metadata for the detector</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfo Metadata { get; set; }
        /// <summary>Support Category</summary>
        string MetadataCategory { get; set; }
        /// <summary>Short description of the detector and its purpose</summary>
        string MetadataDescription { get; set; }
        /// <summary>Support Sub Category</summary>
        string MetadataSubCategory { get; set; }
        /// <summary>Support Topic Id</summary>
        string MetadataSupportTopicId { get; set; }
        /// <summary>DetectorResponse resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseProperties Property { get; set; }

    }
}