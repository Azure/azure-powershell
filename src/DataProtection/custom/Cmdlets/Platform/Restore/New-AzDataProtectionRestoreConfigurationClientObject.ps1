
function New-AzDataProtectionRestoreConfigurationClientObject{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates new restore configuration object')]

    param(
        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        [ValidateSet('AzureKubernetesService')]
        ${DatasourceType},
        
        [Parameter(Mandatory=$false, HelpMessage='List of resource types to be excluded for restore')]
        [System.String[]]
        ${ExcludedResourceType},

        [Parameter(Mandatory=$false, HelpMessage='List of resource types to be included for restore')]
        [System.String[]]
        ${IncludedResourceType},

        [Parameter(Mandatory=$false, HelpMessage='List of namespaces to be excluded for restore')]
        [System.String[]]
        ${ExcludedNamespace},

        [Parameter(Mandatory=$false, HelpMessage='List of namespaces to be included for restore')]
        [System.String[]]
        ${IncludedNamespace},

        [Parameter(Mandatory=$false, HelpMessage='List of labels for internal filtering for restore')]
        [System.String[]]
        ${LabelSelector},

        [Parameter(Mandatory=$false, HelpMessage='Boolean parameter to decide whether cluster scope resources are included for restore. By default this is taken as true.')]
        [Nullable[System.Boolean]]
        ${IncludeClusterScopeResource},

        [Parameter(Mandatory=$false, HelpMessage='Conflict policy for restore. Allowed values are Skip, Patch. Default value is Skip')]        
        [System.String]
        [ValidateSet('Skip','Patch')]
        ${ConflictPolicy},

        [Parameter(Mandatory=$false, HelpMessage='Namespaces mapping from source namespaces to target namespaces to resolve namespace naming conflicts in the target cluster.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.KubernetesClusterRestoreCriteriaNamespaceMappings]
        ${NamespaceMapping},

        [Parameter(Mandatory=$false, HelpMessage='Restore mode for persistent volumes. Allowed values are RestoreWithVolumeData, RestoreWithoutVolumeData. Default value is RestoreWithVolumeData')]
        [System.String]
        [ValidateSet('RestoreWithVolumeData','RestoreWithoutVolumeData')]
        ${PersistentVolumeRestoreMode}
    )

    process {
        $restoreCriteria =  [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.KubernetesClusterRestoreCriteria]::new()
        $restoreCriteria.ObjectType = "KubernetesClusterRestoreCriteria"

        $restoreCriteria.ExcludedResourceType = $ExcludedResourceType
        $restoreCriteria.IncludedResourceType = $IncludedResourceType
        $restoreCriteria.ExcludedNamespace = $ExcludedNamespace
        $restoreCriteria.IncludedNamespace = $IncludedNamespace
        $restoreCriteria.LabelSelector = $LabelSelector
        $restoreCriteria.NamespaceMapping = $NamespaceMapping
                
        if($IncludeClusterScopeResource -ne $null) {
            $restoreCriteria.IncludeClusterScopeResource =  $IncludeClusterScopeResource
        }
        else {
            $restoreCriteria.IncludeClusterScopeResource = $true
        } 

        if($ConflictPolicy -ne "") {
            $restoreCriteria.ConflictPolicy =  $ConflictPolicy
        }
        else {
            $restoreCriteria.ConflictPolicy = "Skip" 
        }

        if($PersistentVolumeRestoreMode -ne "") {
            $restoreCriteria.PersistentVolumeRestoreMode =  $PersistentVolumeRestoreMode
        }
        else {
            $restoreCriteria.PersistentVolumeRestoreMode = "RestoreWithVolumeData" 
        }

        $restoreCriteria
    }
}