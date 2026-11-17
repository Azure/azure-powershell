---
external help file: Az.Relationships-help.xml
Module Name: Az.Relationships
online version: https://learn.microsoft.com/powershell/module/az.relationships/get-azrelationshipscontainsrelationship
schema: 2.0.0
---

# Get-AzRelationshipsContainsRelationship

## SYNOPSIS
List ContainsRelationship resources by subscription ID

## SYNTAX

### List (Default)
```
Get-AzRelationshipsContainsRelationship [-SubscriptionId <String[]>] [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzRelationshipsContainsRelationship [-SubscriptionId <String[]>] -ResourceGroupName <String>
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List ContainsRelationship resources by subscription ID

## EXAMPLES

### Example 1: List contains relationships in a subscription
```powershell
Get-AzRelationshipsContainsRelationship -SubscriptionId "00000000-0000-0000-0000-000000000001"
```

Lists the contains relationships in the specified subscription.

### Example 2: List contains relationships in a resource group
```powershell
Get-AzRelationshipsContainsRelationship -SubscriptionId "00000000-0000-0000-0000-000000000001" -ResourceGroupName "myRG"
```

Lists the contains relationships in the specified resource group.

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

### -Filter
Filters the results by target resource type.
Example: properties.metadata.targetType eq 'Microsoft.Compute/virtualMachines'

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationship

## NOTES

## RELATED LINKS
