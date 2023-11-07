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