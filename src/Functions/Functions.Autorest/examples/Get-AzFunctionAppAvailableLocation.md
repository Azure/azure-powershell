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

Currently, Flex Consumption is supported only on Linux. To retrieve the list of regions, set the PlanType parameter to 'FlexConsumption'. The OSType parameter is optional; however, the cmdlet will return an error if OSType is set to 'Windows'.


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

Flex Consumption plans can optionally be zone redundant in regions that support Availability Zones. To retrieve the list of regions where zone redundancy is available for Flex Consumption, set the PlanType parameter to 'FlexConsumption' and include the ZoneRedundancy switch. Note that zone redundancy is currently supported only for Flex Consumption.

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
