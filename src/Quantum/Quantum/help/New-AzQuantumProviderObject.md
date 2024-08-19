---
external help file: Az.Quantum-help.xml
Module Name: Az.Quantum
online version: https://learn.microsoft.com/powershell/module/Az.Quantum/new-AzQuantumProviderObject
schema: 2.0.0
---

# New-AzQuantumProviderObject

## SYNOPSIS
Create an in-memory object for Provider.

## SYNTAX

```
New-AzQuantumProviderObject [-ApplicationName <String>] [-Id <String>] [-InstanceUri <String>]
 [-ProvisioningState <Status>] [-ResourceUsageId <String>] [-Sku <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Provider.

## EXAMPLES

### Example 1: Create an in-memory object for Provider.
```powershell
New-AzQuantumProviderObject -Id "ionq" -Sku "pay-as-you-go-cred"
```

```output
Sku
---
pay-as-you-go-cred
```

Create an in-memory object for Provider.

## PARAMETERS

### -ApplicationName
The provider's marketplace application display name.

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

### -Id
Unique id of this provider.

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

### -InstanceUri
A Uri identifying the specific instance of this provider.

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

### -ProvisioningState
Provisioning status field.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quantum.Support.Status
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUsageId
Id to track resource usage for the provider.

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

### -Sku
The sku associated with pricing information for this provider.

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

### Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.Api20220110Preview.Provider

## NOTES

## RELATED LINKS
