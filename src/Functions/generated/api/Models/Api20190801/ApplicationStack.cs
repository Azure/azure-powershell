namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Application stack.</summary>
    public partial class ApplicationStack :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal
    {

        /// <summary>Backing field for <see cref="Dependency" /> property.</summary>
        private string _dependency;

        /// <summary>Application stack dependency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Dependency { get => this._dependency; set => this._dependency = value; }

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private string _display;

        /// <summary>Application stack display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Display { get => this._display; set => this._display = value; }

        /// <summary>Backing field for <see cref="Framework" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack[] _framework;

        /// <summary>List of frameworks associated with application stack.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack[] Framework { get => this._framework; set => this._framework = value; }

        /// <summary>Backing field for <see cref="MajorVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion[] _majorVersion;

        /// <summary>List of major versions available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion[] MajorVersion { get => this._majorVersion; set => this._majorVersion = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Application stack name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="ApplicationStack" /> instance.</summary>
        public ApplicationStack()
        {

        }
    }
    /// Application stack.
    public partial interface IApplicationStack :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
        string Name { get; set; }

    }
    /// Application stack.
    internal partial interface IApplicationStackInternal

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
        string Name { get; set; }

    }
}