namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>A container group or container instance event.</summary>
    public partial class Event :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEventInternal
    {

        /// <summary>Backing field for <see cref="Count" /> property.</summary>
        private int? _count;

        /// <summary>The count of the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? Count { get => this._count; }

        /// <summary>Backing field for <see cref="FirstTimestamp" /> property.</summary>
        private global::System.DateTime? _firstTimestamp;

        /// <summary>The date-time of the earliest logged event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public global::System.DateTime? FirstTimestamp { get => this._firstTimestamp; }

        /// <summary>Backing field for <see cref="LastTimestamp" /> property.</summary>
        private global::System.DateTime? _lastTimestamp;

        /// <summary>The date-time of the latest logged event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public global::System.DateTime? LastTimestamp { get => this._lastTimestamp; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The event message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for Count</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEventInternal.Count { get => this._count; set { {_count = value;} } }

        /// <summary>Internal Acessors for FirstTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEventInternal.FirstTimestamp { get => this._firstTimestamp; set { {_firstTimestamp = value;} } }

        /// <summary>Internal Acessors for LastTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEventInternal.LastTimestamp { get => this._lastTimestamp; set { {_lastTimestamp = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEventInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEventInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEventInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The event name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The event type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="Event" /> instance.</summary>
        public Event()
        {

        }
    }
    /// A container group or container instance event.
    public partial interface IEvent :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The count of the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The count of the event.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? Count { get;  }
        /// <summary>The date-time of the earliest logged event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date-time of the earliest logged event.",
        SerializedName = @"firstTimestamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? FirstTimestamp { get;  }
        /// <summary>The date-time of the latest logged event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date-time of the latest logged event.",
        SerializedName = @"lastTimestamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastTimestamp { get;  }
        /// <summary>The event message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The event message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>The event name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The event name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The event type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The event type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// A container group or container instance event.
    internal partial interface IEventInternal

    {
        /// <summary>The count of the event.</summary>
        int? Count { get; set; }
        /// <summary>The date-time of the earliest logged event.</summary>
        global::System.DateTime? FirstTimestamp { get; set; }
        /// <summary>The date-time of the latest logged event.</summary>
        global::System.DateTime? LastTimestamp { get; set; }
        /// <summary>The event message.</summary>
        string Message { get; set; }
        /// <summary>The event name.</summary>
        string Name { get; set; }
        /// <summary>The event type.</summary>
        string Type { get; set; }

    }
}