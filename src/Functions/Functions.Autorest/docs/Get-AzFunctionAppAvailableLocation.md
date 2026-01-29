---
external help file:
Module Name: Az.Functions
online version: https://learn.microsoft.com/powershell/module/az.functions/get-azfunctionappavailablelocation
schema: 2.0.0
---

# Get-AzFunctionAppAvailableLocation

## SYNOPSIS
Gets the location where a function app for the given os and plan type is available.

## SYNTAX

```
Get-AzFunctionAppAvailableLocation [[-SubscriptionId] <String[]>] [[-PlanType] <String>] [[-OSType] <String>]
 [[-DefaultProfile] <PSObject>] [-ZoneRedundancy] [<CommonParameters>]
```

## DESCRIPTION
Gets the location where a function app for the given os and plan type is available.

## EXAMPLES

### Example 1: Get the locations where Premium is available for Windows. If no parameters are specified, PlanType is set to 'Premium' and OSType is set to 'Windows'.
```powershell
Get-AzFunctionAppAvailableLocation
```

```output
Name
----
Central US
North Europe
West Europe
Southeast Asia
East Asia
West US
East US
Japan West
Japan East
East US 2
North Central US
South Central US
Brazil South
Australia East
Australia Southeast
East Asia (Stage)
West India
South India
Canada Central
West US 2
UK West
UK South
East US 2 EUAP
Central US EUAP
Korea Central
France Central
Australia Central 2
Australia Central
Germany West Central
Norway East
```

This command gets the locations where Premium is available for Windows.

### Example 2: Get the locations where Premium is available for Linux.
```powershell
Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Linux
```

```output
Name
----
Central US
North Europe
West Europe
Southeast Asia
East Asia
West US
East US
Japan West
Japan East
East US 2
North Central US
South Central US
Brazil South
Australia East
Australia Southeast
West India
Canada Central
West Central US
West US 2
UK West
UK South
Central US EUAP
Korea Central
France Central
Norway East
```

This command gets the locations where Premium is available for Linux.

### Example 3: Get the locations where Consumption is available for Windows.
```powershell
Get-AzFunctionAppAvailableLocation -PlanType Consumption -OSType Windows
```

```output
Name
----
Central US
North Europe
West Europe
Southeast Asia
East Asia
West US
East US
Japan West
Japan East
East US 2
North Central US
South Central US
Brazil South
Australia East
Australia Southeast
East Asia (Stage)
Central India
West India
South India
Canada Central
Canada East
West Central US
West US 2
UK West
UK South
East US 2 EUAP
Central US EUAP
Korea Central
France Central
Australia Central 2
Australia Central
South Africa North
Switzerland North
Germany West Central
```

This command gets the locations where Consumption is available for Windows.

### Example 4: Get the locations where Flex Consumption is available
```powershell
Get-AzFunctionAppAvailableLocation -PlanType FlexConsumption
```

```output
Name
----
Canada Central
North Europe
West Europe
Southeast Asia
East Asia
West US
Japan West
Japan East
East US 2
North Central US
South Central US
Brazil South
Australia East
Australia Southeast
Central US
East US
North Central US (Stage)
Central India
South India
Canada East
West Central US
West US 2
UK West
UK South
East US 2 EUAP
Korea Central
France South
France Central
South Africa North
Switzerland North
Germany West Central
Switzerland West
UAE North
Norway East
West US 3
Sweden Central
Poland Central
Italy North
Israel Central
Spain Central
Mexico Central
Taiwan North
Taiwan Northwest
New Zealand North
Indonesia Central
Malaysia West
```

This command gets the locations where Flex Consumption is available.

### Example 5: Get the locations where Flex Consumption supports Zone Redundancy
```powershell
Get-AzFunctionAppAvailableLocation -PlanType FlexConsumption -ZoneRedundancy
```

```output
Name
----
Canada Central
Southeast Asia
East Asia
Australia East
East US
Central India
UK South
East US 2 EUAP
South Africa North
Germany West Central
UAE North
Norway East
West US 3
Sweden Central
Italy North
Israel Central
```

This command retrieves the locations where Flex Consumption is available and zone redundancy is supported.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSType
The OS type for the service plan.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanType
The plan type.
Valid inputs: Consumption or Premium

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
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
Position: 0
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneRedundancy
Filter the list to return only locations which support zone redundancy.

```yaml
Type: System.Management.Automation.SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.IGeoRegion

## NOTES

## RELATED LINKS

