﻿

function Edit-AzDataProtectionPolicyRetentionRuleClientObject {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Adds or removes Retention Rule to existing Policy')]

    param(
        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='Backup Policy Object')]
        [Parameter(ParameterSetName='RemoveRetention',Mandatory, HelpMessage='Backup Policy Object')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupPolicy]
        ${Policy},

        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='Retention Rule Name')]
        [Parameter(ParameterSetName='RemoveRetention',Mandatory, HelpMessage='Retention Rule Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RetentionRuleName]
        ${Name},

        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='Specifies if retention rule is default retention rule.')]
        [System.Boolean]
        ${IsDefault},

        [Parameter(ParameterSetName='RemoveRetention',Mandatory, HelpMessage='Specifies whether to remove the retention rule.')]
        [System.Management.Automation.SwitchParameter]
        ${RemoveRule},

        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='Life cycles associated with the retention rule.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISourceLifeCycle[]]
        ${LifeCycles}
    )

    process {
        $parameterSetName = $PsCmdlet.ParameterSetName
        
        if($parameterSetName -eq "RemoveRetention"){
            if($Name -eq "Default")
            {
                throw  "Removing Default Retention Rule is not allowed. Please try again with different rule name."
            }
            $filteredRules = $Policy.PolicyRule | Where-Object { $_.Name –ne $Name }
            $Policy.PolicyRule = $filteredRules
            return $Policy
        }

        if($parameterSetName -eq "AddRetention"){
            $retentionPolicyIndex = -1
            Foreach($index in (1..$Policy.PolicyRule.Length)){
                if($Policy.PolicyRule[$index].Name -eq $Name){
                    $retentionPolicyIndex = $index
                }
            }

            if($retentionPolicyIndex -eq -1){
                $DatasourceType = GetClientDatasourceType -ServiceDatasourceType $Policy.DatasourceType[0]
                $manifest = LoadManifest -DatasourceType $DatasourceType
                if($manifest.policySettings.disableAddRetentionRule -eq $true)
                {
                    $message = "Adding New Retention Rule is not supported for " + $DatasourceType + " datasource Type."
                    throw $message
                }

                if($manifest.policySettings.supportedRetentionTags.Contains($Name.ToString()) -eq $false)
                {
                    throw "Selected Retention Rule " + $Name  + " is not applicable for Datasource Type " + $clientDatasourceType
                }

                $newRetentionRule = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AzureRetentionRule]::new()
                $newRetentionRule.ObjectType = "AzureRetentionRule"
                $newRetentionRule.IsDefault = $IsDefault
                $newRetentionRule.Name = $Name
                $newRetentionRule.LifeCycle = $LifeCycles
                $Policy.PolicyRule += $newRetentionRule

                return $Policy
            }

            if($retentionPolicyIndex -ne -1){
                $Policy.PolicyRule[$retentionPolicyIndex].LifeCycle = $LifeCycles
                return $Policy
            }
        }
    }

}