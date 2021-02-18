---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvpnclientipsecpolicy
=======
online version: https://docs.microsoft.com/powershell/module/az.network/new-azvpnclientipsecpolicy
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# New-AzVpnClientIpsecPolicy

## SYNOPSIS
<<<<<<< HEAD
This command allows the users to create the Vpn ipsec policy object specifying one or all values such as IpsecEncryption,IpsecIntegrity,IkeEncryption,IkeIntegrity,DhGroup,PfsGroup to set on the VPN gateway. This command let output object is used to set vpn ipsec policy for both new / exisitng gateway.
=======
This command allows the users to create the Vpn ipsec policy object specifying one or all values such as IpsecEncryption,IpsecIntegrity,IkeEncryption,IkeIntegrity,DhGroup,PfsGroup to set on the VPN gateway. This command let output object is used to set vpn ipsec policy for both new / existing gateway.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## SYNTAX

```
New-AzVpnClientIpsecPolicy [-SALifeTime <Int32>] [-SADataSize <Int32>] [-IpsecEncryption <String>]
 [-IpsecIntegrity <String>] [-IkeEncryption <String>] [-IkeIntegrity <String>] [-DhGroup <String>]
 [-PfsGroup <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
<<<<<<< HEAD
This command allows the users to create the Vpn ipsec policy object specifying one or all values such as IpsecEncryption,IpsecIntegrity,IkeEncryption,IkeIntegrity,DhGroup,PfsGroup to set on the VPN gateway. This command let output object is used to set vpn ipsec policy for both new / exisitng gateway.

## EXAMPLES

### Define vpn ipsec policy object:
```
=======
This command allows the users to create the Vpn ipsec policy object specifying one or all values such as IpsecEncryption,IpsecIntegrity,IkeEncryption,IkeIntegrity,DhGroup,PfsGroup to set on the VPN gateway. This command let output object is used to set vpn ipsec policy for both new / existing gateway.

## EXAMPLES

### Example 1: Define vpn ipsec policy object:
```powershell
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
PS C:\>$vpnclientipsecpolicy = New-AzVpnClientIpsecPolicy -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTime 86472 -SADataSize 429497 -IkeEncryption AES256 -IkeIntegrity SHA256 -DhGroup DHGroup2 -PfsGroup None
```

This cmdlet is used to create the vpn ipsec policy object using the passed one or all parameters' values which user can pass to param:VpnClientIpsecPolicy of PS command let: New-AzVirtualNetworkGateway (New VPN Gateway creation) / Set-AzVirtualNetworkGateway (existing VPN Gateway update) in ResourceGroup :

<<<<<<< HEAD
### Create new virtual network gateway with setting vpn custom ipsec policy:
```
=======
### Example 2: Create new virtual network gateway with setting vpn custom ipsec policy:
```powershell
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
PS C:\> $vnetGateway = New-AzVirtualNetworkGateway -ResourceGroupName vnet-gateway -name myNGW -location $location -IpConfigurations $vnetIpConfig -GatewayType Vpn -VpnType RouteBased -GatewaySku VpnGw1 -VpnClientIpsecPolicy $vpnclientipsecpolicy
```

This cmdlet returns virtual network gateway object after creation. 

<<<<<<< HEAD
### Set vpn custom ipsec policy on existing virtual network gateway:
```
=======
### Example 3: Set vpn custom ipsec policy on existing virtual network gateway:
```powershell
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
PS C:\> $vnetGateway = Set-AzVirtualNetworkGateway -VirtualNetworkGateway $gateway -VpnClientIpsecPolicy $vpnclientipsecpolicy
```

This cmdlet returns virtual network gateway object after setting vpn custom ipsec policy.

<<<<<<< HEAD
### Get virtual network gateway to see if vpn custom policy is set correctly:
```
=======
### Example 4: Get virtual network gateway to see if vpn custom policy is set correctly:
```powershell
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
PS C:\> $gateway = Get-AzVirtualNetworkGateway -ResourceGroupName vnet-gateway -name myNGW
```

This cmdlet returns virtual network gateway object.

## PARAMETERS

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

### -DhGroup
<<<<<<< HEAD
The Vpnclient DH Groups used in IKE Phase 1 for initial SA
=======
The VpnClient DH Groups used in IKE Phase 1 for initial SA
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: DHGroup24, ECP384, ECP256, DHGroup14, DHGroup2

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IkeEncryption
<<<<<<< HEAD
The Vpnclient IKE encryption algorithm (IKE Phase 2)
=======
The VpnClient IKE encryption algorithm (IKE Phase 2)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: GCMAES256, GCMAES128, AES256, AES128

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IkeIntegrity
<<<<<<< HEAD
The Vpnclient IKE integrity algorithm (IKE Phase 2)
=======
The VpnClient IKE integrity algorithm (IKE Phase 2)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: SHA384, SHA256

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpsecEncryption
<<<<<<< HEAD
The Vpnclient IPSec encryption algorithm (IKE Phase 1)
=======
The VpnClient IPSec encryption algorithm (IKE Phase 1)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: GCMAES256, GCMAES128, AES256, AES128

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpsecIntegrity
<<<<<<< HEAD
The Vpnclient IPSec integrity algorithm (IKE Phase 1)
=======
The VpnClient IPSec integrity algorithm (IKE Phase 1)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: GCMAES256, GCMAES128, SHA256

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PfsGroup
<<<<<<< HEAD
The Vpnclient PFS Groups used in IKE Phase 2 for new child SA
=======
The VpnClient PFS Groups used in IKE Phase 2 for new child SA
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: PFS24, PFSMM, ECP384, ECP256, PFS14, PFS2, None

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SADataSize
<<<<<<< HEAD
The Vpnclient IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB
=======
The VpnClient IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SALifeTime
<<<<<<< HEAD
The Vpnclient IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds
=======
The VpnClient IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy

## NOTES

## RELATED LINKS
