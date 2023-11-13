---
external help file:
Module Name: Az.ADDomainServices
online version: https://learn.microsoft.com/powershell/module/az.addomainservices/new-azaddomainserviceforesttrustobject
schema: 2.0.0
---

# New-AzADDomainServiceForestTrustObject

## SYNOPSIS
Create an in-memory object for ForestTrust.

## SYNTAX

```
New-AzADDomainServiceForestTrustObject [-FriendlyName <String>] [-RemoteDnsIP <String>]
 [-TrustDirection <String>] [-TrustedDomainFqdn <String>] [-TrustPassword <SecureString>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ForestTrust.

## EXAMPLES

### Example 1: Create ServiceForestTrust for ADDomain
```powershell
New-AzADDomainServiceForestTrustObject -FriendlyName FriendlyNameTest
```

```output
FriendlyName     RemoteDnsIP TrustDirection TrustPassword TrustedDomainFqdn
------------     ----------- -------------- ------------- -----------------
FriendlyNameTest
```

Create an in-memory object for ForestTrust.
This object can be used to create or update a domain service.

## PARAMETERS

### -FriendlyName
Friendly Name.

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

### -RemoteDnsIP
Remote Dns ips.

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

### -TrustDirection
Trust Direction.

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

### -TrustedDomainFqdn
Trusted Domain FQDN.

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

### -TrustPassword
Trust Password.

```yaml
Type: System.Security.SecureString
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

### Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ForestTrust

## NOTES

ALIASES

## RELATED LINKS

