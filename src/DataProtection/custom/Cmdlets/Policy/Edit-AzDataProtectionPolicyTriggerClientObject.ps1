function Edit-AzDataProtectionPolicyTriggerClientObject{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Updates Backup schedule of an existing backup policy.')]

    param (
        [Parameter(ParameterSetName='ModifyBackupSchedule', Mandatory, HelpMessage='Backup Policy object.')]
        [Parameter(ParameterSetName='RemoveBackupSchedule', Mandatory, HelpMessage='Backup Policy object.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupPolicy]
        ${Policy},

        [Parameter(ParameterSetName='ModifyBackupSchedule', Mandatory, HelpMessage='Schedule to be associated to backup policy.')]
        [System.String[]]
        ${Schedule},

        [Parameter(ParameterSetName='RemoveBackupSchedule',Mandatory, HelpMessage='Specifies whether to remove the backup Schedule.')]
        [Switch]
        ${RemoveSchedule}
    )

    process {
        $parameterSetName = $PsCmdlet.ParameterSetName

        if($parameterSetName -eq "RemoveBackupSchedule"){
            $filteredRules = $Policy.PolicyRule | Where-Object { $_.ObjectType –ne "AzureBackupRule" }
            $Policy.PolicyRule = $filteredRules
            return $Policy
        }

        if($parameterSetName -eq "ModifyBackupSchedule"){
            $clientDatasourceType = GetClientDatasourceType -ServiceDatasourceType $Policy.DatasourceType[0]
            ValidateBackupSchedule -DatasourceType $clientDatasourceType -Schedule $Schedule

            $backupRuleIndex = -1
            foreach($index in (0..$Policy.PolicyRule.Length)){
                if($Policy.PolicyRule[$index].ObjectType -eq "AzureBackupRule"){
                    $backupRuleIndex = $index
                }
            }

            if($index -ne -1) # $backupRuleIndex -ne -1
            {
                # DppRef : can add a optional parameter TimeZone
                # set Local TimeZone for policy Schedule
                $timezone = Get-TimeZone
                $Policy.PolicyRule[$backupRuleIndex].Trigger.ScheduleTimeZone = $timezone.StandardName

                $Policy.PolicyRule[$backupRuleIndex].Trigger.ScheduleRepeatingTimeInterval = $Schedule
                $Policy.PolicyRule[$backupRuleIndex].Name = GetBackupFrequenceFromTimeInterval -RepeatingTimeInterval $Schedule
                return $Policy
            }
        }
    }
}