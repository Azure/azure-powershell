function Unregister-AzRecoveryServicesBackupContainer
{
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource')]
    [CmdletBinding(SupportsShouldProcess=$true)]
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

        # [Parameter(Mandatory=$true, Position=1, HelpMessage='Specifies the DatasourceType')]        
        # [ValidateSet("MSSQL", "SAPHANA", ErrorMessage = "Invalid value for DatasourceType. Please provide a valid datasource type. Valid values are 'MSSQL'")]
        # [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        # ${DatasourceType},

        [Parameter(Mandatory=$true, Position=1, HelpMessage='Specifies a container object for which this cmdlet triggers the un-registration. To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet', ValueFromPipeline=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource]
        ${Container},

        [Parameter(Mandatory=$false, HelpMessage='Return the container to be deleted/unregistered.')]
        [switch]
        ${PassThru},

        [Parameter(Mandatory=$false, HelpMessage='Force unregisters container (prevents confirmation dialog). This parameter is optional.')]
        [switch]
        ${Force},
                
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
        # TODO: remove
        # $parameterSetName = $PsCmdlet.ParameterSetName        
        # BackupManagementType  : AzureWorkload
        # ContainerType         : VMAppContainer

        # Service values of the BackupManagementType:
        # "Invalid", "AzureIaasVM", "MAB", "DPM", "AzureBackupServer", "AzureSql", "AzureStorage",
        # "AzureWorkload", "DefaultBackup"
        
        # Service values of the containerType. The value of this property for: 
        # 1. Compute Azure VM is Microsoft.Compute/virtualMachines
        # 2.Classic Compute Azure VM is Microsoft.ClassicCompute/virtualMachines 
        # 3. Windows machines (like MAB, DPM etc) is Windows 
        # 4. Azure SQL instance is AzureSqlContainer. 
        # 5. Storage containers is StorageContainer. 
        # 6. Azure workload Backup is VMAppContainer
        if (-not (($Container.ContainerType -eq "Windows" && $Container.BackupManagementType -eq "MAB") ||
            ($Container.ContainerType -eq "AzureSqlContainer" && $Container.BackupManagementType -eq "AzureSql") ||
            ($Container.ContainerType -eq "StorageContainer" && $Container.BackupManagementType -eq "AzureStorage") ||
            ($Container.ContainerType -eq "VMAppContainer" && $Container.BackupManagementType -eq "AzureWorkload")))
        {
            throw "Please provide Container of containerType as Windows and backupManagementType as MAB or Container of containerType as AzureSqlContainer and backupManagementType as AzureSql or Container of containerType as StorageContainer and backupManagementType as AzureStorage. Provided Container has containerType $($Container.ContainerType) and backupManagementType $($Container.BackupManagementType) which is invalid";
        }
        
        $yesToAll = $Force
        $noToAll = $false
        
        if($Force -or $PSCmdlet.ShouldContinue("Deleting server's registration is a destructive operation and cannot be undone. All backup data (recovery points required to restore the data) and Backup items associated with protected server will be permanently deleted. Learn more about deleting your protected servers at https://aka.ms/deletebkp", "Unregister container", [ref]$yesToAll, [ref]$noToAll)
        ){            
            $containerName = $Container.Name

            # not used, deprecated. can be removed 
            if($Container.ContainerType -eq "AzureSqlContainer"){
                $containerName = "AzureSqlContainer;" + $containerName
            }

            if($Container.ContainerType -eq "VMAppContainer" -or $Container.ContainerType -eq "StorageContainer"){
                if($Container.ContainerType -eq "StorageContainer")
                {
                    $containerName = "StorageContainer;" + $containerName;
                }
                
                # UnregisterWorkloadContainers containerName, vaultName, resourceGroupName
                    # ProtectionContainers.UnregisterWithHttpMessagesAsync v, rg, "Azure", containerName
                
                $null = $PSBoundParameters.Remove('Container')
                $null = $PSBoundParameters.Remove('PassThru')
                $null = $PSBoundParameters.Remove('Force')
                $PSBoundParameters.Add('ContainerName', $containerName)
                $PSBoundParameters.Add('FabricName', "Azure")
                $PSBoundParameters.Add('NoWait', $true)

                $unregisterContainerResponse = Az.RecoveryServices.Internal\Unregister-AzRecoveryServicesProtectionContainer @PSBoundParameters

                $null = $PSBoundParameters.Remove('ContainerName')
                $null = $PSBoundParameters.Remove('FabricName')
                $null = $PSBoundParameters.Remove('NoWait')
                $null = $PSBoundParameters.Remove('SubscriptionId')
                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove('VaultName')

                $PSBoundParameters.Add('Target', $unregisterContainerResponse.Target)
                $PSBoundParameters.Add('RefreshAfter', 20)
                
                $operationStatus = GetOperationStatus @PSBoundParameters

                if($operationStatus -ne "Succeeded"){
                    $errormsg= "Unregister container operation failed with operationStatus: $operationStatus"
                    throw $errormsg
                }                
            }
            #else{ # TODO
                # recovery services - create new RS sub folder - generate - consume the command
                # RegisteredIdentities.DeleteWithHttpMessagesAsync containerName, vaultName, resourceGroupName
            #}

            if($PassThru){
                Write-Output $Container
            }
            
        }       
    }
}