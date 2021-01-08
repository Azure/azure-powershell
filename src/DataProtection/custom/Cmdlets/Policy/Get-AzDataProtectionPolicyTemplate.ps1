

function Get-AzDataProtectionPolicyTemplate {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Prepares Datasource object for backup')]

    param(
        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [System.String]
        [ValidateSet("AzureDatabaseForPostgreSQL", "AzureBlob", IgnoreCase = $true)]
        # ...
        ${DatasourceType}
    )

    process {
        $manifest = LoadManifest -DatasourceType $DatasourceType
        $manifestPolicyObject = $manifest.policySettings.defaultPolicy

        $defaultPolicy = TranslateBackupPolicy -Policy $manifestPolicyObject

        return $defaultPolicy
    }
}
