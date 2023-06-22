---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-AzFrontDoorCdnResourceReferenceObject
schema: 2.0.0
---

# New-AzFrontDoorCdnResourceReferenceObject

## SYNOPSIS
Create an in-memory object for ResourceReference.

## SYNTAX

```
New-AzFrontDoorCdnResourceReferenceObject [-Id <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ResourceReference.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN ResourceReference
```powershell
$secret =  Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
```

```output
Id
--
/subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/testps-rg-da16jm/providers/Microsoft.Cdn/profiles/fdp-v542q6/secrets/secret001
```

Create an in-memory object for AzureCDN ResourceReference

## PARAMETERS

### -Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ResourceReference

## NOTES

ALIASES

## RELATED LINKS

