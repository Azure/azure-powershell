---
external help file: Az.Quota-help.xml
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquotaoperation
schema: 2.0.0
---

# Get-AzQuotaOperation

## SYNOPSIS
List all the operations supported by the Microsoft.Quota resource provider.

## SYNTAX

```
Get-AzQuotaOperation [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List all the operations supported by the Microsoft.Quota resource provider.

## EXAMPLES

### Example 1: List all the operations supported by the Microsoft.Quota resource provider.
```powershell
Get-AzQuotaOperation
```

```output
Name                               Origin
----                               ------
Microsoft.Quota/quotas/read
Microsoft.Quota/quotas/write
Microsoft.Quota/quotaRequests/read
Microsoft.Quota/usages/read
Microsoft.Quota/operations/read
Microsoft.Quota/register/action
```

List all the operations supported by the Microsoft.Quota resource provider.

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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IOperationResponse

## NOTES

## RELATED LINKS
