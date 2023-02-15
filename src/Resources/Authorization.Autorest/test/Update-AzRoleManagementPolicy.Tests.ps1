if(($null -eq $TestName) -or ($TestName -contains 'Update-AzRoleManagementPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRoleManagementPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzRoleManagementPolicy' {
    It 'UpdateExpanded' {
        { 
            $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
            $expirationRule = [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.RoleManagementPolicyExpirationRule]@{
                isExpirationRequired = "false";
                maximumDuration = "P180D";
                id = "Expiration_Admin_Eligibility";
                ruleType = [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Support.RoleManagementPolicyRuleType]("RoleManagementPolicyExpirationRule");
                targetCaller = "Admin";
                targetOperation = @('All');
                targetLevel = "Eligibility";
                targetObject = $null;
                targetInheritableSetting = $null;
                targetEnforcedSetting = $null;
            }
            $notificationRule = [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.RoleManagementPolicyNotificationRule]@{
                notificationType = "Email";
                recipientType = "Approver";
                isDefaultRecipientsEnabled = "false";
                notificationLevel = "Critical";
                notificationRecipient = $null;                
                id = "Notification_Approver_Admin_Eligibility";
                ruleType = [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Support.RoleManagementPolicyRuleType]("RoleManagementPolicyNotificationRule");
                targetCaller = "Admin";
                targetOperation = @('All');
                targetLevel = "Eligibility";
                targetObject = $null;
                targetInheritableSetting = $null;
                targetEnforcedSetting = $null;
            }
            $rules = [Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleManagementPolicyRule[]]@($expirationRule, $notificationRule)
            $policy = Update-AzRoleManagementPolicy -Scope $scope -Name "33b520ea-3544-4abc-8565-3588deb8e68e" -Rule $rules
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}