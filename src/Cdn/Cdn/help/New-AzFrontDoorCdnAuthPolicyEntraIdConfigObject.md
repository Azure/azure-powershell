---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azfrontdoorcdnauthpolicyentraidconfigobject
schema: 2.0.0
---

# New-AzFrontDoorCdnAuthPolicyEntraIdConfigObject

## SYNOPSIS
Create an in-memory object for AuthPolicyEntraIDConfig.

## SYNTAX

```
New-AzFrontDoorCdnAuthPolicyEntraIdConfigObject -Audience <String[]> -Issuer <String> [-AuthLocation <String>]
 [-AuthLocationSelector <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AuthPolicyEntraIDConfig.

## EXAMPLES

### Example 1: Create a Microsoft Entra ID authentication configuration
```powershell
New-AzFrontDoorCdnAuthPolicyEntraIdConfigObject -Issuer "https://login.microsoftonline.com/00000000-0000-0000-0000-000000000001/v2.0" -Audience "api://myApplication" -AuthLocation Header -AuthLocationSelector "Authorization"
```

Creates an in-memory Microsoft Entra ID authentication configuration that reads a token from the Authorization header.
Replace the example issuer and audience with your identity provider values.
Pass the object to an authentication policy create or update command; this command does not create or update an Azure resource.

## PARAMETERS

### -Audience
Audiences to validate.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthLocation
Location of the authorization value in the HTTP request.
Only Header is supported.

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

### -AuthLocationSelector
Selector within the authorization location used to find the identity.

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

### -Issuer
Issuer or authority for the identity provider to validate.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AuthPolicyEntraIdConfig

## NOTES

## RELATED LINKS
