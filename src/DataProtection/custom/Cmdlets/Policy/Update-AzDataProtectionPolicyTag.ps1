function Update-AzDataProtectionPolicyTag{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Prepares Datasource object for backup')]

    param(
        [Parameter(ParameterSetName='updateTag', Mandatory, HelpMessage='Datasource Type')]
        [Parameter(ParameterSetName='RemoveTag', Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy]
        ${Policy},

        [Parameter(ParameterSetName='updateTag', Mandatory, HelpMessage='Datasource Type')]
        [Parameter(ParameterSetName='RemoveTag', Mandatory, HelpMessage='Datasource Type')]
        [System.String]
        ${Name},

        [Parameter(ParameterSetName='RemoveTag', Mandatory, HelpMessage='Datasource Type')]
        [System.Management.Automation.SwitchParameter]
        ${RemoveRule},

        [Parameter(ParameterSetName='updateTag', Mandatory, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IScheduleBasedBackupCriteria[]]
        ${Criteria}
    )

    process{
        # Validate the Criteria

        $clientDatasourceType = GetClientDatasourceType -ServiceDatasourceType $Policy.DatasourceType[0]
        $manifest = LoadManifest -DatasourceType $clientDatasourceType

        if($manifest.policySettings.supportedRetentionTags.Contains($Name) -eq $false)
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
                    $Policy.PolicyRule[$backupRuleIndex].Trigger.TaggingCriterion[$index].Criterion = $Criteria
                    return $Policy
                }
                
                if($tagIndex -eq -1)
                {
                    $tagCriteria = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.TaggingCriteria]::new()
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