

function Get-AzDataProtectionPolicyTemplate {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250201.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Gets default policy template for a selected datasource type.')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PreviewMessage("**********************************************************************************************`n
    * This cmdlet will undergo a breaking change in Az v16.0.0, to be released on May 2026. *`n
    * At least one change applies to this cmdlet.                                                     *`n
    * See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486            *`n
    ***************************************************************************************************")]

    param(
        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        ${DatasourceType}
    )

    process {
        $manifest = LoadManifest -DatasourceType $DatasourceType
        
        $manifestPolicyObject = $manifest.policySettings.defaultPolicy
        $jsonPolicyString = $manifestPolicyObject | ConvertTo-Json -Depth 100 
        
        $defaultPolicy = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250201.BackupPolicy]::FromJsonString($jsonPolicyString)

        return $defaultPolicy
    }
}
