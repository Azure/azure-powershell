---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermp2svpngatewayvpnprofile
schema: 2.0.0
---

# Get-AzureRmP2SVpnServerConfiguration

## SYNOPSIS
Retrieves the details of a P2SVpnServerConfiguration associated with Virtual WAN.

## SYNTAX

### ByVirtualWanName (Default)
```
Get-AzureRmP2SVpnServerConfiguration -ResourceGroupName <String> -ParentResourceName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByVirtualWanObject
```
Get-AzureRmP2SVpnServerConfiguration -ParentObject <PSVirtualWan> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByVirtualWanResourceId
```
Get-AzureRmP2SVpnServerConfiguration -ParentResourceId <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves the details of a P2SVpnServerConfiguration associated with Virtual WAN.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmResourceGroup -Location "West US" -Name "testRG" 
PS C:\> New-AzureRmVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US" -AllowBranchToBranchTraffic $true -Office365LocalBreakoutCategory "Optimize"
PS C:\> $p2sVpnServerConfigCertFilePath = "PathToCertFile.cer"
PS C:\> $listOfCerts = New-Object "System.Collections.Generic.List[String]"
PS C:\> $listOfCerts.Add($p2sVpnServerConfigCertFilePath)
PS C:\> $Secure_String_Pwd = ConvertTo-SecureString "TestRadiusServerPassword" -AsPlainText -Force
PS C:\> New-AzureRmP2SVpnServerConfiguration -Name "P2SVpnServerConfiguration2Name" -ResourceGroupName "testRG" -ParentResourceName "myVirtualWAN" -VpnProtocol IkeV2 -RadiusServerAddress "TestRadiusServer" -RadiusServerSecret $Secure_String_Pwd -RadiusServerRootCertificateFilesList $listOfCerts -RadiusClientRootCertificateFilesList $listOfCerts
PS C:\> Get-AzureRmP2SVpnServerConfiguration -ResourceGroupName "testRG" -ParentResourceName "myVirtualWAN" -Name "P2SVpnServerConfiguration2Name"
Name                           VpnProtocols Provisioning State
----                           ------------ ------------------
P2SVpnServerConfiguration2Name {IkeV2}      Succeeded
```

The above will create a resource group "testRG" in region "West US" and an Azure Virtual WAN, creates and associates P2SVpnServerConfiguration with Azure Virtual WAN in that resource group in Azure. 
Get-AzureRmP2SVpnServerConfiguration will get P2SVpnServerConfiguration "P2SVpnServerConfiguration2Name" associated with an existing Virtual WAN.

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

### -Name
The name of the p2sVpnServerConfiguration

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, P2SVpnServerConfigurationName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
The VirtualWan this P2SVpnServerConfiguration is associated with.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualWan
Parameter Sets: ByVirtualWanObject
Aliases: ParentVirtualWan, VirtualWan

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParentResourceId
The Id of the parent VirtualWan this P2SVpnServerConfiguration is associated with.

```yaml
Type: System.String
Parameter Sets: ByVirtualWanResourceId
Aliases: ParentVirtualWanId, VirtualWanId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ParentResourceName
The name of the parent VirtualWan this P2SVpnServerConfiguration is associated with.

```yaml
Type: System.String
Parameter Sets: ByVirtualWanName
Aliases: ParentVirtualWanName, VirtualWanName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByVirtualWanName
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

### Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration

## NOTES

## RELATED LINKS
