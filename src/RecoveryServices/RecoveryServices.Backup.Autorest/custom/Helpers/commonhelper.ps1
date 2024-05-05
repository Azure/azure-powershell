# takes backupmanagement type and workload type as i/p & gives dataspurce type
function Get-DatasourceType {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [string]$BackupManagementType,
        [string]$WorkloadType
    )

    if ($BackupManagementType -eq "AzureWorkload") {
        if ($WorkloadType -eq "SAPHanaDatabase") {
            return "SAPHANA"
        }
        elseif ($WorkloadType -match "SQL") { # -eq "SQLDataBase") {
            return "MSSQL"
        }
    }
    elseif ($BackupManagementType -eq "AzureIaasVM") {
        return "AzureVM"
    }
    elseif($BackupManagementType -eq "AzureStorage"){
        return "AzureFiles"
    }

    # Return null if no match found
    return $null
}

# Summary: get service client backupmanagement type from datasource type
function GetBackupManagementTypeFromDatasourceType {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $DatasourceType
    )

    process {
        # TODO: can this be manifest based directly? 
        if($DatasourceType -eq "AzureVM"){
            return "AzureIaasVM"
        }

        elseif ($DatasourceType -eq "MSSQL" -or $DatasourceType -eq "SAPHANA") {
            return "AzureWorkload"
        }        
        
        elseif($DatasourceType -eq "AzureFiles"){
            return "AzureStorage"
        }

        elseif($DatasourceType -eq "MAB"){
            return "MAB"
        }

        # Return null if no match found
        return $null
    }
}

# Get service client Item type from datasourcetype
# can be used as GetWorkloadTypeFromDatasourceType
function GetItemTypeFromDatasourceType { 
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
    
    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $DatasourceType
    )

    process {
        
        if($DatasourceType -eq "AzureVM"){
            return "VM"
        }

        elseif ($DatasourceType -eq "MSSQL") {
            return "SQLDataBase"
        }        
        
        elseif($DatasourceType -eq "AzureFiles"){
            return "AzureFileShare"
        }

        elseif($DatasourceType -eq "SAPHANA"){
            return "SAPHanaDatabase"
        }

        return $null
    }
}

# Summary: get datasourcetype from datasource type from policy
function GetDatasourceTypeFromPolicy {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource]
        $Policy
    )

    process {
        
        $DatasourceType = Get-DatasourceType -BackupManagementType $Policy.BackupManagementType -WorkloadType $Policy.Property.WorkLoadType
        return $DatasourceType
    }
}

# Summary: takes OerationRepsonse.Target as input, tracks the /backupstorageconfig/vaultstorageconfig/operationStatus to Success/Failure
function GetOperationStatus {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $Target,

        [Parameter(Mandatory=$false)]
        [System.String]
        $RefreshAfter = 10
    )

    process {
        
        $operationId = $Target.Split("/")[-1].Split("?")[0]
        $resourceGroupName = Get-ResourceGroupNameFromArmId -Id $Target
        $vaultName = Get-VaultNameFromArmId -Id $Target
        $subscriptionId = Get-SbscriptionIdFromArmId -Id $Target

        $null = $PSBoundParameters.Remove('Target')
        $null = $PSBoundParameters.Remove('RefreshAfter')

        $PSBoundParameters.Add('OperationId', $operationId)
        $PSBoundParameters.Add('ResourceGroupName', $resourceGroupName)
        $PSBoundParameters.Add('SubscriptionId', $subscriptionId)
        $PSBoundParameters.Add('VaultName', $vaultName)

        # operationStatus
        While((Get-AzRecoveryServicesOperationStatus @PSBoundParameters).Status -eq "InProgress"){

            Write-Debug "Polling after $RefreshAfter seconds"
	        Start-Sleep -Seconds $RefreshAfter
        }

        $operationStatus = (Get-AzRecoveryServicesOperationStatus @PSBoundParameters).Status

        return $operationStatus
    }
}

# Summary: takes OerationRepsonse.Target as input, tracks the backupOperations operationStatus to Success/Failure
function GetProtectedItemOperationStatus {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]

    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $Target,

        [Parameter(Mandatory=$false)]
        [System.String]
        $RefreshAfter = 10,

        [Parameter(Mandatory=$false)]
        [ref]$JobId
    )

    process {
        
        $operationId = $Target.Split("/")[-1].Split("?")[0]
        $resourceGroupName = Get-ResourceGroupNameFromArmId -Id $Target
        $vaultName = Get-VaultNameFromArmId -Id $Target
        $subscriptionId = Get-SbscriptionIdFromArmId -Id $Target

        $null = $PSBoundParameters.Remove('Target')
        $null = $PSBoundParameters.Remove('RefreshAfter')
        $hasJobId = $PSBoundParameters.Remove('JobId')

        $PSBoundParameters.Add('OperationId', $operationId)
        $PSBoundParameters.Add('ResourceGroupName', $resourceGroupName)
        $PSBoundParameters.Add('SubscriptionId', $subscriptionId)
        $PSBoundParameters.Add('VaultName', $vaultName)

        # operationStatus
        While((Get-AzRecoveryServicesBackupOperationStatuses @PSBoundParameters).Status -eq "InProgress"){

            Write-Debug "Polling after $RefreshAfter seconds"
	        Start-Sleep -Seconds $RefreshAfter
        }

        $operationStatus = (Get-AzRecoveryServicesBackupOperationStatuses @PSBoundParameters)

        if($hasJobId){
            Write-Debug "JobId : $($operationStatus.Property.JobId)"
            $JobId.Value = $operationStatus.Property.JobId
        }

        return $operationStatus.Status
    }
}