

function Get-AzDataProtectionPolicyTemplate {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Prepares Datasource object for backup')]

    param(
        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        ${DatasourceType}
    )

    process {
        $manifest = LoadManifest -DatasourceType $DatasourceType
        $manifestPolicyObject = $manifest.policySettings.defaultPolicy

        $jsonPolicyString = $manifestPolicyObject | ConvertTo-Json -Depth 100
        $defaultPolicy = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.BackupPolicy]::FromJsonString($jsonPolicyString)

        return $defaultPolicy
    }
}
