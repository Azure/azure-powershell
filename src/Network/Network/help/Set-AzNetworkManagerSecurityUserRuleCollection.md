---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-aznetworkmanagersecurityuserrulecollection
schema: 2.0.0
---

# Set-AzNetworkManagerSecurityUserRuleCollection

## SYNOPSIS
Updates a network manager security user rule collection.

## SYNTAX

```
Set-AzNetworkManagerSecurityUserRuleCollection -InputObject <PSNetworkManagerSecurityUserRuleCollection>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerSecurityUserRuleCollection** cmdlet updates a network manager security user rule collection.

## EXAMPLES

### Example 1
```powershell
$NetworkManagerSecurityUserRuleCollection = Get-AzNetworkManagerSecurityUserRuleCollection -SecurityUserConfigurationName "psSecurityUserConfig" -Name "psRuleCollection" -NetworkManagerName "psNetworkManager" -ResourceGroupName "psResourceGroup"
$groupItem = New-AzNetworkManagerSecurityUserGroupItem -NetworkGroupId "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup"
$groupItem2 = New-AzNetworkManagerSecurityUserGroupItem -NetworkGroupId "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup2"
[System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserGroupItem]]$configGroup  = @() 
$configGroup.Add($groupItem)
$configGroup.Add($groupItem2)
$NetworkManagerSecurityUserRuleCollection.AppliesToGroups = $configGroup
Set-AzNetworkManagerSecurityUserRuleCollection -InputObject $NetworkManagerSecurityUserRuleCollection
```

```output
AppliesToGroups     : {/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup,
                      /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup2}
AppliesToGroupsText : [
                        {
                          "NetworkGroupId":
                      "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup"
                        },
                        {
                          "NetworkGroupId":
                      "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup2"
                        }
                      ]
DisplayName         :
Description         :
Type                : Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections
ProvisioningState   : Succeeded
SystemData          : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText      : {
                        "CreatedBy": "jaredgorthy@microsoft.com",
                        "CreatedByType": "User",
                        "CreatedAt": "2022-08-08T00:34:32.030751Z",
                        "LastModifiedBy": "jaredgorthy@microsoft.com",
                        "LastModifiedByType": "User",
                        "LastModifiedAt": "2022-08-08T01:19:40.2407843Z"
                      }
Name                : psRuleCollection
Etag                :
Id                  : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityUserConfigurations/psSecurityUserConfig/ruleCollections/psRuleCollection
```

Updates a network manager security user rule collection to include new network groups.

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

### -InputObject
The NetworkManagerSecurityUserRuleCollection

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserRuleCollection
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserRuleCollection

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserRuleCollection

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerSecurityUserRuleCollection](./Get-AzNetworkManagerSecurityUserRuleCollection.md)

[New-AzNetworkManagerSecurityUserRuleCollection](./New-AzNetworkManagerSecurityUserRuleCollection.md)

[Remove-AzNetworkManagerSecurityUserRuleCollection](./Remove-AzNetworkManagerSecurityUserRuleCollection.md)