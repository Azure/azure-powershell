---
Download Help Link: None_Azure
external help file: Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.dll-Help.xml
Help Version: 0.0.1.0
Locale: en-US
Module Guid: acace26c-1775-4100-85c0-20c4d71eaa22
Module Name: AzureRM.PowerBIEmbeddedCapacity
schema: 2.0.0
---

# Update-AzureRmPowerBIEmbeddedCapacity

## SYNOPSIS
Modifies  an instance of PowerBI Embedded Capacity

## SYNTAX

```
Update-AzureRmPowerBIEmbeddedCapacity [-Name] <String> [[-ResourceGroupName] <String>] [[-Sku] <String>]
 [[-Tag] <Hashtable>] [[-Administrators] <String[]>] [[-ResourceId] <String>]
 [[-InputObject] <AzurePowerBIEmbeddedCapacity>] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Update-AzureRmPowerBIEmbeddedCapacity cmdlet modifies an instance of PowerBI Embedded Capacity

## EXAMPLES

### Example 1
```
PS C:\> Update-AzureRmPowerBIEmbeddedCapacity -Name "testcapacity" -ResourceGroupName "testRG" -Tag "key1:value1,key2:value2" -Administrator "testuser1@contoso.com"
Sku                    : A1
Tier                   : PBIE_Azure
Administrators         : {{testuser1@contoso.com}}
State                  : Succeeded
ProvisioningState      : Succeeded
Id                     : /subscriptions/78e47976-009f-4d4a-a961-6046cdabf459/resourceGroups/testRG/providers/Microsoft.PowerBIDedicated/capacities/testcapacity
Name                   : testcapacity
Type                   : Microsoft.PowerBIDedicated/capacities
Location               : West US
Tag                    : {{key1:value1},{key2:value2}}
```

Modifies the capacity named testcapacity in resourcegroup testgroup to set the tags as key1:value1 and key2:value2 and administrator to testuser1@contoso.com

## PARAMETERS

### -Administrators
A comma separated capacity names to set as administrators on the capacity```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -Sku
The name of the Sku for the capacity.
Valid values are: 'A1', 'A2', 'A3', 'A4', 'A5', 'A6'.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: A1, A2, A3, A4, A5, A6

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Key-value pairs in the form of a hash table set as tags on the capacity.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
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

[Remove-AzureRmPowerBIEmbeddedCapacity](./Remove-AzureRmPowerBIEmbeddedCapacity.md)
