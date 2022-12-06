---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-azvpnsitelinkconnectionikesa
schema: 2.0.0
---

# Get-AzVpnSiteLinkConnectionIkeSa

## SYNOPSIS
Get IKE Security Associations of VPN Site Link Connections

## SYNTAX

### ByName (Default)
```
Get-AzVpnSiteLinkConnectionIkeSa -ResourceGroupName <String> -VpnGatewayName <String>
 -VpnConnectionName <String> -Name <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByInputObject
```
Get-AzVpnSiteLinkConnectionIkeSa -InputObject <PSVpnSiteLinkConnection> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzVpnSiteLinkConnectionIkeSa -ResourceId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzVpnSiteLinkConnectionIkeSa** cmdlet returns the IKE Security Associations of your VPN Link Connection based on the VPN Site Link Connection Name, VPN Connection Name, VPN Gateway Name and Resource Group Name.
If the **Get-AzVpnSiteLinkConnectionIkeSa** cmdlet is issued without specifying any of the aforementioned parameters, the output will not show the IKE Security Associations.

## EXAMPLES

### Example 1
```powershell
Get-AzVpnSiteLinkConnectionIkeSa -ResourceGroupName test-rg -VpnGatewayName test-gateway -VpnConnectionName test-connection -ResourceName test-linkConnection
```

```output
LocalEndpoint              : 52.148.27.69
RemoteEndpoint             : 13.78.223.113
InitiatorCookie            : 10994953846917485010
ResponderCookie            : 4652217515638795111
LocalUdpEncapsulationPort  : 0
RemoteUdpEncapsulationPort : 0
Encryption                 : AES256
Integrity                  : SHA1
DhGroup                    : DHGroup2
LifeTimeSeconds            : 28800
IsSaInitiator              : True
ElapsedTimeInseconds       : 21437
Quick Mode SA              : 1 item(s)
```

Returns the IKE Security Associations for the VPN Site Link Connection with the name "test-linkConnection" within the resource group "test-rg"

## PARAMETERS

### -AsJob
Run cmdlet in the background.

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
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The Vpn site link connection object.

```yaml
Type: PSVpnSiteLinkConnection
Parameter Sets: ByInputObject
Aliases: VpnSiteLinkConnection

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Vpn site link connection name.

```yaml
Type: String
Parameter Sets: ByName
Aliases: ResourceName, VpnSiteLinkConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Azure resource ID of the Vpn site link connection for which IKE Security Associations needs to be fetched.

```yaml
Type: String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VpnConnectionName
The Vpn connection name.

```yaml
Type: String
Parameter Sets: ByName
Aliases: ParentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnGatewayName
The Vpn gateway name.

```yaml
Type: String
Parameter Sets: ByName
Aliases: GrandParentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSVpnSiteLinkConnection

### System.String

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.Cortex.PSVpnSiteLinkConnectionIkeSaMainModeSa, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=4.5.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
