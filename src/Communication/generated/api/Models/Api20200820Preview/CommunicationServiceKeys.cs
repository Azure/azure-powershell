namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>A class representing the access keys of a CommunicationService.</summary>
    public partial class CommunicationServiceKeys :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceKeys,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceKeysInternal
    {

        /// <summary>Backing field for <see cref="PrimaryConnectionString" /> property.</summary>
        private string _primaryConnectionString;

        /// <summary>CommunicationService connection string constructed via the primaryKey</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string PrimaryConnectionString { get => this._primaryConnectionString; set => this._primaryConnectionString = value; }

        /// <summary>Backing field for <see cref="PrimaryKey" /> property.</summary>
        private string _primaryKey;

        /// <summary>The primary access key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string PrimaryKey { get => this._primaryKey; set => this._primaryKey = value; }

        /// <summary>Backing field for <see cref="SecondaryConnectionString" /> property.</summary>
        private string _secondaryConnectionString;

        /// <summary>CommunicationService connection string constructed via the secondaryKey</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string SecondaryConnectionString { get => this._secondaryConnectionString; set => this._secondaryConnectionString = value; }

        /// <summary>Backing field for <see cref="SecondaryKey" /> property.</summary>
        private string _secondaryKey;

        /// <summary>The secondary access key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string SecondaryKey { get => this._secondaryKey; set => this._secondaryKey = value; }

        /// <summary>Creates an new <see cref="CommunicationServiceKeys" /> instance.</summary>
        public CommunicationServiceKeys()
        {

        }
    }
    /// A class representing the access keys of a CommunicationService.
    public partial interface ICommunicationServiceKeys :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
        /// <summary>CommunicationService connection string constructed via the primaryKey</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"CommunicationService connection string constructed via the primaryKey",
        SerializedName = @"primaryConnectionString",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryConnectionString { get; set; }
        /// <summary>The primary access key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary access key.",
        SerializedName = @"primaryKey",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryKey { get; set; }
        /// <summary>CommunicationService connection string constructed via the secondaryKey</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"CommunicationService connection string constructed via the secondaryKey",
        SerializedName = @"secondaryConnectionString",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryConnectionString { get; set; }
        /// <summary>The secondary access key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secondary access key.",
        SerializedName = @"secondaryKey",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryKey { get; set; }

    }
    /// A class representing the access keys of a CommunicationService.
    internal partial interface ICommunicationServiceKeysInternal

    {
        /// <summary>CommunicationService connection string constructed via the primaryKey</summary>
        string PrimaryConnectionString { get; set; }
        /// <summary>The primary access key.</summary>
        string PrimaryKey { get; set; }
        /// <summary>CommunicationService connection string constructed via the secondaryKey</summary>
        string SecondaryConnectionString { get; set; }
        /// <summary>The secondary access key.</summary>
        string SecondaryKey { get; set; }

    }
}