---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaAkamaiSignatureHeaderAuthenticationKeyObject
schema: 2.0.0
---

# New-AzMediaAkamaiSignatureHeaderAuthenticationKeyObject

## SYNOPSIS
Create an in-memory object for AkamaiSignatureHeaderAuthenticationKey.

## SYNTAX

```
New-AzMediaAkamaiSignatureHeaderAuthenticationKeyObject [-Base64Key <String>] [-Expiration <DateTime>]
 [-Identifier <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AkamaiSignatureHeaderAuthenticationKey.

## EXAMPLES

### Example 1: Create an in-memory object for AkamaiSignatureHeaderAuthenticationKey.
```powershell
New-AzMediaAkamaiSignatureHeaderAuthenticationKeyObject -Base64Key "dGVzdGlkMQ==" -Expiration "2029-12-31T16:00:00-08:00" -Identifier "id1"
```

```output
Base64Key    Expiration             Identifier
---------    ----------             ----------
dGVzdGlkMQ== 2030-01-01 08:00:00 AM id1
```

Create an in-memory object for AkamaiSignatureHeaderAuthenticationKey.

## PARAMETERS

### -Base64Key
authentication key.

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

### -Expiration
The expiration time of the authentication key.

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

### -Identifier
identifier of the key.

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

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.AkamaiSignatureHeaderAuthenticationKey

## NOTES

ALIASES

## RELATED LINKS

