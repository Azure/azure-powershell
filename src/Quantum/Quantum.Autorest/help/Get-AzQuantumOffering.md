---
external help file:
Module Name: Az.Quantum
online version: https://learn.microsoft.com/powershell/module/az.quantum/get-azquantumoffering
schema: 2.0.0
---

# Get-AzQuantumOffering

## SYNOPSIS
Returns the list of all provider offerings available for the given location.

## SYNTAX

```
Get-AzQuantumOffering -LocationName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the list of all provider offerings available for the given location.

## EXAMPLES

### Example 1: Returns the list of all provider offerings available for the given location.
```powershell
Get-AzQuantumOffering -LocationName eastus
```

```output
Name
----
1Qloud Optimization Platform
IonQ
Microsoft QIO
Microsoft Quantum Computing
Quantinuum
Rigetti Quantum
SQBM+ Cloud on Azure Quantum
```

Returns the list of all provider offerings available for the given location.

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

### -LocationName
Location.

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

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.Api20220110Preview.IProviderDescription

## NOTES

## RELATED LINKS

