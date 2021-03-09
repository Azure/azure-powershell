function Set-AzDataProtectionBackupPolicy
{
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
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy]
        ${Policy}
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

        $policyObject = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BaseBackupPolicyResource]::new()
        $policyObject.Property = $Policy

        $null = $PSBoundParameters.Remove("Policy")
        $null = $PSBoundParameters.Add("Parameter", $policyObject)

        Az.DataProtection.Internal\Set-AzDataProtectionBackupPolicy @PSBoundParameters
    }
}