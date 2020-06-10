namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Virtual application in an app.</summary>
    public partial class VirtualApplication :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal
    {

        /// <summary>Backing field for <see cref="PhysicalPath" /> property.</summary>
        private string _physicalPath;

        /// <summary>Physical path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PhysicalPath { get => this._physicalPath; set => this._physicalPath = value; }

        /// <summary>Backing field for <see cref="PreloadEnabled" /> property.</summary>
        private bool? _preloadEnabled;

        /// <summary><code>true</code> if preloading is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? PreloadEnabled { get => this._preloadEnabled; set => this._preloadEnabled = value; }

        /// <summary>Backing field for <see cref="VirtualDirectory" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualDirectory[] _virtualDirectory;

        /// <summary>Virtual directories for virtual application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualDirectory[] VirtualDirectory { get => this._virtualDirectory; set => this._virtualDirectory = value; }

        /// <summary>Backing field for <see cref="VirtualPath" /> property.</summary>
        private string _virtualPath;

        /// <summary>Virtual path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VirtualPath { get => this._virtualPath; set => this._virtualPath = value; }

        /// <summary>Creates an new <see cref="VirtualApplication" /> instance.</summary>
        public VirtualApplication()
        {

        }
    }
    /// Virtual application in an app.
    public partial interface IVirtualApplication :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Physical path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Physical path.",
        SerializedName = @"physicalPath",
        PossibleTypes = new [] { typeof(string) })]
        string PhysicalPath { get; set; }
        /// <summary><code>true</code> if preloading is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if preloading is enabled; otherwise, <code>false</code>.",
        SerializedName = @"preloadEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PreloadEnabled { get; set; }
        /// <summary>Virtual directories for virtual application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual directories for virtual application.",
        SerializedName = @"virtualDirectories",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualDirectory) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualDirectory[] VirtualDirectory { get; set; }
        /// <summary>Virtual path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual path.",
        SerializedName = @"virtualPath",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualPath { get; set; }

    }
    /// Virtual application in an app.
    internal partial interface IVirtualApplicationInternal

    {
        /// <summary>Physical path.</summary>
        string PhysicalPath { get; set; }
        /// <summary><code>true</code> if preloading is enabled; otherwise, <code>false</code>.</summary>
        bool? PreloadEnabled { get; set; }
        /// <summary>Virtual directories for virtual application.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualDirectory[] VirtualDirectory { get; set; }
        /// <summary>Virtual path.</summary>
        string VirtualPath { get; set; }

    }
}