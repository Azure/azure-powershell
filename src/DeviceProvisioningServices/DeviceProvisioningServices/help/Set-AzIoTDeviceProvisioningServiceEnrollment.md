---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DeviceProvisioningServices.dll-Help.xml
Module Name: Az.DeviceProvisioningServices
online version: https://docs.microsoft.com/powershell/module/az.deviceprovisioningservices/set-aziotdeviceprovisioningserviceenrollment
schema: 2.0.0
---

# Set-AzIoTDeviceProvisioningServiceEnrollment

## SYNOPSIS
Update a device enrollment record.

## SYNTAX

### ResourceSet (Default)
```
Set-AzIoTDeviceProvisioningServiceEnrollment [-ResourceGroupName] <String> [-DpsName] <String>
 -RegistrationId <String> [-DeviceId <String>] [-ReprovisionPolicy <PSReprovisionType>]
 [-EdgeEnabled <Boolean>] [-Tag <Hashtable>] [-Desired <Hashtable>] [-AllocationPolicy <PSAllocationPolicy>]
 [-ProvisioningStatus <PSProvisioningStatus>] [-IotHubHostName <String>] [-IotHub <String[]>]
 [-WebhookUrl <String>] [-ApiVersion <String>] [-EndorsementKey <String>] [-StorageRootKey <String>]
 [-PrimaryKey <String>] [-SecondaryKey <String>] [-PrimaryCertificate <String>]
 [-SecondaryCertificate <String>] [-RootCertificate] [-PrimaryCAName <String>] [-SecondaryCAName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectSet
```
Set-AzIoTDeviceProvisioningServiceEnrollment [-DpsObject] <PSProvisioningServiceDescription>
 -RegistrationId <String> [-DeviceId <String>] [-ReprovisionPolicy <PSReprovisionType>]
 [-EdgeEnabled <Boolean>] [-Tag <Hashtable>] [-Desired <Hashtable>] [-AllocationPolicy <PSAllocationPolicy>]
 [-ProvisioningStatus <PSProvisioningStatus>] [-IotHubHostName <String>] [-IotHub <String[]>]
 [-WebhookUrl <String>] [-ApiVersion <String>] [-EndorsementKey <String>] [-StorageRootKey <String>]
 [-PrimaryKey <String>] [-SecondaryKey <String>] [-PrimaryCertificate <String>]
 [-SecondaryCertificate <String>] [-RootCertificate] [-PrimaryCAName <String>] [-SecondaryCAName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdSet
```
Set-AzIoTDeviceProvisioningServiceEnrollment [-ResourceId] <String> -RegistrationId <String>
 [-DeviceId <String>] [-ReprovisionPolicy <PSReprovisionType>] [-EdgeEnabled <Boolean>] [-Tag <Hashtable>]
 [-Desired <Hashtable>] [-AllocationPolicy <PSAllocationPolicy>] [-ProvisioningStatus <PSProvisioningStatus>]
 [-IotHubHostName <String>] [-IotHub <String[]>] [-WebhookUrl <String>] [-ApiVersion <String>]
 [-EndorsementKey <String>] [-StorageRootKey <String>] [-PrimaryKey <String>] [-SecondaryKey <String>]
 [-PrimaryCertificate <String>] [-SecondaryCertificate <String>] [-RootCertificate] [-PrimaryCAName <String>]
 [-SecondaryCAName <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a device enrollment in an Azure IoT Hub Device Provisioning Service.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-AzIoTDeviceProvisioningServiceEnrollment -ResourceGroupName "myresourcegroup" -DpsName "mydps" -RegistrationId "enroll1" -AllocationPolicy Hashed -IotHub "hub1","hub2"
```

Update allocation policy and hubs for an enrollment record.

### Example 2
```powershell
PS C:\> $tag = @{}
PS C:\> $tag.Add("environment","updatedenv")
PS C:\> $desired = @{}
PS C:\> $desired.add("version_dps", "updateddps")
PS C:\> Set-AzIoTDeviceProvisioningServiceEnrollment -ResourceGroupName "myresourcegroup" -DpsName "mydps" -RegistrationId "enroll1" -tag $tag -Desired $desired
```

Update an enrollment's initial twin state.

### Example 3
```powershell
PS C:\> Set-AzIoTDeviceProvisioningServiceEnrollment -ResourceGroupName "myresourcegroup" -DpsName "mydps" -RegistrationId "enroll1" -PrimaryCertificate ".\primaryCertificate.cer" -SecondaryCertificate ".\secondaryCertificate.cer"
```

Update a symmetric key enrollment's primary and secondary certificates

## PARAMETERS

### -AllocationPolicy
Type of allocation for device assigned to the Hub.

```yaml
Type: Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models.PSAllocationPolicy
Parameter Sets: (All)
Aliases:
Accepted values: Hashed, GeoLatency, Static, Custom

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApiVersion
The API version of the provisioning service in the custom allocation request.

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

### -Desired
Initial twin desired properties.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceId
IoT Hub Device ID.

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

### -DpsName
Name of the IoT Device Provisioning Service

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

### -DpsObject
IoT Device Provisioning Service Object

```yaml
Type: Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models.PSProvisioningServiceDescription
Parameter Sets: InputObjectSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EdgeEnabled
Flag indicating edge enablement.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndorsementKey
TPM endorsement key for a TPM device.

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

### -IotHub
Host name of target IoT Hub.
Use space-separated list for multiple IoT Hubs.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IotHubHostName
Host name of the target IoT Hub.

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

### -PrimaryCAName
The name of the primary root CA certificate.
If attestation with a root CA certificate is desired then a root ca name must be provided.

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

### -PrimaryCertificate
The path to the file containing the primary certificate.
Base-64 representation of X509 certificate .cer file or .pem file path.

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

### -PrimaryKey
The primary symmetric shared access key stored in base64 format.

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

### -ProvisioningStatus
Enable or disable enrollment entry.

```yaml
Type: Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models.PSProvisioningStatus
Parameter Sets: (All)
Aliases:
Accepted values: Enabled, Disabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistrationId
Individual enrollment registration id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReprovisionPolicy
Device data to be handled on re-provision to different Iot Hub.

```yaml
Type: Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models.PSReprovisionType
Parameter Sets: (All)
Aliases:
Accepted values: reprovisionandmigratedata, reprovisionandresetdata, never

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
IoT Device Provisioning Service Resource Id

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

### -RootCertificate
Switch to update X509attestation using root certificates.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecondaryCAName
The name of the secondary root CA certificate.
If attestation with a root CA certificate is desired then a root ca name must be provided.

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

### -SecondaryCertificate
The path to the file containing the secondary certificate.
Base-64 representation of X509 certificate .cer file or .pem file path.

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

### -SecondaryKey
The secondary symmetric shared access key stored in base64 format.

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

### -StorageRootKey
TPM storage root key for a TPM device.

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

### -Tag
Initial twin tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebhookUrl
The webhook URL used for custom allocation requests.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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

### Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models.PSProvisioningServiceDescription

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models.PSIndividualEnrollment

## NOTES

## RELATED LINKS
