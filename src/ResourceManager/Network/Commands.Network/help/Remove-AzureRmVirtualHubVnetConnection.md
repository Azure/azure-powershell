---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/remove-azurermvirtualhubvnetConnection
schema: 2.0.0
---

# Remove-AzureRmVirtualHubVnetConnection

## SYNOPSIS
The Remove-AzureRmVirtualHubVnetConnection cmdlet removes an Azure Virtual Network Connection which peers a remote VNET to the hub VNET.

## SYNTAX

### ByHubVirtualNetworkConnectionName (Default)
```
Remove-AzureRmVirtualHubVnetConnection -Name <String> -ResourceGroupName <String>
 [-ParentResourceName <String>] [-AsJob] [-Force] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHubVirtualNetworkConnectionObject
```
Remove-AzureRmVirtualHubVnetConnection [-InputObject <PSHubVirtualNetworkConnection>] [-AsJob] [-Force]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHubVirtualNetworkConnectionResourceId
```
Remove-AzureRmVirtualHubVnetConnection [-ResourceId <String>] [-AsJob] [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzureRmVirtualHubVnetConnection cmdlet removes an Azure Virtual Network Connection which peers a remote VNET to the hub VNET.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmResourceGroup -Name TestResourceGroup -Location centralus
PS C:\> $frontendSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24"
PS C:\> $backendSubnet  = New-AzureRmVirtualNetworkSubnetConfig -Name backendSubnet  -AddressPrefix "10.0.2.0/24"
PS C:\> $remoteVirtualNetwork = New-AzureRmVirtualNetwork -Name MyVirtualNetwork -ResourceGroupName TestResourceGroup -Location centralus -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet

PS C:\> New-AzureRmVirtualWan -ResourceGroupName TestResourceGroup -Name testvwan -Location?
PS C:\> New-AzureRmVirtualHub -Name testvhub <fill in> -AddressSpaceObject <PSAddressSpace>
PS C:\> New-AzureRmVirtualHubVnetConnection -ResourceGroupName TestResourceGroup -VirtualHubName testvhub -Name testvnetconnection -RemoteVirtualNetwork $remoteVirtualNetwork

PS C:\> Remove-AzureRmVirtualHubVnetConnection -ResourceGroupName TestResourceGroup -VirtualHubName testvhub -Name testvnetconnection
```

The above will create a resource group, Virtual WAN, Virtual Network, Virtual Hub in Central US in that resource group in Azure. A Virtual Network Connection will be created thereafter which will peer the Virtual Network to the Virtual Hub.

After the hub virtual network connection is created, it removes the hub virtual network connection using its resource group name, the hub name and the connection name.

### Example 2
```powershell
PS C:\> New-AzureRmResourceGroup -Name TestResourceGroup -Location centralus
PS C:\> $frontendSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24"
PS C:\> $backendSubnet  = New-AzureRmVirtualNetworkSubnetConfig -Name backendSubnet  -AddressPrefix "10.0.2.0/24"
PS C:\> $remoteVirtualNetwork = New-AzureRmVirtualNetwork -Name MyVirtualNetwork -ResourceGroupName TestResourceGroup -Location centralus -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet

PS C:\> New-AzureRmVirtualWan -ResourceGroupName TestResourceGroup -Name testvwan -Location?
PS C:\> New-AzureRmVirtualHub -Name testvhub <fill in> -AddressSpaceObject <PSAddressSpace>
PS C:\> New-AzureRmVirtualHubVnetConnection -ResourceGroupName TestResourceGroup -VirtualHubName testvhub -Name testvnetconnection -RemoteVirtualNetwork $remoteVirtualNetwork

PS C:\> Get-AzureRmVirtualHubVnetConnection -ResourceGroupName TestResourceGroup -VirtualHubName testvhub -Name testvnetconnection | Remove-AzureRmHubVnetConnection
```

The above will create a resource group, Virtual WAN, Virtual Network, Virtual Hub in Central US in that resource group in Azure. A Virtual Network Connection will be created thereafter which will peer the Virtual Network to the Virtual Hub.

After the hub virtual network connection is created, it removes the hub virtual network connection using powershell piping on the output from Get-AzureRmHubVirtualNetworkConnection.

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

### -Force
Do not ask for confirmation if you want to overrite a resource

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

### -InputObject
The hubvirtualnetworkconnection resource to modify.

```yaml
Type: PSHubVirtualNetworkConnection
Parameter Sets: ByHubVirtualNetworkConnectionObject
Aliases: HubVirtualNetworkConnection

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: ByHubVirtualNetworkConnectionName
Aliases: ResourceName, HubVirtualNetworkConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourceName
The parent resource name.

```yaml
Type: String
Parameter Sets: ByHubVirtualNetworkConnectionName
Aliases: VirtualHubName, ParentVirtualHubName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
{{Fill PassThru Description}}

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

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ByHubVirtualNetworkConnectionName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the hubvirtualnetworkconnection resource to modify.

```yaml
Type: String
Parameter Sets: ByHubVirtualNetworkConnectionResourceId
Aliases: HubVirtualNetworkConnectionId

Required: False
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

### Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection

## NOTES

## RELATED LINKS
