function New-AzDataProtectionBackupPolicy
{

    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBaseBackupPolicyResource')]
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
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupPolicy]
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
        $retentionRulesExceptDefault = @()
        $tagCriteriaExceptDefault = @()

        # Collect all non-Default retention rules
        foreach($rule in $Policy.PolicyRule)
        {
            if($rule.ObjectType -eq "AzureRetentionRule" -and $rule.Name -ne "Default")
            {
                $retentionRulesExceptDefault += $rule.Name
            }
        }

        # Collect all non-Default tag criteria
        foreach($rule in $Policy.PolicyRule)
        {
            if($rule.ObjectType -eq "AzureBackupRule")
            {
                foreach($criteria in $rule.Trigger.TaggingCriterion)
                {
                    if($criteria.TagInfoTagName -ne "Default")
                    {
                        $tagCriteriaExceptDefault += $criteria.TagInfoTagName
                    }
                }
            }
        }

        # Sort both arrays for comparison
        if($retentionRulesExceptDefault.Length -gt 1) 
        { 
            $retentionRulesExceptDefault = $retentionRulesExceptDefault | Sort-Object 
        }
        if($tagCriteriaExceptDefault.Length -gt 1) 
        { 
            $tagCriteriaExceptDefault = $tagCriteriaExceptDefault | Sort-Object 
        }

        # Validate: non-Default retention rules must have matching tag criteria and vice versa
        if($retentionRulesExceptDefault.Length -ne $tagCriteriaExceptDefault.Length)
        {
            throw "Retention Rules and Tag Criteria mismatch. Number of non-Default retention rules (" + $retentionRulesExceptDefault.Length + ") must match number of non-Default tag criteria (" + $tagCriteriaExceptDefault.Length + ")."
        }

        # Check if each retention rule has a corresponding tag criteria with the same name
        for($i = 0; $i -lt $retentionRulesExceptDefault.Length; $i++)
        {
            $retentionRuleName = $retentionRulesExceptDefault[$i]
            $tagCriteriaName = $tagCriteriaExceptDefault[$i]
            
            if($retentionRuleName -ne $tagCriteriaName)
            {
                throw "Retention Rule '" + $retentionRuleName + "' does not have a corresponding tag criteria with the same name. Please ensure each retention rule has a matching tag criteria."
            }
        }

        $policyObject = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BaseBackupPolicyResource]::new()
        $policyObject.Property = $Policy

        $null = $PSBoundParameters.Remove("Policy")
        $null = $PSBoundParameters.Add("Parameter", $policyObject)

        Az.DataProtection.Internal\New-AzDataProtectionBackupPolicy @PSBoundParameters
    }
}