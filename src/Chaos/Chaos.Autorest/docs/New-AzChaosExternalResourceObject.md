---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosexternalresourceobject
schema: 2.0.0
---

# New-AzChaosExternalResourceObject

## SYNOPSIS
Create an in-memory object for ExternalResource.

## SYNTAX

```
New-AzChaosExternalResourceObject [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ExternalResource.

## EXAMPLES

### Example 1: Create an external resource reference
```powershell
New-AzChaosExternalResourceObject -ResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm'
```

```output
ResourceId
----------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm
```

Creates an in-memory external resource reference for a virtual machine.
Use it to point a scenario action at a specific ARM resource.

### Example 2: Reference an external resource from a variable
```powershell
$vmId = (Get-AzVM -ResourceGroupName contoso-rg -Name contoso-vm).Id
New-AzChaosExternalResourceObject -ResourceId $vmId
```

```output
ResourceId
----------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm
```

Creates an external resource reference from the resource id of an existing virtual machine.

## PARAMETERS

### -ResourceId
The resource ID of the external resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ExternalResource

## NOTES

## RELATED LINKS

