---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azp2svpnserverconfiguration
schema: 2.0.0
---

# Set-AzP2SVpnServerConfiguration

## SYNOPSIS
Creates a P2SVpnServerConfiguration to associate with a VirtualWan if it doesn't exist else updates the existing P2SVpnServerConfiguration.

## SYNTAX

### Update (Default)
```
Set-AzP2SVpnServerConfiguration -ResourceGroupName <String> -SubscriptionId <String> -VirtualWanName <String>
 [-Name <String>] [-P2SVpnServerConfigurationParameters <IP2SVpnServerConfiguration>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzP2SVpnServerConfiguration -InputObject <INetworkIdentity> [-Name <String>] [-Id <String>]
 [-P2SVpnServerConfigRadiusClientRootCertificates <IP2SVpnServerConfigRadiusClientRootCertificate[]>]
 [-P2SVpnServerConfigRadiusServerRootCertificates <IP2SVpnServerConfigRadiusServerRootCertificate[]>]
 [-P2SVpnServerConfigVpnClientRevokedCertificates <IP2SVpnServerConfigVpnClientRevokedCertificate[]>]
 [-P2SVpnServerConfigVpnClientRootCertificates <IP2SVpnServerConfigVpnClientRootCertificate[]>]
 [-PropertiesEtag <String>] [-PropertiesName <String>] [-RadiusServerAddress <String>]
 [-RadiusServerSecret <String>] [-VpnClientIPsecPolicy <IIpsecPolicy[]>]
 [-VpnProtocol <VpnGatewayTunnelingProtocol[]>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzP2SVpnServerConfiguration -ResourceGroupName <String> -SubscriptionId <String> -VirtualWanName <String>
 -P2SVpnServerConfigurationName <String> [-Name <String>] [-Id <String>]
 [-P2SVpnServerConfigRadiusClientRootCertificates <IP2SVpnServerConfigRadiusClientRootCertificate[]>]
 [-P2SVpnServerConfigRadiusServerRootCertificates <IP2SVpnServerConfigRadiusServerRootCertificate[]>]
 [-P2SVpnServerConfigVpnClientRevokedCertificates <IP2SVpnServerConfigVpnClientRevokedCertificate[]>]
 [-P2SVpnServerConfigVpnClientRootCertificates <IP2SVpnServerConfigVpnClientRootCertificate[]>]
 [-PropertiesEtag <String>] [-PropertiesName <String>] [-RadiusServerAddress <String>]
 [-RadiusServerSecret <String>] [-VpnClientIPsecPolicy <IIpsecPolicy[]>]
 [-VpnProtocol <VpnGatewayTunnelingProtocol[]>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzP2SVpnServerConfiguration -InputObject <INetworkIdentity>
 [-P2SVpnServerConfigurationParameters <IP2SVpnServerConfiguration>] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a P2SVpnServerConfiguration to associate with a VirtualWan if it doesn't exist else updates the existing P2SVpnServerConfiguration.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: Update, UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -P2SVpnServerConfigRadiusClientRootCertificates
Radius client root certificate of P2SVpnServerConfiguration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusClientRootCertificate[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -P2SVpnServerConfigRadiusServerRootCertificates
Radius Server root certificate of P2SVpnServerConfiguration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificate[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -P2SVpnServerConfigurationName
The name of the P2SVpnServerConfiguration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -P2SVpnServerConfigurationParameters
P2SVpnServerConfiguration Resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -P2SVpnServerConfigVpnClientRevokedCertificates
VPN client revoked certificate of P2SVpnServerConfiguration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRevokedCertificate[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -P2SVpnServerConfigVpnClientRootCertificates
VPN client root certificate of P2SVpnServerConfiguration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRootCertificate[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesEtag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesName
The name of the P2SVpnServerConfiguration that is unique within a VirtualWan in a resource group.
This name can be used to access the resource along with Paren VirtualWan resource name.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RadiusServerAddress
The radius server address property of the P2SVpnServerConfiguration resource for point to site client connection.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RadiusServerSecret
The radius secret property of the P2SVpnServerConfiguration resource for point to site client connection.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The resource group name of the VirtualWan.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualWanName
The name of the VirtualWan.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VpnClientIPsecPolicy
VpnClientIpsecPolicies for P2SVpnServerConfiguration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VpnProtocol
VPN protocols for the P2SVpnServerConfiguration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration

## ALIASES

## RELATED LINKS

