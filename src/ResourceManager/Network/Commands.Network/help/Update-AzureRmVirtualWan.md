---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/update-azurermvirtualwan
schema: 2.0.0
---

# Update-AzureRmVirtualWan

## SYNOPSIS
Updates an Azure Virtual WAN.

## SYNTAX

### ByVirtualWanName (Default)
```
Update-AzureRmVirtualWan -ResourceGroupName <String> -Name <String> [-SecurityProviderName <String>]
 [-Office365LocalBreakoutCategory <String>] [-AllowVnetToVnetTraffic <Boolean>]
 [-AllowBranchToBranchTraffic <Boolean>] [-P2SVpnServerConfiguration <PSP2SVpnServerConfiguration[]>]
 [-Tag <Hashtable>] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVirtualWanObject
```
Update-AzureRmVirtualWan -InputObject <PSVirtualWan> [-SecurityProviderName <String>]
 [-Office365LocalBreakoutCategory <String>] [-AllowVnetToVnetTraffic <Boolean>]
 [-AllowBranchToBranchTraffic <Boolean>] [-P2SVpnServerConfiguration <PSP2SVpnServerConfiguration[]>]
 [-Tag <Hashtable>] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVirtualWanResourceId
```
Update-AzureRmVirtualWan -ResourceId <String> [-SecurityProviderName <String>]
 [-Office365LocalBreakoutCategory <String>] [-AllowVnetToVnetTraffic <Boolean>]
 [-AllowBranchToBranchTraffic <Boolean>] [-P2SVpnServerConfiguration <PSP2SVpnServerConfiguration[]>]
 [-Tag <Hashtable>] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates an Azure Virtual WAN.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmResourceGroup -Location "West US" -Name "testRG" 
PS C:\> New-AzureRmVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US" -Office365LocalBreakoutCategory "Optimize"
PS C:\> $p2sVpnServerConfigCertFilePath = "PathToCertFile.cer"
PS C:\> $listOfCerts = New-Object "System.Collections.Generic.List[String]"
PS C:\> $listOfCerts.Add($p2sVpnServerConfigCertFilePath)
PS C:\> $p2sVpnServerConfigObject1 = New-AzureRmP2SVpnServerConfigurationObject -Name "p2sVpnServerConfiguration1Name" -VpnProtocol IkeV2 -VpnClientRootCertificateFilesList $listOfCerts -VpnClientRevokedCertificateFilesList $listOfCerts
PS C:\> Update-AzureRmVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -AllowBranchToBranchTraffic $true -AllowVnetToVnetTraffic $false -Office365LocalBreakoutCategory "None" -P2SVpnServerConfiguration $P2SVpnServerConfigObject1

Name                              				: testRG
Id                                				: /subscriptions/{SubscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualWans/myVirtualWAN
Number of attached P2SVpnServerConfigurations 	: 1
AllowVnetToVnetTraffic            				: False
AllowBranchToBranchTraffic        				: True
Office365LocalBreakoutCategory    				: Optimize
Location                          				: West US
Type                              				: Microsoft.Network/virtualWans
ProvisioningState                 				: Succeeded
```

The above will create a resource group "testRG" in region "West US" and an Azure Virtual WAN in that resource group in Azure. VirtualWan is updated with new properties.

## PARAMETERS

### -AllowBranchToBranchTraffic
Allow branch to branch traffic for VirtualWan.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowVnetToVnetTraffic
Allow vnet to vnet traffic for VirtualWan.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Force
Do not ask for confirmation if you want to overrite a resource

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
The virtual wan object to be modified

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualWan
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
Type: System.String
Parameter Sets: ByVirtualWanName
Aliases: ResourceName, VirtualWanName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Office365LocalBreakoutCategory
Local breakout category for office 365 traffic.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: All, None, Optimize, OptimizeAndAllow

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -P2SVpnServerConfiguration
The list of PSP2SVpnServerConfigurations that are associated with this VirtualWan.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration[]
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
Parameter Sets: ByVirtualWanName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Azure resource ID for the virtual wan.

```yaml
Type: System.String
Parameter Sets: ByVirtualWanResourceId
Aliases: VirtualWanId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SecurityProviderName
The name of the selected security provider.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.Commands.Network.Models.PSVirtualWan

### System.String

### Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualWan

## NOTES

## RELATED LINKS
