---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanagerconnectivityconfiguration
schema: 2.0.0
---

# New-AzNetworkManagerConnectivityConfiguration

## SYNOPSIS
Creates a network manager connectivity configuration.

## SYNTAX

```
New-AzNetworkManagerConnectivityConfiguration -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> -ConnectivityTopology <String> [-Description <String>]
 [-Hub <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerHub]>]
 [-AppliesToGroup <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem]>]
 [-DeleteExistingPeering] [-IsGlobal] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerConnectivityConfiguration** cmdlet creates a network manager.

## EXAMPLES

### Example 1
```powershell
PS C:\> $connectivityGroupItem = New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId "TestNetworkGroupId" -UseHubGateway -GroupConnectivity "None" -IsGlobal
PS C:\> [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem]]$connectivityGroup = @()
PS C:\> $connectivityGroup.Add($connectivityGroupItem)  
PS C:\> [System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerHub]]$hubList  = @() 
PS C:\> $hub = New-AzNetworkManagerHub -ResourceId "TestVnetId" -ResourceType "Microsoft.Network/virtualNetworks" 
PS C:\> $hubList.Add($hub)
PS C:\> New-AzNetworkManagerConnectivityConfiguration -ResourceGroupName TestResourceGroup -Name TestConnConfigName -NetworkManagerName TestNetworkManagerName -ConnectivityTopology "HubAndSpoke" -Hub $hublist -AppliesToGroup $connectivityGroup -DeleteExistingPeering -IsGlobal 

```

## PARAMETERS

### -AppliesToGroup
Connectivity Group.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -ConnectivityTopology
Connectivity Type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeleteExistingPeering
DeleteExistingPeering Flag.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Description
Description.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayName
DisplayName.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -Hub
Hub Id list.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerHub]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IsGlobal
IsGlobal Flag.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkManagerName
The network manager name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerHub, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=4.11.0.0, Culture=neutral, PublicKeyToken=null]]

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=4.11.0.0, Culture=neutral, PublicKeyToken=null]]

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityConfiguration

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerConnectivityConfiguration](./Get-AzNetworkManagerConnectivityConfiguration.md)

[Remove-AzNetworkManagerConnectivityConfiguration](./Remove-AzNetworkManagerConnectivityConfiguration.md)

[Set-AzNetworkManagerConnectivityConfiguration](./Set-AzNetworkManagerConnectivityConfiguration.md)