---
Download Help Link: None_Azure
external help file: Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.dll-Help.xml
Help Version: 0.0.1.0
Locale: en-US
Module Guid: acace26c-1775-4100-85c0-20c4d71eaa22
Module Name: AzureRM.PowerBIEmbeddedCapacity
schema: 2.0.0
---

# Remove-AzureRmPowerBIEmbeddedCapacity

## SYNOPSIS
Deletes an instance of PowerBI Embedded Capacity

## SYNTAX

```
Remove-AzureRmPowerBIEmbeddedCapacity [-Name] <String> [[-ResourceGroupName] <String>] [[-ResourceId] <String>]
 [[-InputObject] <AzurePowerBIEmbeddedCapacity>] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzureRmPowerBIEmbeddedCapacity cmdlet  deletes an instance of PowerBI Embedded Capacity

## EXAMPLES

### Example 1
```
PS C:\> Remove-AzureRmPowerBIEmbeddedCapacity -Name "testcapacity" -ResourceGroupName "testRG"
Sku                    : A1
Tier				   : PBIE_Azure
Administrators         : {{admin@microsoft.com}}
State                  : Succeeded
ProvisioningState      : Succeeded
Id                     : /subscriptions/78e47976-009f-4d4a-a961-6046cdabf459/resourceGroups/testRG/providers/Microsoft.PowerBIDedicated/capacities/testcapacity
Name                   : testcapacity
Type                   : Microsoft.AnalysisServices/servers
Location               : West US
Tag                    : {}
```

This command will remove the capacity named testcapacity in the resourcegroup testRG

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

### -InputObject
PowerBI Embedded Capacity object.```yaml
Type: AzurePowerBIEmbeddedCapacity
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the PowerBI Embedded Capacity

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Will return the deleted capacity details if the operation completes successfully

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Azure resource group to which the capacity belongs

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

### -ResourceId
PowerBI Embedded Capacity ResourceID.```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts user to confirm whether to perform the operation

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Describes the actions the current operation will perform without actually performing them

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Models.AzurePowerBIEmbeddedCapacity

## NOTES

## RELATED LINKS

[Get-AzureRmPowerBIEmbeddedCapacity](./Get-AzureRmPowerBIEmbeddedCapacity.md)

[New-AzureRmPowerBIEmbeddedCapacity](./New-AzureRmPowerBIEmbeddedCapacity.md)
