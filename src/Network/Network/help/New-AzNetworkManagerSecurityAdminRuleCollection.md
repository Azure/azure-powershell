---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanagersecurityadminrulecollection
schema: 2.0.0
---

# New-AzNetworkManagerSecurityAdminRuleCollection

## SYNOPSIS
Creates a security admin rule collection.

## SYNTAX

```
New-AzNetworkManagerSecurityAdminRuleCollection -Name <String> -SecurityAdminConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> [-Description <String>]
 -AppliesToGroup <Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem[]>
 [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerSecurityAdminConfiguration** cmdlet creates a security admin rule collection.

## EXAMPLES

### Example 1
```powershell
$groupItem = New-AzNetworkManagerSecurityGroupItem -NetworkGroupId "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup"
$configGroup = @($groupItem) 
New-AzNetworkManagerSecurityAdminRuleCollection -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager" -ConfigName "psSecurityAdminConfig" -Name "psRuleCollection" -AppliesToGroup $configGroup 
```
```output
AppliesToGroups     : {/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup}
AppliesToGroupsText : [
                        {
                          "NetworkGroupId":
                      "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup"
                        }
                      ]
DisplayName         :
Description         :
Type                : Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections
ProvisioningState   : Succeeded
SystemData          : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText      : {
                        "CreatedBy": "jaredgorthy@microsoft.com",
                        "CreatedByType": "User",
                        "CreatedAt": "2022-08-08T00:34:32.030751Z",
                        "LastModifiedBy": "jaredgorthy@microsoft.com",
                        "LastModifiedByType": "User",
                        "LastModifiedAt": "2022-08-08T00:34:32.030751Z"
                      }
Name                : psRuleCollection
Etag                :
Id                  : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityAdminConfigurations/psSecurityAdminConfig/ruleCollections/psRuleCollection
```
Creates a security admin rule collection with a network group member.

## PARAMETERS

### -AppliesToGroup
Applies To Groups.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem[]
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

### -SecurityAdminConfigurationName
The network manager security admin configuration name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ConfigName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityGroupItem[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityAdminRuleCollection

## NOTES

## RELATED LINKS
[New-AzNetworkManagerSecurityGroupItem](./New-AzNetworkManagerSecurityGroupItem.md)

[Get-AzNetworkManagerSecurityAdminRuleCollection](./Get-AzNetworkManagerSecurityAdminRuleCollection.md)

[Remove-AzNetworkManagerSecurityAdminRuleCollection](./Remove-AzNetworkManagerSecurityAdminRuleCollection.md)

[Set-AzNetworkManagerSecurityAdminRuleCollection](./Set-AzNetworkManagerSecurityAdminRuleCollection.md)