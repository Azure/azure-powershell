function New-AzRecoveryServicesBackupPolicy
{
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Creates a new backup policy in a given recovery services vault')]

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

        [Parameter(Mandatory, HelpMessage='Policy Name for the policy to be created')]
        [System.String]
        ${PolicyName},

        [Parameter(Mandatory, HelpMessage='Workload specific Backup policy object.')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy]
        ${Policy},

        [Parameter(Mandatory=$false)]
        [ValidateRange(1, 5)]
        [Nullable[int]]
        ${SnapshotRetentionDurationInDays},

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
        ${ProxyUseDefaultCredentials},
            
        [Parameter(Mandatory=$false)]
        [Nullable[System.Boolean]]
        ${MoveToArchiveTier},
        
        [Parameter(Mandatory=$false)]
        [ValidateSet('TierRecommended', 'TierAfter')]
        [string]
        ${TieringMode},
        
        [Parameter(Mandatory=$false)]
        [Nullable[int]]
        ${TierAfterDuration},

        [Parameter(Mandatory=$false)]
        [ValidateSet("Days", "Months", ErrorMessage = "Invalid value for DurationType. Please provide a valid value. Valid values are Days/Months")]
        [string]
        ${TierAfterDurationType}
        
    )

    process
    {   
        #get datasource type
        $BackupManagementType = $policy.BackupManagementType
        $WorkloadType = $policy.WorkLoadType
        $DataSourceType = Get-DataSourceType -BackupManagementType $BackupManagementType -WorkloadType $WorkloadType
        $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()

        if($SnapshotRetentionDurationInDays -ne $null)
        {
            $policy.instantRpRetentionRangeInDay=$SnapshotRetentionDurationInDays
            if(($policy.SchedulePolicy.ScheduleRunFrequency -eq "Weekly") -and ($policy.instantRpRetentionRangeInDay -ne 5))
            {
                $errormsg="SnapshotRetentionDuration value must be 5 for backup policy with frequency of schedule as Weekly"
                throw $errormsg
            }
        }

        if($MoveToArchiveTier -ne $null)
        {
            if($manifest.allowedSubProtectionPolicyTypes.Count -lt 2)
            {
                 $tieringdetails = $policy.tieringPolicy.AdditionalProperties.ArchivedRP
            }
            elseif($manifest.allowedSubProtectionPolicyTypes.Count -gt 2)
            {
                $FullBackupPolicy =  $policy.SubProtectionPolicy | where { $_.PolicyType -match "Full" }
                $Index = $policy.SubProtectionPolicy.IndexOf($FullBackupPolicy)
                $tieringdetails =$policy.SubProtectionPolicy[$Index].tieringPolicy.AdditionalProperties.ArchivedRP
            }
            if($manifest.IsSmartTieringSupported -ne $true)
            {
                $errormsg="Smart tiering not supported for given workload type"
                throw $errormsg
            }
            if($MoveToArchiveTier -eq $false)   #if tiering disabled
            {
                if(($TieringMode -ne "") -or ($TierAfterDuration -ne $null) -or ($TierAfterDurationType -ne ""))
                {
                    $errormsg= "Invalid parameters for disable tiering"
                    throw $errormsg
                }
                $tieringdetails.tieringMode="DoNotTier"
                $tieringdetails.duration=$null
                $tieringdetails.durationType=$null
            }
            else #if tiering enabled
            {
                if($TieringMode -ne $null){
                    $tieringdetails.tieringMode=$TieringMode
                }
                if($TierAfterDuration -ne $null){
                    $tieringdetails.duration=$TierAfterDuration
                }
                if($TierAfterDurationType -ne $null){
                    $tieringdetails.durationType=$TierAfterDurationType
                }
                if($manifest.allowedSubProtectionPolicyTypes.Count -gt 2){
                    if($tieringdetails.durationType -ne "Days" -and $tieringdetails.tieringMode -eq "TierAfter")
                    {
                        $errormsg="DurationType for AzureWorkload should be days"
                        throw $errormsg
                    }
                }
                elseif($manifest.allowedSubProtectionPolicyTypes.Count -lt 2){
                    if($tieringdetails.durationType -ne "Months" -and $tieringdetails.tieringMode -eq "TierAfter")
                    {
                        $errormsg="DurationType for AzureVM should be Months"
                        throw $errormsg
                    }
                }
                if($tieringdetails.tieringMode -eq "TierRecommended")
                {
                    $tieringdetails.duration=0
                    $tieringdetails.durationType="Invalid"
                }
                if(($manifest.allowedSubProtectionPolicyTypes.Count -gt 2) -and ($tieringdetails.tieringMode -eq "TierRecommended"))
                {
                    $errormsg="TierRecommended not supported for AzureWorkload"
                    throw $errormsg
                }
            }
                #Validation
                ValidateTieringPolicy
        }
        $null = $PSBoundParameters.Remove("SnapshotRetentionDurationInDays")
        $null = $PSBoundParameters.Remove("MoveToArchiveTier")
        $null = $PSBoundParameters.Remove("TieringMode")
        $null = $PSBoundParameters.Remove("TierAfterDuration")
        $null = $PSBoundParameters.Remove("TierAfterDurationType")


        # RsvRef
        # public string[] ResourceGuardOperationRequest --- this should be a parameter (check in SDK code) ? If yes, optional parameters ? 
                
        # RsvRef : add policy validation (preferably one entry point)
        
        $policyObject = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectionPolicyResource]::new()
        $policyObject.Property = $Policy

        
        
        $null = $PSBoundParameters.Remove("Policy")
        $null = $PSBoundParameters.Add("Parameter", $policyObject)

        # RsvRef : change command name while taking a pull or modify the directive
        Az.RecoveryServices.Internal\New-AzRecoveryServicesBackupPolicy @PSBoundParameters
    }
}