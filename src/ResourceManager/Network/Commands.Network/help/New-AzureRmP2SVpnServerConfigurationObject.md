---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/new-azurermp2svpnserverconfigurationobject
schema: 2.0.0
---

# New-AzureRmP2SVpnServerConfigurationObject

## SYNOPSIS
Creates a P2SVpnServerConfiguration in-memory object to associate with a VirtualWan in New/Update-AzureRmVirtualWan command let.

## SYNTAX

### Default (Default)
```
New-AzureRmP2SVpnServerConfigurationObject -Name <String> [-VpnProtocol <String[]>]
 [-VpnClientRootCertificateFilesList <String[]>] [-VpnClientRevokedCertificateFilesList <String[]>]
 [-VpnClientIpsecPolicy <PSIpsecPolicy[]>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### RadiusServerConfiguration
```
New-AzureRmP2SVpnServerConfigurationObject -Name <String> [-VpnProtocol <String[]>]
 [-RadiusServerAddress <String>] [-RadiusServerSecret <SecureString>]
 [-RadiusServerRootCertificateFilesList <String[]>] [-RadiusClientRootCertificateFilesList <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a P2SVpnServerConfiguration in-memory object to associate with a VirtualWan in New/Update-AzureRmVirtualWan command let.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmResourceGroup -Location "West US" -Name "testRG" 
PS C:\> $p2sVpnServerConfigCertFilePath = "PathToCertFile.cer"
PS C:\> $listOfCerts = New-Object "System.Collections.Generic.List[String]"
PS C:\> $listOfCerts.Add($p2sVpnServerConfigCertFilePath)
PS C:\> $vpnclientipsecpolicy1 = New-AzureRmVpnClientIpsecPolicy -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTime 86471 -SADataSize 429496 -IkeEncryption AES256 -IkeIntegrity SHA384 -DhGroup DHGroup14 -PfsGroup PFS14
PS C:\> New-AzureRmP2SVpnServerConfigurationObject -Name "p2sVpnServerConfiguration1Name" -VpnProtocol IkeV2 -VpnClientRootCertificateFilesList $listOfCerts -VpnClientRevokedCertificateFilesList $listOfCerts -VpnClientIpsecPolicy $vpnclientipsecpolicy1

Name                           VpnProtocols Provisioning State
----                           ------------ ------------------
p2sVpnServerConfiguration1Name {IkeV2}
```

The above will create a resource group "testRG" in region "West US" and an Azure Virtual WAN in that resource group in Azure. 
New-AzureRmP2SVpnServerConfigurationObject will create in-memory P2SVpnServerConfiguration object to be used in command lets: New/Update-AzureRmVirtualWan to create & associate the P2SVpnServerConfiguration "P2SVpnServerConfiguration2Name" to Virtual WAN.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, P2SVpnServerConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RadiusClientRootCertificateFilesList
A list of RadiusClientRootCertificate files' paths

```yaml
Type: System.String[]
Parameter Sets: RadiusServerConfiguration
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RadiusServerAddress
P2S External Radius server address.

```yaml
Type: System.String
Parameter Sets: RadiusServerConfiguration
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RadiusServerRootCertificateFilesList
A list of RadiusClientRootCertificate files' paths

```yaml
Type: System.String[]
Parameter Sets: RadiusServerConfiguration
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RadiusServerSecret
P2S External Radius server secret.

```yaml
Type: System.Security.SecureString
Parameter Sets: RadiusServerConfiguration
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnClientIpsecPolicy
A list of IPSec policies for P2SVpnServerConfiguration.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy[]
Parameter Sets: Default
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VpnClientRevokedCertificateFilesList
A list of VpnClientCertificates to be revoked files' paths

```yaml
Type: System.String[]
Parameter Sets: Default
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VpnClientRootCertificateFilesList
A list of VpnClientRootCertificates to be added files' paths

```yaml
Type: System.String[]
Parameter Sets: Default
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VpnProtocol
The list of P2S VPN client tunneling protocols

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:
Accepted values: IkeV2, OpenVPN

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.String[]
Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy[]
System.Security.SecureString

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration

## NOTES

## RELATED LINKS
