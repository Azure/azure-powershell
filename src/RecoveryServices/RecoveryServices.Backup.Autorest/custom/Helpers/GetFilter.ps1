
# Summary: takes BackupManagementType, FriendlyName as input & gives filter for get container command
function Get-ContainerFilter {
    [OutputType('string')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $ContainerType,

        [Parameter(Mandatory=$false)]
        [System.String]
        $FriendlyName,

        [Parameter(Mandatory=$false)]
        [System.String]
        $DatasourceType
    )

    process {
        
        $containerBackupManagementType = GetBackupManagementTypeFromContainerType -ContainerType $ContainerType
        
        $backupManagementType = $null
        if($DatasourceType -ne ""){            
            $backupManagementType = GetBackupManagementTypeFromDatasourceType -DatasourceType $DatasourceType
        }

        if($backupManagementType -ne $null -and $containerBackupManagementType -ne $backupManagementType){
            $errormsg = "DatasourceType $DatasourceType provided for ContainerType $ContainerType is incorrect"
    		throw $errormsg 
        }        

        $filter = $null
        if($FriendlyName -ne ""){
            $filter = "friendlyName eq '$FriendlyName' and backupManagementType eq '$containerBackupManagementType'"
        }
        else {
            $filter = "backupManagementType eq '$containerBackupManagementType'"
        }

        # Return null if no match found
        return $filter
    }
}

# Summary: takes DatasourceType, Container as input & gives filter for list backup items
function Get-ProtectedItemFilter {
    [OutputType('string')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $DatasourceType,

        [Parameter(Mandatory=$false)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource]
        $Container,

        [Parameter(Mandatory=$false)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource]
        $Policy
    )

    process {

        $backupManagementType = GetBackupManagementTypeFromDatasourceType -DatasourceType $DatasourceType
        $filter = "backupManagementType eq '$backupManagementType'"

        if($backupManagementType -ne $null -and $Container -ne $null -and $Container.BackupManagementType -ne $backupManagementType ){
            $errormsg = "DatasourceType $DatasourceType is not compatible with the input container"
    		throw $errormsg 
        }

        $itemType = GetItemTypeFromDatasourceType -DatasourceType $DatasourceType
        if($itemType -ne $null){
            $filter += " and itemType eq '$itemType'"
        }
        
        if($Policy -ne $null){
            $filter += " and policyName eq '$($Policy.Name)'"
        }
        
        # backupManagementType eq 'AzureIaasVM' and itemType eq 'VM' and policyName eq 'DefaultPolicy'
        return $filter
    }
}

# Summary: takes $DatasourceType, $Container or $ParentID as input & gives filter for list protectable items
function Get-ProtectableItemFilter {
    [OutputType('string')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(ParameterSetName="DataSourceParamSet", Mandatory=$true)]
        [System.String]
        $DatasourceType,

        [Parameter(ParameterSetName="DataSourceParamSet", Mandatory=$false)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource]
        $Container,

        [Parameter(ParameterSetName="IdParamSet", Mandatory=$true)]
        [System.String]
        $ParentID
    )

    process {
        $backupManagementType = "AzureWorkload"
        $workloadType = ""
        $filter = ""

        # TODO: try without $ParentID first
        if($ParentID -ne ""){
            Write-Debug " .... IdParamSet"
            $containerURI = Get-ContainerNameFromArmId -Id $ParentID
            $protectableItemURI =  Get-ProtectableItemNameFromArmId -Id $ParentID

            if($protectableItemURI.ToLower() -match "sqlinstance" || $protectableItemURI.ToLower() -match "sqlavailabilitygroupcontainer"){
                $workloadType = "SQLDataBase"
            }

            $filter = "backupManagementType eq '$backupManagementType' and workloadType eq '$workloadType' and containerName eq '$containerURI'"
        }
        else{
            Write-Debug " .... DataSourceParamSet"

            $workloadType = GetItemTypeFromDatasourceType -DatasourceType $DatasourceType

            if($Container -ne $null){                
                $backupManagementType = $Container.BackupManagementType
                $containerName = $Container.Name

                $filter = "backupManagementType eq '$backupManagementType' and workloadType eq '$workloadType' and containerName eq '$containerName'"
            }
            else {
                $filter = "backupManagementType eq '$backupManagementType' and workloadType eq '$workloadType'"
            }
        }
        
        return $filter
    }
}

# Summary: takes $ItemType, $ItemName, $ParentName, $BackupManagementType as input & gives filter for list protection intent
function Get-ProtectionIntentFilter {
    [OutputType('string')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $ItemType,

        [Parameter(Mandatory=$true)]
        [System.String]
        $ItemName,

        [Parameter(Mandatory=$true)]
        [System.String]
        $ParentName,

        [Parameter(Mandatory=$true)]
        [System.String]
        $BackupManagementType
    )

    process {

        return "itemType eq '$ItemType' and itemName eq '$ItemName' and parentName eq '$ParentName' and backupManagementType eq '$BackupManagementType'"        
    }
}

# Summary: takes backupManagementType as input & gives filter. This works for refresh container APIs.
function Get-BackupManagementTypeFilter {
    [OutputType('string')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $DatasourceType
    )

    process {
        $backupManagementType = GetBackupManagementTypeFromDatasourceType -DatasourceType $DatasourceType
        return "backupManagementType eq '$backupManagementType'"
    }
}
 