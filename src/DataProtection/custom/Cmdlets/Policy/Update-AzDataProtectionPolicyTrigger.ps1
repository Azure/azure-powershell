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
        $clientDatasourceType = GetClientDatasourceType -ServiceDatasourceType $Policy.DatasourceType[0]
        ValidateBackupSchedule -DatasourceType $clientDatasourceType -Schedule $Schedule

        $backupRuleIndex = -1
        foreach($index in (0..$Policy.PolicyRule.Length)){
            if($Policy.PolicyRule[$index].ObjectType -eq "AzureBackupRule"){
                $backupRuleIndex = $index
            }
        }

        if($index -ne -1)
        {
            $Policy.PolicyRule[$backupRuleIndex].Trigger.ScheduleRepeatingTimeInterval = $Schedule
            $Policy.PolicyRule[$backupRuleIndex].Name = GetBackupFrequenceFromTimeInterval -RepeatingTimeInterval $Schedule
            return $Policy
        }
    }
}