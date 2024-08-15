---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteradminplanmember
schema: 2.0.0
---

# Get-AzDevCenterAdminPlanMember

## SYNOPSIS
Gets a devcenter plan member.

## SYNTAX

### List (Default)
```
Get-AzDevCenterAdminPlanMember -PlanName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterAdminPlanMember -MemberName <String> -PlanName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterAdminPlanMember -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets a devcenter plan member.

## EXAMPLES

### Example 1: List plan members in a plan
```powershell
Get-AzDevCenterAdminPlanMember -PlanName ContosoPlan -ResourceGroupName testRg
```

This command lists the plan members in the plan "ContosoPlan" under the resource group "testRg".

### Example 2: Get a plan member
```powershell
Get-AzDevCenterAdminPlanMember -PlanName ContosoPlan -MemberName d702f662-b3f2-4796-9e8c-13c22378ced3 -ResourceGroupName testRg
```

This command gets the plan member named "d702f662-b3f2-4796-9e8c-13c22378ced3" in the plan "ContosoPlan" under the resource group "testRg".

### Example 3: Get a plan member using InputObject
```powershell
$planMember = @{"ResourceGroupName" = "testRg"; "PlanName" = "ContosoPlan"; "MemberName" = "d702f662-b3f2-4796-9e8c-13c22378ced3"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$planMember = Get-AzDevCenterAdminPlanMember -InputObject $planMember
```

This command gets the plan member named "d702f662-b3f2-4796-9e8c-13c22378ced3" in the plan "ContosoPlan" under the resource group "testRg".

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MemberName
The name of a devcenter plan member.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanName
The name of the devcenter plan.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IDevCenterPlanMember

## NOTES

## RELATED LINKS
