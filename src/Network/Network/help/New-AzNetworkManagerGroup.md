---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagergroup
schema: 2.0.0
---

# New-AzNetworkManagerGroup

## SYNOPSIS
Creates a network manager group.

## SYNTAX

```
New-AzNetworkManagerGroup -Name <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-Description <String>] [-MemberType <String>] [-IfMatch <String>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerGroup** cmdlet creates a network manager group.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerGroup -ResourceGroupName "psTestResourceGroup" -NetworkManagerName "psNetworkManager" -Name psNetworkGroup -Description "psDescription"
```

```output
MemberType        : VirtualNetwork
DisplayName       :
Description       : psDescription
Type              : Microsoft.Network/networkManagers/networkGroups
ProvisioningState : Succeeded
SystemData        : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText    : {
                      "CreatedBy": "jaredgorthy@microsoft.com",
                      "CreatedByType": "User",
                      "CreatedAt": "2022-08-07T04:32:21.6585296Z",
                      "LastModifiedBy": "jaredgorthy@microsoft.com",
                      "LastModifiedByType": "User",
                      "LastModifiedAt": "2022-08-07T04:32:21.6585296Z"
                    }
Name              : psNetworkGroup
Etag              :
Id                : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup
```

Creates a network manager group. Default member type is Virtual Network.

### Example 2
```powershell
New-AzNetworkManagerGroup -ResourceGroupName "psTestResourceGroup" -NetworkManagerName "psNetworkManager" -Name psNetworkGroup -Description "psDescription" -MemberType "Subnet"
```

```output
MemberType        : Subnet
DisplayName       :
Description       : psDescription
Type              : Microsoft.Network/networkManagers/networkGroups
ProvisioningState : Succeeded
SystemData        : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText    : {
                      "CreatedBy": "jaredgorthy@microsoft.com",
                      "CreatedByType": "User",
                      "CreatedAt": "2022-08-07T04:32:21.6585296Z",
                      "LastModifiedBy": "jaredgorthy@microsoft.com",
                      "LastModifiedByType": "User",
                      "LastModifiedAt": "2022-08-07T04:32:21.6585296Z"
                    }
Name              : psNetworkGroup
Etag              :
Id                : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup
```

Creates a network manager group of type Subnet.

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -IfMatch
If match header.

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

### -MemberType
Network Group member type. Valid values include 'VirtualNetwork' and 'Subnet'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: VirtualNetwork, Subnet

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
Accept wildcard characters: True
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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerGroup

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerGroup](./Get-AzNetworkManagerGroup.md)

[Remove-AzNetworkManagerGroup](./Remove-AzNetworkManagerGroup.md)

[Set-AzNetworkManagerGroup](./Set-AzNetworkManagerGroup.md)