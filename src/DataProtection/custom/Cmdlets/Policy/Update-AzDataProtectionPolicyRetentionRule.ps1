

function Update-AzDataProtectionPolicyRetentionRule {
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Adds or removes Retention Rule to existing Policy')]

    param(
        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='Backup Policy')]
        [Parameter(ParameterSetName='RemoveRetention',Mandatory, HelpMessage='Backup Policy')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy]
        ${Policy},

        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='Retention Rule Name')]
        [Parameter(ParameterSetName='RemoveRetention',Mandatory, HelpMessage='Retention Rule Name')]
        [System.String]
        ${Name},

        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='is default')]
        [System.Boolean]
        ${IsDefault},

        [Parameter(ParameterSetName='RemoveRetention',Mandatory, HelpMessage='SwitchParameter')]
        [System.Management.Automation.SwitchParameter]
        ${RemoveRule},

        [Parameter(ParameterSetName='AddRetention',Mandatory, HelpMessage='SwitchParameter')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ISourceLifeCycle[]]
        ${LifeCycles}
    )

    process {
        $parameterSetName = $PsCmdlet.ParameterSetName
        
        if($parameterSetName -eq "RemoveRetention"){
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

                $newRetentionRule = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.AzureRetentionRule]::new()
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