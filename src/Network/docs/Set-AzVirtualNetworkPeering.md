---
external help file: Az.Network-help.xml
Module Name:
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azvirtualnetworkgatewayvpnclientipsecparameter
schema: 2.0.0
---

# Set-AzVirtualNetworkGatewayVpnclientIpsecParameter

## SYNOPSIS
The Set VpnclientIpsecParameters operation sets the vpnclient ipsec policy for P2S client of virtual network gateway in the specified resource group through Network resource provider.

## SYNTAX

### Set (Default)
```
Set-AzVirtualNetworkGatewayVpnclientIpsecParameter -ResourceGroupName <String> -SubscriptionId <String>
 -VirtualNetworkGatewayName <String> [-VpnclientIpsecParam <IVpnClientIPsecParameters>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetExpanded
```
Set-AzVirtualNetworkGatewayVpnclientIpsecParameter -ResourceGroupName <String> -SubscriptionId <String>
 -VirtualNetworkGatewayName <String> -DhGroup <DhGroup> -IkeEncryption <IkeEncryption>
 -IkeIntegrity <IkeIntegrity> -IpsecEncryption <IpsecEncryption> -IpsecIntegrity <IpsecIntegrity>
 -PfsGroup <PfsGroup> -SaDataSizeKilobyte <Int32> -SaLifeTimeSecond <Int32> [-DefaultProfile <PSObject>]
 [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Set-AzVirtualNetworkGatewayVpnclientIpsecParameter -InputObject <INetworkIdentity> -DhGroup <DhGroup>
 -IkeEncryption <IkeEncryption> -IkeIntegrity <IkeIntegrity> -IpsecEncryption <IpsecEncryption>
 -IpsecIntegrity <IpsecIntegrity> -PfsGroup <PfsGroup> -SaDataSizeKilobyte <Int32> -SaLifeTimeSecond <Int32>
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetViaIdentity
```
Set-AzVirtualNetworkGatewayVpnclientIpsecParameter -InputObject <INetworkIdentity>
 [-VpnclientIpsecParam <IVpnClientIPsecParameters>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Set VpnclientIpsecParameters operation sets the vpnclient ipsec policy for P2S client of virtual network gateway in the specified resource group through Network resource provider.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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
```

### -DhGroup
The DH Group used in IKE Phase 1 for initial SA.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DhGroup
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IkeEncryption
The IKE encryption algorithm (IKE phase 2).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeEncryption
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IkeIntegrity
The IKE integrity algorithm (IKE phase 2).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrity
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: SetViaIdentityExpanded, SetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IpsecEncryption
The IPSec encryption algorithm (IKE phase 1).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryption
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpsecIntegrity
The IPSec integrity algorithm (IKE phase 1).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecIntegrity
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PfsGroup
The Pfs Group used in IKE Phase 2 for new child SA.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroup
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Set, SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SaDataSizeKilobyte
The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for P2S client..

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SaLifeTimeSecond
The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for P2S client.

```yaml
Type: System.Int32
Parameter Sets: SetExpanded, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Set, SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkGatewayName
The name of the virtual network gateway.

```yaml
Type: System.String
Parameter Sets: Set, SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnclientIpsecParam
An IPSec parameters for a virtual network gateway P2S connection.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientIPsecParameters
Parameter Sets: Set, SetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientIPsecParameters
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/set-azvirtualnetworkgatewayvpnclientipsecparameter](https://docs.microsoft.com/en-us/powershell/module/az.network/set-azvirtualnetworkgatewayvpnclientipsecparameter)

