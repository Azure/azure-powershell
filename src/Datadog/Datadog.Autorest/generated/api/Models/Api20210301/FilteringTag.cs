namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>
    /// The definition of a filtering tag. Filtering tags are used for capturing resources and include/exclude them from being
    /// monitored.
    /// </summary>
    public partial class FilteringTag :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTagInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.TagAction? _action;

        /// <summary>Valid actions for a filtering tag. Exclusion takes priority over inclusion.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.TagAction? Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name (also known as the key) of the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>The value of the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="FilteringTag" /> instance.</summary>
        public FilteringTag()
        {

        }
    }
    /// The definition of a filtering tag. Filtering tags are used for capturing resources and include/exclude them from being
    /// monitored.
    public partial interface IFilteringTag :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>Valid actions for a filtering tag. Exclusion takes priority over inclusion.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Valid actions for a filtering tag. Exclusion takes priority over inclusion.",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.TagAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.TagAction? Action { get; set; }
        /// <summary>The name (also known as the key) of the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name (also known as the key) of the tag.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The value of the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of the tag.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// The definition of a filtering tag. Filtering tags are used for capturing resources and include/exclude them from being
    /// monitored.
    internal partial interface IFilteringTagInternal

    {
        /// <summary>Valid actions for a filtering tag. Exclusion takes priority over inclusion.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.TagAction? Action { get; set; }
        /// <summary>The name (also known as the key) of the tag.</summary>
        string Name { get; set; }
        /// <summary>The value of the tag.</summary>
        string Value { get; set; }

    }
}