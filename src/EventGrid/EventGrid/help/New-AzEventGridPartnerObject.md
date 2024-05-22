---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridpartnerobject
schema: 2.0.0
---

# New-AzEventGridPartnerObject

## SYNOPSIS
Create an in-memory object for Partner.

## SYNTAX

```
New-AzEventGridPartnerObject [-AuthorizationExpirationTimeInUtc <DateTime>] [-Name <String>]
 [-RegistrationImmutableId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Partner.

## EXAMPLES

### Example 1: Create an in-memory object for Partner.
```powershell
New-AzEventGridPartnerObject -AuthorizationExpirationTimeInUtc "2023-11-19T09:31:42.521Z" -Name "Auth0" -RegistrationImmutableId "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
```

```output
AuthorizationExpirationTimeInUtc Name  RegistrationImmutableId
-------------------------------- ----  -----------------------
2023-11-19 下午 05:31:42         Auth0 804a11ca-ce9b-4158-8e94-3c8dc7a072ec
```

Create an in-memory object for Partner.

## PARAMETERS

### -AuthorizationExpirationTimeInUtc
Expiration time of the partner authorization.
If this timer expires, any request from this partner to create, update or delete resources in subscriber's
        context will fail.
If specified, the allowed values are between 1 to the value of defaultMaximumExpirationTimeInDays specified in PartnerConfiguration.
        If not specified, the default value will be the value of defaultMaximumExpirationTimeInDays specified in PartnerConfiguration or 7 if this value is not specified.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The partner name.

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

### -RegistrationImmutableId
The immutableId of the corresponding partner registration.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.Partner

## NOTES

## RELATED LINKS
