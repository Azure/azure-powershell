---
external help file: Microsoft.Azure.Commands.ContainerInstance.dll-Help.xml
Module Name: AzureRM.ContainerInstance
online version: 
schema: 2.0.0
---

# Export-AzureRmContainerGroupLogs

## SYNOPSIS
Export the logs of a container in the container group.

## SYNTAX

```
Export-AzureRmContainerGroupLogs [-ResourceGroupName] <String> [-Name] <String> [-ContainerName <String>]
 -Directory <String>
```

## DESCRIPTION
The **Export-AzureRmContainerGroupLogs** cmdlet exports the logs of a container in a container group.

## EXAMPLES

### Example 1: Exports the logs of the container that has the same name as the container group
```
PS C:\> Export-AzureRmContainerGroupLogs -ResourceGroupName MyResourceGroup -Name MyContainer -Dir .
VERBOSE: Logs saved in MyContainer_log
```

This command exports the logs of the container with name `MyContainer` in container group `MyContainer`.

### Example 2: Exports the logs of the container
```
PS C:\> Export-AzureRmContainerGroupLogs -ResourceGroupName MyResourceGroup -Name MyContainerGroup -ContainerName container1 -Dir .
VERBOSE: Logs saved in container1_log
```

This command exports the logs of the container with name `container1` in container group `MyContainer`.

### Example 3: Exports the logs of the container by piping
```
PS C:\> Get-AzureRmContainerGroup -ResourceGroupName MyResourceGroup -Name MyContainerGroup | Export-AzureRmContainerGroupLogs -Dir .
VERBOSE: Logs saved in MyContainer_log
```

This command exports the logs of the container with name `MyContainer` in container group `MyContainer` by piping.

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

### -Directory
The directory to save the logs.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Dir

Required: True
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

