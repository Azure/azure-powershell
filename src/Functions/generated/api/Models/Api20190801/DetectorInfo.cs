namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Definition of Detector</summary>
    public partial class DetectorInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal
    {

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private string _category;

        /// <summary>Support Category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Category { get => this._category; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Short description of the detector and its purpose</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Internal Acessors for Category</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal.Category { get => this._category; set { {_category = value;} } }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for SubCategory</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal.SubCategory { get => this._subCategory; set { {_subCategory = value;} } }

        /// <summary>Internal Acessors for SupportTopicId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfoInternal.SupportTopicId { get => this._supportTopicId; set { {_supportTopicId = value;} } }

        /// <summary>Backing field for <see cref="SubCategory" /> property.</summary>
        private string _subCategory;

        /// <summary>Support Sub Category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SubCategory { get => this._subCategory; }

        /// <summary>Backing field for <see cref="SupportTopicId" /> property.</summary>
        private string _supportTopicId;

        /// <summary>Support Topic Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SupportTopicId { get => this._supportTopicId; }

        /// <summary>Creates an new <see cref="DetectorInfo" /> instance.</summary>
        public DetectorInfo()
        {

        }
    }
    /// Definition of Detector
    public partial interface IDetectorInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Support Category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Support Category",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get;  }
        /// <summary>Short description of the detector and its purpose</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Short description of the detector and its purpose",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Support Sub Category</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Support Sub Category",
        SerializedName = @"subCategory",
        PossibleTypes = new [] { typeof(string) })]
        string SubCategory { get;  }
        /// <summary>Support Topic Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Support Topic Id",
        SerializedName = @"supportTopicId",
        PossibleTypes = new [] { typeof(string) })]
        string SupportTopicId { get;  }

    }
    /// Definition of Detector
    internal partial interface IDetectorInfoInternal

    {
        /// <summary>Support Category</summary>
        string Category { get; set; }
        /// <summary>Short description of the detector and its purpose</summary>
        string Description { get; set; }
        /// <summary>Support Sub Category</summary>
        string SubCategory { get; set; }
        /// <summary>Support Topic Id</summary>
        string SupportTopicId { get; set; }

    }
}