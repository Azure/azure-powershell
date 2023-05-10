---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azrolemanagementpolicy
schema: 2.0.0
---

# Update-AzRoleManagementPolicy

## SYNOPSIS
Update a role management policy

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzRoleManagementPolicy -Name <String> -Scope <String> [-Description <String>] [-DisplayName <String>]
 [-IsOrganizationDefault] [-Rule <IRoleManagementPolicyRule[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzRoleManagementPolicy -InputObject <IAuthorizationIdentity> [-Description <String>]
 [-DisplayName <String>] [-IsOrganizationDefault] [-Rule <IRoleManagementPolicyRule[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a role management policy

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The role management policy description.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The role management policy display name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.IAuthorizationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsOrganizationDefault
The role management policy is default policy.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name (guid) of the role management policy to upsert.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: RoleManagementPolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
The rule applied to the policy.
To construct, see NOTES section for RULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleManagementPolicyRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the role management policy to upsert.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.IAuthorizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleManagementPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAuthorizationIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[RoleAssignmentScheduleInstanceName <String>]`: The name (hash of schedule name + time) of the role assignment schedule to get.
  - `[RoleAssignmentScheduleName <String>]`: The name (guid) of the role assignment schedule to get.
  - `[RoleAssignmentScheduleRequestName <String>]`: The name of the role assignment to create. It can be any valid GUID.
  - `[RoleEligibilityScheduleInstanceName <String>]`: The name (hash of schedule name + time) of the role eligibility schedule to get.
  - `[RoleEligibilityScheduleName <String>]`: The name (guid) of the role eligibility schedule to get.
  - `[RoleEligibilityScheduleRequestName <String>]`: The name of the role eligibility to create. It can be any valid GUID.
  - `[RoleManagementPolicyAssignmentName <String>]`: The name of format {guid_guid} the role management policy assignment to get.
  - `[RoleManagementPolicyName <String>]`: The name (guid) of the role management policy to get.
  - `[Scope <String>]`: The scope of the role management policy.

`RULE <IRoleManagementPolicyRule[]>`: The rule applied to the policy.
  - `RuleType <RoleManagementPolicyRuleType>`: The type of rule
  - `[Id <String>]`: The id of the rule.
  - `[TargetCaller <String>]`: The caller of the setting.
  - `[TargetEnforcedSetting <String[]>]`: The list of enforced settings.
  - `[TargetInheritableSetting <String[]>]`: The list of inheritable settings.
  - `[TargetLevel <String>]`: The assignment level to which it is applied.
  - `[TargetObject <String[]>]`: The list of target objects.
  - `[TargetOperation <String[]>]`: The type of operation.

## RELATED LINKS

