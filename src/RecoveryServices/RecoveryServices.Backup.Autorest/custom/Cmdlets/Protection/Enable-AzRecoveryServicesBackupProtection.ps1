function Enable-AzRecoveryServicesBackupProtection {
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Triggers the enable protection operation for the given item')]

    param(

        [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The name of the resource group where the recovery services vault is present.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The name of the recovery services vault.')]
        [System.String]
        ${VaultName},

        # TODO : [ValidateNotNullOrEmpty]
        [Parameter(Position=1, Mandatory=$true, HelpMessage='Specifies protection policy that this cmdlet associates with an item. To obtain policy use Get-AzRecoveryServicesBackupProtectionPolicy cmdlet')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource]
        ${Policy},

        [Parameter(Position=2, ParameterSetName="AzureVMClassicComputeEnableProtection", ValueFromPipelineByPropertyName=$true, Mandatory=$true, HelpMessage='Specifies the name of backup item. For file share, specify the unique ID of protected file share.')]
        [Parameter(Position=2, ParameterSetName="AzureVMComputeEnableProtection", ValueFromPipelineByPropertyName=$true, Mandatory=$true, HelpMessage='Specifies the name of backup item. For file share, specify the unique ID of protected file share.')]
        [Parameter(Position=2, ParameterSetName="AzureFileShareEnableProtection", ValueFromPipelineByPropertyName=$true, Mandatory=$true, HelpMessage='Specifies the name of backup item. For file share, specify the unique ID of protected file share.')]
        [System.String]
        ${Name},

        # TODO: virtual machine name - verify with Daya 
        [Parameter(Position=3, ParameterSetName="AzureVMComputeEnableProtection",  ValueFromPipelineByPropertyName=$true, Mandatory=$true, HelpMessage='Resource Group Name for Azure Compute VM.')]
        [System.String]
        ${VMResourceGroupName},
                
        [Parameter(ParameterSetName="AzureVMClassicComputeEnableProtection", Mandatory=$false, HelpMessage='List of Disk LUNs to be included in backup and the rest are automatically excluded except OS disk.')]
        [Parameter(ParameterSetName="AzureVMComputeEnableProtection", Mandatory=$false, HelpMessage='List of Disk LUNs to be included in backup and the rest are automatically excluded except OS disk.')]
        [Parameter(ParameterSetName="ModifyProtection", Mandatory=$false, HelpMessage='List of Disk LUNs to be included in backup and the rest are automatically excluded except OS disk.')]
        [System.String[]]
        ${InclusionDisksList},

        [Parameter(ParameterSetName="AzureVMClassicComputeEnableProtection", Mandatory=$false, HelpMessage='List of Disk LUNs to be excluded in backup and the rest are automatically included.')]
        [Parameter(ParameterSetName="AzureVMComputeEnableProtection", Mandatory=$false, HelpMessage='List of Disk LUNs to be excluded in backup and the rest are automatically included.')]
        [Parameter(ParameterSetName="ModifyProtection", Mandatory=$false, HelpMessage='List of Disk LUNs to be excluded in backup and the rest are automatically included.')]
        [System.String[]]
        ${ExclusionDisksList},

        [Parameter(ParameterSetName="AzureVMClassicComputeEnableProtection", Mandatory=$false, HelpMessage='Option to specify to backup OS disks only')]
        [Parameter(ParameterSetName="AzureVMComputeEnableProtection", Mandatory=$false, HelpMessage='Option to specify to backup OS disks only')]
        [Parameter(ParameterSetName="ModifyProtection", Mandatory=$false, HelpMessage='Option to specify to backup OS disks only')]
        [Switch]
        ${ExcludeAllDataDisks},

        [Parameter(ParameterSetName="ModifyProtection", Mandatory=$false, HelpMessage='Specifies to reset disk exclusion setting associated with the item')]
        [switch]
        ${ResetExclusionSettings},
        
        # TODO: [ValidateNotNullOrEmpty]
        [Parameter(Position=4, ParameterSetName="ModifyProtection", Mandatory=$true, HelpMessage='Specifies the item to be protected with the given policy. To obtain a BackupItem , use the Get-AzRecoveryServicesBackupItem cmdlet.', ValueFromPipeline=$true)]        
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource]
        ${Item},
                
        [Parameter(Position=3, ParameterSetName="AzureVMClassicComputeEnableProtection", Mandatory=$true, ValueFromPipelineByPropertyName=$true, HelpMessage='Cloud Service Name for Azure Classic Compute VM.')]
        [System.String]
        ${ServiceName},
        
        [Parameter(Position=3, ParameterSetName="AzureFileShareEnableProtection", Mandatory=$true, ValueFromPipelineByPropertyName=$true, HelpMessage='Azure file share storage account name')]
        [System.String]
        ${StorageAccountName},

        [Parameter(Position=2, ParameterSetName="AzureWorkloadEnableProtection", Mandatory=$true, HelpMessage='Specifies the protectable item to be protected with the given policy.', ValueFromPipeline=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IWorkloadProtectableItemResource]
        ${ProtectableItem},
        
        [Parameter(ParameterSetName="ModifyProtection", Mandatory=$false, HelpMessage="Auxiliary access token for authenticating critical operation to resource guard subscription", ValueFromPipeline=$false)]
        [System.String]
        ${Token},
        
        #[Parameter()]
        #[System.Management.Automation.SwitchParameter]
        #${NoWait},
                
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}      
    )
    process
    {   
        $parameterSetName = $PsCmdlet.ParameterSetName

        # Multi user authorization
        $isMUAOperation = $false
        $auxiliaryAccessToken = ($Token -ne "") ? $Token : $null
        if($parameterSetName -match "Modify")
        {
            # shouldProcessName = Item.Name;
            $isMUAOperation = $true
        }
        Write-Debug "isMUAOperation: $isMUAOperation"

        $DatasourceType = ""
        if($Item -ne $null){
            $DatasourceType = Get-DatasourceType -BackupManagementType $Item.BackupManagementType -WorkloadType $Item.WorkloadType
            
            $DatasourceTypePolicy = GetDatasourceTypeFromPolicy -Policy $Policy

            if($DatasourceType -ne $DatasourceTypePolicy){
                $errormsg="Incompatible parameters Policy and Item"
                throw $errormsg
            }
        }
        else{
            $DatasourceType = GetDatasourceTypeFromPolicy -Policy $Policy
        }
                
        $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()

        if($DatasourceType -eq "AzureVM"){
            Write-Warning "Ignite (November) 2023 onwards Virtual Machine deployments using PS and CLI will default to Trusted Launch configuration. You need to ensure Policy Name used with this command is of type Enhanced Policy for Trusted Launch VMs. Non-Trusted Launch Virtual Machines will not be impacted by this change. To know more about default change and Trusted Launch, please visit https://aka.ms/TLaD."
        }

        # PSBoundParameters
        $null = $PSBoundParameters.Remove('Policy')
        $null = $PSBoundParameters.Remove('Name')
        $null = $PSBoundParameters.Remove('VMResourceGroupName')
        $null = $PSBoundParameters.Remove('InclusionDisksList')
        $null = $PSBoundParameters.Remove('ExclusionDisksList')
        $null = $PSBoundParameters.Remove('ExcludeAllDataDisks')
        $null = $PSBoundParameters.Remove('ResetExclusionSettings')
        $null = $PSBoundParameters.Remove('Item')
        $null = $PSBoundParameters.Remove('ServiceName')
        $null = $PSBoundParameters.Remove('StorageAccountName')
        $null = $PSBoundParameters.Remove('ProtectableItem')
        $null = $PSBoundParameters.Remove('Token')
        
        if($parameterSetName -eq "ModifyProtection" -and $Item.PolicyId -ne "" -and $Item.PolicyId -ne $null){

            $oldPolicyName = Get-PolicyNameFromArmId -Id $Item.PolicyId
            $newPolicyName = Get-PolicyNameFromArmId -Id $Policy.Id            
            
            $PSBoundParameters.Add('Name', $oldPolicyName)
            $oldPoloicy = Get-AzRecoveryServicesBackupProtectionPolicy @PSBoundParameters

            $null = $PSBoundParameters.Remove('Name')
            $PSBoundParameters.Add('Name', $newPolicyName)
            $newPolicy = Get-AzRecoveryServicesBackupProtectionPolicy @PSBoundParameters
            $null = $PSBoundParameters.Remove('Name')
        }

        # validate selective disk backup
        if($manifest.allowSelectiveDiskBackup){
            if($InclusionDisksList -ne $null -and $ExclusionDisksList -ne $null){
                $errormsg="Both Inclusion and Exclusion lists provided. Please provide only one of them."
                throw $errormsg
            }

            # if($ResetExclusionSettings -and ($InclusionDisksList -ne $null -and $ExclusionDisksList -ne $null))
            # Multiple Parameters Provided. Please specify only one of the parameters from InclusionDisksList, ExclusionDisksList, ResetExclusionSetting and ExcludeAllDataDisks

            if($ExcludeAllDataDisks -and ($InclusionDisksList -ne $null -or $ExclusionDisksList -ne $null -or $ResetExclusionSettings)){
                $errormsg="Multiple selective disk parameters provided. Please specify ExcludeAllDataDisks alone if you want to exclude all data disks."
                throw $errormsg
            }
        }
        elseif($ResetExclusionSettings -or $InclusionDisksList -ne $null -or $ExclusionDisksList -ne $null -or $ExcludeAllDataDisks){
            $errormsg="Selective disk backup is not enabled for the given workload. Please try without passing ResetExclusionSettings, InclusionDisksList, ExclusionDisksList,ExcludeAllDataDisks parameters"
            throw $errormsg
        }
          
        # validate VM Count - manifest based
        # Cannot configure backup for more than 100 VMs per policy
        if($manifest.validateProtectedItemsCount -and $Policy.ProtectedItemsCount -gt 100){
            $errormsg="Can not configure backup for more than 100 VMs per policy. Please try with another backup policy."
            throw $errormsg
        }
        
        $fabricName="Azure"
        $protectedItemType = "[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201." + $manifest.protectedItemType + "]::new()"
        $Object =  Invoke-Expression $protectedItemType # equivalent to properties        

        $containerUri = ""
        $protectedItemUri = ""        
        $sourceResourceId = ""
                
        # IaasVM specific variables
        $isComputeAzureVM = $false 
        $azureVMRGName = ""
        
        if(-not($Item)) #configure backup
        {            
            $protectableObjectResource = $null
            if($manifest.fetchAzureVMProperties){
                $isComputeAzureVM = ($ServiceName -eq $null -or $ServiceName -eq "") ? $true : $false
                $azureVMRGName = ($isComputeAzureVM) ? $VMResourceGroupName : $ServiceName

                # ValidateProtectionRequest
                Validate-AzureVMEnableProtectionRequest -AzureVMName $Name -CloudServiceName $ServiceName -VMResourceGroupName $VMResourceGroupName -Policy $Policy

                # PSBoundParameters            
                $PSBoundParameters.Add('AzureVMName', $Name)
                $PSBoundParameters.Add('VMResourceGroupName', $VMResourceGroupName)
                $PSBoundParameters.Add('IsComputeAzureVM', $IsComputeAzureVM)
                $PSBoundParameters.Add('DatasourceType', $DatasourceType)
                $protectableObjectResource = Get-AzureVMProtectableObject @PSBoundParameters

                $null = $PSBoundParameters.Remove('AzureVMName')
                $null = $PSBoundParameters.Remove('VMResourceGroupName')
                $null = $PSBoundParameters.Remove('IsComputeAzureVM')
                $null = $PSBoundParameters.Remove('DatasourceType')
                
                if($protectableObjectResource.Property -ne $null){
                    $sourceResourceId = $protectableObjectResource.Property.VirtualMachineId
                }                
            }
            elseif($manifest.fetchAzureFileShareProperties){
                Validate-AzureFileShareEnableProtectionRequest -AzureFileShareName $Name -StorageAccountName $StorageAccountName

                $PSBoundParameters.Add('AzureFileShareName', $Name)
                $PSBoundParameters.Add('StorageAccountName', $StorageAccountName)

                $protectableObjectResource = Get-AzureFileShareProtectableObject @PSBoundParameters

                $null = $PSBoundParameters.Remove('AzureFileShareName')
                $null = $PSBoundParameters.Remove('StorageAccountName')

                if($protectableObjectResource.Property -ne $null){
                    $sourceResourceId = $protectableObjectResource.Property.ParentContainerFabricId #TODO: check this field
                }
            }
            else{
                if($parameterSetName -eq "AzureWorkloadEnableProtection"){
                    $protectableObjectResource = $ProtectableItem
                }
            }           

            Write-Debug "protectableObjectResource.Id: $($protectableObjectResource.Id)"

            $containerUri = Get-ContainerNameFromArmId -Id $protectableObjectResource.Id
            $protectedItemUri = Get-ProtectableItemNameFromArmId -Id $protectableObjectResource.Id

            Write-Debug "Container URI: $containerUri"
            Write-Debug "Protected Item URI: $protectedItemUri"            
            Write-Debug "sourceResourceId: $sourceResourceId"
        }
        elseif($Item -ne $null) #modify backup
        {
            if($manifest.fetchAzureVMProperties){
                if([string]::IsNullOrEmpty($Item.Property.VirtualMachineId)){
                    throw "VirtualMachineId is NULL or Empty. Please enter valid VirtualMachineId"
                }

                $isComputeAzureVM = IsComputeAzureVM($Item.Property.VirtualMachineId)
            }
            elseif($manifest.fetchAzureFileShareProperties){ 
                if(-not($Item.Property.GetType() -match "FileShare")){
                    throw "Invalid type of parameter Item. Expected type is AzureFileShareItem"
                }
            }
            
            $protectedItemUri = Get-ProtectedItemNameFromArmId -Id $Item.Id
            $containerUri = Get-ContainerNameFromArmId -Id $Item.Id            
                        
            if(($manifest.fetchAzureVMProperties -or $manifest.fetchAzureFileShareProperties) -and ($Item.SourceResourceId -ne "" -and $Item.SourceResourceId -ne $null))
            {
                $sourceResourceId = $Item.SourceResourceId
            }
            elseif($manifest.fetchAzureVMProperties)
            {
                $sourceResourceId= $Item.Property.VirtualMachineId
            }
        }
        else
        {
            $errormsg="Please provide the item that needs to be protected"
            throw $errormsg
        }
        
        
        if($manifest.fetchAzureVMProperties -and -not $isComputeAzureVM){                
            $protectedItemType = "[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureIaaSClassicComputeVmprotectedItem]::new()"
            
            $Object =  Invoke-Expression $protectedItemType
        }

        Write-Debug "Request Type: $($Object.GetType())"

        # Prepare object
        if($Policy -ne $null)
        {
            $Object.PolicyId = $Policy.Id
        }
        elseif($Item.PolicyId -eq $null -or $Item.PolicyId -eq "")
        {
            $errormsg="Please specify the Policy with which item needs to be protected."
            throw $errormsg
        }
        else
        {
            $Object.PolicyId = $Item.PolicyId
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
                $inclusionList = New-Object System.Collections.Generic.List[System.Nullable[int]]
                $Object.ExtendedProperty.DiskExclusionPropertyIsInclusionList=$true
                $Object.ExtendedProperty.DiskExclusionPropertyDiskLunList=$inclusionList
            }
        }

        $ItemObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectedItemResource]::new()
        $ItemObject.Property=$Object
        
        if($sourceResourceId -ne ""){
            $Object.SourceResourceId = $sourceResourceId
            $ItemObject.SourceResourceId = $Object.SourceResourceId
        }

        Write-Debug "ItemObject.ProtectedItemType $($ItemObject.ProtectedItemType)"

        if($manifest.protectedItemType -match "AzureIaaSComputeVmprotectedItem" -and (-not $isComputeAzureVM)){
            $ItemObject.ProtectedItemType = $manifest.classicComputeProtectedItemResourceType
        }
        else{
            $ItemObject.ProtectedItemType = $manifest.protectedItemResourceType
        }

        Write-Debug "ItemObject.ProtectedItemType $($ItemObject.ProtectedItemType)"

        # PSBoundParameters
        $PSBoundParameters.Add('ContainerName', $containerUri)
        $PSBoundParameters.Add('FabricName', $fabricName)
        $PSBoundParameters.Add('Name', $protectedItemUri)
        $PSBoundParameters.Add('Parameter', $ItemObject)
        $PSBoundParameters.Add('NoWait', $true)

        # TODO: handle MUA        
        $newItem = New-AzRecoveryServicesProtectedItem @PSBoundParameters
        $jobId = ""

        $null = $PSBoundParameters.Remove('ContainerName')
        $null = $PSBoundParameters.Remove('FabricName')
        $null = $PSBoundParameters.Remove('Name')
        $null = $PSBoundParameters.Remove('Parameter')
        $null = $PSBoundParameters.Remove('NoWait')
        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove('VaultName')
        $null = $PSBoundParameters.Remove('SubscriptionId') # $hasSubscriptionId
        $PSBoundParameters.Add('Target', $newItem.Target)
        $PSBoundParameters.Add('RefreshAfter', 30)
        $PSBoundParameters.Add('JobId', ([ref]$jobId))
        # getOpStatus
        $operationStatus = GetProtectedItemOperationStatus @PSBoundParameters
        
        if($operationStatus -ne "Succeeded"){
            $errormsg= "Enable protection operation failed with Status: $operationStatus"
            throw $errormsg
        }
        
        Write-Output $jobId # TODO: need to give Job as output?
    }
}