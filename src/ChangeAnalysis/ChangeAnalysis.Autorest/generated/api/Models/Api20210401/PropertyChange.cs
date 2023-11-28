namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Extensions;

    /// <summary>Data of a property change.</summary>
    public partial class PropertyChange :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange,
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal
    {

        /// <summary>Backing field for <see cref="ChangeCategory" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeCategory? _changeCategory;

        /// <summary>The change category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeCategory? ChangeCategory { get => this._changeCategory; set => this._changeCategory = value; }

        /// <summary>Backing field for <see cref="ChangeType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType? _changeType;

        /// <summary>The type of the change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType? ChangeType { get => this._changeType; set => this._changeType = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description of the changed property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>
        /// The enhanced display name of the json path. E.g., the json path value[0].properties will be translated to something meaningful
        /// like slots["Staging"].properties.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="IsDataMasked" /> property.</summary>
        private bool? _isDataMasked;

        /// <summary>
        /// The boolean indicating whether the oldValue and newValue are masked. The values are masked if it contains sensitive information
        /// that the user doesn't have access to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public bool? IsDataMasked { get => this._isDataMasked; set => this._isDataMasked = value; }

        /// <summary>Backing field for <see cref="JsonPath" /> property.</summary>
        private string _jsonPath;

        /// <summary>The json path of the changed property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public string JsonPath { get => this._jsonPath; set => this._jsonPath = value; }

        /// <summary>Backing field for <see cref="Level" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.Level? _level;

        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.Level? Level { get => this._level; set => this._level = value; }

        /// <summary>Backing field for <see cref="NewValue" /> property.</summary>
        private string _newValue;

        /// <summary>The value of the property after the change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public string NewValue { get => this._newValue; set => this._newValue = value; }

        /// <summary>Backing field for <see cref="OldValue" /> property.</summary>
        private string _oldValue;

        /// <summary>The value of the property before the change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public string OldValue { get => this._oldValue; set => this._oldValue = value; }

        /// <summary>Creates an new <see cref="PropertyChange" /> instance.</summary>
        public PropertyChange()
        {

        }
    }
    /// Data of a property change.
    public partial interface IPropertyChange :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.IJsonSerializable
    {
        /// <summary>The change category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The change category.",
        SerializedName = @"changeCategory",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeCategory) })]
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeCategory? ChangeCategory { get; set; }
        /// <summary>The type of the change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the change.",
        SerializedName = @"changeType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType? ChangeType { get; set; }
        /// <summary>The description of the changed property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description of the changed property.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>
        /// The enhanced display name of the json path. E.g., the json path value[0].properties will be translated to something meaningful
        /// like slots["Staging"].properties.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The enhanced display name of the json path. E.g., the json path value[0].properties will be translated to something meaningful like slots[""Staging""].properties.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>
        /// The boolean indicating whether the oldValue and newValue are masked. The values are masked if it contains sensitive information
        /// that the user doesn't have access to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The boolean indicating whether the oldValue and newValue are masked. The values are masked if it contains sensitive information that the user doesn't have access to.",
        SerializedName = @"isDataMasked",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDataMasked { get; set; }
        /// <summary>The json path of the changed property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The json path of the changed property.",
        SerializedName = @"jsonPath",
        PossibleTypes = new [] { typeof(string) })]
        string JsonPath { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.Level) })]
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.Level? Level { get; set; }
        /// <summary>The value of the property after the change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of the property after the change.",
        SerializedName = @"newValue",
        PossibleTypes = new [] { typeof(string) })]
        string NewValue { get; set; }
        /// <summary>The value of the property before the change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of the property before the change.",
        SerializedName = @"oldValue",
        PossibleTypes = new [] { typeof(string) })]
        string OldValue { get; set; }

    }
    /// Data of a property change.
    internal partial interface IPropertyChangeInternal

    {
        /// <summary>The change category.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeCategory? ChangeCategory { get; set; }
        /// <summary>The type of the change.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType? ChangeType { get; set; }
        /// <summary>The description of the changed property.</summary>
        string Description { get; set; }
        /// <summary>
        /// The enhanced display name of the json path. E.g., the json path value[0].properties will be translated to something meaningful
        /// like slots["Staging"].properties.
        /// </summary>
        string DisplayName { get; set; }
        /// <summary>
        /// The boolean indicating whether the oldValue and newValue are masked. The values are masked if it contains sensitive information
        /// that the user doesn't have access to.
        /// </summary>
        bool? IsDataMasked { get; set; }
        /// <summary>The json path of the changed property.</summary>
        string JsonPath { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.Level? Level { get; set; }
        /// <summary>The value of the property after the change.</summary>
        string NewValue { get; set; }
        /// <summary>The value of the property before the change.</summary>
        string OldValue { get; set; }

    }
}