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

### UpdateExpanded (Default)
```
Set-AzP2SVpnServerConfiguration -Name <String> -ResourceGroupName <String> -VirtualWanName <String>
 [-SubscriptionId <String>] [-Etag <String>] [-Id <String>]
 [-RadiusClientRootCertificate <IP2SVpnServerConfigRadiusClientRootCertificate[]>]
 [-RadiusServerAddress <String>]
 [-RadiusServerRootCertificate <IP2SVpnServerConfigRadiusServerRootCertificate[]>]
 [-RadiusServerSecret <String>] [-ResourceName <String>] [-ResourceName2 <String>]
 [-VpnClientIPsecPolicy <IIpsecPolicy[]>]
 [-VpnClientRevokedCertificate <IP2SVpnServerConfigVpnClientRevokedCertificate[]>]
 [-VpnClientRootCertificate <IP2SVpnServerConfigVpnClientRootCertificate[]>]
 [-VpnProtocol <VpnGatewayTunnelingProtocol[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzP2SVpnServerConfiguration -Name <String> -ResourceGroupName <String> -VirtualWanName <String>
 -P2SVpnServerConfiguration <IP2SVpnServerConfiguration> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Default value: None
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

### -Etag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the P2SVpnServerConfiguration.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: P2SVpnServerConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -P2SVpnServerConfiguration
P2SVpnServerConfiguration Resource.
To construct, see NOTES section for P2SVPNSERVERCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -RadiusClientRootCertificate
Radius client root certificate of P2SVpnServerConfiguration.
To construct, see NOTES section for RADIUSCLIENTROOTCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusClientRootCertificate[]
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RadiusServerRootCertificate
Radius Server root certificate of P2SVpnServerConfiguration.
To construct, see NOTES section for RADIUSSERVERROOTCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificate[]
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName
The name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName2
The name of the P2SVpnServerConfiguration that is unique within a VirtualWan in a resource group.
This name can be used to access the resource along with Paren VirtualWan resource name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualWanName
The name of the VirtualWan.

```yaml
Type: System.String
Parameter Sets: (All)
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
To construct, see NOTES section for VPNCLIENTIPSECPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VpnClientRevokedCertificate
VPN client revoked certificate of P2SVpnServerConfiguration.
To construct, see NOTES section for VPNCLIENTREVOKEDCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRevokedCertificate[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VpnClientRootCertificate
VPN client root certificate of P2SVpnServerConfiguration.
To construct, see NOTES section for VPNCLIENTROOTCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRootCertificate[]
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### P2SVPNSERVERCONFIGURATION <IP2SVpnServerConfiguration>: P2SVpnServerConfiguration Resource.
  - `[Id <String>]`: Resource ID.

#### RADIUSCLIENTROOTCERTIFICATE <IP2SVpnServerConfigRadiusClientRootCertificate[]>: Radius client root certificate of P2SVpnServerConfiguration.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Thumbprint <String>]`: The Radius client root certificate thumbprint.

#### RADIUSSERVERROOTCERTIFICATE <IP2SVpnServerConfigRadiusServerRootCertificate[]>: Radius Server root certificate of P2SVpnServerConfiguration.
  - `PublicCertData <String>`: The certificate public data.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.

#### VPNCLIENTIPSECPOLICY <IIpsecPolicy[]>: VpnClientIpsecPolicies for P2SVpnServerConfiguration.
  - `DhGroup <DhGroup>`: The DH Group used in IKE Phase 1 for initial SA.
  - `IkeEncryption <IkeEncryption>`: The IKE encryption algorithm (IKE phase 2).
  - `IkeIntegrity <IkeIntegrity>`: The IKE integrity algorithm (IKE phase 2).
  - `IpsecEncryption <IpsecEncryption>`: The IPSec encryption algorithm (IKE phase 1).
  - `IpsecIntegrity <IpsecIntegrity>`: The IPSec integrity algorithm (IKE phase 1).
  - `PfsGroup <PfsGroup>`: The Pfs Group used in IKE Phase 2 for new child SA.
  - `SaDataSizeKilobyte <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
  - `SaLifeTimeSecond <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.

#### VPNCLIENTREVOKEDCERTIFICATE <IP2SVpnServerConfigVpnClientRevokedCertificate[]>: VPN client revoked certificate of P2SVpnServerConfiguration.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Thumbprint <String>]`: The revoked VPN client certificate thumbprint.

#### VPNCLIENTROOTCERTIFICATE <IP2SVpnServerConfigVpnClientRootCertificate[]>: VPN client root certificate of P2SVpnServerConfiguration.
  - `PublicCertData <String>`: The certificate public data.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.

## RELATED LINKS

