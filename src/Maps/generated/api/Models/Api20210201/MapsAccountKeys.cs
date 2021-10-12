namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>
    /// The set of keys which can be used to access the Maps REST APIs. Two keys are provided for key rotation without interruption.
    /// </summary>
    public partial class MapsAccountKeys :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeys,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeysInternal
    {

        /// <summary>Internal Acessors for PrimaryKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeysInternal.PrimaryKey { get => this._primaryKey; set { {_primaryKey = value;} } }

        /// <summary>Internal Acessors for PrimaryKeyLastUpdated</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeysInternal.PrimaryKeyLastUpdated { get => this._primaryKeyLastUpdated; set { {_primaryKeyLastUpdated = value;} } }

        /// <summary>Internal Acessors for SecondaryKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeysInternal.SecondaryKey { get => this._secondaryKey; set { {_secondaryKey = value;} } }

        /// <summary>Internal Acessors for SecondaryKeyLastUpdated</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeysInternal.SecondaryKeyLastUpdated { get => this._secondaryKeyLastUpdated; set { {_secondaryKeyLastUpdated = value;} } }

        /// <summary>Backing field for <see cref="PrimaryKey" /> property.</summary>
        private string _primaryKey;

        /// <summary>The primary key for accessing the Maps REST APIs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string PrimaryKey { get => this._primaryKey; }

        /// <summary>Backing field for <see cref="PrimaryKeyLastUpdated" /> property.</summary>
        private string _primaryKeyLastUpdated;

        /// <summary>The last updated date and time of the primary key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string PrimaryKeyLastUpdated { get => this._primaryKeyLastUpdated; }

        /// <summary>Backing field for <see cref="SecondaryKey" /> property.</summary>
        private string _secondaryKey;

        /// <summary>The secondary key for accessing the Maps REST APIs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string SecondaryKey { get => this._secondaryKey; }

        /// <summary>Backing field for <see cref="SecondaryKeyLastUpdated" /> property.</summary>
        private string _secondaryKeyLastUpdated;

        /// <summary>The last updated date and time of the secondary key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string SecondaryKeyLastUpdated { get => this._secondaryKeyLastUpdated; }

        /// <summary>Creates an new <see cref="MapsAccountKeys" /> instance.</summary>
        public MapsAccountKeys()
        {

        }
    }
    /// The set of keys which can be used to access the Maps REST APIs. Two keys are provided for key rotation without interruption.
    public partial interface IMapsAccountKeys :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>The primary key for accessing the Maps REST APIs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The primary key for accessing the Maps REST APIs.",
        SerializedName = @"primaryKey",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryKey { get;  }
        /// <summary>The last updated date and time of the primary key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The last updated date and time of the primary key.",
        SerializedName = @"primaryKeyLastUpdated",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryKeyLastUpdated { get;  }
        /// <summary>The secondary key for accessing the Maps REST APIs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The secondary key for accessing the Maps REST APIs.",
        SerializedName = @"secondaryKey",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryKey { get;  }
        /// <summary>The last updated date and time of the secondary key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The last updated date and time of the secondary key.",
        SerializedName = @"secondaryKeyLastUpdated",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryKeyLastUpdated { get;  }

    }
    /// The set of keys which can be used to access the Maps REST APIs. Two keys are provided for key rotation without interruption.
    internal partial interface IMapsAccountKeysInternal

    {
        /// <summary>The primary key for accessing the Maps REST APIs.</summary>
        string PrimaryKey { get; set; }
        /// <summary>The last updated date and time of the primary key.</summary>
        string PrimaryKeyLastUpdated { get; set; }
        /// <summary>The secondary key for accessing the Maps REST APIs.</summary>
        string SecondaryKey { get; set; }
        /// <summary>The last updated date and time of the secondary key.</summary>
        string SecondaryKeyLastUpdated { get; set; }

    }
}