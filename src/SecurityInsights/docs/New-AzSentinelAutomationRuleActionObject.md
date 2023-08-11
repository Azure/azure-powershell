---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/new-azsentinelautomationruleactionobject
schema: 2.0.0
---

# New-AzSentinelAutomationRuleActionObject

## SYNOPSIS
Create the automation rule action object.

## SYNTAX

### CreateRunPlaybook (Default)
```
New-AzSentinelAutomationRuleActionObject -ActionType <String> -Order <Int32> [-LogicAppResourceId <String>]
 [-TenantId <String>] [<CommonParameters>]
```

### CreateModifyProperties
```
New-AzSentinelAutomationRuleActionObject -ActionType <String> -Order <Int32> [-Classification <String>]
 [-ClassificationComment <String>] [-ClassificationReason <String>] [-Label <IIncidentLabel>]
 [-OwnerAssignedTo <String>] [-OwnerEmail <String>] [-OwnerObjectId <String>] [-OwnerType <String>]
 [-OwnerUserPrincipalName <String>] [-Severity <String>] [-Status <String>] [<CommonParameters>]
```

## DESCRIPTION
Create the automation rule action object.

## EXAMPLES

### Example 1: Create a RunPlaybook automation rule action object for automation rule
```powershell
New-AzSentinelAutomationRuleActionObject -ActionType RunPlaybook -Order 1 -LogicAppResourceId $LogicAppResource.Id -TenantId (Get-AzContext).Tenant.Id
```

```output
ActionConfigurationLogicAppResourceId                                                                                           ActionConfigurationTenantId          ActionType  Order
-------------------------------------                                                                                           ---------------------------          ----------  -----
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.Logic/workflows/AlertLogicApp 72f988bf-86f1-41af-91ab-2d7cd011db47 RunPlaybook     1
```

This command creates a automation rule action object for automation rule.

### Example 2: Create a ModifyProperties automation rule action object for automation rule
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

### -ActionType
The type of the automation rule action.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Classification
The reason the incident was closed.

```yaml
Type: System.String
Parameter Sets: CreateModifyProperties
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClassificationComment
Describes the reason the incident was closed.

```yaml
Type: System.String
Parameter Sets: CreateModifyProperties
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClassificationReason
The classification reason the incident was closed with.

```yaml
Type: System.String
Parameter Sets: CreateModifyProperties
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
List of labels to add to the incident.
To construct, see NOTES section for LABEL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IIncidentLabel
Parameter Sets: CreateModifyProperties
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogicAppResourceId
The resource id of the playbook resource.

```yaml
Type: System.String
Parameter Sets: CreateRunPlaybook
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
Parameter Sets: CreateModifyProperties
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
Parameter Sets: CreateModifyProperties
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
Parameter Sets: CreateModifyProperties
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
Parameter Sets: CreateModifyProperties
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
Parameter Sets: CreateModifyProperties
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity
The severity of the incident.

```yaml
Type: System.String
Parameter Sets: CreateModifyProperties
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The status of the incident.

```yaml
Type: System.String
Parameter Sets: CreateModifyProperties
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The tenant id of the playbook resource.

```yaml
Type: System.String
Parameter Sets: CreateRunPlaybook
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IAutomationRuleAction

## NOTES

## RELATED LINKS

