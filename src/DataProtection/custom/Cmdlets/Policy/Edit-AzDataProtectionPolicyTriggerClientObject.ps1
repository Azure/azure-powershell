function Edit-AzDataProtectionPolicyTriggerClientObject{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Updates Backup schedule of an existing backup policy.')]

    param (
        [Parameter(Mandatory, HelpMessage='Backup Policy object.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy]
        ${Policy},

        [Parameter(Mandatory, HelpMessage='Schedule to be associated to backup policy.')]
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