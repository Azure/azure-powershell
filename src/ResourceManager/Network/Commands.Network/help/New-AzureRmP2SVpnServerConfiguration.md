---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/new-azurermp2svpnserverconfiguration
schema: 2.0.0
---

# New-AzureRmP2SVpnServerConfiguration

## SYNOPSIS
Creates a P2SVpnServerConfiguration and associates it with an existing VirtualWan.

## SYNTAX

### ByVirtualWanNameDefault (Default)
```
New-AzureRmP2SVpnServerConfiguration -ResourceGroupName <String> -ParentResourceName <String> -Name <String>
 [-VpnProtocol <String[]>] [-VpnClientRootCertificateFilesList <String[]>]
 [-VpnClientRevokedCertificateFilesList <String[]>] [-VpnClientIpsecPolicy <PSIpsecPolicy[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualWanNameRadiusServerConfiguration
```
New-AzureRmP2SVpnServerConfiguration -ResourceGroupName <String> -ParentResourceName <String> -Name <String>
 [-VpnProtocol <String[]>] [-RadiusServerAddress <String>] [-RadiusServerSecret <SecureString>]
 [-RadiusServerRootCertificateFilesList <String[]>] [-RadiusClientRootCertificateFilesList <String[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualWanObjectDefault
```
New-AzureRmP2SVpnServerConfiguration -ParentObject <PSVirtualWan> -Name <String> [-VpnProtocol <String[]>]
 [-VpnClientRootCertificateFilesList <String[]>] [-VpnClientRevokedCertificateFilesList <String[]>]
 [-VpnClientIpsecPolicy <PSIpsecPolicy[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByVirtualWanObjectRadiusServerConfiguration
```
New-AzureRmP2SVpnServerConfiguration -ParentObject <PSVirtualWan> -Name <String> [-VpnProtocol <String[]>]
 [-RadiusServerAddress <String>] [-RadiusServerSecret <SecureString>]
 [-RadiusServerRootCertificateFilesList <String[]>] [-RadiusClientRootCertificateFilesList <String[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualWanResourceIdDefault
```
New-AzureRmP2SVpnServerConfiguration -ParentResourceId <String> -Name <String> [-VpnProtocol <String[]>]
 [-VpnClientRootCertificateFilesList <String[]>] [-VpnClientRevokedCertificateFilesList <String[]>]
 [-VpnClientIpsecPolicy <PSIpsecPolicy[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByVirtualWanResourceIdRadiusServerConfiguration
```
New-AzureRmP2SVpnServerConfiguration -ParentResourceId <String> -Name <String> [-VpnProtocol <String[]>]
 [-RadiusServerAddress <String>] [-RadiusServerSecret <SecureString>]
 [-RadiusServerRootCertificateFilesList <String[]>] [-RadiusClientRootCertificateFilesList <String[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a P2SVpnServerConfiguration and associates it with an existing VirtualWan.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmResourceGroup -Location "West US" -Name "testRG" 
PS C:\> New-AzureRmVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US" -AllowBranchToBranchTraffic $true -Office365LocalBreakoutCategory "Optimize"
PS C:\> $p2sVpnServerConfigCertFilePath = "PathToCertFile.cer"
PS C:\> $listOfCerts = New-Object "System.Collections.Generic.List[String]"
PS C:\> $listOfCerts.Add($p2sVpnServerConfigCertFilePath)
PS C:\> $Secure_String_Pwd = ConvertTo-SecureString "TestRadiusServerPassword" -AsPlainText -Force
PS C:\> New-AzureRmP2SVpnServerConfiguration -Name "P2SVpnServerConfiguration2Name" -ResourceGroupName "testRG" -ParentResourceName "myVirtualWAN" -VpnProtocol IkeV2 -RadiusServerAddress "TestRadiusServer" -RadiusServerSecret $Secure_String_Pwd -RadiusServerRootCertificateFilesList $listOfCerts -RadiusClientRootCertificateFilesList $listOfCerts
Name                           VpnProtocols Provisioning State
----                           ------------ ------------------
P2SVpnServerConfiguration2Name {IkeV2}      Succeeded         
```

The above will create a resource group "testRG" in region "West US" and an Azure Virtual WAN in that resource group in Azure. 
New-AzureRmP2SVpnServerConfiguration will create P2SVpnServerConfiguration "P2SVpnServerConfiguration2Name" and associates it with an existing Virtual WAN.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -ParentObject
The VirtualWan this P2SVpnServerConfiguration needs to be associated with.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualWan
Parameter Sets: ByVirtualWanObjectDefault, ByVirtualWanObjectRadiusServerConfiguration
Aliases: ParentVirtualWan, VirtualWan

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParentResourceId
The Id of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.

```yaml
Type: System.String
Parameter Sets: ByVirtualWanResourceIdDefault, ByVirtualWanResourceIdRadiusServerConfiguration
Aliases: ParentVirtualWanId, VirtualWanId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ParentResourceName
The name of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.

```yaml
Type: System.String
Parameter Sets: ByVirtualWanNameDefault, ByVirtualWanNameRadiusServerConfiguration
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
Type: System.String[]
Parameter Sets: ByVirtualWanNameRadiusServerConfiguration, ByVirtualWanObjectRadiusServerConfiguration, ByVirtualWanResourceIdRadiusServerConfiguration
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RadiusServerAddress
P2S External Radius server address.

```yaml
Type: System.String
Parameter Sets: ByVirtualWanNameRadiusServerConfiguration, ByVirtualWanObjectRadiusServerConfiguration, ByVirtualWanResourceIdRadiusServerConfiguration
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
Parameter Sets: ByVirtualWanNameRadiusServerConfiguration, ByVirtualWanObjectRadiusServerConfiguration, ByVirtualWanResourceIdRadiusServerConfiguration
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RadiusServerSecret
P2S External Radius server secret.

```yaml
Type: System.Security.SecureString
Parameter Sets: ByVirtualWanNameRadiusServerConfiguration, ByVirtualWanObjectRadiusServerConfiguration, ByVirtualWanResourceIdRadiusServerConfiguration
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
Type: System.String
Parameter Sets: ByVirtualWanNameDefault, ByVirtualWanNameRadiusServerConfiguration
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnClientIpsecPolicy
A list of IPSec policies for P2SVpnServerConfiguration.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy[]
Parameter Sets: ByVirtualWanNameDefault, ByVirtualWanObjectDefault, ByVirtualWanResourceIdDefault
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VpnClientRevokedCertificateFilesList
A list of VpnClientCertificates to be revoked files' paths

```yaml
Type: System.String[]
Parameter Sets: ByVirtualWanNameDefault, ByVirtualWanObjectDefault, ByVirtualWanResourceIdDefault
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnClientRootCertificateFilesList
A list of VpnClientRootCertificates to be added files' paths

```yaml
Type: System.String[]
Parameter Sets: ByVirtualWanNameDefault, ByVirtualWanObjectDefault, ByVirtualWanResourceIdDefault
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### System.String
System.String[]
Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy[]
System.Security.SecureString

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration

## NOTES

## RELATED LINKS
