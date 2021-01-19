function Initialize-AzDataProtectionTargetRestoreInfo
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Get Backup Vault storage setting object')]

    param(
        [Parameter(Mandatory, ParameterSetName="RestoreAlternateLocation", HelpMessage='Storage Type of the vault')]
        [System.String]
        ${Location},

        [Parameter(Mandatory, ParameterSetName="RestoreAlternateLocation", HelpMessage='Storage Type of the vault')]
        [System.String]
        ${DatasourceId},

        [Parameter(ParameterSetName='RestoreAlternateLocation', Mandatory, HelpMessage='Datasource Type')]
        [System.String]
        [ValidateSet("AzureDatabaseForPostgreSQL", "AzureBlob", IgnoreCase = $true)]
        ${DatasourceType}
    )

    process {

        $manifest = LoadManifest -DatasourceType $DatasourceType
        if(2 -ge 1)
        {
            $restoreTargetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.RestoreTargetInfo]::new()
            $DatasourceInfo = Prepare-AzDataProtectionDatasourceInfo @PSBoundParameters
            $restoreTargetInfo.DatasourceInfo = $DatasourceInfo
            $restoreTargetInfo.RestoreLocation = $Location
            $restoreTargetInfo.ObjectType = "RestoreTargetInfo"
            if($manifest.isProxyResource -eq $true)
            {
                $DatasourceSetInfo = GetDatasourceSetInfo -DatasourceInfo $DatasourceInfo
                $restoreTargetInfo.DatasourceSetInfo = $DatasourceSetInfo
            }
            
            return $restoreTargetInfo
        }


    }
}