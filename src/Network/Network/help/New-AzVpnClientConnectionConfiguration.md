---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azvpnclientconfiguration
schema: 2.0.0
---

# New-AzVpnClientConnectionConfiguration

## SYNOPSIS
Create Virtual Network Gateway Connection configuration

## SYNTAX

```
New-AzVpnClientConnectionConfiguration -Name <String>
 -VirtualNetworkGatewayPolicyGroup <PSVirtualNetworkGatewayPolicyGroup[]> -VpnClientAddressPool <String[]>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Conneciton Configuration associate between the address space of the P2S client and the according virtual network gateway policy groups 

## EXAMPLES

### Example 1
```powershell
$member1=New-AzVirtualNetworkGatewayPolicyGroupMember -Name "member1" -AttributeType "CertificateGroupId" -AttributeValue "ab"
$member2=New-AzVirtualNetworkGatewayPolicyGroupMember -Name "member2" -AttributeType "CertificateGroupId" -AttributeValue "cd"
$policyGroup1=New-AzVirtualNetworkGatewayPolicyGroup -Name "policyGroup1" -Priority 0 -DefaultPolicyGroup  -PolicyMember $member1
$policyGroup2=New-AzVirtualNetworkGatewayPolicyGroup -Name "policyGroup2" -Priority 10 -PolicyMember $member2
$vngconnectionConfig=New-AzVpnClientConnectionConfiguration -Name "coonfig1" -VirtualNetworkGatewayPolicyGroup $policyGroup1 -VpnClientAddressPool "192.168.10.0/24" 
$vngconnectionConfig2=New-AzVpnClientConnectionConfiguration -Name "coonfig2" -VirtualNetworkGatewayPolicyGroup $policyGroup2 -VpnClientAddressPool "192.168.20.0/24" 
```

Create Client Connection configuration

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Virtual Network Gateway Policy Group Member

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkGatewayPolicyGroup
Virtual Network Gateway Policy Groups

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGatewayPolicyGroup[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VpnClientAddressPool
The Associatted client address pool

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGatewayPolicyGroup[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVpnClientRootCertificate

## NOTES

## RELATED LINKS
