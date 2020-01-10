namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    public partial class IpsecPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicyInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicy"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicy __ipsecPolicy = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IpsecPolicy();

        /// <summary>The DH Group used in IKE Phase 1 for initial SA.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup DhGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).DhGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).DhGroup = value; }

        /// <summary>The IKE encryption algorithm (IKE phase 2).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption IkeEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).IkeEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).IkeEncryption = value; }

        /// <summary>The IKE integrity algorithm (IKE phase 2).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity IkeIntegrity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).IkeIntegrity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).IkeIntegrity = value; }

        /// <summary>The IPSec encryption algorithm (IKE phase 1).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption IpsecEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).IpsecEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).IpsecEncryption = value; }

        /// <summary>The IPSec integrity algorithm (IKE phase 1).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity IpsecIntegrity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).IpsecIntegrity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).IpsecIntegrity = value; }

        /// <summary>The Pfs Group used in IKE Phase 2 for new child SA.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup PfsGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).PfsGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).PfsGroup = value; }

        /// <summary>
        /// The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public int SaDataSizeKilobyte { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).SaDataSizeKilobyte; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).SaDataSizeKilobyte = value; }

        /// <summary>
        /// The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public int SaLifeTimeSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).SaLifeTimeSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal)__ipsecPolicy).SaLifeTimeSecond = value; }

        /// <summary>Creates an new <see cref="IpsecPolicy" /> instance.</summary>
        public IpsecPolicy()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__ipsecPolicy), __ipsecPolicy);
            await eventListener.AssertObjectIsValid(nameof(__ipsecPolicy), __ipsecPolicy);
        }
    }
    public partial interface IIpsecPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicy
    {

    }
    internal partial interface IIpsecPolicyInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicyInternal
    {

    }
}