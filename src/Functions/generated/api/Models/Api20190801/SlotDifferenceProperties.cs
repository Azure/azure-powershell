namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SlotDifference resource specific properties</summary>
    public partial class SlotDifferenceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the setting difference.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Backing field for <see cref="DiffRule" /> property.</summary>
        private string _diffRule;

        /// <summary>Rule that describes how to process the setting difference during a slot swap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DiffRule { get => this._diffRule; }

        /// <summary>Backing field for <see cref="Level" /> property.</summary>
        private string _level;

        /// <summary>Level of the difference: Information, Warning or Error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Level { get => this._level; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for DiffRule</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal.DiffRule { get => this._diffRule; set { {_diffRule = value;} } }

        /// <summary>Internal Acessors for Level</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal.Level { get => this._level; set { {_level = value;} } }

        /// <summary>Internal Acessors for SettingName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal.SettingName { get => this._settingName; set { {_settingName = value;} } }

        /// <summary>Internal Acessors for SettingType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal.SettingType { get => this._settingType; set { {_settingType = value;} } }

        /// <summary>Internal Acessors for ValueInCurrentSlot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal.ValueInCurrentSlot { get => this._valueInCurrentSlot; set { {_valueInCurrentSlot = value;} } }

        /// <summary>Internal Acessors for ValueInTargetSlot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal.ValueInTargetSlot { get => this._valueInTargetSlot; set { {_valueInTargetSlot = value;} } }

        /// <summary>Backing field for <see cref="SettingName" /> property.</summary>
        private string _settingName;

        /// <summary>Name of the setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SettingName { get => this._settingName; }

        /// <summary>Backing field for <see cref="SettingType" /> property.</summary>
        private string _settingType;

        /// <summary>The type of the setting: General, AppSetting or ConnectionString.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SettingType { get => this._settingType; }

        /// <summary>Backing field for <see cref="ValueInCurrentSlot" /> property.</summary>
        private string _valueInCurrentSlot;

        /// <summary>Value of the setting in the current slot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ValueInCurrentSlot { get => this._valueInCurrentSlot; }

        /// <summary>Backing field for <see cref="ValueInTargetSlot" /> property.</summary>
        private string _valueInTargetSlot;

        /// <summary>Value of the setting in the target slot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ValueInTargetSlot { get => this._valueInTargetSlot; }

        /// <summary>Creates an new <see cref="SlotDifferenceProperties" /> instance.</summary>
        public SlotDifferenceProperties()
        {

        }
    }
    /// SlotDifference resource specific properties
    public partial interface ISlotDifferenceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Description of the setting difference.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Description of the setting difference.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Rule that describes how to process the setting difference during a slot swap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Rule that describes how to process the setting difference during a slot swap.",
        SerializedName = @"diffRule",
        PossibleTypes = new [] { typeof(string) })]
        string DiffRule { get;  }
        /// <summary>Level of the difference: Information, Warning or Error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Level of the difference: Information, Warning or Error.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(string) })]
        string Level { get;  }
        /// <summary>Name of the setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the setting.",
        SerializedName = @"settingName",
        PossibleTypes = new [] { typeof(string) })]
        string SettingName { get;  }
        /// <summary>The type of the setting: General, AppSetting or ConnectionString.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of the setting: General, AppSetting or ConnectionString.",
        SerializedName = @"settingType",
        PossibleTypes = new [] { typeof(string) })]
        string SettingType { get;  }
        /// <summary>Value of the setting in the current slot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value of the setting in the current slot.",
        SerializedName = @"valueInCurrentSlot",
        PossibleTypes = new [] { typeof(string) })]
        string ValueInCurrentSlot { get;  }
        /// <summary>Value of the setting in the target slot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value of the setting in the target slot.",
        SerializedName = @"valueInTargetSlot",
        PossibleTypes = new [] { typeof(string) })]
        string ValueInTargetSlot { get;  }

    }
    /// SlotDifference resource specific properties
    internal partial interface ISlotDifferencePropertiesInternal

    {
        /// <summary>Description of the setting difference.</summary>
        string Description { get; set; }
        /// <summary>Rule that describes how to process the setting difference during a slot swap.</summary>
        string DiffRule { get; set; }
        /// <summary>Level of the difference: Information, Warning or Error.</summary>
        string Level { get; set; }
        /// <summary>Name of the setting.</summary>
        string SettingName { get; set; }
        /// <summary>The type of the setting: General, AppSetting or ConnectionString.</summary>
        string SettingType { get; set; }
        /// <summary>Value of the setting in the current slot.</summary>
        string ValueInCurrentSlot { get; set; }
        /// <summary>Value of the setting in the target slot.</summary>
        string ValueInTargetSlot { get; set; }

    }
}