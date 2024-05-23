

function Update-AzDataProtectionResourceGuard
{   
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IResourceGuardResource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Updates a resource guard belonging to a resource group')]

    param(
        [Parameter(ParameterSetName="UpdateResourceGuardOperations", Mandatory=$false, HelpMessage='Subscription Id of the resource guard')]
        [System.String]
        ${SubscriptionId},

        [Parameter(ParameterSetName="UpdateResourceGuardOperations", Mandatory, HelpMessage='Resource Group name of the resource guard')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName="UpdateResourceGuardOperations", Mandatory, HelpMessage='Name of the resource guard')]
        [System.String]
        ${Name},

        [Parameter(ParameterSetName="UpdateResourceGuardOperations", Mandatory=$false, HelpMessage='Optional ETag')]
        [System.String]
        ${ETag},

        [Parameter(ParameterSetName="UpdateResourceGuardOperations", Mandatory=$false, HelpMessage='This parameter is no longer in use and will be depricated')]
        [System.String]
        ${IdentityType},
        
        [Parameter(ParameterSetName="UpdateResourceGuardOperations", Mandatory=$false, HelpMessage='Resource tags')]        
        [Hashtable]
        ${Tag},

        [Parameter(ParameterSetName="UpdateResourceGuardOperations", Mandatory=$false, HelpMessage='List of critical operations which are not protected by this resourceGuard. Supported values are DeleteProtection, UpdateProtection, UpdatePolicy, GetSecurityPin, DeleteBackupInstance, RecoveryServicesDisableImmutability, DataProtectionDisableImmutability, RecoveryServicesModifyEncryptionSettings, DataProtectionModifyEncryptionSettings')]
        [System.String[]]
        ${CriticalOperationExclusionList},
        
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
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
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
        $ResGuard = $null
        if($SubscriptionId -ne $null){
            $ResGuard = Get-AzDataProtectionResourceGuard -Name $Name -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId
        }
        else {
            $ResGuard = Get-AzDataProtectionResourceGuard -Name $Name -ResourceGroupName $ResourceGroupName
        }       
        
        # modify Critical operation exclusion list 
        $CriticalOperationsMap = @{ DeleteProtection = "Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/delete"; UpdateProtection = "Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/write"; UpdatePolicy = "Microsoft.RecoveryServices/vaults/backupPolicies/write"; GetSecurityPin = "Microsoft.RecoveryServices/vaults/backupSecurityPIN/action"; DeleteBackupInstance = "Microsoft.DataProtection/backupVaults/backupInstances/delete"; RecoveryServicesDisableImmutability = "Microsoft.RecoveryServices/vaults/write#reduceImmutabilityState"; DataProtectionDisableImmutability = "Microsoft.DataProtection/backupVaults/write#reduceImmutabilityState"; RecoveryServicesModifyEncryptionSettings = "Microsoft.RecoveryServices/vaults/write#modifyEncryptionSettings"; DataProtectionModifyEncryptionSettings = "Microsoft.DataProtection/backupVaults/write#modifyEncryptionSettings"}
       
        $CriticalOperationExclusionListInternal = [System.Collections.ArrayList]@()

        foreach($item in $CriticalOperationExclusionList)
        {
            if($CriticalOperationsMap.ContainsKey($item)){
                $arrayIndex = $CriticalOperationExclusionListInternal.Add($CriticalOperationsMap[$item])
            }
            else {
                $arrayIndex = $CriticalOperationExclusionListInternal.Add($item)
            }
        }

        if($PSBoundParameters.ContainsKey("CriticalOperationExclusionList"))
        {
            $null = $PSBoundParameters.Remove("CriticalOperationExclusionList")
            $null = $PSBoundParameters.Add("CriticalOperationExclusionList", $CriticalOperationExclusionListInternal)
        }

        # Add Location
        $null = $PSBoundParameters.Add("Location", $ResGuard.Location)
        
        if($PSBoundParameters.ContainsKey("IdentityType"))
        {
            $null = $PSBoundParameters.Remove("IdentityType")
            # TODO : need to move this to parameter level 
            Write-Warning "Parameter IdentityType is no longer in use and will be depricated in upcoming breaking change release"
        }

        Az.DataProtection.Internal\New-AzDataProtectionResourceGuard @PSBoundParameters
    }
}