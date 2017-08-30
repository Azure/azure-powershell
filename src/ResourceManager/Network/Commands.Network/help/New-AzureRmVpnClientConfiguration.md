---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: 
schema: 2.0.0
---

# New-AzureRmVpnClientConfiguration

## SYNOPSIS
This command allows the users to create the Vpn profile package based on pre-configured vpn settings on the VPN gateway, in addition to some additional settings that users may need to configure, for e.g. some root certificates.

## SYNTAX

```
New-AzureRmVpnClientConfiguration [-Name <String>] -ResourceGroupName <String>
 [-ProcessorArchitecture <String>] -AuthenticationMethod <String> [-RadiusRootCertificateFile <String>]
 [-ClientRootCertificateFile <System.Collections.Generic.List`1[System.String]>]
```

## DESCRIPTION
this allows the users to create the Vpn profile package based on pre-configured vpn settings on the VPN gateway, in addition to some additional settings that users may need to configure, for e.g. some root certificates.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmVpnClientConfiguration -VirtualNetworkGatewayName "ContosoVirtualNetworkGateway" -ResourceGroupName "ContosoResourceGroup" -AuthenticationMethod "EAPTLS" -RadiusRootCert "C:\Users\Test\Desktop\VpnProfileRadiusCert.cer"
```

This cmdlet is used to create a VPN client profile zip file for "ContosoVirtualNetworkGateway" in ResourceGroup "ContosoResourceGroup". The profile is generated for a pre-configured radius server that is configured to use "EAPTLS" authentication method with the VpnProfileRadiusCert certificate file.

## PARAMETERS

### -AuthenticationMethod
Authentication Method
Can take values EAPMSCHAPv2 or EAPTLS. When EAPMSCHAPv2 is specified then the cmdlet generates a client configuration installer for username/password authentication that uses EAP-MSCHAPv2 authentication protocol. If EAPTLS is specified then the cmdlet generates a client configuration installer for certificate authentication that uses EAP-TLS protocol. The “EapTls” option can be used for both RADIUS-based certificate authentication and certification authentication performed by the Virtual Network Gateway by uploading the trusted root. The cmdlet automatically detects what is configured.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: EAPTLS, EAPMSCHAPv2

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ClientRootCertificateFile
This is a collection of the full path names of .cer files containing the client root certificate. It is used for EAP-TLS with RaDIUS authentication. Sometimes a Windows device has multiple client certificates. During authentication this results in a popup dialog listing all these certificates and the user has to choose a certificate that he wants to use. The right certificate can be filtered out by specifying the root certificate to which the client cert should chain. The ClientRootCert param is the .cer file containing this root cert. It's an optional parameter. If the device that you wish to connect from has only one client certificate then this parameter does not have to be specified.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProcessorArchitecture
ProcessorArchitecture

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: Amd64, X86

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RadiusRootCertificateFile
Radius server root certificate path. This is a mandatory parameter that has to be specified when EAP-TLS with RADIUS authentication is used. This is the full path name of .cer file containing the RADIUS root certificate that the client uses to validates the RADIUS server during authentication.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
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
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String
System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]


## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVpnProfile


## NOTES

## RELATED LINKS

