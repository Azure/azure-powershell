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

### Example 1: Gets a specified container group
```
PS C:\> Get-AzureRmContainerGroup -ResourceGroupName "MyResourceGroup" -Name "MyContainer"

{
  "ResourceGroupName": "MyResourceGroup",
  "Id": "/subscriptions/ae43b1e3-c35d-4c8c-bc0d-f148b4c52b78/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerInstance/containerGroups/MyContainer",
  "Name": "MyContainer",
  "Type": "Microsoft.ContainerInstance/containerGroups",
  "Location": "westus",
  "Tags": null,
  "ProvisioningState": "Succeeded",
  "Containers": [
    {
      "Name": "MyContainer",
      "Image": "myimage",
      "Command": [],
      "Ports": [
        8003
      ],
      "EnvironmentVariables": {},
      "CurrentState": {
        "state": "Running",
        "startTime": "2017-08-05T01:11:48Z",
        "exitCode": null,
        "finishTime": null,
        "detailStatus": ""
      },
      "PreviousState": null,
      "Events": [],
      "Cpu": 1.0,
      "MemoryInGb": 1.5,
      "CpuLimit": null,
      "MemoryLimitInGb": null,
      "VolumeMounts": null
    }
  ],
  "ImageRegistryCredentials": null,
  "RestartPolicy": null,
  "IpAddress": "13.64.237.171",
  "Ports": [
    {
      "protocol": "TCP",
      "port": 8003
    }
  ],
  "OsType": "Linux",
  "Volumes": null
}
```

The command gets the specified container group. The default output is in JSON format.

### Example 2: Gets container groups in a resource group
```
PS C:\> Get-AzureRmContainerGroup -ResourceGroupName "MyResourceGroup" | Format-Table

ResourceGroupName Name                     Location   OsType  Image                         IP                   Resources        ProvisioningState
----------------- ----                     --------   ------  -----                         --                   ---------        -----------------
demo              container1               west us    Linux   alpine:latest                 40.83.144.50:8002    1 cores/1 gb             Succeeded
demo              container2               west us    Linux   alpine:latest                 104.42.228.253:8001  1 cores/1 gb             Succeeded
```

The command gets the container groups in the resource group `MyResourceGroup` and output in table format.

### Example 3: Gets container groups in the current subscription
```
PS C:\> Get-AzureRmContainerGroup | Format-Table

ResourceGroupName Name                     Location   OsType  Image                         IP                   Resources        ProvisioningState
----------------- ----                     --------   ------  -----                         --                   ---------        -----------------
demo1             container1               west us    Linux   alpine:latest                 40.83.144.50:8002    1 cores/1 gb             Succeeded
demo2             container2               west us    Linux   alpine:latest                 104.42.228.253:8001  1 cores/1 gb             Succeeded
```

The command gets the container groups in the current subscription and output in table format.

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

