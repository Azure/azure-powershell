---
external help file: Microsoft.Azure.Commands.SubscriptionDefinition.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmSubscriptionDefinition

## SYNOPSIS
Creates a subscription definition.

## SYNTAX

### Create subscription definition
```
New-AzureRmSubscriptionDefinition -ManagementGroupId <String> -Name <String> -OfferType <String>
```

## DESCRIPTION
The **New-AzureRmSubscriptionDefinition** cmdlet creates a subscription definitions within the specified management group.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmSubscriptionDefinition -ManagementGroupId 3d0a564b-2803-4019-9f99-0a497dfeea91 -Name MySubDef -OfferType MS-AZR-0017P
```

Creates a subscription definition with a default subscription display name.

### Example 2
```
PS C:\> New-AzureRmSubscriptionDefinition -ManagementGroupId 3d0a564b-2803-4019-9f99-0a497dfeea91 -Name MySubDef -OfferType MS-AZR-0017P -SubscriptionDisplayName MyPaygoSub
```

Creates a subscription definition with a custom subscription display name.

## PARAMETERS

### -ManagementGroupId
The id of the management group in which to create the subscription definition.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the subscription definition to create.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferType
The type of offer to use when creating the underlying subscription.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionDisplayName
The display name to use when creating the subscription definition's underlying subscription.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: Name
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.SubscriptionDefinition.Models.PSSubscriptionDefinition

## NOTES

## RELATED LINKS

