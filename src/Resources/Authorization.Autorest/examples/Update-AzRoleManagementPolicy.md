### Example 1: Update expiration rule of a policy
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
$expirationRule = [RoleManagementPolicyExpirationRule]@{
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
$rules = [IRoleManagementPolicyRule[]]@($expirationRule)
Update-AzRoleManagementPolicy -Scope $scope -Name "33b520ea-3544-4abc-8565-3588deb8e68e" -Rule $rules
```

```output
Name                                 Type                                           Scope
----                                 ----                                           -----
33b520ea-3544-4abc-8565-3588deb8e68e Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d

```

Each individual `Rule` on a policy can be update independently.

### Example 2: Update expiration rule and a notification rule of a policy
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
$expirationRule = [RoleManagementPolicyExpirationRule]@{
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
$notificationRule = [RoleManagementPolicyNotificationRule]@{
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
$rules = [IRoleManagementPolicyRule[]]@($expirationRule, $notificationRule)
Update-AzRoleManagementPolicy -Scope $scope -Name "33b520ea-3544-4abc-8565-3588deb8e68e" -Rule $rules
```

```output
Name                                 Type                                           Scope
----                                 ----                                           -----
33b520ea-3544-4abc-8565-3588deb8e68e Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d

```

Multiple `Rule` can be updated together.

