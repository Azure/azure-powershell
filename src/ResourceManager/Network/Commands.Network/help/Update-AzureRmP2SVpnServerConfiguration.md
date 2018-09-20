---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# Update-AzureRmP2SVpnServerConfiguration

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByVirtualWanNameDefault (Default)
```
Update-AzureRmP2SVpnServerConfiguration [-VpnProtocol <String[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnServerConfigurationNameDefault
```
Update-AzureRmP2SVpnServerConfiguration -ResourceGroupName <String> -ParentResourceName <String> -Name <String>
 [-VpnProtocol <String[]>] [-VpnClientRootCertificateFilesList <String[]>]
 [-VpnClientRevokedCertificateFilesList <String[]>] [-VpnClientIpsecPolicy <PSIpsecPolicy[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnServerConfigurationNameRadiusServerConfiguration
```
Update-AzureRmP2SVpnServerConfiguration -ResourceGroupName <String> -ParentResourceName <String> -Name <String>
 [-VpnProtocol <String[]>] [-RadiusServerAddress <String>] [-RadiusServerSecret <SecureString>]
 [-RadiusServerRootCertificateFilesList <String[]>] [-RadiusClientRootCertificateFilesList <String[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnServerConfigurationResourceIdDefault
```
Update-AzureRmP2SVpnServerConfiguration -ResourceId <String> [-VpnProtocol <String[]>]
 [-VpnClientRootCertificateFilesList <String[]>] [-VpnClientRevokedCertificateFilesList <String[]>]
 [-VpnClientIpsecPolicy <PSIpsecPolicy[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByP2SVpnServerConfigurationResourceIdRadiusServerConfiguration
```
Update-AzureRmP2SVpnServerConfiguration -ResourceId <String> [-VpnProtocol <String[]>]
 [-RadiusServerAddress <String>] [-RadiusServerSecret <SecureString>]
 [-RadiusServerRootCertificateFilesList <String[]>] [-RadiusClientRootCertificateFilesList <String[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnServerConfigurationObjectDefault
```
Update-AzureRmP2SVpnServerConfiguration -InputObject <PSP2SVpnServerConfiguration> [-VpnProtocol <String[]>]
 [-VpnClientRootCertificateFilesList <String[]>] [-VpnClientRevokedCertificateFilesList <String[]>]
 [-VpnClientIpsecPolicy <PSIpsecPolicy[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DefaultRadiusServerConfiguration
```
Update-AzureRmP2SVpnServerConfiguration -InputObject <PSP2SVpnServerConfiguration> [-VpnProtocol <String[]>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnServerConfigurationObjectRadiusServerConfiguration
```
Update-AzureRmP2SVpnServerConfiguration [-VpnProtocol <String[]>] [-RadiusServerAddress <String>]
 [-RadiusServerSecret <SecureString>] [-RadiusServerRootCertificateFilesList <String[]>]
 [-RadiusClientRootCertificateFilesList <String[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The P2SVpnServerConfiguration object to update.

```yaml
Type: PSP2SVpnServerConfiguration
Parameter Sets: ByP2SVpnServerConfigurationObjectDefault, DefaultRadiusServerConfiguration
Aliases: P2SVpnServerConfiguration

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: ByP2SVpnServerConfigurationNameDefault, ByP2SVpnServerConfigurationNameRadiusServerConfiguration
Aliases: ResourceName, P2SVpnServerConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourceName
The name of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.

```yaml
Type: String
Parameter Sets: ByP2SVpnServerConfigurationNameDefault, ByP2SVpnServerConfigurationNameRadiusServerConfiguration
Aliases: ParentVirtualWanName, VirtualWanName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RadiusClientRootCertificateFilesList
A list of RadiusClientRootCertificate files' paths

```yaml
Type: String[]
Parameter Sets: ByP2SVpnServerConfigurationNameRadiusServerConfiguration, ByP2SVpnServerConfigurationResourceIdRadiusServerConfiguration, ByP2SVpnServerConfigurationObjectRadiusServerConfiguration
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
Type: String
Parameter Sets: ByP2SVpnServerConfigurationNameRadiusServerConfiguration, ByP2SVpnServerConfigurationResourceIdRadiusServerConfiguration, ByP2SVpnServerConfigurationObjectRadiusServerConfiguration
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
Type: String[]
Parameter Sets: ByP2SVpnServerConfigurationNameRadiusServerConfiguration, ByP2SVpnServerConfigurationResourceIdRadiusServerConfiguration, ByP2SVpnServerConfigurationObjectRadiusServerConfiguration
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
Type: SecureString
Parameter Sets: ByP2SVpnServerConfigurationNameRadiusServerConfiguration, ByP2SVpnServerConfigurationResourceIdRadiusServerConfiguration, ByP2SVpnServerConfigurationObjectRadiusServerConfiguration
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
Parameter Sets: ByP2SVpnServerConfigurationNameDefault, ByP2SVpnServerConfigurationNameRadiusServerConfiguration
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the P2SVpnServerConfiguration object to delete.

```yaml
Type: String
Parameter Sets: ByP2SVpnServerConfigurationResourceIdDefault, ByP2SVpnServerConfigurationResourceIdRadiusServerConfiguration
Aliases: P2SVpnServerConfigurationId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VpnClientIpsecPolicy
A list of IPSec policies for P2SVpnServerConfiguration.

```yaml
Type: PSIpsecPolicy[]
Parameter Sets: ByP2SVpnServerConfigurationNameDefault, ByP2SVpnServerConfigurationResourceIdDefault, ByP2SVpnServerConfigurationObjectDefault
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
Type: String[]
Parameter Sets: ByP2SVpnServerConfigurationNameDefault, ByP2SVpnServerConfigurationResourceIdDefault, ByP2SVpnServerConfigurationObjectDefault
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
Type: String[]
Parameter Sets: ByP2SVpnServerConfigurationNameDefault, ByP2SVpnServerConfigurationResourceIdDefault, ByP2SVpnServerConfigurationObjectDefault
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
Type: String[]
Parameter Sets: (All)
Aliases:
Accepted values: IkeV2, OpenVPN

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration
System.String[]
Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy[]


## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration


## NOTES

## RELATED LINKS
