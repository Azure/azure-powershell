function Get-AzDataProtectionRecoveryPoint_List
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Gets list of recovery point associated with a protected backup instance.')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the vault')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(HelpMessage='Resource Group of the backup vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(HelpMessage='Name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(HelpMessage='Unique Name of protected backup instance')]
        [System.String]
        ${BackupInstanceName},

        [Parameter(HelpMessage='Start Time filter for recovery points')]
        [System.DateTime]
        ${StartTime},

        [Parameter(HelpMessage='End Time filter for recovery points')]
        [System.DateTime]
        ${EndTime},

        [Parameter(Mandatory=$false, HelpMessage='Switch parameter to fetch recovery points from secondary region')]
        [Switch]
        ${UseSecondaryRegion},

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
        $filter = ""
        if($PSBoundParameters.ContainsKey("StartTime"))
        {
            $utcStartTime = $StartTime.ToUniversalTime()
            $startTimeFilter = $utcStartTime.ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
            $filter = "startDate eq '" + $startTimeFilter + "'"
        }
        if($PSBoundParameters.ContainsKey("EndTime"))
        {
            if($PSBoundParameters.ContainsKey("StartTime"))
            {
                $filter += " and "
            }
            $utcEndTime = $EndTime.ToUniversalTime()
            $endTimeFilter = $utcEndTime.ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
            $filter += "endDate eq '" + $endTimeFilter + "'"
            $null = $PSBoundParameters.Remove("EndTime")
        }

        if($PSBoundParameters.ContainsKey("StartTime"))
        {
            $null = $PSBoundParameters.Remove("StartTime")
        }

        if($filter -ne "")
        {
            $null = $PSBoundParameters.Add("Filter", $filter)
        }

        $hasUseSecondaryRegion = $PSBoundParameters.Remove("UseSecondaryRegion")

        $rps = $null
        if($hasUseSecondaryRegion){

            # fetch vault from ARG
            $null = $PSBoundParameters.Remove("BackupInstanceName")
            $hasFilter = $PSBoundParameters.Remove("Filter")            
            $hasSubscriptionId = $PSBoundParameters.Remove("SubscriptionId")
            $null = $PSBoundParameters.Remove("ResourceGroupName")
            $null = $PSBoundParameters.Remove("VaultName")
            $PSBoundParameters.Add('ResourceGroup', $ResourceGroupName)
            $PSBoundParameters.Add('Vault', $VaultName)
            if($hasSubscriptionId) { $PSBoundParameters.Add('Subscription', $SubscriptionId) }
            
            $vault = Search-AzDataProtectionBackupVaultInAzGraph @PSBoundParameters

            $null = $PSBoundParameters.Remove("Subscription")
            $null = $PSBoundParameters.Remove("ResourceGroup")
            $null = $PSBoundParameters.Remove("Vault")
            $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
            if($hasSubscriptionId) { $PSBoundParameters.Add('SubscriptionId', $SubscriptionId) }
            if($hasFilter) { $PSBoundParameters.Add('Filter', $Filter) }

            $backupInstanceId = "/subscriptions/" + $SubscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.DataProtection/backupVaults/" + $VaultName + "/backupInstances/" + $BackupInstanceName

            $PSBoundParameters.Add('Location', $vault.ReplicatedRegion[0])
            $PSBoundParameters.Add('SourceBackupInstanceId', $backupInstanceId)
            $PSBoundParameters.Add('SourceRegion', $vault.Location)

            $rps = Az.DataProtection.internal\Get-AzDataProtectionFetchSecondaryRecoveryPoint @PSBoundParameters
        }
        else{
            $rps = Az.DataProtection.internal\Get-AzDataProtectionRecoveryPoint @PSBoundParameters
        }
        
        return $rps
    }
}