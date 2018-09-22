---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermp2svpngatewayvpnprofile
schema: 2.0.0
---

# Get-AzureRmP2SVpnGatewayVpnProfile

## SYNOPSIS
Generates VPN profile for P2S client of the P2SVpnGateway in the specified resource group.

## SYNTAX

```
Get-AzureRmP2SVpnGatewayVpnProfile -ResourceGroupName <String> -Name <String> -AuthenticationMethod <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Generates VPN profile for P2S client of the P2SVpnGateway in the specified resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmResourceGroup -Location "West US" -Name "testRG"
PS C:\> $virtualWan = New-AzureRmVirtualWan -ResourceGroupName testRG -Name myVirtualWAN -Location "West US"
PS C:\> $virtualHub = New-AzureRmVirtualHub -VirtualWan $virtualWan -ResourceGroupName "testRG" -Name "westushub" -AddressPrefix "10.0.0.1/24"
PS C:\> $p2sVpnServerConfigCertFilePath = "PathToCertificate.cer"
PS C:\> $listOfCerts = New-Object "System.Collections.Generic.List[String]"
PS C:\> $listOfCerts.Add($p2sVpnServerConfigCertFilePath)
PS C:\> $p2sVpnServerConfigObject1 = New-AzureRmP2SVpnServerConfigurationObject -Name $p2sVpnServerConfiguration1Name -VpnProtocol IkeV2 -VpnClientRootCertificateFilesList $listOfCerts -VpnClientRevokedCertificateFilesList $listOfCerts
PS C:\> Update-AzureRmVirtualWan -Name $virtualWanName -ResourceGroupName $rgName -P2SVpnServerConfiguration $p2sVpnServerConfigObject1 -Force
PS C:\> $p2sVpnServerConfig1 = Get-AzureRmP2SVpnServerConfiguration -ParentResourceName $virtualWanName -ResourceGroupName $rgName -Name $P2SVpnServerConfiguration1Name
PS C:\> $vpnClientAddressSpaces = New-Object string[] 2
PS C:\> $vpnClientAddressSpaces[0] = "192.168.2.0/24"
PS C:\> New-AzureRmP2SVpnGateway -ResourceGroupName "testRG" -Name "testvpngw" -VirtualHub $virtualHub -VpnGatewayScaleUnit 1 -VpnClientAddressPool $vpnClientAddressSpaces -P2SVpnServerConfiguration $p2sVpnServerConfig1
PS C:\> Get-AzureRmP2SVpnGatewayVpnProfile -Name "testvpngw" -ResourceGroupName "testRG" -AuthenticationMethod "EAPTLS"
P2SVpnGateway Client Profile SASUrl
-----------------------------------                                                                                                                                                                         
https://SASUrl&fileExtension=.zip
```

The above will create a resource group, Virtual WAN, associates P2SVpnServerConfiguration to it, Virtual Network, Virtual Hub in West US in "testRG" resource group in Azure. 
A P2SVPN gateway will be created thereafter in the Virtual Hub with 2 scale units and attaching VirtualWan P2SVpnServerConfiguration created. 
Get-AzureRmP2SVpnGatewayVpnProfile will generate the VPN profile for P2S client of the P2SVpnGateway which VpnClients can download from returned SASUrl to install on their end.

## PARAMETERS

### -AuthenticationMethod
AuthenticationMethod

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: EAPTLS, EAPMSCHAPv2

Required: True
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
P2SVpnGateway name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, P2SVpnGatewayName, GatewayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
ResourceGroup name

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVpnProfileResponse

## NOTES

## RELATED LINKS
