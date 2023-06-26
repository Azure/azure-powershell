
function New-AzDataProtectionBackupConfigurationClientObject{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates new backup configuration object')]

    param(
        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        [ValidateSet('AzureKubernetesService', 'AzureBlob')]
        ${DatasourceType},
        
        [Parameter(Mandatory=$false, HelpMessage='List of resource types to be excluded from backup')]
        [System.String[]]
        ${ExcludedResourceType},

        [Parameter(Mandatory=$false, HelpMessage='List of resource types to be included for backup')]
        [System.String[]]
        ${IncludedResourceType},

        [Parameter(Mandatory=$false, HelpMessage='List of namespaces to be excluded from backup')]
        [System.String[]]
        ${ExcludedNamespace},

        [Parameter(Mandatory=$false, HelpMessage='List of namespaces to be included for backup')]
        [System.String[]]
        ${IncludedNamespace},

        [Parameter(Mandatory=$false, HelpMessage='List of labels for internal filtering for backup')]
        [System.String[]]
        ${LabelSelector},

        [Parameter(Mandatory=$false, HelpMessage='Boolean parameter to decide whether snapshot volumes are included for backup. By default this is taken as true.')]        
        [Nullable[System.Boolean]]
        ${SnapshotVolume},

        [Parameter(Mandatory=$false, HelpMessage='Boolean parameter to decide whether cluster scope resources are included for backup. By default this is taken as true.')]        
        [Nullable[System.Boolean]]
        ${IncludeClusterScopeResource},
        
        [Parameter(Mandatory=$false, HelpMessage='List of containers to be backed up inside the VaultStore. Use this parameter for DatasourceType AzureBlob.')]
        [System.String[]]
        ${VaultedBackupContainer},
        
        [Parameter(Mandatory=$false, HelpMessage='Switch parameter to include all containers to be backed up inside the VaultStore. Use this parameter for DatasourceType AzureBlob.')]
        [Switch]
        ${IncludeAllContainer},
        
        [Parameter(Mandatory=$false, HelpMessage='Storage account where the Datasource is present. Use this parameter for DatasourceType AzureBlob.')]
        [System.String]
        ${StorageAccountName},
        
        [Parameter(Mandatory=$false, HelpMessage='Storage account resource group name where the Datasource is present. Use this parameter for DatasourceType AzureBlob.')]
        [System.String]
        ${StorageAccountResourceGroupName}
    )

    process {        
        # need to have parameter validation when this command supports another DatasourceType           
        $dataSourceParam = $null

        if($DatasourceType.ToString() -eq "AzureKubernetesService"){

            # parameter validation
            if($VaultedBackupContainer -ne $null -or $IncludeAllContainer){
                $message = "Invalid parameter VaultedBackupContainer or IncludeAllContainer for given DatasourceType."
                throw $message
            }

            $dataSourceParam = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.KubernetesClusterBackupDatasourceParameters]::new()
            $dataSourceParam.ObjectType = "KubernetesClusterBackupDatasourceParameters"
        
            $dataSourceParam.ExcludedResourceType = $ExcludedResourceType
            $dataSourceParam.IncludedResourceType = $IncludedResourceType
            $dataSourceParam.ExcludedNamespace = $ExcludedNamespace
            $dataSourceParam.IncludedNamespace = $IncludedNamespace
            $dataSourceParam.LabelSelector = $LabelSelector
                        
            if ($SnapshotVolume -ne $null) {
                $dataSourceParam.SnapshotVolume = $SnapshotVolume
            }
            else{
                $dataSourceParam.SnapshotVolume = $true
            }

            if($IncludeClusterScopeResource -ne $null){
                $dataSourceParam.IncludeClusterScopeResource = $IncludeClusterScopeResource
            }
            else{
                $dataSourceParam.IncludeClusterScopeResource = $true        
            }
        }

        if($DatasourceType.ToString() -eq "AzureBlob"){
            $dataSourceParam = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.BlobBackupDatasourceParameters]::new()
            $dataSourceParam.ObjectType = "BlobBackupDatasourceParameters"
            
            if($VaultedBackupContainer -ne $null){
                $dataSourceParam.ContainersList = $VaultedBackupContainer
            }
            elseif($IncludeAllContainer){
                if($StorageAcountName -eq $null -or $StorageAccountResourceGroupName -eq $null){
                    $message = "Please input StorageAcountName and StorageAccountResourceGroupName parameters for fetching all vaulted containers."
                    throw $message
                }

                CheckStorageModuleDependency
                $storageAccount = Get-AzStorageAccount -ResourceGroupName $StorageAccountResourceGroupName -Name $StorageAcountName 
                $containers=Get-AzStorageContainer -Context $storageAccount.Context
                $dataSourceParam.ContainersList = $containers.Name
            }
            elseif($ExcludedResourceType -ne $null -or $IncludedResourceType -ne $null -or $ExcludedNamespace -ne $null -or $IncludedNamespace -ne $null -or $LabelSelector -ne $null -or $SnapshotVolume -ne $null -or $IncludeClusterScopeResource -ne $null){
                $message = "Invalid parameters ExcludedResourceType, IncludedResourceType, ExcludedNamespace, IncludedNamespace, LabelSelector, SnapshotVolume, IncludeClusterScopeResource for given DatasourceType."
                throw $message
            }
            else {
                 $message = "Please input VaultedBackupContainer or IncludeAllContainer parameters for given workload type."
                 throw $message
            }
        }

        $dataSourceParam
    }
}