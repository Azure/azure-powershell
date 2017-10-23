---
external help file: Microsoft.Azure.Commands.SubscriptionDefinition.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmSubscriptionDefinition

## SYNOPSIS
Get a subscription definition.

## SYNTAX

### Subscription (Default)
```
Get-AzureRmSubscriptionDefinition
```

### Management group
```
Get-AzureRmSubscriptionDefinition -ManagementGroupId <String> [-Name <String>]
```

## DESCRIPTION
The **Get-AzureRmSubscriptionDefinition** cmdlet gets one or more subscription definitions within the specified scope.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmSubscriptionDefinition
```

Gets the subscription definition for the subscription in the current context.

### Example 2
```
PS C:\> Get-AzureRmSubscription | Get-AzureRmSubscriptionDefinition
```

Gets the subscription definitions for all subscriptions in the current tenant.

### Example 3
```
PS C:\> Get-AzureRmSubscriptionDefinition -ManagementGroupId 3d0a564b-2803-4019-9f99-0a497dfeea91
```

Gets the subscription definitions within management group 3d0a564b-2803-4019-9f99-0a497dfeea91.

## PARAMETERS

### -ManagementGroupId
The id of the management group in which to retrieve subscription definitions.

```yaml
Type: String
Parameter Sets: ByManagementGroup
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the subscription definition to retrieve.

```yaml
Type: String
Parameter Sets: ByManagementGroup
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subscription
The subscription for which to retrieve the subscription definition.

```yaml
Type: IAzureSubscription
Parameter Sets: BySubscription
Aliases: 

Required: False
Position: Named
Default value: Subscription in current context
Accept pipeline input: True
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.SubscriptionDefinition.Models.PSSubscriptionDefinition, Microsoft.Azure.Commands.SubscriptionDefinition, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

