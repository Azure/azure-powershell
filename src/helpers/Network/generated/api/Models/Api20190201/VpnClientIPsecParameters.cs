namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>An IPSec parameters for a virtual network gateway P2S connection.</summary>
    public partial class VpnClientIPsecParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientIPsecParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientIPsecParametersInternal
    {

        /// <summary>Backing field for <see cref="DhGroup" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup _dhGroup;

        /// <summary>The DH Group used in IKE Phase 1 for initial SA.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup DhGroup { get => this._dhGroup; set => this._dhGroup = value; }

        /// <summary>Backing field for <see cref="IkeEncryption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption _ikeEncryption;

        /// <summary>The IKE encryption algorithm (IKE phase 2).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption IkeEncryption { get => this._ikeEncryption; set => this._ikeEncryption = value; }

        /// <summary>Backing field for <see cref="IkeIntegrity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity _ikeIntegrity;

        /// <summary>The IKE integrity algorithm (IKE phase 2).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity IkeIntegrity { get => this._ikeIntegrity; set => this._ikeIntegrity = value; }

        /// <summary>Backing field for <see cref="IpsecEncryption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption _ipsecEncryption;

        /// <summary>The IPSec encryption algorithm (IKE phase 1).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption IpsecEncryption { get => this._ipsecEncryption; set => this._ipsecEncryption = value; }

        /// <summary>Backing field for <see cref="IpsecIntegrity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity _ipsecIntegrity;

        /// <summary>The IPSec integrity algorithm (IKE phase 1).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity IpsecIntegrity { get => this._ipsecIntegrity; set => this._ipsecIntegrity = value; }

        /// <summary>Backing field for <see cref="PfsGroup" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup _pfsGroup;

        /// <summary>The Pfs Group used in IKE Phase 2 for new child SA.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup PfsGroup { get => this._pfsGroup; set => this._pfsGroup = value; }

        /// <summary>Backing field for <see cref="SaDataSizeKilobyte" /> property.</summary>
        private int _saDataSizeKilobyte;

        /// <summary>
        /// The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for P2S client..
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int SaDataSizeKilobyte { get => this._saDataSizeKilobyte; set => this._saDataSizeKilobyte = value; }

        /// <summary>Backing field for <see cref="SaLifeTimeSecond" /> property.</summary>
        private int _saLifeTimeSecond;

        /// <summary>
        /// The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for P2S client.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int SaLifeTimeSecond { get => this._saLifeTimeSecond; set => this._saLifeTimeSecond = value; }

        /// <summary>Creates an new <see cref="VpnClientIPsecParameters" /> instance.</summary>
        public VpnClientIPsecParameters()
        {

        }
    }
    /// An IPSec parameters for a virtual network gateway P2S connection.
    public partial interface IVpnClientIPsecParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The DH Group used in IKE Phase 1 for initial SA.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The DH Group used in IKE Phase 1 for initial SA.",
        SerializedName = @"dhGroup",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup DhGroup { get; set; }
        /// <summary>The IKE encryption algorithm (IKE phase 2).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The IKE encryption algorithm (IKE phase 2).",
        SerializedName = @"ikeEncryption",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption IkeEncryption { get; set; }
        /// <summary>The IKE integrity algorithm (IKE phase 2).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The IKE integrity algorithm (IKE phase 2).",
        SerializedName = @"ikeIntegrity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity IkeIntegrity { get; set; }
        /// <summary>The IPSec encryption algorithm (IKE phase 1).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The IPSec encryption algorithm (IKE phase 1).",
        SerializedName = @"ipsecEncryption",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption IpsecEncryption { get; set; }
        /// <summary>The IPSec integrity algorithm (IKE phase 1).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The IPSec integrity algorithm (IKE phase 1).",
        SerializedName = @"ipsecIntegrity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity IpsecIntegrity { get; set; }
        /// <summary>The Pfs Group used in IKE Phase 2 for new child SA.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Pfs Group used in IKE Phase 2 for new child SA.",
        SerializedName = @"pfsGroup",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup PfsGroup { get; set; }
        /// <summary>
        /// The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for P2S client..
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for P2S client..",
        SerializedName = @"saDataSizeKilobytes",
        PossibleTypes = new [] { typeof(int) })]
        int SaDataSizeKilobyte { get; set; }
        /// <summary>
        /// The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for P2S client.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for P2S client.",
        SerializedName = @"saLifeTimeSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int SaLifeTimeSecond { get; set; }

    }
    /// An IPSec parameters for a virtual network gateway P2S connection.
    internal partial interface IVpnClientIPsecParametersInternal

    {
        /// <summary>The DH Group used in IKE Phase 1 for initial SA.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup DhGroup { get; set; }
        /// <summary>The IKE encryption algorithm (IKE phase 2).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption IkeEncryption { get; set; }
        /// <summary>The IKE integrity algorithm (IKE phase 2).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity IkeIntegrity { get; set; }
        /// <summary>The IPSec encryption algorithm (IKE phase 1).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption IpsecEncryption { get; set; }
        /// <summary>The IPSec integrity algorithm (IKE phase 1).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity IpsecIntegrity { get; set; }
        /// <summary>The Pfs Group used in IKE Phase 2 for new child SA.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup PfsGroup { get; set; }
        /// <summary>
        /// The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for P2S client..
        /// </summary>
        int SaDataSizeKilobyte { get; set; }
        /// <summary>
        /// The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for P2S client.
        /// </summary>
        int SaLifeTimeSecond { get; set; }

    }
}