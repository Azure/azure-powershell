---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# Get-AzureRmVirtualWanVpnSitesConfiguration

## SYNOPSIS
Gets the Vpn configuration for a subset of VpnSites connected to this WAN via VpnConnections. Uploads the generated Vpn
configuration to a storage blob specified by the customer.


## SYNTAX

### ByVirtualWanName
```
Get-AzureRmVirtualWanVpnSitesConfiguration -Name <String> -ResourceGroupName <String> -StorageSasUrl <String>
 [-VpnSiteIds <System.Collections.Generic.List`1[System.String]>]
 [-VpnSites <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVpnSite]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualWanObject
```
Get-AzureRmVirtualWanVpnSitesConfiguration -InputObject <PSVirtualWan> -StorageSasUrl <String>
 [-VpnSiteIds <System.Collections.Generic.List`1[System.String]>]
 [-VpnSites <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVpnSite]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualWanResourceId
```
Get-AzureRmVirtualWanVpnSitesConfiguration -ResourceId <String> -StorageSasUrl <String>
 [-VpnSiteIds <System.Collections.Generic.List`1[System.String]>]
 [-VpnSites <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVpnSite]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Gets the Vpn configuration for a subset of VpnSites connected to this WAN via VpnConnections. Uploads the generated Vpn
configuration to a storage blob specified by the customer.

## EXAMPLES

### Example 1
### Example 1
```powershell
PS C:\> New-AzureRmResourceGroup -Location "West US" -Name "testRG"
PS C:\> $virtualWan = New-AzureRmVirtualWan -ResourceGroupName testRG -Name myVirtualWAN -Location "West US"
PS C:\> $virtualHub = New-AzureRmVirtualHub -VirtualWan $virtualWan -ResourceGroupName "testRG" -Name “westushub” -AddressPrefix "10.0.0.1/24"
PS C:\> New-AzureRmVpnGateway -ResourceGroupName "testRG" -Name "testvpngw" -VirtualHubId $virtualHub.Id -BGPPeeringWeight 10 -VpnGatewayScaleUnit 2
PS C:\> $vpnGateway = Get-AzureRmVpnGateway -ResourceGroupName "testRG" -Name "testvpngw"

PS C:\> $vpnSiteAddressSpaces = New-Object string[] 2
PS C:\> $vpnSiteAddressSpaces[0] = "192.168.2.0/24"
PS C:\> $vpnSiteAddressSpaces[1] = "192.168.3.0/24"

PS C:\> $vpnSite = New-AzureRmVpnSite -ResourceGroupName "testRG" -Name "testVpnSite" -Location "West US" -VirtualWan $virtualWan -IpAddress "1.2.3.4" -AddressSpace $vpnSiteAddressSpaces -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -LinkSpeedInMbps "10"

PS C:\> New-AzureRmVpnConnection -ResourceGroupName $vpnGateway.ResourceGroupName -ParentResourceName $vpnGateway.Name -Name "testConnection" -VpnSite $vpnSite

PS C:\> $vpnSitesForConfig = New-Object Microsoft.Azure.Commands.Network.Models.PSVpnSite[] 2
PS C:\> $vpnSitesForConfig[0] = $vpnSite.Id
PS C:\> Get-AzureRmVirtualWanVpnSitesConfiguration -VirtualWan $virtualWan -StorageSasUrl "SignedSasUrl" -VpnSites $vpnSitesForConfig
```

The above will create a resource group, Virtual WAN, Virtual Network, Virtual Hub and a VpnSite in West US in "testRG" resource group in Azure. 
A VPN gateway will be created thereafter in the Virtual Hub with 2 scale units.

Once the gateway has been created, it is connected to the VpnSite using the New-AzureRmVpnConnection command.

The configuration is then downloaded using this commandlet.

## PARAMETERS

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
The vpn site object to be modified

```yaml
Type: PSVirtualWan
Parameter Sets: ByVirtualWanObject
Aliases: VirtualWan

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
Parameter Sets: ByVirtualWanName
Aliases: ResourceName, VirtualWanName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ByVirtualWanName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The Azure resource ID for the virtual wan.

```yaml
Type: String
Parameter Sets: ByVirtualWanResourceId
Aliases: VirtualWanId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageSasUrl
The SAS Url for the storage location where the configuration is to be generated.

Must be a valid Blob SAS Url of a storage blob.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnSiteIds
The list of VpnSite resource ids to generate configuration for.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnSites
The list of VpnSites to generate configuration for.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVpnSite]
Parameter Sets: (All)
Aliases:

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.PSVpnSite

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualWanVpnSitesConfiguration

## NOTES

## RELATED LINKS
