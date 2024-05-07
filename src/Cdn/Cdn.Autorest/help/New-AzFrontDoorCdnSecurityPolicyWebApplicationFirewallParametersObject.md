---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-azfrontdoorcdnsecuritypolicywebapplicationfirewallparametersobject
schema: 2.0.0
---

# New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject

## SYNOPSIS
Create an in-memory object for SecurityPolicyWebApplicationFirewallParameters.

## SYNTAX

```
New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject
 [-Association <ISecurityPolicyWebApplicationFirewallAssociation[]>] [-WafPolicyId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SecurityPolicyWebApplicationFirewallParameters.

## EXAMPLES

### Example 1: Create an in-memory object for AzureFrontDoor SecurityPolicyWebApplicationFirewallAssociation
```powershell
$endpoint = Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
$association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  $association `
            -WafPolicyId $wafPolicyId
```

```output
Association
-----------
{{...
```

Create an in-memory object for AzureFrontDoor SecurityPolicyWebApplicationFirewallAssociation

## PARAMETERS

### -Association
Waf associations.
To construct, see NOTES section for ASSOCIATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ISecurityPolicyWebApplicationFirewallAssociation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WafPolicyId
Resource ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.SecurityPolicyWebApplicationFirewallParameters

## NOTES

## RELATED LINKS

