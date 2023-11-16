function Get-AzRecoveryServicesBackupItem
{
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Gets list of backup items protected with a recovery services vault')]

	param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The name of the resource group where the recovery services vault is present.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The name of the recovery services vault.')]
        [System.String]
        ${VaultName},
        
        [Parameter(ParameterSetName="GetItemsForVault", Mandatory=$true, HelpMessage='Specifies the DatasourceType')]
        [Parameter(ParameterSetName="GetItemsForContainer", Mandatory=$true, HelpMessage='Specifies the DatasourceType')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(ParameterSetName="GetItemsForContainer", Mandatory=$true, HelpMessage='Specifies a container object from which this cmdlet gets backup items. To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource]
        ${Container},

        [Parameter(ParameterSetName="GetItemsForpolicy", Mandatory=$true, HelpMessage='Protection policy object')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource]
        ${Policy},

        [Parameter(Mandatory=$false, HelpMessage='FriendlyName of the backed up item')]
        [System.String]
        ${FriendlyName},

        [Parameter(Mandatory=$false, HelpMessage='Specifies the name of backup item. For file share, specify the unique ID of protected file share.')]
        [System.String]
        ${Name},
                
        [Parameter(Mandatory=$false, HelpMessage='Specifies the overall protection status of an item in the container. The acceptable values for this parameter are: Healthy, Unhealthy')]
        [ValidateSet("Healthy", "Unhealthy", ErrorMessage = "Invalid value for ProtectionStatus. Please provide a valid protection status. Valid values are 'Healthy' and 'Unhealthy'.")]
        [System.String]
        ${ProtectionStatus},

        [Parameter(Mandatory=$false, HelpMessage="Specifies the state of protection. The acceptable values for this parameter are: `n IRPending. Initial synchronization has not started and there is no recovery point yet. `n Protected. Protection is ongoing. `n ProtectionError. There is a protection error. `n ProtectionStopped. Protection is disabled.")]
        [ValidateSet("IRPending", "Protected", "ProtectionError", "ProtectionStopped", "BackupsSuspended", ErrorMessage = "Invalid value for ProtectionState. Please provide a valid protection state. Valid values are 'IRPending', 'Protected', 'ProtectionError', 'ProtectionStopped', 'BackupsSuspended'.")]
        [System.String]
        ${ProtectionState},

        [Parameter(Mandatory=$false, HelpMessage="Specifies the delete state of the item The acceptable values for this parameter are: `n ToBeDeleted `n NotDeleted")]
        [System.String]
        [ValidateSet("ToBeDeleted", "NotDeleted", ErrorMessage = "Invalid value for DeleteState. Please provide a valid delete state. Valid values are 'ToBeDeleted', 'NotDeleted'.")]
        ${DeleteState},

        # [Parameter(Mandatory=$false, HelpMessage='Specifies the name of backup item')]
        # [System.String]
        # ${UseSecondaryRegion},
                
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
        if($parameterSetName -eq "GetItemsForpolicy"){
            $DatasourceType = GetDatasourceTypeFromPolicy -Policy $Policy
        }
        $manifest = LoadManifest -DatasourceType $DatasourceType

        # get backup items filter 
        $filter = Get-ProtectedItemFilter -DatasourceType $DatasourceType -Container $Container -Policy $Policy
        
        $itemsList = $null
        
        $null = $PSBoundParameters.Remove('DatasourceType')
        $null = $PSBoundParameters.Remove('Container')
        $null = $PSBoundParameters.Remove('Policy')
        $null = $PSBoundParameters.Remove('FriendlyName')
        $null = $PSBoundParameters.Remove('Name')
        $null = $PSBoundParameters.Remove('ProtectionStatus')
        $null = $PSBoundParameters.Remove('ProtectionState')
        $null = $PSBoundParameters.Remove('DeleteState')
        $PSBoundParameters.Add('Filter', $filter)
        $itemsList = Az.RecoveryServices.Internal\Get-AzRecoveryServicesBackupProtectedItem @PSBoundParameters
        
        $null = $PSBoundParameters.Remove('Filter')

        # filter on policy or container
        if($parameterSetName -eq "GetItemsForpolicy"){
            $itemsList = $itemsList | Where-Object { $_.PolicyId.ToLower() -match $Policy.Id.ToLower() }
        }
        elseif($parameterSetName -eq "GetItemsForContainer"){
            $itemsList = $itemsList | Where-Object { $_.ContainerName.ToLower() -match $Container.Name.ToLower() }
        }
        
        # Item Name filter - match with protected item URI
        if($Name -ne ""){
            $itemsList = $itemsList | Where-Object { $_.ID.Split("/protectedItems/")[-1].ToLower() -match $Name.ToLower() }
        }

        # FriendlyName filter for AzureFiles 
        if($manifest.allowFriendlyNameFilterForProtectedItems -eq $true -and $FriendlyName -ne ""){ 
            $itemsList = $itemsList | Where-Object { $_.ID.Split("/protectedItems/")[-1].ToLower() -match $FriendlyName.ToLower() }
        }
        elseif($FriendlyName -ne ""){
            $errormsg= "FriendlyName parameter isn't supported for given DatasourceType $DatasourceType"
            throw $errormsg
        }

        # ProtectionStatus filter 
        if($ProtectionStatus -ne ""){
            $itemsList = $itemsList | Where-Object { $_.Property.ProtectionStatus -eq $ProtectionStatus }
        }
        
        # ProtectionStatus filter 
        if($ProtectionState -ne ""){
            $itemsList = $itemsList | Where-Object { $_.Property.ProtectionState -eq $ProtectionState }
        }
         
        # delete state filter - TODO : this might need to be corrected
        if($DeleteState -eq "NotDeleted"){            
            $itemsList = $itemsList | Where-Object { $_.IsScheduledForDeferredDelete -eq $null } # -or $_.IsScheduledForDeferredDelete -eq $false
        }

        if($DeleteState -eq "ToBeDeleted"){            
            $itemsList = $itemsList | Where-Object { $_.IsScheduledForDeferredDelete -ne $null } # $_.IsScheduledForDeferredDelete -eq $false
        }

        # Extended Info - only to be added when itemName or Friendly name given 
        if($Name -ne "" -or ($manifest.allowFriendlyNameFilterForProtectedItems -eq $true -and $FriendlyName -ne "")){
            
            $PSBoundParameters.Add('ContainerName', $containerName)
            $PSBoundParameters.Add('FabricName', 'Azure')
            $PSBoundParameters.Add('Name', $item.Name)
            $PSBoundParameters.Add('Filter', "expand eq 'extendedinfo'")

            foreach($item in $itemsList){
                $containerName = Get-ContainerNameFromArmId -Id $item.Id

                $itemDetails = $null
                $PSBoundParameters.Add('Name', $item.Name)
                $itemDetails = Az.RecoveryServices.Internal\Get-AzRecoveryServicesProtectedItem @PSBoundParameters
                $null = $PSBoundParameters.Remove('Name')

                $item.Property.ExtendedInfo = $itemDetails.Property.ExtendedInfo
            }
        }

        # get MAB protected items 
            # filter : BackupManagementType = MAB 
            # fetch from service 
            # fetch the container name from ITEM ARM Id and match with the given container name       
        
        $itemsList
    }
}