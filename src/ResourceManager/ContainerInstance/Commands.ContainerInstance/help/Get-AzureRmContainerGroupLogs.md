---
external help file: Microsoft.Azure.Commands.ContainerInstance.dll-Help.xml
Module Name: AzureRM.ContainerInstance
online version: 
schema: 2.0.0
---

# Get-AzureRmContainerGroupLogs

## SYNOPSIS
Get the logs of a container in the container group.

## SYNTAX

```
Get-AzureRmContainerGroupLogs [-ResourceGroupName] <String> [-Name] <String> [-ContainerName <String>]
```

## DESCRIPTION
The **Get-AzureRmContainerGroupLogs** cmdlet gets the logs of a container in a container group.

## EXAMPLES

### Example 1: Gets the logs of the container that has the same name as the container group
```
PS C:\> Get-AzureRmContainerGroupLogs -ResourceGroupName MyResourceGroup -Name MyContainer

This is the log content.
```

This command gets the logs of the container with name `MyContainer` in container group `MyContainer`.

### Example 2: Gets the logs of the container
```
PS C:\> Get-AzureRmContainerGroupLogs -ResourceGroupName MyResourceGroup -Name MyContainerGroup -ContainerName container1

This is the log content.
```

This command gets the logs of the container with name `container1` in container group `MyContainer`.

### Example 3: Gets the logs of the container by piping
```
PS C:\> Get-AzureRmContainerGroup -ResourceGroupName MyResourceGroup -Name MyContainerGroup | Get-AzureRmContainerGroupLogs

This is the log content.
```

This command gets the logs of the container with name `MyContainer` in container group `MyContainer` by piping.

## PARAMETERS

### -ContainerName
The name of the container to tail the log, by default it's the same as container group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The container group name.

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
The resource group name.

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

### System.String


## NOTES

## RELATED LINKS

