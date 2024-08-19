---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azmanagementgroupsubscription
schema: 2.0.0
---

# Get-AzManagementGroupSubscription

## SYNOPSIS
Gets the details of Subscription(s) under a Management Group.

## SYNTAX

```
Get-AzManagementGroupSubscription [-GroupName] <String> [[-SubscriptionId] <String>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzManagementGroupSubscription** cmdlet gets the subscription info under a Management Group. Providing the **SubscriptionId** and **GroupName** will give only the Subscription details for that subscription. Providing only the **GroupName** will list the details for all Subscriptions under the Management Group.

## EXAMPLES

### Example 1: Get Subscription Details under a Management Group
```powershell
Get-AzManagementGroupSubscription -GroupName "TestGroup" -SubscriptionId 5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de
```

```output
Name              : 5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de
Type              : Microsoft.Management/managementGroups/subscriptions
Id                : /providers/Microsoft.Management/managementGroups/TestGroup/subscriptions/5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName       : Visual Studio Enterprise Subscription
ParentId          : /providers/Microsoft.Management/managementGroups/TestGroup
State             : Active
```

### Example 2: Get all Subscription Details under a Management Group
```powershell
Get-AzManagementGroupSubscription -GroupName "TestGroup"
```

```output
Name              : 5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de
Type              : Microsoft.Management/managementGroups/subscriptions
Id                : /providers/Microsoft.Management/managementGroups/TestGroup/subscriptions/5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName       : Visual Studio Enterprise Subscription
ParentId          : /providers/Microsoft.Management/managementGroups/TestGroup
State             : Active

Name              : 2120692d-35c3-44c8-81f5-631fa7351726
Type              : Microsoft.Management/managementGroups/subscriptions
Id                : /providers/Microsoft.Management/managementGroups/TestGroup/subscriptions/2120692d-35c3-44c8-81f5-631fa7351726
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName       : Test Subscription
ParentId          : /providers/Microsoft.Management/managementGroups/TestGroup
State             : Active
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupName
Management Group Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GroupId

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Return `true` on successful execution

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id of the subscription associated with the management

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSManagementGroupSubscription

## NOTES

## RELATED LINKS
