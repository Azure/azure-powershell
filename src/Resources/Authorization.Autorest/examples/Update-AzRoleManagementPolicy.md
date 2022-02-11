### Example 1: Update expiration rule of a policy
```powershell
PS C:\> $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
PS C:\> $expirationRule = [RoleManagementPolicyExpirationRule]@{
            isExpirationRequired = "false";
            maximumDuration = "P180D";
            id = "Expiration_Admin_Eligibility";
            ruleType = [RoleManagementPolicyRuleType]("RoleManagementPolicyExpirationRule");
            targetCaller = "Admin";
            targetOperation = @('All');
            targetLevel = "Eligibility";
            targetObject = $null;
            targetInheritableSetting = $null;
            targetEnforcedSetting = $null;
        }
PS C:\> $rules = [IRoleManagementPolicyRule[]]@($expirationRule)
PS C:\> Update-AzRoleManagementPolicy -Scope $scope -Name "33b520ea-3544-4abc-8565-3588deb8e68e" -Rule $rules

Name                                 Type                                           Scope
----                                 ----                                           -----
33b520ea-3544-4abc-8565-3588deb8e68e Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d

```

Each individual `Rule` on a policy can be update independently.

### Example 2: Update expiration rule and a notification rule of a policy
```powershell
PS C:\> $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
PS C:\> $expirationRule = [RoleManagementPolicyExpirationRule]@{
            isExpirationRequired = "false";
            maximumDuration = "P180D";
            id = "Expiration_Admin_Eligibility";
            ruleType = [RoleManagementPolicyRuleType]("RoleManagementPolicyExpirationRule");
            targetCaller = "Admin";
            targetOperation = @('All');
            targetLevel = "Eligibility";
            targetObject = $null;
            targetInheritableSetting = $null;
            targetEnforcedSetting = $null;
        }
PS C:\> $notificationRule = [RoleManagementPolicyNotificationRule]@{
            notificationType = "Email";
            recipientType = "Approver";
            isDefaultRecipientsEnabled = "false";
            notificationLevel = "Critical";
            notificationRecipient = $null;                
            id = "Notification_Approver_Admin_Eligibility";
            ruleType = [RoleManagementPolicyRuleType]("RoleManagementPolicyNotificationRule");
            targetCaller = "Admin";
            targetOperation = @('All');
            targetLevel = "Eligibility";
            targetObject = $null;
            targetInheritableSetting = $null;
            targetEnforcedSetting = $null;
        }
PS C:\> $rules = [IRoleManagementPolicyRule[]]@($expirationRule, $notificationRule)
PS C:\> Update-AzRoleManagementPolicy -Scope $scope -Name "33b520ea-3544-4abc-8565-3588deb8e68e" -Rule $rules

Name                                 Type                                           Scope
----                                 ----                                           -----
33b520ea-3544-4abc-8565-3588deb8e68e Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d

```

Multiple `Rule` can be updated together.

