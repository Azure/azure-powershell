---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/get-azcdnedgenode
schema: 2.0.0
---

# Get-AzCdnEdgeNode

## SYNOPSIS
Edgenodes are the global Point of Presence (POP) locations used to deliver CDN content to end users.

## SYNTAX

```
Get-AzCdnEdgeNode [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Edgenodes are the global Point of Presence (POP) locations used to deliver CDN content to end users.

## EXAMPLES

### Example 1: List AzureCDN Edge Noes
```powershell
Get-AzCdnEdgeNode
```

```output
Name
----
Standard_Verizon
Premium_Verizon
Custom_Verizon
```

List AzureCDN Edge Noes

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IEdgeNode

## NOTES

ALIASES

## RELATED LINKS

