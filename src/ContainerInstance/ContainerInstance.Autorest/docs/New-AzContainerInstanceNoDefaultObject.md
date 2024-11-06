---
external help file:
Module Name: Az.ContainerInstance
online version: https://learn.microsoft.com/powershell/module/az.ContainerInstance/New-AzContainerInstanceNoDefaultObject
schema: 2.0.0
---

# New-AzContainerInstanceNoDefaultObject

## SYNOPSIS
Create a in-memory object for Container with no default values

## SYNTAX

```
New-AzContainerInstanceNoDefaultObject -Name <String> [-ConfigMapKeyValuePair <IConfigMapKeyValuePairs>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Container with no default values

## EXAMPLES

### Example 1: Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb
```powershell
New-AzContainerInstanceNoDefaultObject -Name "test-container" -Image alpine -RequestCpu 1 -RequestMemoryInGb 1.5
```

```output
Name
----
test-container
```

Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb

### Example 2: Create a container instance using image alphine with limit cpu 2.0 and limit memory 2.5Gb
```powershell
New-AzContainerInstanceNoDefaultObject -Image alpine -Name "test-container" -LimitCpu 2 -LimitMemoryInGb 2.5
```

```output
Name
----
test-container
```

Create a container instance using image alphine with limit cpu 2.0 and limit memory 2.5Gb

### Example 3: Create a container group with a container instance
```powershell
$container = New-AzContainerInstanceNoDefaultObject -Name test-container -Image alpine
New-AzContainerGroup -ResourceGroupName testrg-rg -Name test-cg -Location eastus -Container $container
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

Create a container group with a container instance

## PARAMETERS

### -ConfigMapKeyValuePair
The key value pairs dictionary in the config map to set in the container instance.
To construct, see NOTES section for CONFIGMAPKEYVALUEPAIR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IConfigMapKeyValuePairs
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The user-provided name of the container instance.

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.Container

## NOTES

## RELATED LINKS

