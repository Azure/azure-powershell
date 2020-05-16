namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>DetectorResponse resource specific properties</summary>
    public partial class DetectorResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Dataset" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData[] _dataset;

        /// <summary>Data Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData[] Dataset { get => this._dataset; set => this._dataset = value; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfo _metadata;

        /// <summary>metadata for the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfo Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorInfo()); set => this._metadata = value; }

        /// <summary>Support Category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MetadataCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).Category; }

        /// <summary>Short description of the detector and its purpose</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MetadataDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).Description; }

        /// <summary>Support Sub Category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MetadataSubCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).SubCategory; }

        /// <summary>Support Topic Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MetadataSupportTopicId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).SupportTopicId; }

        /// <summary>Internal Acessors for Metadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfo Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal.Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorInfo()); set { {_metadata = value;} } }

        /// <summary>Internal Acessors for MetadataCategory</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal.MetadataCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).Category; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).Category = value; }

        /// <summary>Internal Acessors for MetadataDescription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal.MetadataDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).Description = value; }

        /// <summary>Internal Acessors for MetadataSubCategory</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal.MetadataSubCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).SubCategory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).SubCategory = value; }

        /// <summary>Internal Acessors for MetadataSupportTopicId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal.MetadataSupportTopicId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).SupportTopicId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal)Metadata).SupportTopicId = value; }

        /// <summary>Creates an new <see cref="DetectorResponseProperties" /> instance.</summary>
        public DetectorResponseProperties()
        {

        }
    }
    /// DetectorResponse resource specific properties
    public partial interface IDetectorResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// DetectorResponse resource specific properties
    internal partial interface IDetectorResponsePropertiesInternal

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

    }
}