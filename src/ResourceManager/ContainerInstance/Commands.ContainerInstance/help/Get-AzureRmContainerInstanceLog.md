---
external help file: Microsoft.Azure.Commands.ContainerInstance.dll-Help.xml
Module Name: AzureRM.ContainerInstance
online version: 
schema: 2.0.0
---

# Get-AzureRmContainerInstanceLog

## SYNOPSIS
Get the logs of a container instance in a container group.

## SYNTAX

### GetContainerInstanceLogByNames
```
Get-AzureRmContainerInstanceLog [-ResourceGroupName] <String> -ContainerGroupName <String> [-Name <String>]
 [-Tail <Int32>]
```

### GetContainerInstanceLogByPSContainerGroup
```
Get-AzureRmContainerInstanceLog -InputContainerGroup <PSContainerGroup> [-Name <String>] [-Tail <Int32>]
```

### GetContainerInstanceLogByResourceId
```
Get-AzureRmContainerInstanceLog -ResourceId <String> [-Name <String>] [-Tail <Int32>]
```

## DESCRIPTION
The **Get-AzureRmContainerInstanceLog** cmdlet gets the logs of a container in a container group.

## EXAMPLES

### Example 1: Get the tail log of a container instance
```
PS C:\> Get-AzureRmContainerInstanceLog -ResourceGroupName demo -ContainerGroupName mycontainer -Name container1

Log line 1.
Log line 2.
Log line 3.
Log line 4.
```

Get the log from `container1` in container group `mycontainer`. By default, it will return up to 4MB log content.

### Example 2: Get the tail log of a container instance that has the same name as the container group
```
PS C:\> Get-AzureRmContainerInstanceLog -ResourceGroupName demo -ContainerGroupName mycontainer

Log line 1.
Log line 2.
Log line 3.
Log line 4.
```

Get the log from `mycontainer` in container group `mycontainer`. By default, it will return up to 4MB log content.

### Example 3: Get the tail 2 lines of log of a container instance
```
PS C:\> Get-AzureRmContainerInstanceLog -ResourceGroupName demo -ContainerGroupName mycontainer -Name container1 -Tail 2

Log line 3.
Log line 4.
```

Get the tail 2 lines of log from `container1` in container group `mycontainer`.

### Example 4: Get the tail log of a container instance in a piped in container group
```
PS C:\> Get-AzureRmContainerGroup -ResourceGroupName demo -Name mycontainer | Get-AzureRmContainerInstanceLog

Log line 1.
Log line 2.
Log line 3.
Log line 4.
```

Get the log from `mycontainer` in piped in container group `mycontainer`. By default, it will return up to 4MB log content.

## PARAMETERS

### -ContainerGroupName
The container group name.

```yaml
Type: String
Parameter Sets: GetContainerInstanceLogByNames
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputContainerGroup
The input container group object.

```yaml
Type: PSContainerGroup
Parameter Sets: GetContainerInstanceLogByPSContainerGroup
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The container instance name in the container group.
Default: the same as the container group name

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

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: GetContainerInstanceLogByNames
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: GetContainerInstanceLogByResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tail
The number of lines to tail the log.
If not specify, the cmdlet will return up to 4MB tailed log

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### Microsoft.Azure.Commands.ContainerInstance.Models.PSContainerGroup


## OUTPUTS

### System.String


## NOTES

## RELATED LINKS

