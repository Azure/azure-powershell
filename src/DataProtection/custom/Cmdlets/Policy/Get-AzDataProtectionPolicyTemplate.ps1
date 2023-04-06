

function Get-AzDataProtectionPolicyTemplate {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Gets default policy template for a selected datasource type.')]

    param(
        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        ${DatasourceType}
    )

    process {
        $manifest = LoadManifest -DatasourceType $DatasourceType
        
        $manifestPolicyObject = $manifest.policySettings.defaultPolicy
        $jsonPolicyString = $manifestPolicyObject | ConvertTo-Json -Depth 100 
        
        $defaultPolicy = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.BackupPolicy]::FromJsonString($jsonPolicyString)

        return $defaultPolicy
    }
}
