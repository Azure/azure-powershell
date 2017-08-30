---
external help file: Microsoft.Azure.Commands.ContainerInstance.dll-Help.xml
Module Name: AzureRM.ContainerInstance
online version: 
schema: 2.0.0
---

# New-AzureRmContainerGroup

## SYNOPSIS
Creates a container group.

## SYNTAX

```
New-AzureRmContainerGroup [-ResourceGroupName] <String> [-Name] <String> -Image <String> [-Location <String>]
 [-OsType <String>] [-Cpu <Double>] [-Memory <Double>] [-IpAddressType <String>] [-Port <Int32>]
 [-Command <String[]>] [-EnvironmentVariables <Hashtable>] [-RegistryServer <String>]
 [-RegistryUsername <String>] [-RegistryPassword <SecureString>] [-Tags <Hashtable>]
```

## DESCRIPTION
The **New-AzureRmContainerGroup** cmdlets creates a container group.

## EXAMPLES

### Example 1: Creates a container group with public IP address
```
PS C:\> New-AzureRmContainerGroup -ResourceGroupName MyResourceGroup -Name MyContainer -Image nginx -OsType Linux -IpAddressType Public -Port 8000

{
  "ResourceGroupName": "MyResourceGroup",
  "Id": "/subscriptions/ae43b1e3-c35d-4c8c-bc0d-f148b4c52b78/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerInstance/containerGroups/MyContainer",
  "Name": "MyContainer",
  "Type": "Microsoft.ContainerInstance/containerGroups",
  "Location": "westus",
  "Tags": null,
  "ProvisioningState": "Creating",
  "Containers": [
    {
      "Name": "MyContainer",
      "Image": "nginx:",
      "Command": [],
      "Ports": [
        8000
      ],
      "EnvironmentVariables": {},
      "CurrentState": null,
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
  "IpAddress": "13.64.118.11",
  "Ports": [
    {
      "protocol": "TCP",
      "port": 8000
    }
  ],
  "OsType": "Linux",
  "Volumes": null
}
```

This commands creates a container group using latest nginx image and requests a public IP address with opening port 8000.

### Example 2: Creates a container group with container command and environment variables
```
PS C:\> New-AzureRmContainerGroup -ResourceGroupName MyResourceGroup -Name MyContainer -Image ubuntu -OsType Linux -Command @('/bin/sh', '-c', 'myscript.sh') -EnvironmentVariables @{'env1'='value1'; 'env2'='value2'}

{
  "ResourceGroupName": "MyResourceGroup",
  "Id": "/subscriptions/ae43b1e3-c35d-4c8c-bc0d-f148b4c52b78/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerInstance/containerGroups/MyContainer",
  "Name": "MyContainer",
  "Type": "Microsoft.ContainerInstance/containerGroups",
  "Location": "westus",
  "Tags": null,
  "ProvisioningState": "Creating",
  "Containers": [
    {
      "Name": "MyContainer",
      "Image": "ubuntu",
      "Command": [
        "/bin/sh",
        "-c",
        "myscript.sh"
      ],
      "Ports": [],
      "EnvironmentVariables": {
        "env1": "value1",
        "env2": "value2"
      },
      "CurrentState": null,
      "PreviousState": null,
      "Events": null,
      "Cpu": 1.0,
      "MemoryInGb": 1.5,
      "CpuLimit": null,
      "MemoryLimitInGb": null,
      "VolumeMounts": null
    }
  ],
  "ImageRegistryCredentials": null,
  "RestartPolicy": null,
  "IpAddress": null,
  "Ports": null,
  "OsType": "Linux",
  "Volumes": null
}
```

This commands creates a container group and runs a custom script inside the container. Notice the `-Command` parameter is an array.

### Example 3: Creates a container group using image in Azure Container Registry
```
PS C:\> $registryPassword = ConvertTo-SecureString <password> -AsPlainText -Force
PS C:\> New-AzureRmContainerGroup -ResourceGroupName MyResourceGroup -Name MyContainer -Image azcloudconsoleregistry.azurecr.io/nginx:latest -IpAddressType Public -RegistryPassword $registryPassword

{
  "ResourceGroupName": "MyResourceGroup",
  "Id": "/subscriptions/ae43b1e3-c35d-4c8c-bc0d-f148b4c52b78/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerInstance/containerGroups/MyContainer",
  "Name": "MyContainer",
  "Type": "Microsoft.ContainerInstance/containerGroups",
  "Location": "westus",
  "Tags": null,
  "ProvisioningState": "Creating",
  "Containers": [
    {
      "Name": "MyContainer",
      "Image": "azcloudconsoleregistry.azurecr.io/nginx:latest",
      "Command": null,
      "Ports": [
        80
      ],
      "EnvironmentVariables": {},
      "CurrentState": null,
      "PreviousState": null,
      "Events": [],
      "Cpu": 1.0,
      "MemoryInGb": 1.5,
      "CpuLimit": null,
      "MemoryLimitInGb": null,
      "VolumeMounts": null
    }
  ],
  "ImageRegistryCredentials": [
    {
      "server": "azcloudconsoleregistry.azurecr.io",
      "username": "azcloudconsoleregistry",
      "password": null
    }
  ],
  "RestartPolicy": null,
  "IpAddress": "13.64.118.11",
  "Ports": [
    {
      "protocol": "TCP",
      "port": 80
    }
  ],
  "OsType": "Linux",
  "Volumes": null
}
```

This commands creates a container group using the nginx image in Azure Container Registry.

### Example 4: Creates a container group using image in custom container image registry
```
PS C:\> $registryPassword = ConvertTo-SecureString <password> -AsPlainText -Force
PS C:\> New-AzureRmContainerGroup -ResourceGroupName MyResourceGroup -Name MyContainer -Image myserver.com/myimage:latest -RegistryServer myserver.com -RegistryUsername username -RegistryPassword $registryPassword

{
  "ResourceGroupName": "MyResourceGroup",
  "Id": "/subscriptions/ae43b1e3-c35d-4c8c-bc0d-f148b4c52b78/resourceGroups/MyResourceGroup/providers/Microsoft.ContainerInstance/containerGroups/MyContainer",
  "Name": "MyContainer",
  "Type": "Microsoft.ContainerInstance/containerGroups",
  "Location": "westus",
  "Tags": null,
  "ProvisioningState": "Creating",
  "Containers": [
    {
      "Name": "MyContainer",
      "Image": "myserver.com/myimage:latest",
      "Command": null,
      "Ports": null,
      "EnvironmentVariables": {},
      "CurrentState": null,
      "PreviousState": null,
      "Events": [],
      "Cpu": 1.0,
      "MemoryInGb": 1.5,
      "CpuLimit": null,
      "MemoryLimitInGb": null,
      "VolumeMounts": null
    }
  ],
  "ImageRegistryCredentials": [
    {
      "server": "myserver.com",
      "username": "username",
      "password": null
    }
  ],
  "RestartPolicy": null,
  "IpAddress": "13.64.118.11",
  "Ports": null,
  "OsType": "Linux",
  "Volumes": null
}
```

This commands creates a container group using a custom image from a custom container image registry.

## PARAMETERS

### -Command
The command to run in the container.
e.g.
@("executable","param1","param2")

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Cpu
The required CPU cores.
Default: 1

```yaml
Type: Double
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentVariables
The container environment variables.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Image
The container image.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpAddressType
The IP address type.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: Public

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The container group Location.
Default to the location of the resource group.

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

### -Memory
The required memory in GB.
Default: 1.5

```yaml
Type: Double
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

### -OsType
The container OS type.
Default: Linux

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: Linux, Windows

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
The port to open.

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

### -RegistryPassword
The custom container registry password.

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryServer
The custom container registry login server.

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

### -RegistryUsername
The custom container registry username.

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
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tags
{{Fill Tags Description}}

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: Tag

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

## INPUTS

### System.String
System.Collections.Hashtable


## OUTPUTS

### Microsoft.Azure.Commands.ContainerInstance.Models.PSContainerGroup


## NOTES

## RELATED LINKS

