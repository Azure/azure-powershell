---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version:
schema: 2.0.0
---

# Get-AzsDelegatedProvider

## SYNOPSIS
Get the list of delegatedProviders.

## SYNTAX

### List (Default)
```
Get-AzsDelegatedProvider [<CommonParameters>]
```

### Get
```
Get-AzsDelegatedProvider [-DelegatedProviderId] <String> [<CommonParameters>]
```

## DESCRIPTION
Get the list of delegatedProviders.

## EXAMPLES

### EXAMPLE 1
```
Get-AzsDelegatedProvider
```

Get a list of delegated providers.

### EXAMPLE 2
```
Get-AzsDelegatedProvider -DelegatedProviderId "c90173b1-de7a-4b1d-8600-b832b0e65946"
```

Get the a specific delegated provider.

## PARAMETERS

### -DelegatedProviderId
Subscription ID of the delegated provider

```yaml
Type: String
Parameter Sets: Get
Aliases:

Required: True
Position: 1
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
