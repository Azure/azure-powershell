

function Get-AzDataProtectionPolicyTemplate {
<<<<<<< HEAD
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IBackupPolicy')]
=======
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.IBackupPolicy')]
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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
        
<<<<<<< HEAD
        $defaultPolicy = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.BackupPolicy]::FromJsonString($jsonPolicyString)
=======
        $defaultPolicy = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.BackupPolicy]::FromJsonString($jsonPolicyString)
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91

        return $defaultPolicy
    }
}
