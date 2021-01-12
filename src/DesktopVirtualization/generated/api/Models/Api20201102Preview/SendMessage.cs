namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Represents message sent to a UserSession.</summary>
    public partial class SendMessage :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISendMessage,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISendMessageInternal
    {

        /// <summary>Backing field for <see cref="MessageBody" /> property.</summary>
        private string _messageBody;

        /// <summary>Body of message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string MessageBody { get => this._messageBody; set => this._messageBody = value; }

        /// <summary>Backing field for <see cref="MessageTitle" /> property.</summary>
        private string _messageTitle;

        /// <summary>Title of message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string MessageTitle { get => this._messageTitle; set => this._messageTitle = value; }

        /// <summary>Creates an new <see cref="SendMessage" /> instance.</summary>
        public SendMessage()
        {

        }
    }
    /// Represents message sent to a UserSession.
    public partial interface ISendMessage :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Body of message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Body of message.",
        SerializedName = @"messageBody",
        PossibleTypes = new [] { typeof(string) })]
        string MessageBody { get; set; }
        /// <summary>Title of message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Title of message.",
        SerializedName = @"messageTitle",
        PossibleTypes = new [] { typeof(string) })]
        string MessageTitle { get; set; }

    }
    /// Represents message sent to a UserSession.
    internal partial interface ISendMessageInternal

    {
        /// <summary>Body of message.</summary>
        string MessageBody { get; set; }
        /// <summary>Title of message.</summary>
        string MessageTitle { get; set; }

    }
}