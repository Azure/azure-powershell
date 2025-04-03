---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanagersecurityuserrulecollection
schema: 2.0.0
---

# Get-AzNetworkManagerSecurityUserRuleCollection

## SYNOPSIS
Gets a security user rule collection in a network manager.

## SYNTAX

### ByList (Default)
```
Get-AzNetworkManagerSecurityUserRuleCollection -SecurityUserConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByName
```
Get-AzNetworkManagerSecurityUserRuleCollection -Name <String> -SecurityUserConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByResourceId
```
Get-AzNetworkManagerSecurityUserRuleCollection -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerSecurityUserRuleCollection** cmdlet gets a security user rule collection in a network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerSecurityUserRuleCollection  -Name "TestRC" -SecurityUserConfigurationName "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

```output
Name              : TestRC
Description       : Sample rule Collection Description
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityUserConfigurations/TestSecConfig/ruleCollections/TestRC
Type              : Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections
Etag              : "00000000-0000-0000-0000-000000000000"
ProvisioningState : Succeeded
AppliesToGroups   : [
                      {
                        "NetworkGroupId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testng"
                      }
                    ]
SystemData        : {
                      "CreatedBy": "00000000-0000-0000-0000-000000000000",
                      "CreatedByType": "Application",
                      "CreatedAt": "2021-10-18T04:06:01",
                      "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                      "LastModifiedByType": "Application",
                      "LastModifiedAt": "2021-10-18T04:06:03"
                    }
```

Gets a rule collection with a security user configuration.

### Example 2
```powershell
Get-AzNetworkManagerSecurityUserRuleCollection  -SecurityUserConfigurationName "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

```output
Name              : TestRC
Description       : Sample rule Collection Description
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityUserConfigurations/TestSecConfig/ruleCollections/TestRC
Type              : Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections
Etag              : "00000000-0000-0000-0000-000000000000"
ProvisioningState : Succeeded
AppliesToGroups   : [
                      {
                        "NetworkGroupId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testng"
                      }
                    ]
SystemData        : {
                      "CreatedBy": "00000000-0000-0000-0000-000000000000",
                      "CreatedByType": "Application",
                      "CreatedAt": "2021-10-18T04:06:01",
                      "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                      "LastModifiedByType": "Application",
                      "LastModifiedAt": "2021-10-18T04:06:03"
                    }

                    Name              : TestRC2
Description       : Sample rule Collection Description
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityUserConfigurations/TestSecConfig/ruleCollections/TestRC2
Type              : Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections
Etag              : "00000000-0000-0000-0000-000000000000"
ProvisioningState : Succeeded
AppliesToGroups   : [
                      {
                        "NetworkGroupId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testng"
                      }
                    ]
SystemData        : {
                      "CreatedBy": "00000000-0000-0000-0000-000000000000",
                      "CreatedByType": "Application",
                      "CreatedAt": "2021-10-18T04:06:01",
                      "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                      "LastModifiedByType": "Application",
                      "LastModifiedAt": "2021-10-18T04:06:03"
                    }
```

Gets all rule collections within a security user configuration.

## PARAMETERS

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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByName
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
Type: System.String
Parameter Sets: ByList, ByName
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
Parameter Sets: ByList, ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceId
NetworkManager SecurityUserCollection Id

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: SecurityUserCollectionId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SecurityUserConfigurationName
The network manager security user configuration name.

```yaml
Type: System.String
Parameter Sets: ByList, ByName
Aliases: ConfigName

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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserRuleCollection

## NOTES

## RELATED LINKS

[New-AzNetworkManagerSecurityUserRuleCollection](./New-AzNetworkManagerSecurityUserRuleCollection.md)

[Remove-AzNetworkManagerSecurityUserRuleCollection](./Remove-AzNetworkManagerSecurityUserRuleCollection.md)

[Set-AzNetworkManagerSecurityUserRuleCollection](./Set-AzNetworkManagerSecurityUserRuleCollection.md)