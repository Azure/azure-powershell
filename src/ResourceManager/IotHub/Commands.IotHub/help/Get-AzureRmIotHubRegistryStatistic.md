---
external help file: Microsoft.Azure.Commands.IotHub.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmIotHubRegistryStatistic

## SYNOPSIS
Gets the RegistryStatistics for an IotHub.

## SYNTAX

```
Get-AzureRmIotHubRegistryStatistic [-ResourceGroupName] <String> [-Name] <String>
```

## DESCRIPTION
Gets the RegistryStatistics for an IotHub.
This provides information about the number of total, enabled and disabled devices in an IotHub.

## EXAMPLES

### Example 1 Get the RegistryStatistics
```
PS C:\> Get-AzureRmIotHubRegistryStatistic -ResourceGroupName "myresourcegroup" -Name "myiothub"
```

Gets the RegistryStatictics for the IotHub named "myiothub"

## PARAMETERS

### -Name
Name

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

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

## INPUTS

### System.String

## OUTPUTS

### System.Collections.Generic.IList`1[[Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHubRegistryStatistics, Microsoft.Azure.Commands.IotHub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

