---
external help file: Microsoft.Azure.PowerShell.Cmdlets.IotHub.dll-Help.xml
Module Name: Az.IotHub
online version: https://docs.microsoft.com/powershell/module/az.iothub/get-aziothubmoduleconnectionstring
schema: 2.0.0
---

# Get-AzIotHubModuleConnectionString

## SYNOPSIS
Get the connection string of a target IoT device module in an Iot Hub.

## SYNTAX

### ResourceSet (Default)
```
Get-AzIotHubModuleConnectionString [-ResourceGroupName] <String> [-IotHubName] <String> [-DeviceId] <String>
 [-ModuleId <String>] [-KeyType <PSKeyType>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InputObjectSet
```
Get-AzIotHubModuleConnectionString [-InputObject] <PSIotHub> [-DeviceId] <String> [-ModuleId <String>]
 [-KeyType <PSKeyType>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdSet
```
Get-AzIotHubModuleConnectionString [-ResourceId] <String> [-DeviceId] <String> [-ModuleId <String>]
 [-KeyType <PSKeyType>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
List connection string of all modules or a specified module of a target IoT device contained within an Azure IoT Hub.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzIotHubModuleConnectionString -ResourceGroupName "myresourcegroup" -IotHubName "myiothub" -Deviceid "myDevice1"

Module Id Connection String
--------- -----------------
module1   HostName=myiothub.azure-devices.net;DeviceId=myDevice1;ModuleId=module1;SharedAccessKey=/X4yj******     
module2   HostName=myiothub.azure-devices.net;DeviceId=myDevice1;ModuleId=module2;x509=true
```

Show all modules connection string of a target IoT device in an Iot Hub.

### Example 2
```powershell
PS C:\> Get-AzIotHubMCS -ResourceGroupName "myresourcegroup" -IotHubName "myiothub" -DeviceId "myDevice1" -ModuleId "module1" -KeyType secondary

Module Id Connection String
--------- -----------------
module1   HostName=myiothub.azure-devices.net;DeviceId=myDevice1;ModuleId=module1;SharedAccessKey=/X4yj******
```

Get the secondary module connection string of a target IoT device in an Iot Hub.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceId
Target Device Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
IotHub object

```yaml
Type: Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHub
Parameter Sets: InputObjectSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IotHubName
Name of the Iot Hub

```yaml
Type: System.String
Parameter Sets: ResourceSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyType
Shared access policy key type for auth.

```yaml
Type: Microsoft.Azure.Commands.Management.IotHub.Models.PSKeyType
Parameter Sets: (All)
Aliases:
Accepted values: primary, secondary

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModuleId
Target Module Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource Group

```yaml
Type: System.String
Parameter Sets: ResourceSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
IotHub Resource Id

```yaml
Type: System.String
Parameter Sets: ResourceIdSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHub

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.IotHub.Models.PSModuleConnectionString

## NOTES

## RELATED LINKS
