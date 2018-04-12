---
external help file: Microsoft.Azure.Commands.DeviceProvisioningServices.dll-Help.xml
Module Name: AzureRM.DeviceProvisioningServices
online version: 
schema: 2.0.0
---

# New-AzureRmIoTDeviceProvisioningServiceCertificateVerificationCode

## SYNOPSIS
Generate a verification code for an Azure IoT Hub Device Provisioning Service certificate.

## SYNTAX

### ResourceSet (Default)
```
New-AzureRmIoTDeviceProvisioningServiceCertificateVerificationCode [-ResourceGroupName] <String>
 [-Name] <String> [-CertificateName] <String> [-Etag] <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectSet
```
New-AzureRmIoTDeviceProvisioningServiceCertificateVerificationCode [-InputObject] <PSCertificateResponse>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdSet
```
New-AzureRmIoTDeviceProvisioningServiceCertificateVerificationCode [-ResourceId] <String> [-Etag] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This verification code is used to complete the proof of possession step for a certificate. Use this verification code as the CN of a new certificate signed with the root certificates private key.
For a detailed explanation of CA certificates in Azure IoT Hub Device Provisioning Service, see https://docs.microsoft.com/en-us/azure/iot-dps/how-to-verify-certificates.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmIoTDeviceProvisioningServiceCertificateVerificationCode -ResourceGroupName "myresourcegroup" -Name "myiotdps" -CertificateName "mycertificate" -Etag "AAAAAAFPazE="

Id					: /subscriptions/377cxxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Devices/provisioningServices/myiotdps/certificates/mycertificate
ResourceGroupName	: myresourcegroup
Name				: myiotdps
CertificateName		: mycertificate
Subject				: CN=mycertificate
Thumbprint			: 38303FC7371EC78DDE3E18D712C8414EE50969C7
VerificationCode	: A901A843EFF75419AC1F0EB460E85DF153092A0547AA30F5
Status				: Unverified
Expiry				: 1/01/2027 16:01
Created				: 1/01/2017 16:01
Etag				: AAAAAAFpGcA=
```

Generate a verification code for "mycertificate".

### Example 2
```
PS C:\> Get-AzureRmIoTDpsCertificate -ResourceGroupName "myresourcegroup" -Name "myiotdps" -CertificateName "mycertificate" | New-AzureRmIoTDpsCVC

Id					: /subscriptions/377cxxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Devices/provisioningServices/myiotdps/certificates/mycertificate
ResourceGroupName	: myresourcegroup
Name				: myiotdps
CertificateName		: mycertificate
Subject				: CN=mycertificate
Thumbprint			: 38303FC7371EC78DDE3E18D712C8414EE50969C7
VerificationCode	: A901A843EFF75419AC1F0EB460E85DF153092A0547AA30F5
Status				: Unverified
Expiry				: 1/01/2027 16:01
Created				: 1/01/2017 16:01
Etag				: AAAAAAFpGcA=
```

Generate a verification code for "mycertificate" using pipeline.

## PARAMETERS

### -CertificateName
Name of the Iot device provisioning service certificate

```yaml
Type: String
Parameter Sets: ResourceSet
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Etag
Etag of the Certificate

```yaml
Type: String
Parameter Sets: ResourceSet, ResourceIdSet
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
IoT Device Provisioning Service Certificate Object

```yaml
Type: PSCertificateResponse
Parameter Sets: InputObjectSet
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the IoT Device Provisioning Service

```yaml
Type: String
Parameter Sets: ResourceSet
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
Type: String
Parameter Sets: ResourceSet
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
IoT Device Provisioning Service Certificate Resource Id

```yaml
Type: String
Parameter Sets: ResourceIdSet
Aliases: 

Required: True
Position: 0
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models.PSCertificateResponse
System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models.PSVerificationCodeResponse

## NOTES

## RELATED LINKS

