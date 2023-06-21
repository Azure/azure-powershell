function Edit-AzDataProtectionPolicyTagClientObject{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Adds or removes schedule tag in an existing backup policy.')]

    param(
        [Parameter(ParameterSetName='updateTag', Mandatory, HelpMessage='Backup Policy Object.')]
        [Parameter(ParameterSetName='RemoveTag', Mandatory, HelpMessage='Backup Policy Object.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupPolicy]
        ${Policy},

        [Parameter(ParameterSetName='updateTag', Mandatory, HelpMessage='Name of the Schedule tag.')]
        [Parameter(ParameterSetName='RemoveTag', Mandatory, HelpMessage='Name of the Schedule tag.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.TagName]
        ${Name},

        [Parameter(ParameterSetName='RemoveTag', Mandatory, HelpMessage='Specify whether to remove the tag from the given policy object.')]
        [System.Management.Automation.SwitchParameter]
        ${RemoveRule},

        [Parameter(ParameterSetName='updateTag', Mandatory, HelpMessage='Criterias to be associated with the schedule tag.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IScheduleBasedBackupCriteria[]]
        ${Criteria}
    )

    process{
        # Validate the Criteria

        $clientDatasourceType = GetClientDatasourceType -ServiceDatasourceType $Policy.DatasourceType[0]
        $manifest = LoadManifest -DatasourceType $clientDatasourceType

        if($manifest.policySettings.supportedRetentionTags.Contains($Name.ToString()) -eq $false)
        {
            throw "Selected Retention Tag " + $Name  + " is not applicable for Datasource Type " + $clientDatasourceType
        }

        if($manifest.policySettings.disableCustomRetentionTag -eq $true)
        {
            foreach($criterion in $criteria)
            {
                if($criterion.AbsoluteCriterion -eq $null)
                {
                    throw "Only Absolute Criteria is supported for this policy"
                }
            }
        }

        $parameterSetName = $PsCmdlet.ParameterSetName
        $backupRuleIndex = -1
        foreach($index in (0..$Policy.PolicyRule.Length))
        {
            if($Policy.PolicyRule[$index].ObjectType -eq "AzureBackupRule")
            {
                $backupRuleIndex = $index
            }
        }

        if($backupRuleIndex -ne -1)
        {
            if($parameterSetName -eq "RemoveTag")
            {
                $filteredTags = $Policy.PolicyRule[$backupRuleIndex].Trigger.TaggingCriterion | Where-Object { $_.TagInfoTagName –ne $Name }
                $Policy.PolicyRule[$backupRuleIndex].Trigger.TaggingCriterion = $filteredTags
                return $Policy
            }

            if($parameterSetName -eq "updateTag")
            {
                $tagIndex = -1
                foreach($index in (0..$Policy.PolicyRule[$backupRuleIndex].Trigger.TaggingCriterion.Length))
                {
                    if($Policy.PolicyRule[$backupRuleIndex].Trigger.TaggingCriterion[$index].TagInfoTagName -eq $Name)
                    {
                        $tagIndex = $index
                    }
                }

                if($tagIndex -ne -1)
                {
                    $Policy.PolicyRule[$backupRuleIndex].Trigger.TaggingCriterion[$tagIndex].Criterion = $Criteria
                    return $Policy
                }
                
                if($tagIndex -eq -1)
                {
                    $tagCriteria = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.TaggingCriteria]::new()
                    $tagCriteria.TaggingPriority = GetTaggingPriority -Name $Name
                    $tagCriteria.Criterion = $Criteria
                    $tagCriteria.TagInfoTagName = $Name

                    $Policy.PolicyRule[$backupRuleIndex].Trigger.TaggingCriterion += $tagCriteria
                    return $Policy
                }
            }
        }
        
    }
}