

function Disable-AzRecoveryServicesProtection {
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Triggers the disable protection operation for the given item')]

    param(

        [Parameter(ParameterSetName="ModifyRetentionPolicy",Mandatory=$true, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(Mandatory, HelpMessage='The name of the resource group where the recovery services vault is present.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The name of the recovery services vault.')]
        [System.String]
        ${VaultName},
        
        [Parameter(Mandatory, HelpMessage='Specifies the Backup item for which this cmdlet disables protection. To obtain a BackupItem , use the Get-AzRecoveryServicesBackupItem cmdlet.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource]
        ${Item},

        [Parameter(Mandatory=$false, HelpMessage='Switch parameter to indicate that this cmdlet disables protection and deletes existing recovery points')]
        [Switch]
        ${RemoveRecoveryPoints},
        
        [Parameter(Mandatory=$false, HelpMessage='Switch parameter to indicate that this cmdlet disables protection and retains recovery points as per policy')]
        [Switch]
        ${RetainRecoveryPointsAsPerPolicy},

        [Parameter(Mandatory=$false, HelpMessage='Switch parameter to indicate that this cmdlet disables protection and retains recovery points forever')]
        [Switch]
        ${RetainRecoveryPointsForever},
        
        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        ${NoWait}
    )

    process
    {   
        if($DatasourceType -eq "AzureVM")
        {
            $Object=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureIaaSvmProtectedItem]::new() 
        }
        elseif($DatasourceType -eq "SAPHANA")
        {
            $Object=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureVMWorkloadSapHanaDatabaseProtectedItem]::new()
        }
        elseif($DatasourceType -eq "MSSQL")
        {
            $Object=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureVMWorkloadSqlDatabaseProtectedItem]::new()
        }
        $vaultName=$VaultName
        $resourceGroupName=$ResourceGroupName
        $itemName=$Item.Name
        $fabricName="Azure"
        $containerName=Get-containerNameFromArmId -Id $Item.Id

        if($RemoveRecoveryPoints)
        {   #disable immutability
            if($NoWait)
            {
                Remove-AzRecoveryServicesProtectedItem -ContainerName $containerName -FabricName $fabricName -Name $itemName -ResourceGroupName $resourceGroupName -VaultName $vaultName -NoWait
            }
            else
            {
                Remove-AzRecoveryServicesProtectedItem -ContainerName $containerName -FabricName $fabricName -Name $itemName -ResourceGroupName $resourceGroupName -VaultName $vaultName
            }
            #Get-AzRecoveryServicesBackupOperationStatuses -OperationId "655642a4-dbcd-482e-98eb-debbeead3822" -ResourceGroupName arohijain-rg -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -VaultName arohijain-backupvault -debug
        }
        if($RetainRecoveryPointsAsPerPolicy)
        {
            #first unlock the immutable state 
            $Object.ProtectionState= "BackupsSuspended"
            $Object.SourceResourceId= $Item.SourceResourceId
            
            $ItemObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectedItemResource]::new()
            $ItemObject.Property=$Object
            if($DatasourceType -eq "AzureVM")
            {
                $ItemObject.ProtectedItemType="AzureIaaSVMProtectedItem"
            }
            elseif ($DatasourceType -eq "SAPHANA" -or $DatasourceType -eq "MSSQL")
            {
                $ItemObject.ProtectedItemType="AzureVmWorkloadProtectedItem"
            }
            if($NoWait)
            {
                New-AzRecoveryServicesProtectedItem -ContainerName $containerName -FabricName $fabricName -Name $itemName -ResourceGroupName $resourceGroupName -VaultName $vaultName -Parameter $ItemObject -NoWait
            }
            else
            {
                New-AzRecoveryServicesProtectedItem -ContainerName $containerName -FabricName $fabricName -Name $itemName -ResourceGroupName $resourceGroupName -VaultName $vaultName -Parameter $ItemObject
            }
        }
        if($RetainRecoveryPointsForever)
        {
            $Object.ProtectionState= "ProtectionStopped"
            $Object.SourceResourceId= $Item.SourceResourceId
            
            $ItemObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectedItemResource]::new()
            $ItemObject.Property=$Object
            if($DatasourceType -eq "AzureVM")
            {
                $ItemObject.ProtectedItemType="Microsoft.Compute/virtualMachines"
            }
            elseif ($DatasourceType -eq "SAPHANA" -or $DatasourceType -eq "MSSQL")
            {
                $ItemObject.ProtectedItemType="AzureVmWorkloadProtectedItem"
            }
            if($NoWait)
            {
                New-AzRecoveryServicesProtectedItem -ContainerName $containerName -FabricName $fabricName -Name $itemName -ResourceGroupName $resourceGroupName -VaultName $vaultName -Parameter $ItemObject -NoWait
            }
            else
            {
                New-AzRecoveryServicesProtectedItem -ContainerName $containerName -FabricName $fabricName -Name $itemName -ResourceGroupName $resourceGroupName -VaultName $vaultName -Parameter $ItemObject
            }
        }
    }
}


