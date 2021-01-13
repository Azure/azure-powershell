
function TranslateBackupPolicy {
	param(
		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [PSObject]
        $policy
	)
	
	process{
		$translatedPolicy = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.BackupPolicy]::DeserializeFromPSObject($policy)
		$translatedPolicy.PolicyRule = @()
		Foreach ($policyRule in $policy.PolicyRule){
			$translatedPolicyRule = TranslateBackupPolicyRule -PolicyRule $policyRule
			$translatedPolicy.PolicyRule += $translatedPolicyRule
		}
		return $translatedPolicy
	}
}

function TranslateBackupPolicyRule {
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[PSObject]
		$PolicyRule
	)

	process {
		if($PolicyRule.ObjectType -eq "AzureBackupRule"){
			$translatedPolicyRule = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.AzureBackupRule]::DeserializeFromPSObject($PolicyRule)
			$translatedPolicyRule.BackupParameter = TranslateBackupParam -BackupParam $PolicyRule.BackupParameter
			$translatedPolicyRule.Trigger = TranslateBackupPolicyTrigger -Trigger $PolicyRule.Trigger
			return $translatedPolicyRule
		}

		if($PolicyRule.ObjectType -eq "AzureRetentionRule"){
			$translatedPolicyRule = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.AzureRetentionRule]::DeserializeFromPSObject($PolicyRule)
			$translatedPolicyRule.Lifecycle = @()
			Foreach($lifecycle in $PolicyRule.Lifecycle){
				$translatedPolicyRule.Lifecycle += TranslatePolicyRetentionLifeCycle -Lifecycle $lifecycle
			}
			return $translatedPolicyRule
		}
	}
}

function TranslateBackupParam {
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[PSObject]
		$BackupParam
	)

	process {
		if($BackupParam.ObjectType -eq "AzureBackupParams") {
			$translatedBackupParam = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.AzureBackupParams]::DeserializeFromPSObject($BackupParam)
			return $translatedBackupParam
		}
	}
}

function TranslateBackupPolicyTrigger {
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[PSObject]
		$Trigger
	)

	process {
		if($Trigger.ObjectType -eq "ScheduleBasedTriggerContext"){
			$translatedTrigger = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ScheduleBasedTriggerContext]::DeserializeFromPSObject($Trigger)
			$translatedTrigger.TaggingCriterion = @()
			Foreach ($triggerCriteria in $Trigger.TaggingCriterion){
				$translatedTrigger.TaggingCriterion += TranslateBackupPolicyTagCriteria -TagCriteria $triggerCriteria
			}
			return $translatedTrigger
		}
	}
}

function TranslateBackupPolicyTagCriteria {
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[PSObject]
		$TagCriteria
	)

	process {
		$translatedTagCriteria = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.TaggingCriteria]::DeserializeFromPSObject($TagCriteria)
		return $translatedTagCriteria
	}
}

function TranslatePolicyRetentionLifeCycle {
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[PSObject]
		$LifeCycle
	)

	process {
		$translatedLifeCycle = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.SourceLifeCycle]::DeserializeFromPSObject($LifeCycle)
		return $translatedLifeCycle
	}
}

function GetBackupFrequencyString {
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.BackupFrequency]
		$frequency
	)

	process {
		$freq = $frequency.ToString()
		if($freq -eq "Weekly"){
			return "P1W"
		}

		if($freq -eq "Daily"){
			return "P1D"
		}
	}
}

function GetTaggingPriority {
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$Name
	)

	process{
		$priorityMap = @{"Default"=99;"Weekly"=20;"Monthly"=15;"Yearly"=10}
		return $priorityMap[$Name]
	}
}