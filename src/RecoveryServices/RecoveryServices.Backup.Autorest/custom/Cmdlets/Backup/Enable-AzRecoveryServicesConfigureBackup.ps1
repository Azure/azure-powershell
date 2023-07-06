function Enable-AzRecoveryServicesProtection {
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Triggers the enable protection operation for the given item')]

    param(

        [Parameter(ParameterSetName="ModifyRetentionPolicy",Mandatory=$true, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(Mandatory, HelpMessage='Specifies the name of the resource group of a virtual machine.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The name of the recovery services vault.')]
        [System.String]
        ${VaultName},
        
        [Parameter( HelpMessage='Specifies the item for which this cmdlet enables protection. To obtain a BackupItem , use the Get-AzRecoveryServicesBackupItem cmdlet.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource]
        ${Item},

        [Parameter( HelpMessage='Specifies the name of the Backup item. Pass this parameter if it is first time protection')]
        [System.String]
        ${VMName},

        [Parameter( HelpMessage='Specifies protection policyId that this cmdlet associates with an item. To obtain policyId use Get-AzRecoveryServicesBackupPolicy cmdlet, then extract Id from the obtained policy')]
        [System.String]
        ${PolicyId},

        [Parameter( HelpMessage='List of Disk LUNs to be included in backup and the rest are automatically excluded except OS disk.')]
        [System.String[]]
        ${InclusionDisksList},

        [Parameter( HelpMessage='List of Disk LUNs to be excluded in backup and the rest are automatically included.')]
        [System.String[]]
        ${ExclusionDisksList},

        [Parameter( HelpMessage='Option to specify to backup OS disks only')]
        [switch]
        ${ExcludeAllDataDisks},

        [Parameter( HelpMessage='Specifies to reset disk exclusion setting associated with the item')]
        [switch]
        ${ResetExclusionSettings},

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
        $fabricName="Azure"
        if(-not($Item))   #configure backup
        {
            if($DatasourceType -eq "AzureVM")
            {
                $ProtectableItem= Get-AzRecoveryServicesBackupProtectableItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.friendlyName -match $VMName}
            }
            elseif($DatasourceType -eq "MSSQL")
            {
                $ProtectableItem= Get-AzRecoveryServicesBackupProtectableItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -Filter "backupManagementType eq 'AzureWorkload' and WorkloadType -eq 'SQLDataBase'" | Where-Object { $_.friendlyName -match $VMName}
            }
            if($ProtectableItem -eq $null)
            {
                $errormsg= "There is no protectable item by this name in the current vault."
                throw $errormsg
            }
            $containerName=Get-containerNameFromArmId -Id $ProtectableItem.Id
            $itemName=Get-ProtectableItemNameFromArmId -Id $ProtectableItem.Id
            if($DatasourceType -eq "AzureVM")
            {
                $Object.SourceResourceId=$ProtectableItem.Property.VirtualMachineId
            }
            if($PolicyId -ne "" -and $PolicyId -ne $null)
            {
                $Object.PolicyId =$PolicyId
            }
            elseif($Item.PolicyId -eq $null -or $Item.PolicyId -eq "")
            {
                $errormsg="Please specify the policyId with which item is to be protected."
                throw $errormsg
            }
        }
        elseif($Item -ne $null) #modify backup
        {
            $itemName=Get-ProtectedItemNameFromArmId -Id $Item.Id
            $containerName=Get-containerNameFromArmId -Id $Item.Id
            if($DatasourceType -eq "AzureVM")
            { 
               if($Item.SourceResourceId -ne "" -and $Item.SourceResourceId -ne $null)
               {
                   $Object.SourceResourceId= $Item.SourceResourceId
               }
               else
               {
                   $Object.SourceResourceId= $Item.Property.VirtualMachineId
               }
            }

            if($PolicyId -ne "" -and $PolicyId -ne $null)
            {
                $Object.PolicyId =$PolicyId
            }
            elseif($Item.PolicyId -eq $null -or $Item.PolicyId -eq "")
            {
                $errormsg="Please specify the policyId with which item is to be protected."
                throw $errormsg
            }
            else
            {
                $Object.PolicyId = $Item.PolicyId
            }
        }
        else
        {
            $errormsg="Please provide the item that needs to be protected"
            throw $errormsg
        }
        
        # NOTE: The OS disk is by default added to the VM backup and can't be excluded.
        if($ResetExclusionSettings)
        {    
             $Object.ExtendedProperty=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ExtendedProperties]::new()
             $Object.ExtendedProperty.DiskExclusionPropertyDiskLunList=@()
        }
        else
        {
            if($InclusionDisksList -ne $null)
            {
                $inclusionList = $InclusionDisksList | ForEach-Object { [int]$_ } | Where-Object { $_ -ne $null }
                $Object.ExtendedProperty.DiskExclusionPropertyIsInclusionList=$true
                $Object.ExtendedProperty.DiskExclusionPropertyDiskLunList=$inclusionList
            }
            elseif($ExclusionDisksList -ne $null)
            {
                $exclusionList = $ExclusionDisksList | ForEach-Object { [int]$_ } | Where-Object { $_ -ne $null }
                $Object.ExtendedProperty.DiskExclusionPropertyIsInclusionList=$false
                $Object.ExtendedProperty.DiskExclusionPropertyDiskLunList=$exclusionList
            }
            elseif($ExcludeAllDataDisks)
            {
                $exclusionList = New-Object System.Collections.Generic.List[System.Nullable[int]]
                $Object.ExtendedProperty.DiskExclusionPropertyIsInclusionList=$true
                $Object.ExtendedProperty.DiskExclusionPropertyDiskLunList=$exclusionList
            }
        }
        $ItemObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectedItemResource]::new()
        $ItemObject.Property=$Object
        if($DatasourceType -eq "AzureVM")
        {
            $ItemObject.SourceResourceId=$Object.SourceResourceId
        }
        if($DatasourceType -eq "AzureVM")
        {
            $ItemObject.ProtectedItemType="Microsoft.Compute/virtualMachines"
        }
        elseif($DatasourceType -eq "SAPHANA")
        {
            $ItemObject.ProtectedItemType="AzureVmWorkloadSAPHanaDatabase"
        }
        elseif($DatasourceType -eq "MSSQL")
        {
            $ItemObject.ProtectedItemType="AzureVmWorkloadSQLDatabase"
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