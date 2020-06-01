namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A setting difference between two deployment slots of an app.</summary>
    public partial class SlotDifference :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifference,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Description of the setting difference.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).Description; }

        /// <summary>Rule that describes how to process the setting difference during a slot swap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DiffRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).DiffRule; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Level of the difference: Information, Warning or Error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Level { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).Level; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).Description = value; }

        /// <summary>Internal Acessors for DiffRule</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceInternal.DiffRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).DiffRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).DiffRule = value; }

        /// <summary>Internal Acessors for Level</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceInternal.Level { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).Level; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).Level = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SlotDifferenceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for SettingName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceInternal.SettingName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).SettingName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).SettingName = value; }

        /// <summary>Internal Acessors for SettingType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceInternal.SettingType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).SettingType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).SettingType = value; }

        /// <summary>Internal Acessors for ValueInCurrentSlot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceInternal.ValueInCurrentSlot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).ValueInCurrentSlot; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).ValueInCurrentSlot = value; }

        /// <summary>Internal Acessors for ValueInTargetSlot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceInternal.ValueInTargetSlot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).ValueInTargetSlot; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).ValueInTargetSlot = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceProperties _property;

        /// <summary>SlotDifference resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SlotDifferenceProperties()); set => this._property = value; }

        /// <summary>Name of the setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SettingName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).SettingName; }

        /// <summary>The type of the setting: General, AppSetting or ConnectionString.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SettingType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).SettingType; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Value of the setting in the current slot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ValueInCurrentSlot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).ValueInCurrentSlot; }

        /// <summary>Value of the setting in the target slot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ValueInTargetSlot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferencePropertiesInternal)Property).ValueInTargetSlot; }

        /// <summary>Creates an new <see cref="SlotDifference" /> instance.</summary>
        public SlotDifference()
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
    /// A setting difference between two deployment slots of an app.
    public partial interface ISlotDifference :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// A setting difference between two deployment slots of an app.
    internal partial interface ISlotDifferenceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Description of the setting difference.</summary>
        string Description { get; set; }
        /// <summary>Rule that describes how to process the setting difference during a slot swap.</summary>
        string DiffRule { get; set; }
        /// <summary>Level of the difference: Information, Warning or Error.</summary>
        string Level { get; set; }
        /// <summary>SlotDifference resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotDifferenceProperties Property { get; set; }
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