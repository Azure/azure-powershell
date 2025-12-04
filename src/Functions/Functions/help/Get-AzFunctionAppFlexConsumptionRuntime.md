---
external help file: Az.Functions-help.xml
Module Name: Az.Functions
online version: https://learn.microsoft.com/powershell/module/az.functions/get-azfunctionappflexconsumptionruntime
schema: 2.0.0
---

# Get-AzFunctionAppFlexConsumptionRuntime

## SYNOPSIS
Gets the Flex Consumption function app runtimes supported at the specified location.

## SYNTAX

### AllRuntimes (Default)
```
Get-AzFunctionAppFlexConsumptionRuntime -Location <String> [-SubscriptionId <String>]
 [<CommonParameters>]
```

### AllVersions
```
Get-AzFunctionAppFlexConsumptionRuntime -Location <String> [-SubscriptionId <String>] -Runtime <String>
 [<CommonParameters>]
```

### ByVersion
```
Get-AzFunctionAppFlexConsumptionRuntime -Location <String> [-SubscriptionId <String>] -Runtime <String>
 -Version <String> [<CommonParameters>]
```

### DefaultOrLatest
```
Get-AzFunctionAppFlexConsumptionRuntime -Location <String> [-SubscriptionId <String>] -Runtime <String>
 [-DefaultOrLatest] [<CommonParameters>]
```

## DESCRIPTION
Gets the Flex Consumption function app runtimes supported at the specified location.

## EXAMPLES

### Example 1: Get all supported runtimes for Flex Consumption in a specific location.
```powershell
Get-AzFunctionAppFlexConsumptionRuntime -Location 'East Asia'
```

```output
Name            Version IsDefault EndOfLifeDate Sku
----            ------- --------- ------------- ---
dotnet-isolated 10.0    False     11/9/2028     @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
dotnet-isolated 9.0     False     5/11/2026     @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
dotnet-isolated 8.0     True      11/9/2026     @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
node            22      True      4/29/2027     @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
node            20      False     4/29/2026     @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
java            21      False     8/31/2028     @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
java            17      True      8/31/2027     @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
powershell      7.4     True      11/9/2026     @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
python          3.13    False     10/30/2029    @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
python          3.12    True      10/30/2028    @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
python          3.11    True      10/30/2027    @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
python          3.10    True      10/30/2026    @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
custom          1.0     False                   @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
```

This command retrieves all available runtimes and their versions for Flex Consumption function apps in the East Asia region.
Supported runtimes include: dotnet-isolated, node, java, powershell, python, and custom.

### Example 2: Get all supported versions for a specific runtime.
```powershell
Get-AzFunctionAppFlexConsumptionRuntime -Location 'East Asia' -Runtime Python
```

```output
Name   Version IsDefault EndOfLifeDate Sku
----   ------- --------- ------------- ---
python 3.13    False     10/30/2029    @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
python 3.12    True      10/30/2028    @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
python 3.11    True      10/30/2027    @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
python 3.10    True      10/30/2026    @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
```

This command retrieves all supported Python versions for Flex Consumption function apps in the East Asia region.

### Example 3: Get the default or latest runtime version for PowerShell.
```powershell
Get-AzFunctionAppFlexConsumptionRuntime -Location 'east asia' -Runtime PowerShell -DefaultOrLatest
```

```output
Name   Version IsDefault EndOfLifeDate Sku
----   ------- --------- ------------- ---
python 3.12    True      10/30/2028    @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
```

This command retrieves the default PowerShell version for Flex Consumption function apps in the East Asia region.
Use this parameter when you need to determine the default runtime version that will be used if no specific version is provided during function app creation.

### Example 4: Get a specific runtime version.
```powershell
Get-AzFunctionAppFlexConsumptionRuntime -Location 'East Asia' -Runtime Python -Version 3.12
```

```output
Name   Version IsDefault EndOfLifeDate Sku
----   ------- --------- ------------- ---
python 3.12    True      10/30/2028    @{skuCode=FC1; instanceMemoryMB=System.Object[]; maximumInstanceCount=; functionAppConfigProperties=}
```

This command validates that Python 3.12 is supported for Flex Consumption function apps in the East Asia region and retrieves its details.

## PARAMETERS

### -DefaultOrLatest
Get the default or latest version of the specified runtime.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DefaultOrLatest
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location where Flex Consumption function apps are supported.

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

### -Runtime
The Flex Consumption function app runtime.

```yaml
Type: System.String
Parameter Sets: AllVersions, ByVersion, DefaultOrLatest
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The function app runtime version.

```yaml
Type: System.String
Parameter Sets: ByVersion
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

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.FunctionAppFlexConsumptionRuntime

## NOTES

## RELATED LINKS
