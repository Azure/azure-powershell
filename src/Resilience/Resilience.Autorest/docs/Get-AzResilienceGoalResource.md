---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/get-azresiliencegoalresource
schema: 2.0.0
---

# Get-AzResilienceGoalResource

## SYNOPSIS
Get a GoalResource

## SYNTAX

### List (Default)
```
Get-AzResilienceGoalResource -GoalAssignmentName <String> -ServiceGroupName <String> [-SkipToken <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzResilienceGoalResource -GoalAssignmentName <String> -Name <String> -ServiceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzResilienceGoalResource -InputObject <IResilienceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityGoalAssignment
```
Get-AzResilienceGoalResource -GoalAssignmentInputObject <IResilienceIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityServiceGroup
```
Get-AzResilienceGoalResource -GoalAssignmentName <String> -Name <String>
 -ServiceGroupInputObject <IResilienceIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a GoalResource

## EXAMPLES

### Example 1: Get a goal resource by name
```powershell
Get-AzResilienceGoalResource `
  -GoalAssignmentName 'ga-payments-tier1' `
  -Name 'gr-payments-web' `
  -ServiceGroupName 'azcmdlet-testing'
```

Retrieves the specified goal resource.

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

### -GoalAssignmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: GetViaIdentityGoalAssignment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -GoalAssignmentName
The name of the GoalAssignment

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityServiceGroup, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the GoalAssignment

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityGoalAssignment, GetViaIdentityServiceGroup
Aliases: GoalResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: GetViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
Skip over when retrieving results.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Number of elements to return when retrieving results.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IGoalResource

## NOTES

## RELATED LINKS

