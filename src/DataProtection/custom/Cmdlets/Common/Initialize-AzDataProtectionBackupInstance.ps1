


function Initialize-AzDataProtectionBackupInstance {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupInstanceResource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Prepares Backup instance object for backup')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Policy Id to be assiciated to Datasource')]
        [System.String]
        ${PolicyId},

        [Parameter(Mandatory=$false, HelpMessage='ARM ID of the datasource to be protected')]
        [System.String]
        ${DatasourceId},

        [Parameter( Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        [ValidateSet("AzureDatabaseForPostgreSQL", "AzureBlob", IgnoreCase = $true)]
        ${DatasourceType}
    )

    process {

        $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
        $backupInstance = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.BackupInstance]::new()
        $backupInstance.ObjectType = "BackupInstance"

        if($PSBoundParameters.ContainsKey("DatasourceId"))
        {
            $backupInstance.DataSourceInfo.ObjectType = "Datasource"
            $backupInstance.DataSourceInfo.ResourceId = $DatasourceId
            $backupInstance.DataSourceInfo.ResourceLocation = ""
            $backupInstance.DataSourceInfo.ResourceName = $DatasourceId.Split("/")[-1]
            $backupInstance.DataSourceInfo.ResourceType = $manifest.resourceType
            $backupInstance.DataSourceInfo.ResourceUri = ""
            if($manifest.isProxyResource -eq $false)
            {
                $backupInstance.DataSourceInfo.ResourceUri = $DatasourceId
            }
            $backupInstance.DataSourceInfo.Type = $manifest.datasourceType

            if($manifest.isProxyResource -eq $true)
            {
                $backupInstance.DataSourceSetInfo = GetDatasourceSetInfo -DatasourceInfo $backupInstance.DataSourceInfo
            }
        }

        if($PSBoundParameters.ContainsKey("PolicyId"))
        {
            $backupInstance.PolicyInfo.PolicyId = $PolicyId
        }



        $backupInstanceResource = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.BackupInstanceResource]::new()
        $backupInstanceResource.Property = $backupInstance

        if($PSBoundParameters.ContainsKey("DatasourceId"))
        {
            $guid = (New-Guid).Guid
            $name = ""
            if($backupInstance.DataSourceSetInfo.ResourceId -eq $null){
                $name = $backupInstance.DataSourceInfo.ResourceName + "-" + $backupInstance.DatasourceInfo.ResourceName + "-" + $guid
            } else {
                $name = $backupInstance.DataSourceSetInfo.ResourceName + "-" + $backupInstance.DatasourceInfo.ResourceName + "-" + $guid
            }

            $backupInstanceResource.BackupInstanceName = $name
        }

        return $backupInstanceResource
       
        #/subscriptions/e3d2d341-4ddb-4c5d-9121-69b7e719485e/resourceGroups/sarath-dpprg/providers/Microsoft.Storage/storageAccounts/sarathblobsa
    }
}