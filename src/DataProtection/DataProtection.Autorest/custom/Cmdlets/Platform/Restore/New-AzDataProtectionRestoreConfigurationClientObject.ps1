
function New-AzDataProtectionRestoreConfigurationClientObject{
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.ModelCmdletAttribute()]
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates new restore configuration object')]

    param(
        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        [ValidateSet('AzureKubernetesService', 'AzureElasticSAN')]
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
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.KubernetesClusterRestoreCriteriaNamespaceMappings]
        ${NamespaceMapping},

        [Parameter(Mandatory=$false, HelpMessage='Restore mode for persistent volumes. Allowed values are RestoreWithVolumeData, RestoreWithoutVolumeData. Default value is RestoreWithVolumeData')]
        [System.String]
        [ValidateSet('RestoreWithVolumeData','RestoreWithoutVolumeData')]
        ${PersistentVolumeRestoreMode},
        
        [Parameter(Mandatory=$false, HelpMessage='Hook reference to be executed during restore.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.NamespacedNameResource[]]
        ${RestoreHookReference},

        [Parameter(Mandatory=$false, HelpMessage='Resource modifier reference to be executed during restore.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.NamespacedNameResource]
        ${ResourceModifierReference},

        [Parameter(Mandatory=$false, HelpMessage='Staging resource group Id for restore.')]
        [System.String]
        [ValidatePattern("/subscriptions/([A-z0-9\-]+)/resourceGroups/(?<rg>.+)")]
        ${StagingResourceGroupId},

        [Parameter(Mandatory=$false, HelpMessage='Staging storage account Id for restore.')]
        [System.String]
        [ValidatePattern("/subscriptions/([A-z0-9\-]+)/resourceGroups/([A-z0-9\-]+)/providers/Microsoft.Storage/storageAccounts/([A-z0-9\-]+)")]
        ${StagingStorageAccountId},

        [Parameter(Mandatory=$false, HelpMessage='List of source volume names to be restored. Use this parameter for DatasourceType AzureElasticSAN. The service currently supports exactly one volume per restore request.')]
        [System.String[]]
        ${ResourceIdentifier},

        [Parameter(Mandatory=$false, HelpMessage='Map of source volume name to target volume name to restore into. Use this parameter for DatasourceType AzureElasticSAN. Any source name not included will be restored with a default naming format.')]
        [System.Collections.Hashtable]
        ${ResourceNameOverride}
    )

    process {

        if($DatasourceType.ToString() -eq "AzureElasticSAN"){

            if($ResourceIdentifier -eq $null -or $ResourceIdentifier.Count -eq 0){
                throw "Please input parameter ResourceIdentifier for DatasourceType AzureElasticSAN."
            }

            # Current eSAN service supports restoring exactly one volume per restore request.
            # The payload remains a list for forward compatibility when multi-volume support ships.
            if($ResourceIdentifier.Count -ne 1){
                throw "DatasourceType AzureElasticSAN currently supports exactly one volume per restore request. Please provide a single entry in ResourceIdentifier."
            }

            $resourceListCriteria = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ResourceListSelectionCriteria]::new()
            $resourceListCriteria.ObjectType = "ResourceListSelectionCriteria"
            $resourceListCriteria.ResourceIdentifier = $ResourceIdentifier

            if($ResourceNameOverride -ne $null -and $ResourceNameOverride.Count -gt 0){

                $overrideMap = [System.Collections.Generic.Dictionary[string,string]]::new()
                $seenTargets = @{}

                foreach($key in $ResourceNameOverride.Keys){
                    if($ResourceIdentifier -notcontains $key){
                        throw "ResourceNameOverride key '$key' is not present in ResourceIdentifier. Each override key must match a source volume in ResourceIdentifier."
                    }

                    $value = $ResourceNameOverride[$key]
                    if($value -eq $null -or $value -eq ""){
                        throw "ResourceNameOverride value for key '$key' must be a non-empty target volume name."
                    }

                    if($seenTargets.ContainsKey($value)){
                        throw "ResourceNameOverride target name '$value' is specified more than once. Target names must be unique."
                    }
                    $seenTargets[$value] = $true

                    $overrideMap[$key] = $value
                }

                $resourceListCriteria.ResourceNameOverride = $overrideMap
            }

            $restoreCriteria = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.GenericRestoreDatasourceCriteria]::new()
            $restoreCriteria.ObjectType = "GenericRestoreDatasourceCriteria"
            $restoreCriteria.ResourceSelector = $resourceListCriteria

            return $restoreCriteria
        }

        $hasStagingResourceGroupId = $PSBoundParameters.Remove("StagingResourceGroupId")
        $hasStagingStorageAccountId = $PSBoundParameters.Remove("StagingStorageAccountId")

        $restoreCriteria = $null
        if($hasStagingResourceGroupId -and $hasStagingStorageAccountId){
            $restoreCriteria =  [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.KubernetesClusterVaultTierRestoreCriteria]::new()
            $restoreCriteria.ObjectType = "KubernetesClusterVaultTierRestoreCriteria"

            $restoreCriteria.StagingResourceGroupId = $StagingResourceGroupId
            $restoreCriteria.StagingStorageAccountId = $StagingStorageAccountId        
        }
        elseif($hasStagingResourceGroupId -or $hasStagingStorageAccountId) {
            throw "Both StagingResourceGroupId and StagingStorageAccountId are mandatory for vaulted tier restore for AzureKubernetesService. Please either provide or remove both of them."
        }
        else {
            $restoreCriteria =  [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.KubernetesClusterRestoreCriteria]::new()
            $restoreCriteria.ObjectType = "KubernetesClusterRestoreCriteria"
        }        

        $restoreCriteria.ExcludedResourceType = $ExcludedResourceType
        $restoreCriteria.IncludedResourceType = $IncludedResourceType
        $restoreCriteria.ExcludedNamespace = $ExcludedNamespace
        $restoreCriteria.IncludedNamespace = $IncludedNamespace
        $restoreCriteria.LabelSelector = $LabelSelector
        $restoreCriteria.NamespaceMapping = $NamespaceMapping
        $restoreCriteria.RestoreHookReference = $RestoreHookReference
        $restoreCriteria.ResourceModifierReference = $ResourceModifierReference        

        
                
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