---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmVpnClientConfiguration

## SYNOPSIS
This cmdlet is used to create a VPN client configuration installer package. The package is installed on a Windows client machine to create a VPN client profile to connect to Azure. The cmdlet provides a URL link to a zip file that contains 64-bit and 32-bit installers.

## SYNTAX

```
New-AzureRmVpnClientConfiguration -ResourceGroupName <String> -VirtualNetworkGatewayName <String>
 [-ProcessorArchitecture <String>] -AuthenticationMethod <String> [-RadiusRootCert <String>]
 [-ClientRootCertificates <String>]
```

## DESCRIPTION
This cmdlet is used to create a VPN client configuration installer package. The package is installed on a Windows client machine to create a VPN client profile to connect to Azure. The cmdlet provides a URL link to a zip file that contains 64-bit and 32-bit installers.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmVpnClientConfiguration -VirtualNetworkGatewayName "ContosoVirtualNetworkGateway" -ResourceGroupName "ContosoResourceGroup" -AuthenticationMethod "EAPTLS" -RadiusRootCert "C:\Users\Test\Desktop\VpnProfileRadiusCert.cer"
```

This cmdlet is used to create a VPN client profile zip file for "ContosoVirtualNetworkGateway" in ResourceGroup "ContosoResourceGroup". The profile is generated for a pre-configured radius server that is configured to use "EAPTLS" authentication method with the VpnProfileRadiusCert certificate file.

## PARAMETERS

### -AuthenticationMethod
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

### -ClientRootCertificates
This is a collection of the full path names of .cer files containing the client root certificate. It is used for EAP-TLS with RaDIUS authentication. Sometimes a Windows device has multiple client certificates. During authentication this results in a popup dialog listing all these certificates and the user has to choose a certificate that he wants to use. The right certificate can be filtered out by specifying the root certificate to which the client cert should chain. The ClientRootCert param is the .cer file containing this root cert. It's an optional parameter. If the device that you wish to connect from has only one client certificate then this parameter does not have to be specified.

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

### -ProcessorArchitecture
Processor Architecture to be used for generation of the VpnProfile

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

### -RadiusRootCert
This is a mandatory parameter that has to be specified when EAP-TLS with RADIUS authentication is used. This is the full path name of .cer file containing the RADIUS root certificate that the client uses to validates the RADIUS server during authentication.

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
Name of the resource group in which the Virtual Network Gateway that you want to connect to resides.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualNetworkGatewayName
Name of the Virtual Network Gateway that you want to connect to resides.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.String


## NOTES

## RELATED LINKS

