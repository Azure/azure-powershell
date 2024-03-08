# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicySetDefinitionVersion'

Describe 'GetPolicySetDefinitionVersion' {
	It 'Environment' {
		{
			Write-Host "TenantId       : [$($env.Tenant)]"
			Write-Host "SubscriptionId : [$($env.SubscriptionId)]"
			Write-Host "RandomName     : [$(Get-RandomName)]"
		} | Should -Not -Throw
	}
}