namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The instance view of the container group. Only valid in response.</summary>
    public partial class ContainerGroupPropertiesInstanceView :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceViewInternal
    {

        /// <summary>Backing field for <see cref="Event" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] _event;

        /// <summary>The events of this container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Event { get => this._event; }

        /// <summary>Internal Acessors for Event</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceViewInternal.Event { get => this._event; set { {_event = value;} } }

        /// <summary>Internal Acessors for State</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceViewInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>The state of the container group. Only valid in response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string State { get => this._state; }

        /// <summary>Creates an new <see cref="ContainerGroupPropertiesInstanceView" /> instance.</summary>
        public ContainerGroupPropertiesInstanceView()
        {

        }
    }
    /// The instance view of the container group. Only valid in response.
    public partial interface IContainerGroupPropertiesInstanceView :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The events of this container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The events of this container group.",
        SerializedName = @"events",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Event { get;  }
        /// <summary>The state of the container group. Only valid in response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the container group. Only valid in response.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get;  }

    }
    /// The instance view of the container group. Only valid in response.
    internal partial interface IContainerGroupPropertiesInstanceViewInternal

    {
        /// <summary>The events of this container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Event { get; set; }
        /// <summary>The state of the container group. Only valid in response.</summary>
        string State { get; set; }

    }
}