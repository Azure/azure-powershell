---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DeviceProvisioningServices.dll-Help.xml
Module Name: Az.DeviceProvisioningServices
online version: https://docs.microsoft.com/powershell/module/az.deviceprovisioningservices/get-aziotdeviceprovisioningservice
schema: 2.0.0
---

# Get-AzIoTDeviceProvisioningService

## SYNOPSIS
List all or show details of Azure IoT Hub device provisioning services.

## SYNTAX

### ListIotDpsByResourceGroup (Default)
```
Get-AzIoTDeviceProvisioningService [-ResourceGroupName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetIotDpsByName
```
Get-AzIoTDeviceProvisioningService -ResourceGroupName <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
For an introduction to Azure IoT Hub Device Provisioning Service, see https://docs.microsoft.com/azure/iot-dps/about-iot-dps.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzIoTDeviceProvisioningService

ResourceGroupName	Name		Location	ServiceOperationsHostName					IotHubs	AllocationPolicy	Tags	State
-----------------	----		--------	-------------------------					------- ----------------	----	-----	
myresourcegroup0	myiotdps0	eastus		myiotdps0.azure-devices-provisioning.net	0       Static				0		Active
myresourcegroup1    myiotdps1	eastus		myiotdps1.azure-devices-provisioning.net	4       Hashed				0		Active
myresourcegroup1    myiotdps2	westus		myiotdps2.azure-devices-provisioning.net	4       GeoLatency			0		Active
```

List all Azure IoT Hub device provisioning services in a subscription.

### Example 2
```
PS C:\> Get-AzIoTDeviceProvisioningService -ResourceGroupName "myresourcegroup"

ResourceGroupName	Name		Location	ServiceOperationsHostName					IotHubs	AllocationPolicy	Tags	State
-----------------	----		--------	-------------------------					------- ----------------	----	-----
myresourcegroup		myiotdps1	eastus		myiotdps1.azure-devices-provisioning.net	1       Hashed				0		Active
myresourcegroup     myiotdps2	westus		myiotdps2.azure-devices-provisioning.net	4       GeoLatency			0		Active
```

List all Azure IoT Hub device provisioning services in the resource group 'myresourcegroup'.

### Example 3
```
PS C:\> Get-AzIoTDeviceProvisioningService -ResourceGroupName "myresourcegroup" -Name "myiotdps"

ResourceGroupName			: myresourcegroup
Name						: myiotdps
Location					: eastus
Type						: Microsoft.Devices/provisioningServices
ServiceOperationsHostName	: myiotdps.azure-devices-provisioning.net
IotHubs						: 0
State						: Active
AllocationPolicy			: Hashed
Tags						: {}
SkuName						: S1
SkuTier						: Standard
Etag						: AAAAAAAT52k=
```

Show details of an Azure IoT Hub device provisioning service 'myiotdps'.

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

### -Name
Name of the IoT Device Provisioning Service

```yaml
Type: System.String
Parameter Sets: GetIotDpsByName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource Group

```yaml
Type: System.String
Parameter Sets: ListIotDpsByResourceGroup
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GetIotDpsByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models.PSProvisioningServiceDescription

## NOTES

## RELATED LINKS
