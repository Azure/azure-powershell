---
external help file: Az.ServiceLinker-help.xml
Module Name: Az.ServiceLinker
online version: https://learn.microsoft.com/powershell/module/az.ServiceLinker/new-azservicelinkerserviceprincipalsecretauthinfoobject
schema: 2.0.0
---

# New-AzServiceLinkerServicePrincipalSecretAuthInfoObject

## SYNOPSIS
Create an in-memory object for ServicePrincipalSecretAuthInfo.

## SYNTAX

```
New-AzServiceLinkerServicePrincipalSecretAuthInfoObject -ClientId <String> -PrincipalId <String>
 -Secret <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ServicePrincipalSecretAuthInfo.

## EXAMPLES

### Example 1: Create AuthInfo of service principal secret type
```powershell
New-AzServiceLinkerServicePrincipalSecretAuthInfoObject -ClientId 00000000-0000-0000-0000-000000000000 -PrincipalId 00000000-0000-0000-0000-000000000000 -Secret secret
```

```output
AuthType               ClientId                             PrincipalId
--------               --------                             -----------
servicePrincipalSecret 00000000-0000-0000-0000-000000000000 00000000-0000-0000-0000-00…
```

Create AuthInfo of service principal secret type

## PARAMETERS

### -ClientId
ServicePrincipal application clientId for servicePrincipal auth.

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

### -PrincipalId
Principal Id for servicePrincipal auth.

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

### -Secret
Secret for servicePrincipal auth.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.ServicePrincipalSecretAuthInfo

## NOTES

## RELATED LINKS
