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
 -ResourceGroupName <String>
 -AppliesToGroup <Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem[]>
 -ConnectivityTopology <String> [-Description <String>]
 [-Hub <Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerHub[]>]
 [-DeleteExistingPeering] [-IsGlobal] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerConnectivityConfiguration** cmdlet creates a network manager connectivity configuration.

## EXAMPLES

### Example 1
```powershell
$connectivityGroupItem = New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup"
$connectivityGroup  = @($connectivityGroupItem)  

$hub = New-AzNetworkManagerHub -ResourceId "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnetHub" -ResourceType "Microsoft.Network/virtualNetworks" 
$hubList = @($hub)
New-AzNetworkManagerConnectivityConfiguration -ResourceGroupName psResourceGroup -Name "psConnectivityConfig" -NetworkManagerName psNetworkManager -ConnectivityTopology "HubAndSpoke" -Hub $hublist -AppliesToGroup $connectivityGroup -DeleteExistingPeering 
```
```output
ConnectivityTopology  : HubAndSpoke
Hubs                  : {/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnetHub}
DeleteExistingPeering : True
IsGlobal              : False
AppliesToGroups       : {/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup}
AppliesToGroupsText   : [
                          {
                            "NetworkGroupId": "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup",
                            "UseHubGateway": "False",
                            "IsGlobal": "False",
                            "GroupConnectivity": "None"
                          }
                        ]
HubsText              : [
                          {
                            "ResourceId": "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnetHub",
                            "ResourceType": "Microsoft.Network/virtualNetworks"
                          }
                        ]
DisplayName           :
Description           :
Type                  : Microsoft.Network/networkManagers/connectivityConfigurations
ProvisioningState     : Succeeded
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "jaredgorthy@microsoft.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2022-08-07T04:37:43.1186543Z",
                          "LastModifiedBy": "jaredgorthy@microsoft.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2022-08-07T04:37:43.1186543Z"
                        }
Name                  : psConnectivityConfig
Etag                  :
Id                    : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/connectivityConfigurations/psConnectivityConfig
```
Creates a hub and spoke network manager connectivity configuration.

### Example 2
```powershell
$connectivityGroupItem = New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup"
[System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem]]$connectivityGroup  = @()  
$connectivityGroup.Add($connectivityGroupItem)   
New-AzNetworkManagerConnectivityConfiguration -ResourceGroupName psResourceGroup -Name "psConnectivityConfigMesh" -NetworkManagerName psNetworkManager -ConnectivityTopology "Mesh" -AppliesToGroup $connectivityGroup -DeleteExistingPeering 
```
```output
ConnectivityTopology  : Mesh
Hubs                  : {}
DeleteExistingPeering : True
IsGlobal              : False
AppliesToGroups       : {/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup}
AppliesToGroupsText   : [
                          {
                            "NetworkGroupId": "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup",
                            "UseHubGateway": "False",
                            "IsGlobal": "False",
                            "GroupConnectivity": "None"
                          }
                        ]
HubsText              : []
DisplayName           :
Description           :
Type                  : Microsoft.Network/networkManagers/connectivityConfigurations
ProvisioningState     : Succeeded
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "jaredgorthy@microsoft.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2022-08-07T04:43:00.9075845Z",
                          "LastModifiedBy": "jaredgorthy@microsoft.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2022-08-07T04:43:00.9075845Z"
                        }
Name                  : psConnectivityConfigMesh
Etag                  :
Id                    : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/connectivityConfigurations/psConnectivityConfigMesh
```
Creates a mesh network manager connectivity configuration.

## PARAMETERS

### -AppliesToGroup
Connectivity Group.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -ConnectivityTopology
Connectivity Topology.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: HubAndSpoke, Mesh

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
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
Type: SwitchParameter
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
Type: String
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
Type: SwitchParameter
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
Type: SwitchParameter
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
Type: String
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
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=4.16.1.0, Culture=neutral, PublicKeyToken=null]]

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerHub, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=4.16.1.0, Culture=neutral, PublicKeyToken=null]]

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityConfiguration

## NOTES

## RELATED LINKS
[Get-AzNetworkManagerConnectivityConfiguration](./Get-AzNetworkManagerConnectivityConfiguration.md)

[Remove-AzNetworkManagerConnectivityConfiguration](./Remove-AzNetworkManagerConnectivityConfiguration.md)

[Set-AzNetworkManagerConnectivityConfiguration](./Set-AzNetworkManagerConnectivityConfiguration.md)