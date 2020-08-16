namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    /// <summary>Protection Policy input.</summary>
    public partial class CreatePolicyInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreatePolicyInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreatePolicyInputInternal
    {

        /// <summary>Policy creation properties.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreatePolicyInputProperties PropertyDummy { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CreatePolicyInputProperties()); set => this._property = value; }
       
    }
  
}