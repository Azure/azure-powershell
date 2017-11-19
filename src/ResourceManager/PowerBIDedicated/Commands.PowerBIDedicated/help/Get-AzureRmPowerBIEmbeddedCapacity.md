---
Download Help Link: None_Azure
external help file: Microsoft.Azure.Commands.PowerBIDedicated.dll-Help.xml
Help Version: 0.0.1.0
Locale: en-US
Module Guid: acace26c-1775-4100-85c0-20c4d71eaa22
Module Name: AzureRM.PowerBIDedicated
schema: 2.0.0
---

# Get-AzureRmPowerBIEmbeddedCapacity

## SYNOPSIS
Gets the details of an PowerBI Embedded Capacity.

## SYNTAX

```
Get-AzureRmPowerBIEmbeddedCapacity [[-ResourceGroupName] <String>] [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmPowerBIEmbeddedCapacity cmdlet gets the details of an PowerBI Embedded Capacity.

## EXAMPLES

### Example 1: Get resource group capacities
```
PS C:\>Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName "testRG"
Sku                    : A1
Tier                   : PBIE_Azure
Administrators         : {{admin@microsoft.com}}
State                  : Succeeded
ProvisioningState      : Succeeded
Id                     : /subscriptions/78e47976-009f-4d4a-a961-6046cdabf459/resourceGroups/testRG/providers/Microsoft.PowerBIDedicated/capacities/testcapacity
Name                   : testcapacity
Type                   : Microsoft.PowerBIDedicated/capacities
Location               : West US
Tag                    : {}

Sku                    : A4
Tier                   : PBIE_Azure
Administrators         : {{admin@microsoft.com}}
State                  : Succeeded
ProvisioningState      : Succeeded
Id                     : /subscriptions/78e47976-009f-4d4a-a961-6046cdabf459/resourceGroups/testRG/providers/Microsoft.PowerBIDedicated/capacities/mycapacity
Name                   : mycapacity
Type                   : Microsoft.PowerBIDedicated/capacities
Location               : West US
Tag                    : {}
```

This command gets all Azure PowerBI Embedded Capacity in the resource group named testRG

### Example 2: Get a capacity
```
PS C:\>Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName "testRG" -Name "testcapacity"
Sku                    : A1
Tier                   : PBIE_Azure
Administrators         : {{admin@microsoft.com}}
State                  : Succeeded
ProvisioningState      : Succeeded
Id                     : /subscriptions/78e47976-009f-4d4a-a961-6046cdabf459/resourceGroups/testRG/providers/Microsoft.PowerBIDedicated/capacities/testcapacity
Name                   : testcapacity
Type                   : Microsoft.PowerBIDedicated/capacities
Location               : West US
Tag                    : {}
```

This command gets the Azure PowerBI Embedded Capacity named testcapacity in the resource group named testRG.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the PowerBI Embedded Capacity

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Azure resource group to which the capacity belongs

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.PowerBIDedicated.Models.AzurePowerBIEmbeddedCapacity

## NOTES

## RELATED LINKS

[New-AzureRmPowerBIEmbeddedCapacity ](./New-AzureRmPowerBIEmbeddedCapacity.md)

[Remove-AzureRmPowerBIEmbeddedCapacity ](./Remove-AzureRmPowerBIEmbeddedCapacity.md)