---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/Az.SecurityInsights/new-azsentinelautomationrulemodifypropertiesactionobject
schema: 2.0.0
---

# New-AzSentinelAutomationRuleModifyPropertiesActionObject

## SYNOPSIS
Create an in-memory object for AutomationRuleModifyPropertiesAction.

## SYNTAX

```
New-AzSentinelAutomationRuleModifyPropertiesActionObject -Order <Int32>
 [-ActionConfigurationClassification <String>] [-ActionConfigurationClassificationComment <String>]
 [-ActionConfigurationClassificationReason <String>] [-ActionConfigurationLabel <IIncidentLabel[]>]
 [-ActionConfigurationSeverity <String>] [-ActionConfigurationStatus <String>] [-OwnerAssignedTo <String>]
 [-OwnerEmail <String>] [-OwnerObjectId <String>] [-OwnerType <String>] [-OwnerUserPrincipalName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AutomationRuleModifyPropertiesAction.

## EXAMPLES

### Example 1: Create a ModifyProperties automation rule action object for automation rule
```powershell
New-AzSentinelAutomationRuleActionObject -ActionType ModifyProperties -Order 1 -Severity High
```

```output
ActionConfigurationClassification        : 
ActionConfigurationClassificationComment : 
ActionConfigurationClassificationReason  : 
ActionConfigurationLabel                 : 
ActionConfigurationSeverity              : High
ActionConfigurationStatus                : 
ActionType                               : ModifyProperties
Order                                    : 1
OwnerAssignedTo                          : 
OwnerEmail                               : 
OwnerObjectId                            : 
OwnerType                                : 
OwnerUserPrincipalName                   : 
```

This command creates a ModifyProperties automation rule action object for automation rule.

## PARAMETERS

### -ActionConfigurationClassification
The reason the incident was closed.

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

### -ActionConfigurationClassificationComment
Describes the reason the incident was closed.

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

### -ActionConfigurationClassificationReason
The classification reason the incident was closed with.

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

### -ActionConfigurationLabel
List of labels to add to the incident.
To construct, see NOTES section for ACTIONCONFIGURATIONLABEL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IIncidentLabel[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActionConfigurationSeverity
The severity of the incident.

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

### -ActionConfigurationStatus
The status of the incident.

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

### -Order


```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OwnerAssignedTo
The name of the user the incident is assigned to.

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

### -OwnerEmail
The email of the user the incident is assigned to.

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

### -OwnerObjectId
The object id of the user the incident is assigned to.

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

### -OwnerType
The type of the owner the incident is assigned to.

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

### -OwnerUserPrincipalName
The user principal name of the user the incident is assigned to.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.AutomationRuleModifyPropertiesAction

## NOTES

## RELATED LINKS

