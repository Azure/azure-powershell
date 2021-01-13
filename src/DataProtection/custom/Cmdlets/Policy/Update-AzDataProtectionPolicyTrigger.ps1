function Update-AzDataProtectionPolicyTrigger{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates new Schedule object')]

    param (
        [Parameter(Mandatory, HelpMessage='Source Datastore')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy]
        ${Policy},

        [Parameter(Mandatory, HelpMessage='Source Datastore')]
        [System.String[]]
        ${Schedule}
    )

    process {
        $backupRuleIndex = -1
        foreach($index in (0..$Policy.PolicyRule.Length)){
            if($Policy.PolicyRule[$index].ObjectType -eq "AzureBackupRule"){
                $backupRuleIndex = $index
            }
        }

        if($index -ne -1)
        {
            $Policy.PolicyRule[$backupRuleIndex].Trigger.ScheduleRepeatingTimeInterval = $Schedule
            return $Policy
        }
    }
}