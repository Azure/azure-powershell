---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/get-azsupportoperation
schema: 2.0.0
---

# Get-AzSupportOperation

## SYNOPSIS
Lists all the available Microsoft Support REST API operations.

## SYNTAX

```
Get-AzSupportOperation [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
Get-AzSupportOperation
```

```output
Name
----
Microsoft.Support/register/action
Microsoft.Support/lookUpResourceId/action
Microsoft.Support/checkNameAvailability/action
Microsoft.Support/services/read
Microsoft.Support/services/problemClassifications/read
Microsoft.Support/supportTickets/read
Microsoft.Support/supportTickets/write
Microsoft.Support/operationresults/read
Microsoft.Support/operationsstatus/read
Microsoft.Support/operations/read
```

Lists all the available Microsoft Support REST API operations.

## PARAMETERS

### -DefaultProfile


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

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.IOperation

## NOTES

## RELATED LINKS

