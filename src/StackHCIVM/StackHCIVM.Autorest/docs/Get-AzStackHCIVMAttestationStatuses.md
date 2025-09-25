---
external help file:
Module Name: Az.StackHCIVM
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmattestationstatuses
schema: 2.0.0
---

# Get-AzStackHCIVMAttestationStatuses

## SYNOPSIS
Implements AttestationStatus GET method.

## SYNTAX

```
Get-AzStackHCIVMAttestationStatuses -ResourceUri <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements AttestationStatus GET method.

## EXAMPLES

### Example 1: Get Vm Attestation Status
```powershell
Get-AzStackHCIVMAttestationStatuses -ResourceUri "resourceuri"
```



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

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IAttestationStatus

## NOTES

## RELATED LINKS

