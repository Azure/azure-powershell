---
external help file: Microsoft.Azure.Commands.IotHub.dll-Help.xml
Module Name: AzureRM.IotHub
online version: 
schema: 2.0.0
---

# Get-AzureRmIotHubCertificate

## SYNOPSIS
Lists all certificates or a particular certificate contained within an Azure IoT Hub. 

## SYNTAX

```
Get-AzureRmIotHubCertificate [-ResourceGroupName] <String> [-Name] <String> [[-CertificateName] <String>]
 [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
For a detailed explanation of CA certificates in Azure IoT Hub, see https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-x509ca-overview

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmIotHubCertificate -ResourceGroupName "myresourcegroup" -Name "myiothub"
```

List all certificates in MyIotHub

### Example 2
```
PS C:\> Get-AzureRmIotHubCertificate -ResourceGroupName "myresourcegroup" -Name "myiothub" -CertificateName "mycertificate"
```

Show details about MyCertificate

## PARAMETERS

### -CertificateName
Name of the Certificate

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -Name
Name of the Iot Hub

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
Name of the Resource Group

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

### Microsoft.Azure.Commands.Management.IotHub.Models.PSCertificateDescription
System.Collections.Generic.IList`1[[Microsoft.Azure.Commands.Management.IotHub.Models.PSCertificateDescription, Microsoft.Azure.Commands.IotHub, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS

