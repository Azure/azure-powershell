---
external help file:
Module Name: Az.Functions
online version: https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azfunctionappavailablelocation
schema: 2.0.0
---

# Get-AzFunctionAppAvailableLocation

## SYNOPSIS
Gets the location where a function app for the given os and plan type is available.

## SYNTAX

```
Get-AzFunctionAppAvailableLocation [-PlanType] <String> [-OSType] <String> [[-DefaultProfile] <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the location where a function app for the given os and plan type is available.

## EXAMPLES

### Example 1: Get the locations where Premium is available for Linux.
```powershell
PS C:\> Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Linux

Name                Type
----                ----
Central US          Microsoft.Web/geoRegions
North Europe        Microsoft.Web/geoRegions
West Europe         Microsoft.Web/geoRegions
Southeast Asia      Microsoft.Web/geoRegions
East Asia           Microsoft.Web/geoRegions
West US             Microsoft.Web/geoRegions
East US             Microsoft.Web/geoRegions
Japan West          Microsoft.Web/geoRegions
Japan East          Microsoft.Web/geoRegions
East US 2           Microsoft.Web/geoRegions
North Central US    Microsoft.Web/geoRegions
South Central US    Microsoft.Web/geoRegions
Brazil South        Microsoft.Web/geoRegions
Australia East      Microsoft.Web/geoRegions
Australia Southeast Microsoft.Web/geoRegions
West India          Microsoft.Web/geoRegions
Canada Central      Microsoft.Web/geoRegions
West Central US     Microsoft.Web/geoRegions
West US 2           Microsoft.Web/geoRegions
UK West             Microsoft.Web/geoRegions
UK South            Microsoft.Web/geoRegions
Central US EUAP     Microsoft.Web/geoRegions
Korea Central       Microsoft.Web/geoRegions
France Central      Microsoft.Web/geoRegions
Norway East         Microsoft.Web/geoRegions

```

### Example 2: Get the locations where Premium is available for Windows.
```powershell
PS C:\> Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Windows

Name                 Type
----                 ----
Central US           Microsoft.Web/geoRegions
North Europe         Microsoft.Web/geoRegions
West Europe          Microsoft.Web/geoRegions
Southeast Asia       Microsoft.Web/geoRegions
East Asia            Microsoft.Web/geoRegions
West US              Microsoft.Web/geoRegions
East US              Microsoft.Web/geoRegions
Japan West           Microsoft.Web/geoRegions
Japan East           Microsoft.Web/geoRegions
East US 2            Microsoft.Web/geoRegions
North Central US     Microsoft.Web/geoRegions
South Central US     Microsoft.Web/geoRegions
Brazil South         Microsoft.Web/geoRegions
Australia East       Microsoft.Web/geoRegions
Australia Southeast  Microsoft.Web/geoRegions
East Asia (Stage)    Microsoft.Web/geoRegions
West India           Microsoft.Web/geoRegions
South India          Microsoft.Web/geoRegions
Canada Central       Microsoft.Web/geoRegions
West US 2            Microsoft.Web/geoRegions
UK West              Microsoft.Web/geoRegions
UK South             Microsoft.Web/geoRegions
East US 2 EUAP       Microsoft.Web/geoRegions
Central US EUAP      Microsoft.Web/geoRegions
Korea Central        Microsoft.Web/geoRegions
France Central       Microsoft.Web/geoRegions
Australia Central 2  Microsoft.Web/geoRegions
Australia Central    Microsoft.Web/geoRegions
Germany West Central Microsoft.Web/geoRegions
Norway East          Microsoft.Web/geoRegions

```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSType
The OS type for the service plan.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanType
The plan type.
Valid inputs: 'Premium'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20160301.IGeoRegion

## ALIASES

## NOTES

## RELATED LINKS

