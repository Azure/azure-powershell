function Get-AzRecoveryServicesBackupProtectableItem
{
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IWorkloadProtectableItemResource')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('This command will retrieve all protectable items within a certain container or across all registered containers. It will consist of all the elements of the hierarchy of the application. Returns DBs and their upper tier entities like Instance, AvailabilityGroup etc.')]

	param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The name of the resource group where the recovery services vault is present')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The name of the recovery services vault')]
        [System.String]
        ${VaultName},

        [Parameter(ParameterSetName="FilterParamSet", Mandatory=$true, HelpMessage='Specifies the DatasourceType')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(ParameterSetName="FilterParamSet", Mandatory=$false, HelpMessage='Specifies a container object for which this cmdlet gets protectable items. To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource]
        ${Container},

        [Parameter(ParameterSetName="IdParamSet", Mandatory=$true, HelpMessage='Specifies the ARM ID of an Instance or Availability Group')]
        [System.String]
        ${ParentID},

        [Parameter(ParameterSetName="FilterParamSet", Mandatory=$false, HelpMessage='Specifies the type of protectable item. Acceptable values: SQLDataBase, SQLInstance, SQLAvailabilityGroup')]
        [Parameter(ParameterSetName="IdParamSet", Mandatory=$false, HelpMessage='Specifies the type of protectable item. Acceptable values: SQLDataBase, SQLInstance, SQLAvailabilityGroup')]
        [ValidateSet("SQLDataBase", "SQLInstance", "SQLAvailabilityGroup", ErrorMessage = "Invalid value for ItemType. Please provide a valid item type. Valid values are 'SQLDataBase', 'SQLInstance' and 'SQLAvailabilityGroup'")]
        [System.String]
        ${ItemType},

        [Parameter(ParameterSetName="FilterParamSet", Mandatory=$false, HelpMessage="Specifies the name of the Database, Instance or AvailabilityGroup")]
        [Parameter(ParameterSetName="IdParamSet", Mandatory=$false, HelpMessage="Specifies the name of the Database, Instance or AvailabilityGroup")]        
        [System.String]
        ${Name},

        [Parameter(ParameterSetName="FilterParamSet", Mandatory=$false, HelpMessage="Specifies the name of the server to which the item belongs")]
        [Parameter(ParameterSetName="IdParamSet", Mandatory=$false, HelpMessage="Specifies the name of the server to which the item belongs")]        
        [System.String]
        ${ServerName},
                
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
        # get DSType from policy
        $parameterSetName = $PsCmdlet.ParameterSetName
                
        # get protectable items filter
        $filter = $null
        if($parameterSetName -eq "IdParamSet"){
            $filter = Get-ProtectableItemFilter -ParentID $ParentID 
        }
        else{
            if($Container -ne $null){
                $filter = Get-ProtectableItemFilter -DatasourceType $DatasourceType -Container $Container
            }
            else {                
                $filter = Get-ProtectableItemFilter -DatasourceType $DatasourceType
            }
        }
        
        $protectableItemsList = $null
        $null = $PSBoundParameters.Remove('DatasourceType')
        $null = $PSBoundParameters.Remove('Container')
        $null = $PSBoundParameters.Remove('ParentID')
        $null = $PSBoundParameters.Remove('ItemType')
        $null = $PSBoundParameters.Remove('Name')
        $null = $PSBoundParameters.Remove('ServerName')
        $PSBoundParameters.Add('Filter', $filter)
        $protectableItemsList = Az.RecoveryServices.Internal\Get-AzRecoveryServicesBackupProtectableItem @PSBoundParameters
        $null = $PSBoundParameters.Remove('Filter')

        # Protectable item type filter
        # alternate - $protectableItemsList.Property.GetType().Name -match
        if($ItemType -ne ""){
            $protectableItemsList = $protectableItemsList | Where-Object { $_.ProtectableItemType -eq $ItemType }
        }

        # Name filter 
        if($Name -ne ""){
            $protectableItemsList = $protectableItemsList | Where-Object { $_.Name -eq $Name }
        }
        
        # ServerName filter 
        if($ServerName -ne ""){
            $protectableItemsList = $protectableItemsList | Where-Object { $_.Property.ServerName -eq $ServerName }
        }
        
        # FetchNodesListAndAutoProtectionPolicy - TODO - add manifest control, only for SQL currently
        foreach($proItem in $protectableItemsList){

            $protectableItemURI = Get-ProtectableItemNameFromArmId -Id $proItem.Id

            $proItemType = ($protectableItemURI -split ";")[0]
            $itemName = ($protectableItemURI -split ";")[1]
            
            $containerUri = Get-ContainerNameFromArmId -Id $proItem.Id
                 
            if($proItem.ProtectableItemType -ne "SQLDataBase"){
                    
                $backupManagementType = "AzureWorkload"
                $filter = Get-ProtectionIntentFilter -ItemType $proItemType -ItemName $itemName -ParentName $containerUri -BackupManagementType $backupManagementType
                
                # list protection intent
                $PSBoundParameters.Add('Filter', $filter)
                $intentList = Az.RecoveryServices.Internal\Get-AzRecoveryServicesBackupProtectionIntent @PSBoundParameters
                $null = $PSBoundParameters.Remove('Filter')

                foreach($intent in $intentList){                    
                    Write-Debug "AutoProtectionPolicy - $($intent.PolicyId)"                    
                    $proItem.AutoProtectionPolicy = $intent.PolicyId
                }
            }

            if($proItem.ProtectableItemType -eq "SQLAvailabilityGroup"){
                try{
                    # get container
                    $PSBoundParameters.Add('FabricName', 'Azure')
                    $PSBoundParameters.Add('ContainerName', $containerUri)
                    $container = Az.RecoveryServices.Internal\Get-AzRecoveryServicesProtectionContainer @PSBoundParameters
                    $null = $PSBoundParameters.Remove('FabricName')
                    $null = $PSBoundParameters.Remove('ContainerName')

                    if($container -ne $null -and $container.Property.ExtendedInfo -ne $null){                        
                        Write-Host "NodesList - $($container.Property.ExtendedInfo.NodesList)"
                        $proItem.NodesList = $container.Property.ExtendedInfo.NodesList
                    }
                }
                catch{
                    Write-Debug "An error occurred: $($_.Exception.Message)"
                    # Write-Debug "An error occurred: $($Error[0].Exception.Message)"
                }
            }            
        }

        $protectableItemsList
    }
}