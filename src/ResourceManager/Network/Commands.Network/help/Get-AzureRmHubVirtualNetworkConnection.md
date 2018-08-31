---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# Get-AzureRmHubVirtualNetworkConnection

## SYNOPSIS
Gets a Virtual Network Connection in a virtual hub or lists all virtual network connections in a virtual hub.

## SYNTAX

```
Get-AzureRmHubVirtualNetworkConnection [-Name <String>] -ResourceGroupName <String>
 [-ParentResourceName <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Virtual Network Connection in a virtual hub or lists all virtual network connections in a virtual hub.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmResourceGroup -Name TestResourceGroup -Location centralus
PS C:\> $frontendSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24"
PS C:\> $backendSubnet  = New-AzureRmVirtualNetworkSubnetConfig -Name backendSubnet  -AddressPrefix "10.0.2.0/24"
PS C:\> $remoteVirtualNetwork = New-AzureRmVirtualNetwork -Name MyVirtualNetwork -ResourceGroupName TestResourceGroup -Location centralus -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet

PS C:\> New-AzureRmVirtualWan -ResourceGroupName TestResourceGroup -Name testvwan -Location?
PS C:\> New-AzureRmVirtualHub -Name testvhub <fill in> -AddressSpaceObject <PSAddressSpace>
PS C:\> New-AzureRmHubVirtualNetworkConnection -ResourceGroupName TestResourceGroup -VirtualHubName testvhub -Name testvnetconnection -RemoteVirtualNetwork $remoteVirtualNetwork

PS C:\> Get-AzureRmHubVirtualNetworkConnection -ResourceGroupName TestResourceGroup -VirtualHubName testvhub -Name testvnetconnection
```

The above will create a resource group, Virtual WAN, Virtual Network, Virtual Hub in Central US in that resource group in Azure. A Virtual Network Connection will be created thereafter which will peer the Virtual Network to the Virtual Hub.

After the hub virtual network connection is created, it gets the hub virtual network connection using its resource group name, the hub name and the connection name.


### Example 2
```powershell
PS C:\> New-AzureRmResourceGroup -Name TestResourceGroup -Location centralus
PS C:\> $frontendSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24"
PS C:\> $backendSubnet  = New-AzureRmVirtualNetworkSubnetConfig -Name backendSubnet  -AddressPrefix "10.0.2.0/24"
PS C:\> $remoteVirtualNetwork = New-AzureRmVirtualNetwork -Name MyVirtualNetwork -ResourceGroupName TestResourceGroup -Location centralus -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet

PS C:\> New-AzureRmVirtualWan -ResourceGroupName TestResourceGroup -Name testvwan -Location?
PS C:\> New-AzureRmVirtualHub -Name testvhub <fill in> -AddressSpaceObject <PSAddressSpace>
PS C:\> New-AzureRmHubVirtualNetworkConnection -ResourceGroupName TestResourceGroup -VirtualHubName testvhub -Name testvnetconnection -RemoteVirtualNetwork $remoteVirtualNetwork

PS C:\> Get-AzureRmHubVirtualNetworkConnection -ResourceGroupName TestResourceGroup -VirtualHubName testvhub
```

The above will create a resource group, Virtual WAN, Virtual Network, Virtual Hub in Central US in that resource group in Azure. A Virtual Network Connection will be created thereafter which will peer the Virtual Network to the Virtual Hub.

After the hub virtual network connection is created, it lists all the hub virtual network connection using its resource group name and the hub name.


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

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName, HubVirtualNetworkConnectionName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ParentResourceName
The parent resource name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: VirtualHubName, ParentVirtualHubName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection

## NOTES

## RELATED LINKS
