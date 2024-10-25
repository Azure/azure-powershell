---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanagerroutingrulecollection
schema: 2.0.0
---

# Get-AzNetworkManagerRoutingRuleCollection

## SYNOPSIS
Gets a routing rule collection in a network manager.

## SYNTAX

### ByList (Default)
```
Get-AzNetworkManagerRoutingRuleCollection -RoutingConfigurationName <String> -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByName
```
Get-AzNetworkManagerRoutingRuleCollection -Name <String> -RoutingConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByResourceId
```
Get-AzNetworkManagerRoutingRuleCollection -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerRoutingRuleCollection** cmdlet gets a routing rule collection in a network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerRoutingRuleCollection  -Name "TestRC" -RoutingConfigurationName "TestRoutingConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

```output
Name              : TestRC
Description       : Sample rule Collection Description
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/routingConfigurations/TestRoutingConfig/ruleCollections/TestRC
Type              : Microsoft.Network/networkManagers/routingConfigurations/ruleCollections
Etag              : "00000000-0000-0000-0000-000000000000"
ProvisioningState : Succeeded
AppliesTo         : [
                      {
                        "NetworkGroupId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testng"
                      }
                    ]
DisableBgpRoutePropagation : "False"
SystemData        : {
                      "CreatedBy": "00000000-0000-0000-0000-000000000000",
                      "CreatedByType": "Application",
                      "CreatedAt": "2021-10-18T04:06:01",
                      "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                      "LastModifiedByType": "Application",
                      "LastModifiedAt": "2021-10-18T04:06:03"
                    }
```

Gets a rule collection within a routing configuration.

### Example 2
```powershell
Get-AzNetworkManagerRoutingRuleCollection  -RoutingConfigurationName "TestRoutingConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

```output
Name              : TestRC
Description       : Sample rule Collection Description
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/routingConfigurations/TestRoutingConfig/ruleCollections/TestRC
Type              : Microsoft.Network/networkManagers/routingConfigurations/ruleCollections
Etag              : "00000000-0000-0000-0000-000000000000"
ProvisioningState : Succeeded
AppliesTo         : [
                      {
                        "NetworkGroupId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testng"
                      }
                    ]
DisableBgpRoutePropagation : "False"
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
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/routingConfigurations/TestRoutingConfig/ruleCollections/TestRC2
Type              : Microsoft.Network/networkManagers/routingConfigurations/ruleCollections
Etag              : "00000000-0000-0000-0000-000000000000"
ProvisioningState : Succeeded
AppliesTo         : [
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

Gets all rule collections within a routing configuration.

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
NetworkManager RoutingCollection Id

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: RoutingCollectionId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RoutingConfigurationName
The network manager routing configuration name.

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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRuleCollection

## NOTES

## RELATED LINKS

[New-AzNetworkManagerRoutingRuleCollection](./New-AzNetworkManagerRoutingRuleCollection.md)

[Remove-AzNetworkManagerRoutingRuleCollection](./Remove-AzNetworkManagerRoutingRuleCollection.md)

[Set-AzNetworkManagerRoutingRuleCollection](./Set-AzNetworkManagerRoutingRuleCollection.md)