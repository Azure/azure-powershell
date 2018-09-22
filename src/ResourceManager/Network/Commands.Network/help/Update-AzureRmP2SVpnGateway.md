---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/update-azurermp2svpngateway
schema: 2.0.0
---

# Update-AzureRmP2SVpnGateway

## SYNOPSIS
Update-AzureRmP2SVpnGateway updates a scalable P2S VPN Gateway to the appropriate goal state.

## SYNTAX

### ByP2SVpnGatewayName (Default)
```
Update-AzureRmP2SVpnGateway -ResourceGroupName <String> -Name <String> [-VpnGatewayScaleUnit <UInt32>]
 [-VpnClientAddressPool <String[]>] [-P2SVpnServerConfiguration <PSP2SVpnServerConfiguration>]
 [-Tag <Hashtable>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByP2SVpnGatewayObject
```
Update-AzureRmP2SVpnGateway -InputObject <PSP2SVpnGateway> [-VpnGatewayScaleUnit <UInt32>]
 [-VpnClientAddressPool <String[]>] [-P2SVpnServerConfiguration <PSP2SVpnServerConfiguration>]
 [-Tag <Hashtable>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByP2SVpnGatewayResourceId
```
Update-AzureRmP2SVpnGateway -ResourceId <String> [-VpnGatewayScaleUnit <UInt32>]
 [-VpnClientAddressPool <String[]>] [-P2SVpnServerConfiguration <PSP2SVpnServerConfiguration>]
 [-Tag <Hashtable>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update-AzureRmP2SVpnGateway updates a scalable P2S VPN Gateway to the appropriate goal state. An AzureRmP2SVpnGateway is a software defined connectivity for point to site connections inside the VirtualHub. 
This gateway resizes and scales based on the scale unit specified by the user. 
A connection is set up from many remote VpnClients to the scalable gateway.

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
PS C:\> Update-AzureRmVpnP2SGateway -ResourceGroupName "testRG" -Name "testvpngw" -VpnGatewayScaleUnit 3

Name   		Address Space                    Virtual Hub                                                                                                   Scale Unit ProvisioningState
----   		-------------                    -----------                                                                                                   ---------- -----------------
testvpngw {192.168.2.0/24, 192.168.3.0/24} 	 /subscriptions/{subscriptionId}/resourceGroups/Ali_pS_Test/providers/Microsoft.Network/virtualHubs/westushub  3          Succeeded
```

The above will create a resource group, Virtual WAN, associates P2SVpnServerConfiguration to it, Virtual Network, Virtual Hub in West US in "testRG" resource group in Azure. 
A P2S VPN gateway will be created thereafter in the Virtual Hub with 2 scale units.

After the gateway has been created, it uses Set-AzureRmP2SVpnGateway to upgrade the gateway to 3 scale units.

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

### -InputObject
The P2SVpnGateway object to be modified

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSP2SVpnGateway
Parameter Sets: ByP2SVpnGatewayObject
Aliases: P2SVpnGateway

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The P2SVpnGateway name.

```yaml
Type: System.String
Parameter Sets: ByP2SVpnGatewayName
Aliases: ResourceName, P2SVpnGatewayName, GatewayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -P2SVpnServerConfiguration
The VirtualWan P2SVpnServerConfiguration to be attached to this P2SVpnGateway.

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
Parameter Sets: ByP2SVpnGatewayName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Azure resource ID of the P2SVpnGateway to be modified.

```yaml
Type: System.String
Parameter Sets: ByP2SVpnGatewayResourceId
Aliases: P2SVpnGatewayId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -VpnClientAddressPool
P2S VpnClient AddressPool for this P2SVpnGateway.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.Commands.Network.Models.PSP2SVpnGateway
System.String
Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSP2SVpnGateway

## NOTES

## RELATED LINKS
