function Edit-AzDataProtectionPolicyTriggerClientObject{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.IBackupPolicy')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Updates Backup schedule of an existing backup policy.')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PreviewMessage("**********************************************************************************************`n
    * This cmdlet will undergo a breaking change in Az v16.0.0, to be released on May 2026. *`n
    * At least one change applies to this cmdlet.                                                     *`n
    * See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486            *`n
    ***************************************************************************************************")]

    param (
        [Parameter(ParameterSetName='ModifyBackupSchedule', Mandatory, HelpMessage='Backup Policy object.')]
        [Parameter(ParameterSetName='RemoveBackupSchedule', Mandatory, HelpMessage='Backup Policy object.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.IBackupPolicy]
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
                # TODO : can add a optional parameter TimeZone
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