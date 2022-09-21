---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagerstaticmember
schema: 2.0.0
---

# Get-AzNetworkManagerStaticMember

## SYNOPSIS
Gets network manager static members.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerStaticMember [-Name <String>] -NetworkGroupName <String> -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerStaticMember -Name <String> -NetworkGroupName <String> -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerStaticMember** cmdlet gets a network manager static member.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerStaticMember  -Name "TestStaticMember" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG" -NetworkGroupName "TestNetworkGroup"
```
```output
Name              : TestSM
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/TestNetworkGroup/staticMembers/TestStaticMember
ResourceId        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/virtualNetworks/vnet1
Description       :
Type              : Microsoft.Network/networkManagers/networkGroups/staticMembers
Etag              :
ProvisioningState : Succeeded
```
Gets a single static member.

### Example 2
```powershell
Get-AzNetworkManagerStaticMember -NetworkManagerName "psNetworkManager" -ResourceGroupName "psResourceGroup" -NetworkGroupName "psNetworkGroup"
```
```output
Name              : TestSM
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/TestNetworkGroup/staticMembers/TestSM
ResourceId        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/virtualNetworks/vnet1
Description       :
Type              : Microsoft.Network/networkManagers/networkGroups/staticMembers
Etag              :
ProvisioningState : Succeeded

Name              : TestSM2
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/TestNetworkGroup/staticMembers/TestSM2
ResourceId        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/virtualNetworks/vnet2
Description       :
Type              : Microsoft.Network/networkManagers/networkGroups/staticMembers
Etag              :
ProvisioningState : Succeeded
```

## PARAMETERS

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

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: NoExpand
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

```yaml
Type: String
Parameter Sets: Expand
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -NetworkGroupName
The network manager group name.

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
Accept wildcard characters: True
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerStaticMember

## NOTES

## RELATED LINKS

[New-AzNetworkManagerStaticMember](./New-AzNetworkManagerStaticMember.md)

[Remove-AzNetworkManagerStaticMember](./Remove-AzNetworkManagerStaticMember.md)