﻿function Register-AzRecoveryServicesBackupContainer
{
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('The Register-AzRecoveryServicesBackupContainer cmdlet registers an Azure VM for AzureWorkloads with specific DatasourceType.')]

	param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The name of the resource group where the recovery services vault is present')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The name of the recovery services vault')]
        [System.String]
        ${VaultName},

        [Parameter(Mandatory=$true, Position=1, HelpMessage='Specifies the DatasourceType')]        
        [ValidateSet("MSSQL", "SAPHANA", ErrorMessage = "Invalid value for DatasourceType. Please provide a valid datasource type. Valid values are 'MSSQL'")]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(ParameterSetName="ReRegister", Mandatory=$true, Position=0, HelpMessage='Specifies a container object for which this cmdlet triggers the re-registration. To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet', ValueFromPipelineByPropertyName=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource]
        ${Container},

        [Parameter(ParameterSetName="Register", Position=0, Mandatory=$true, HelpMessage='Specifies the ARM ID of an Instance or Availability Group')]
        [System.String]
        ${ResourceId},
                
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
        
        $containerName = ""
        if($parameterSetName -eq "ReRegister"){
            $containerName = ($Container.Name -split ";")[-1]
        }
        else{
            $containerName = ($ResourceId -split "/")[-1]
        }

        # confirm:$false/ force  
        #$containerType - workload type 
        #$backupManagementType
        #$container = $Container

        # Refresh containers
        $filter = Get-BackupManagementTypeFilter -DatasourceType $DatasourceType
        
        $refreshOperationResponse = $null
        if($SubscriptionId -ne "" -and $SubscriptionId -ne $null){
            $refreshOperationResponse = Az.RecoveryServices.Internal\Update-AzRecoveryServicesProtectionContainer -FabricName "Azure" -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -VaultName $VaultName -Filter $filter -NoWait
        }
        else{
            $refreshOperationResponse = Az.RecoveryServices.Internal\Update-AzRecoveryServicesProtectionContainer -FabricName "Azure" -ResourceGroupName $ResourceGroupName -VaultName $VaultName -Filter $filter -NoWait
        }        

        $operationStatus = GetOperationStatus -Target $refreshOperationResponse.Target
        if($operationStatus -ne "Succeeded"){
            $errormsg= "Refresh container operation failed with operationStatus: $operationStatus"
            throw $errormsg
        }
        
        # Get protectable containers  (register) / container (re-register)

        $protectableContainers = $null
        if($SubscriptionId -ne "" -and $SubscriptionId -ne $null){
            $protectableContainers = Az.RecoveryServices.Internal\Get-AzRecoveryServicesProtectableContainer -FabricName "Azure" -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -VaultName $VaultName -Filter $filter | Where-Object { ($_.Name -split ";")[-1] -eq $containerName -or $_.Name -eq $containerName }
        }
        else{
            $protectableContainers = Az.RecoveryServices.Internal\Get-AzRecoveryServicesProtectableContainer -FabricName "Azure" -ResourceGroupName $ResourceGroupName -VaultName $VaultName -Filter $filter | Where-Object { ($_.Name -split ";")[-1] -eq $containerName -or $_.Name -eq $containerName }
        }               

        if($protectableContainers -ne $null -or $Container -ne $null){
            $protectionContainerResource = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectionContainerResource]::new()

            $containerFullName = ($Container -ne $null) ? $Container.Name : $protectableContainers.Name

            $property = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureVMAppContainerProtectionContainer]::new()

            $property.FriendlyName = $containerName
            $property.BackupManagementType = GetBackupManagementTypeFromDatasourceType -DatasourceType $DatasourceType 
            $property.SourceResourceId = ($Container -ne $null) ? $Container.Property.SourceResourceId : $protectableContainers.ContainerId
            $property.WorkloadType = GetItemTypeFromDatasourceType -DatasourceType $DatasourceType
            $property.OperationType = ($Container -ne $null) ? "Reregister" : "Register"
            $property.ContainerType = "VMAppContainer"

            $protectionContainerResource.Property = $property

            # register container
            $registerOperationResponse = $null
            if($SubscriptionId -ne "" -and $SubscriptionId -ne $null){
                $registerOperationResponse = Az.RecoveryServices.Internal\Register-AzRecoveryServicesProtectionContainer -ContainerName $containerFullName -FabricName "Azure" -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -VaultName $VaultName -Parameter $protectionContainerResource -NoWait
            }
            else{
                $registerOperationResponse = Az.RecoveryServices.Internal\Register-AzRecoveryServicesProtectionContainer -ContainerName $containerFullName -FabricName "Azure" -ResourceGroupName $ResourceGroupName -VaultName $VaultName -Parameter $protectionContainerResource -NoWait
            }                  

            $operationStatus = GetOperationStatus -Target $registerOperationResponse.Target -RefreshAfter 30    

            if($operationStatus -ne "Succeeded"){
                $errormsg= "Register container operation failed with operationStatus: $operationStatus"
                throw $errormsg
            }
        }
        else{
            # throw error
            $errormsg= "The specified datasource is already registered with the given recovery services vault"
            throw $errormsg
        }

        # List containers
        $registeredContainer = $null
        if($SubscriptionId -ne "" -and $SubscriptionId -ne $null){
            $registeredContainer = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $ResourceGroupName -VaultName $VaultName -SubscriptionId $SubscriptionId -ContainerType AzureVMAppContainer -DatasourceType $DatasourceType | Where-Object { $_.Name -eq $containerFullName }            
        }
        else{            
            $registeredContainer = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $ResourceGroupName -VaultName $VaultName -ContainerType AzureVMAppContainer -DatasourceType $DatasourceType | Where-Object { $_.Name -eq $containerFullName }
        }

        $registeredContainer
    }
}