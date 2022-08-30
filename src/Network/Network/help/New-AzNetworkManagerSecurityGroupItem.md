---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanagersecuritygroupitem
schema: 2.0.0
---

# New-AzNetworkManagerSecurityGroupItem

## SYNOPSIS
Creates a security group item.

## SYNTAX

```
New-AzNetworkManagerSecurityGroupItem -NetworkGroupId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerSecurityGroupItem** cmdlet creates a security group item.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerSecurityGroupItem -NetworkGroupId "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup"
```
```output
NetworkGroupId
--------------
/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup
```
Creates a security group item.

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

### -NetworkGroupId
Network Group Id

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem

## NOTES

## RELATED LINKS
[New-AzNetworkManagerSecurityAdminRuleCollection](./New-AzNetworkManagerSecurityAdminRuleCollection.md)
