---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version:
schema: 2.0.0
---

# Test-AzsNameAvailability

## SYNOPSIS
Returns the avaialbility of the specified subscriptions resource type and name

## SYNTAX

```
Test-AzsNameAvailability -Name <String> -ResourceType <String> [<CommonParameters>]
```

## DESCRIPTION
Returns the avaialbility of the specified subscriptions resource type and name

## EXAMPLES

### EXAMPLE 1
```
Test-AzsNameAvailability -ResourceType "Microsoft.Subscriptions.Admin/offers" -Name offername1
```

Returns the avaialbility of the specified subscriptions resource type and name

## PARAMETERS

### -Name
The resource name to verify.

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

### -ResourceType
The resource type to verify.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.CheckNameAvailabilityResponse

## NOTES

## RELATED LINKS
