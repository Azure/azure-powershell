---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version: 
schema: 2.0.0
---

# Get-AzsUserSubscription

## SYNOPSIS
Get the list of user subscriptions as administrator.

## SYNTAX

### List (Default)
```
Get-AzsUserSubscription [-Filter <String>] [<CommonParameters>]
```

### Get
```
Get-AzsUserSubscription -SubscriptionId <Guid> [<CommonParameters>]
```

## DESCRIPTION
Get the list of user subscriptions as administrator.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsUserSubscription
```

Get the list of user subscriptions as administrator.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id parameter.

```yaml
Type: Guid
Parameter Sets: Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Subscription

## NOTES

## RELATED LINKS

