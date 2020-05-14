namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>DetectorDefinition resource specific properties</summary>
    public partial class DetectorDefinitionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display name of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; }

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool? _isEnabled;

        /// <summary>Flag representing whether detector is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsEnabled { get => this._isEnabled; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionPropertiesInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionPropertiesInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for IsEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionPropertiesInternal.IsEnabled { get => this._isEnabled; set { {_isEnabled = value;} } }

        /// <summary>Internal Acessors for Rank</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionPropertiesInternal.Rank { get => this._rank; set { {_rank = value;} } }

        /// <summary>Backing field for <see cref="Rank" /> property.</summary>
        private double? _rank;

        /// <summary>Detector Rank</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? Rank { get => this._rank; }

        /// <summary>Creates an new <see cref="DetectorDefinitionProperties" /> instance.</summary>
        public DetectorDefinitionProperties()
        {

        }
    }
    /// DetectorDefinition resource specific properties
    public partial interface IDetectorDefinitionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Description of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Description of the detector",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Display name of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display name of the detector",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Flag representing whether detector is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Flag representing whether detector is enabled or not.",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnabled { get;  }
        /// <summary>Detector Rank</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Detector Rank",
        SerializedName = @"rank",
        PossibleTypes = new [] { typeof(double) })]
        double? Rank { get;  }

    }
    /// DetectorDefinition resource specific properties
    internal partial interface IDetectorDefinitionPropertiesInternal

    {
        /// <summary>Description of the detector</summary>
        string Description { get; set; }
        /// <summary>Display name of the detector</summary>
        string DisplayName { get; set; }
        /// <summary>Flag representing whether detector is enabled or not.</summary>
        bool? IsEnabled { get; set; }
        /// <summary>Detector Rank</summary>
        double? Rank { get; set; }

    }
}