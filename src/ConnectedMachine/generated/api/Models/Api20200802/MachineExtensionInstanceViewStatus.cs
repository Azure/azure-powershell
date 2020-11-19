namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Instance view status.</summary>
    public partial class MachineExtensionInstanceViewStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewStatus,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewStatusInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The status code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="DisplayStatus" /> property.</summary>
        private string _displayStatus;

        /// <summary>The short localizable label for the status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string DisplayStatus { get => this._displayStatus; }

        /// <summary>Backing field for <see cref="Level" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes? _level;

        /// <summary>The level code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes? Level { get => this._level; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The detailed status message, including for alerts and error messages.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewStatusInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for DisplayStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewStatusInternal.DisplayStatus { get => this._displayStatus; set { {_displayStatus = value;} } }

        /// <summary>Internal Acessors for Level</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewStatusInternal.Level { get => this._level; set { {_level = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewStatusInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for Time</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewStatusInternal.Time { get => this._time; set { {_time = value;} } }

        /// <summary>Backing field for <see cref="Time" /> property.</summary>
        private global::System.DateTime? _time;

        /// <summary>The time of the status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public global::System.DateTime? Time { get => this._time; }

        /// <summary>Creates an new <see cref="MachineExtensionInstanceViewStatus" /> instance.</summary>
        public MachineExtensionInstanceViewStatus()
        {

        }
    }
    /// Instance view status.
    public partial interface IMachineExtensionInstanceViewStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {
        /// <summary>The status code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>The short localizable label for the status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The short localizable label for the status.",
        SerializedName = @"displayStatus",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayStatus { get;  }
        /// <summary>The level code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The level code.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes? Level { get;  }
        /// <summary>The detailed status message, including for alerts and error messages.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The detailed status message, including for alerts and error messages.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>The time of the status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time of the status.",
        SerializedName = @"time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Time { get;  }

    }
    /// Instance view status.
    internal partial interface IMachineExtensionInstanceViewStatusInternal

    {
        /// <summary>The status code.</summary>
        string Code { get; set; }
        /// <summary>The short localizable label for the status.</summary>
        string DisplayStatus { get; set; }
        /// <summary>The level code.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes? Level { get; set; }
        /// <summary>The detailed status message, including for alerts and error messages.</summary>
        string Message { get; set; }
        /// <summary>The time of the status.</summary>
        global::System.DateTime? Time { get; set; }

    }
}