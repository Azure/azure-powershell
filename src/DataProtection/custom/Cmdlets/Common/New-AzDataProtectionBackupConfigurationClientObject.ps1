
function New-AzDataProtectionBackupConfigurationClientObject{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates new backup configuration object')]

    param(
        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        [ValidateSet('AzureKubernetesService')]
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
        ${IncludeClusterScopeResource}
    )

    process {        
        # need to have parameter validation when this command supports another DatasourceType 

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

        $dataSourceParam
    }
}