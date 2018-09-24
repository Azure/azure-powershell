---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/new-azurermp2svpngateway
schema: 2.0.0
---

# New-AzureRmP2SVpnGateway

## SYNOPSIS
Creates a Scalable P2S VPN Gateway.

## SYNTAX

### ByVirtualHubName (Default)
```
New-AzureRmP2SVpnGateway -ResourceGroupName <String> -Name <String> -VirtualHubName <String>
 [-VpnGatewayScaleUnit <UInt32>] -VpnClientAddressPool <String[]>
 [-P2SVpnServerConfiguration <PSP2SVpnServerConfiguration>] [-Tag <Hashtable>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubObject
```
New-AzureRmP2SVpnGateway -ResourceGroupName <String> -Name <String> -VirtualHub <PSVirtualHub>
 [-VpnGatewayScaleUnit <UInt32>] -VpnClientAddressPool <String[]>
 [-P2SVpnServerConfiguration <PSP2SVpnServerConfiguration>] [-Tag <Hashtable>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubResourceId
```
New-AzureRmP2SVpnGateway -ResourceGroupName <String> -Name <String> -VirtualHubId <String>
 [-VpnGatewayScaleUnit <UInt32>] -VpnClientAddressPool <String[]>
 [-P2SVpnServerConfiguration <PSP2SVpnServerConfiguration>] [-Tag <Hashtable>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
New-AzureRmP2SVpnGateway creates a scalable P2S VPN Gateway. This is software defined connectivity for point to site connections inside the VirtualHub. 

This gateway resizes and scales based on the scale unit specified in this or the Set-AzureRmP2SVpnGateway cmdlet. 

A connection is set up from many remote VpnClients to the scalable gateway.

The P2SVpnGateway will be in the same location as the referenced VirtualHub.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-AzureRmResourceGroup -Location "West US" -Name "testRG"
PS C:\> $p2sVpnServerConfigCertFilePath = "PathToCertFile.cer"
PS C:\> $listOfCerts = New-Object "System.Collections.Generic.List[String]"
PS C:\> $listOfCerts.Add($p2sVpnServerConfigCertFilePath)
PS C:\> $p2sVpnServerConfigObject1 = New-AzureRmP2SVpnServerConfigurationObject -Name "p2sVpnServerConfiguration1Name" -VpnProtocol IkeV2 -VpnClientRootCertificateFilesList $listOfCerts -VpnClientRevokedCertificateFilesList $listOfCerts
PS C:\> New-AzureRmVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US" -P2SVpnServerConfiguration $p2sVpnServerConfigs
$P2SVpnServerConfig1 = Get-AzureRmP2SVpnServerConfiguration -ParentResourceName "myVirtualWAN" -ResourceGroupName "testRG" -Name "p2sVpnServerConfiguration1Name"
PS C:\> $virtualHub = New-AzureRmVirtualHub -VirtualWan $virtualWan -ResourceGroupName "testRG" -Name "westushub" -AddressPrefix "10.0.0.1/24"
$vpnClientAddressSpaces = New-Object string[] 2
$vpnClientAddressSpaces[0] = "192.168.2.0/24"
$vpnClientAddressSpaces[1] = "192.168.3.0/24"
PS C:\> New-AzureRmP2SVpnGateway -ResourceGroupName "testRG" -Name "testvpngw" -VirtualHubId $virtualHub.Id -VpnGatewayScaleUnit 2 -VpnClientAddressPool $vpnClientAddressSpaces -P2SVpnServerConfiguration $P2SVpnServerConfig1

Name   		Address Space                    Virtual Hub                                                                                                   Scale Unit ProvisioningState
----   		-------------                    -----------                                                                                                   ---------- -----------------
testvpngw {192.168.2.0/24, 192.168.3.0/24} 	 /subscriptions/{subscriptionId}/resourceGroups/Ali_pS_Test/providers/Microsoft.Network/virtualHubs/westushub  2          Succeeded
```

The above will create a resource group, Virtual WAN, associates P2SVpnServerConfiguration to it, Virtual Network, Virtual Hub in West US in "testRG" resource group in Azure. 
A P2SVPN gateway will be created thereafter in the Virtual Hub with 2 scale units and attaching VirtualWan P2SVpnServerConfiguration created.

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
Aliases: ResourceName, P2SVpnGatewayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -P2SVpnServerConfiguration
The VirtualWan PSP2SVpnServerConfiguration to be attached to this P2SVpnGateway.
This is optional parameter.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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

### -Tag
A hashtable which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHub
The VirtualHub this P2SVpnGateway needs to be associated with.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualHub
Parameter Sets: ByVirtualHubObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualHubId
The Id of the VirtualHub this P2SVpnGateway needs to be associated with.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualHubName
The name of the VirtualHub this P2SVpnGateway needs to be associated with.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnClientAddressPool
P2S VpnClient AddressPool for this P2SVpnGateway.

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

### -VpnGatewayScaleUnit
The scale unit for this P2SVpnGateway.

```yaml
Type: System.UInt32
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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSP2SVpnGateway

## NOTES

## RELATED LINKS
