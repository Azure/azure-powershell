function Get-AzRecoveryServicesBackupProtectionPolicy
{
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Gets backup protection policies for a recovery services vault.')]

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

        [Parameter(ParameterSetName="GetPolicyByName", Mandatory, HelpMessage='Specifies the name of the policy')]
        [System.String]
        ${Name},

        [Parameter(ParameterSetName="ListPolicy", Mandatory=$false, HelpMessage='Specifies the DatasourceType')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(Mandatory=$false, HelpMessage='Parameter to list policies for which smart tiering is Enabled/Disabled. Allowed values are $true, $false.')]
        [Nullable[System.Boolean]]
        ${IsArchiveSmartTieringEnabled},

        [Parameter(Mandatory=$false, HelpMessage='Type of policy to be fetched: Standard, Enhanced')]
        [ValidateSet("", "Standard", "Enhanced", ErrorMessage = "Invalid value for PolicySubType. Valid values are 'Standard', 'Enhanced'")]
        [System.String]
        ${PolicySubType} = "",
        
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
        $manifest = $null
        $workloadType = $null
        $isArchiveSmartTieringEnabled = $IsArchiveSmartTieringEnabled 
        $policySubType = $PolicySubType
        $null = $PSBoundParameters.Remove("IsArchiveSmartTieringEnabled")
        $null = $PSBoundParameters.Remove("PolicySubType")
        
        if($PSBoundParameters.ContainsKey("Name")){
            $null = $PSBoundParameters.Add("PolicyName", $Name)
            $null = $PSBoundParameters.Remove("Name")            
        }
        else{            
            if($PSBoundParameters.ContainsKey("DatasourceType")){
                # load manifest and get workload type filter if enabled
                $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
                
                if($manifest.filterPolicyBasedonWorkloadType -eq $true){                    
                    $workloadType = GetItemTypeFromDatasourceType -DatasourceType $DatasourceType
                }

                # add filter
                $filter = Get-BackupManagementTypeFilter -DatasourceType $DatasourceType
                Write-Debug "Policy filter - $filter"

                $null = $PSBoundParameters.Add("Filter", $filter)
                $null = $PSBoundParameters.Remove("DatasourceType")
            }            
        }

        $policies = Az.RecoveryServices.Internal\Get-AzRecoveryServicesBackupPolicy @PSBoundParameters

        if($workloadType -ne $null){
            
            # filter policy based on Workload Type if enabled
            $policies = $policies | Where-Object { $_.Property.WorkloadType -match $workloadType }
        }

        # filter based on PolicySubType
        if($policySubType -ne ""){
            
            if($policySubType.ToLower() -eq "enhanced"){
                $policies = $policies | Where-Object { $_.Property.PolicyType -ne $null -and $_.Property.PolicyType.ToString() -ne $null -and $_.Property.PolicyType.ToString().ToLower() -match "v2" }
            }
            else{
                $policies = $policies | Where-Object { -not ($_.Property.PolicyType -ne $null -and $_.Property.PolicyType.ToString() -ne $null -and $_.Property.PolicyType.ToString().ToLower() -match "v2") }
            }
        }

        if($isArchiveSmartTieringEnabled -ne $null){
            Write-Debug "Filter on IsArchiveSmartTieringEnabled $isArchiveSmartTieringEnabled"

            if($isArchiveSmartTieringEnabled){
                $policies = $policies | Where-Object { ($_.Property.TieringPolicy -ne $null -and ($_.Property.TieringPolicy["ArchivedRP"].TieringMode -eq "TierRecommended" -or $_.Property.TieringPolicy["ArchivedRP"].TieringMode -eq "TierAfter")) -or ($_.Property.SubProtectionPolicy -ne $null -and $_.Property.SubProtectionPolicy[$_.PolicyType -eq "Full"].TieringPolicy -ne $null -and ($_.Property.SubProtectionPolicy[$_.PolicyType -eq "Full"].TieringPolicy["ArchivedRP"].TieringMode -eq "TierRecommended" -or $_.Property.SubProtectionPolicy[$_.PolicyType -eq "Full"].TieringPolicy["ArchivedRP"].TieringMode -eq "TierAfter")) }
            }
            else{
                $policies = $policies | Where-Object { -not (($_.Property.TieringPolicy -ne $null -and ($_.Property.TieringPolicy["ArchivedRP"].TieringMode -eq "TierRecommended" -or $_.Property.TieringPolicy["ArchivedRP"].TieringMode -eq "TierAfter")) -or ($_.Property.SubProtectionPolicy -ne $null -and $_.Property.SubProtectionPolicy[$_.PolicyType -eq "Full"].TieringPolicy -ne $null -and ($_.Property.SubProtectionPolicy[$_.PolicyType -eq "Full"].TieringPolicy["ArchivedRP"].TieringMode -eq "TierRecommended" -or $_.Property.SubProtectionPolicy[$_.PolicyType -eq "Full"].TieringPolicy["ArchivedRP"].TieringMode -eq "TierAfter"))) }
            }
        }

        $policies
    }
}