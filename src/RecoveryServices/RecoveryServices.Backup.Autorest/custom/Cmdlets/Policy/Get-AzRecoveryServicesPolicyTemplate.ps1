﻿

function Get-AzRecoveryServicesPolicyTemplate {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectionPolicy')]
    [CmdletBinding(PositionalBinding=$false)]    
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Gets default policy template for a selected datasource type.')]    

    param(
        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        ${DatasourceType}
    )

    process {
        $manifest = LoadManifest -DatasourceType $DatasourceType
        $manifestPolicyObject = $manifest.policySettings.defaultPolicy
        
        $jsonPolicyString = $manifestPolicyObject | ConvertTo-Json -Depth 100 
        $defaultPolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectionPolicy]::FromJsonString($jsonPolicyString)

        return $defaultPolicy
    }
}
