---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanagerstaticmember
schema: 2.0.0
---

# New-AzNetworkManagerStaticMember

## SYNOPSIS
Creates a network manager static member.

## SYNTAX

```
New-AzNetworkManagerStaticMember -Name <String> -NetworkManagerName <String> -NetworkGroupName <String>
 -ResourceGroupName <String> -ResourceId <String> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerStaticMember** cmdlet creates a network manager static member.

## EXAMPLES

### Example 1
```powershell
$vnetId = "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnet"
New-AzNetworkManagerStaticMember -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager" -NetworkGroupName "psNetworkGroup" -Name "psStaticMember" -ResourceId $vnetId
```
```output
ResourceId        : /subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnet
DisplayName       :
Description       :
Type              : Microsoft.Network/networkManagers/networkGroups/staticMembers
ProvisioningState : Updating
SystemData        : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText    : {
                      "CreatedBy": "jaredgorthy@microsoft.com",
                      "CreatedByType": "User",
                      "CreatedAt": "2022-08-08T00:13:22.2067814Z",
                      "LastModifiedBy": "jaredgorthy@microsoft.com",
                      "LastModifiedByType": "User",
                      "LastModifiedAt": "2022-08-08T00:13:22.2067814Z"
                    }
Name              : psStaticMember
Etag              :
Id                : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup/staticMembers/psStaticMember
```
Creates a network manager static member with a vnet resource.

## PARAMETERS

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
Accept wildcard characters: False
```

### -ResourceId
Resource Id.

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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerStaticMember

## NOTES

## RELATED LINKS
[Get-AzNetworkManagerStaticMember](./Get-AzNetworkManagerStaticMember.md)

[Remove-AzNetworkManagerStaticMember](./Remove-AzNetworkManagerStaticMember.md)