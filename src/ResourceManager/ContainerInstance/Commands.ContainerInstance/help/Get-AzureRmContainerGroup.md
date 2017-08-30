---
external help file: Microsoft.Azure.Commands.ContainerInstance.dll-Help.xml
Module Name: AzureRM.ContainerInstance
online version: 
schema: 2.0.0
---

# Get-AzureRmContainerGroup

## SYNOPSIS
Gets container groups.

## SYNTAX

### ListAllContainerGroupParamSet (Default)
```
Get-AzureRmContainerGroup [[-ResourceGroupName] <String>]
```

### GetContainerGroupInResourceGroupParamSet
```
Get-AzureRmContainerGroup [-ResourceGroupName] <String> [-Name] <String>
```

### ListContainerGroupInResourceGroupParamSet
```
Get-AzureRmContainerGroup [-ResourceGroupName] <String>
```

## DESCRIPTION
The **Get-AzureRmContainerGroup** cmdlet gets a specified container group or all the container groups in a resource group or the subscription.

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Name
The container group Name.

```yaml
Type: String
Parameter Sets: GetContainerGroupInResourceGroupParamSet
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource Group Name.

```yaml
Type: String
Parameter Sets: ListAllContainerGroupParamSet
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: GetContainerGroupInResourceGroupParamSet, ListContainerGroupInResourceGroupParamSet
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

### Microsoft.Azure.Commands.ContainerInstance.Models.PSContainerGroup


## NOTES

## RELATED LINKS

