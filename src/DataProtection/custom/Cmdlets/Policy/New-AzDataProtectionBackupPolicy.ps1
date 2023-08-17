function New-AzDataProtectionBackupPolicy
{

    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBaseBackupPolicyResource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates a new backup policy in a given backup vault')]

	param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource Group Name')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Vault Name')]
        [System.String]
        ${VaultName},

        [Parameter(Mandatory, HelpMessage='Policy Name')]
        [System.String]
        ${Name},

        [Parameter(Mandatory, HelpMessage='Policy Request Object')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupPolicy]
        ${Policy},
    
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
        # Do Validation
        $retentionNames = @()
        $tagNames = @()

        foreach($rule in $Policy.PolicyRule)
        {
            if(($rule.ObjectType -eq "AzureRetentionRule") -and ($rule.Name -ne "Default"))
            {
                $retentionNames += $rule.Name
            }

            if($rule.ObjectType -eq "AzureBackupRule")
            {
                foreach($criteria in $rule.Trigger.TaggingCriterion)
                {
                    if($criteria.TagInfoTagName -ne "Default")
                    {
                        $tagNames += $criteria.TagInfoTagName
                    }
                }
            }
        }
        if($retentionNames.Length -gt 1) { $retentionNames = $retentionNames | Sort-Object }
        if($tagNames.Length -gt 1) { $tagNames = $tagNames | Sort-Object }

        $index = 0
        while($index -lt $retentionNames.Length)
        {
            $retentionRuleName = $retentionNames[$index]
            if($index -eq $tagNames.Length)
            {
                throw "Retention Rule " + $retentionRuleName + " has no corresponding tag criteria. Please add tag criteria for " + $retentionRuleName + " retention or remove " + $retentionRuleName + " retention rule from backup policy."
            }
            if($retentionRuleName -ne $tagNames[$index])
            {
                throw "Retention Rule " + $retentionRuleName + " has no corresponding tag criteria. Please add tag criteria for " + $retentionRuleName + " retention or remove " + $retentionRuleName + " retention rule from backup policy."
            }
            if(($index -eq ($retentionNames.Length - 1)) -and ($tagNames.Length -gt $retentionNames.Length))
            {
                $tagName = $tagNames[$index + 1]
                throw "Tag Criteria " + $tagName + " has no corresponding retention rule. Please add retention rule for " + $tagName + " tag criteria or remove " + $tagName + " tag criteria from Azure Backup Rule."
            }
            $index += 1
        }

        $policyObject = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.BaseBackupPolicyResource]::new()
        $policyObject.Property = $Policy

        $null = $PSBoundParameters.Remove("Policy")
        $null = $PSBoundParameters.Add("Parameter", $policyObject)

        Az.DataProtection.Internal\New-AzDataProtectionBackupPolicy @PSBoundParameters
    }
}