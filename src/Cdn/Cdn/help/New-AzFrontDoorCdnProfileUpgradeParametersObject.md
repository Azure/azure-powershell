---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzFrontDoorCdnProfileUpgradeParametersObject
schema: 2.0.0
---

# New-AzFrontDoorCdnProfileUpgradeParametersObject

## SYNOPSIS
Create an in-memory object for ProfileUpgradeParameters.

## SYNTAX

```
New-AzFrontDoorCdnProfileUpgradeParametersObject -WafMappingList <IProfileChangeSkuWafMapping[]>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ProfileUpgradeParameters.

## EXAMPLES

### Example 1: Create an in-memory object for ProfileUpgradeParameters.
```powershell
$waf1 = New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName policyName -ChangeToWafPolicyId toWafPolicyId
New-AzFrontDoorCdnProfileUpgradeParametersObject -WafMappingList $waf1
```

```output
WafMappingList
--------------
{{…
```

Create an in-memory object for ProfileUpgradeParameters.

### Example 2: Create an in-memory object for ProfileUpgradeParameters, show the details of the object.
```powershell
$waf1 = New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName policyName -ChangeToWafPolicyId toWafPolicyId
$upgrade = New-AzFrontDoorCdnProfileUpgradeParametersObject -WafMappingList $waf1  
$upgrade.ToString()
```

```output
{
  "wafMappingList": [
    {
      "changeToWafPolicy": {
        "id": "toWafPolicyId"
      },
      "securityPolicyName": "policyName"
    }
  ]
}
```

Create an in-memory object for ProfileUpgradeParameters, show the details of the object.

## PARAMETERS

### -WafMappingList
Web Application Firewall (WAF) and security policy mapping for the profile upgrade.
To construct, see NOTES section for WAFMAPPINGLIST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IProfileChangeSkuWafMapping[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ProfileUpgradeParameters

## NOTES

## RELATED LINKS
