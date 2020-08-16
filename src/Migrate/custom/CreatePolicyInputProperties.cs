namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Policy creation properties.</summary>
    public partial class CreatePolicyInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreatePolicyInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreatePolicyInputPropertiesInternal
    {

        /// <summary>The ReplicationProviderSettings.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInput ProviderSpecificInputDummy { get => (this._providerSpecificInput = this._providerSpecificInput ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.PolicyProviderSpecificInput()); set => this._providerSpecificInput = value; }
        
    }
}