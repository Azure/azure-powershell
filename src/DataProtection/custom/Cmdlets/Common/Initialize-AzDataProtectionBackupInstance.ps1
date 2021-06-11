


function Initialize-AzDataProtectionBackupInstance {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceResource')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Initializes Backup instance Request object for configuring backup')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Policy Id to be assiciated to Datasource')]
        [System.String]
        [ValidatePattern("/subscriptions/([A-z0-9\-]+)/resourceGroups/(?<rg>.+)/providers/(?<provider>.+)/backupVaults/(?<vault>.+)/backupPolicies/(?<name>.+)")]
        ${PolicyId},

        [Parameter(Mandatory=$false, HelpMessage='ID of the datasource to be protected')]
        [System.String]
        [ValidatePattern("/subscriptions/([A-z0-9\-]+)/resourceGroups/(?<rg>.+)/(?<id>.+)")]
        ${DatasourceId},

        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(Mandatory, HelpMessage='Location of the Datasource to be protected.')]
        [System.String]
        ${DatasourceLocation}
    )

    process {

        $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
        $backupInstance = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupInstance]::new()
        $backupInstance.ObjectType = "BackupInstance"

        if($PSBoundParameters.ContainsKey("DatasourceId"))
        {
            $backupInstance.DataSourceInfo = GetDatasourceInfo -ResourceId $DatasourceId -ResourceLocation $DatasourceLocation -DatasourceType $DatasourceType

            if($manifest.isProxyResource -eq $true)
            {
                $backupInstance.DataSourceSetInfo = GetDatasourceSetInfo -DatasourceInfo $backupInstance.DataSourceInfo
            }
            $backupInstance.FriendlyName = $backupInstance.DataSourceInfo.ResourceName
        }

        if($PSBoundParameters.ContainsKey("PolicyId"))
        {
            $backupInstance.PolicyInfo.PolicyId = $PolicyId
        }



        $backupInstanceResource = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupInstanceResource]::new()
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

        if($DatasourceType.ToString() -eq "AzureDisk")
        {
            $operationalParam = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureOperationalStoreParameters]::new()
            $operationalParam.DataStoreType = "OperationalStore"
            $operationalParam.ObjectType = "AzureOperationalStoreParameters"
            $operationalParam.ResourceGroupId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}"
            $backupInstanceResource.Property.PolicyInfo.PolicyParameter.DataStoreParametersList += @($operationalParam)
        }

        return $backupInstanceResource
       
        #/subscriptions/e3d2d341-4ddb-4c5d-9121-69b7e719485e/resourceGroups/sarath-dpprg/providers/Microsoft.Storage/storageAccounts/sarathblobsa
    }
}