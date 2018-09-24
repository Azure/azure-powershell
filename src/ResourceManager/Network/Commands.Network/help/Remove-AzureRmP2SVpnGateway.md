---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/remove-azurermp2svpngateway
schema: 2.0.0
---

# Remove-AzureRmP2SVpnGateway

## SYNOPSIS
The Remove-AzureRmP2SVpnGateway cmdlet removes an Azure P2S VPN gateway. This is a gateway specific to Azure Virtual WAN's software defined Point to site connectivity.

## SYNTAX

### ByP2SVpnGatewayName (Default)
```
Remove-AzureRmP2SVpnGateway -ResourceGroupName <String> -Name <String> [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnGatewayObject
```
Remove-AzureRmP2SVpnGateway -InputObject <PSP2SVpnGateway> [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnGatewayResourceId
```
Remove-AzureRmP2SVpnGateway -ResourceId <String> [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzureRmP2SVpnGateway cmdlet removes an Azure P2S VPN gateway. This is a gateway specific to Azure Virtual WAN's software defined Point to site connectivity.

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
PS C:\> New-AzureRmP2SVpnGateway -ResourceGroupName "testRG" -Name "testvpngw" -VirtualHub $virtualHub -VpnGatewayScaleUnit 2 -VpnClientAddressPool $vpnClientAddressSpaces -P2SVpnServerConfiguration $p2sVpnServerConfig1
PS C:\> Remove-AzureRmP2SVpnGateway -ResourceGroupName "testRG" -Name "testvpngw" -Passthru
```

This example creates a Resource group, Virtual WAN, associates P2SVpnServerConfiguration to it, Virtual Hub, scalable VPN P2S gateway in Central US and then immediately deletes it. 
To suppress the prompt when deleting the Virtual Gateway, use the -Force flag.
This will delete the P2SVpnGateway.

### Example 2

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
PS C:\> New-AzureRmP2SVpnGateway -ResourceGroupName "testRG" -Name "testvpngw" -VirtualHubId $virtualHub.Id -VpnGatewayScaleUnit 2 -VpnClientAddressPool $vpnClientAddressSpaces -P2SVpnServerConfiguration $p2sVpnServerConfig1
PS C:\> Get-AzureRmP2SVpnGateway -ResourceGroupName "testRG" -Name "testvpngw" | Remove-AzureRmP2SVpnGateway -Passthru
```

This example creates a Resource group, Virtual WAN, associates P2SVpnServerConfiguration to it, Virtual Hub, scalable VPN P2S gateway in Central US and then immediately deletes it.
To suppress the prompt when deleting the Virtual Gateway, use the -Force flag.
This will delete the P2SVpnGateway.

## PARAMETERS

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

### -Force
Do not ask for confirmation.

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

### -InputObject
The P2SVpnGateway object to be deleted.

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
Aliases: ResourceName, P2SVpnGatewayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object representing the item on which this operation is being performed.

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
The Azure resource ID for the p2sVpnGateway to be deleted.

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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
