---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzFrontDoorCdnProfileChangeSkuWafMappingObject
schema: 2.0.0
---

# New-AzFrontDoorCdnProfileChangeSkuWafMappingObject

## SYNOPSIS
Create an in-memory object for ProfileChangeSkuWafMapping.

## SYNTAX

```
New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName <String>
 [-ChangeToWafPolicyId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ProfileChangeSkuWafMapping.

## EXAMPLES

### Example 1: Create an in-memory object for ProfileChangeSkuWafMapping.
```powershell
New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName policyName -ChangeToWafPolicyId toWafPolicyId
```

```output
SecurityPolicyName
------------------
policyName
```

Create an in-memory object for ProfileChangeSkuWafMapping

## PARAMETERS

### -ChangeToWafPolicyId
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

### -SecurityPolicyName
The security policy name.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ProfileChangeSkuWafMapping

## NOTES

ALIASES

## RELATED LINKS

