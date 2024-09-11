---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanagerroutingrule
schema: 2.0.0
---

# Get-AzNetworkManagerRoutingRule

## SYNOPSIS
Gets a routing rule in a network manager.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerRoutingRule [-Name <String>] -RuleCollectionName <String>
 -RoutingConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerRoutingRule -Name <String> -RuleCollectionName <String>
 -RoutingConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerRoutingRule** cmdlets gets a routing rule in a network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerRoutingRule  -Name "testRule" -RuleCollectionName "TestRC" -RoutingConfigurationName "TestRoutingConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

```output
Name                  : testRule
Description           : Description
Type                  : Microsoft.Network/networkManagers/routingConfigurations/ruleCollections/rules
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/routingConfigurations/TestRoutingConfig/ruleCollections/TestRC/rules/testRule
Etag                  : "00000000-0000-0000-0000-000000000000"
ProvisioningState     : Succeeded
NextHop               : {
                            "NextHopAddress": "ApiManagement",
                            "NextHopType": "ServiceTag"
                        }
Destination           : {
                            "DestinationAddress": "10.0.0.1",
                            "Type": "AddressPrefix"
                        }
SystemData            : {
                          "CreatedBy": "00000000-0000-0000-0000-000000000000",
                          "CreatedByType": "Application",
                          "CreatedAt": "2021-10-18T04:06:05",
                          "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                          "LastModifiedByType": "Application",
                          "LastModifiedAt": "2021-10-18T04:06:06"
                        }
```

Gets a routing rule in a rule rollection.

### Example 2
```powershell
Get-AzNetworkManagerRoutingRule  -RuleCollectionName "TestRC" -RoutingConfigurationName "TestRoutingConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

```output
Name                  : testRule
Description           : Description
Type                  : Microsoft.Network/networkManagers/routingConfigurations/ruleCollections/rules
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/routingConfigurations/TestRoutingConfig/ruleCollections/TestRC/rules/testRule
Etag                  : "00000000-0000-0000-0000-000000000000"
ProvisioningState     : Succeeded
NextHop               : {
                            "NextHopAddress": "ApiManagement",
                            "NextHopType": "ServiceTag"
                        }
Destination           : {
                            "DestinationAddress": "10.0.0.1",
                            "Type": "AddressPrefix"
                        }
SystemData            : {
                          "CreatedBy": "00000000-0000-0000-0000-000000000000",
                          "CreatedByType": "Application",
                          "CreatedAt": "2021-10-18T04:06:05",
                          "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                          "LastModifiedByType": "Application",
                          "LastModifiedAt": "2021-10-18T04:06:06"
                        }

Name                  : testRule2
Description           : Description
Type                  : Microsoft.Network/networkManagers/routingConfigurations/ruleCollections/rules
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/routingConfigurations/TestRoutingConfig/ruleCollections/TestRC/rules/testRule2
Etag                  : "00000000-0000-0000-0000-000000000000"
ProvisioningState     : Succeeded
NextHop               : {
                            "NextHopAddress": "ApiManagement",
                            "NextHopType": "ServiceTag"
                        }
Destination           : {
                            "DestinationAddress": "20.0.0.1",
                            "Type": "AddressPrefix"
                        }
SystemData            : {
                          "CreatedBy": "00000000-0000-0000-0000-000000000000",
                          "CreatedByType": "Application",
                          "CreatedAt": "2021-10-18T04:06:05",
                          "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                          "LastModifiedByType": "Application",
                          "LastModifiedAt": "2021-10-18T04:06:06"
                        }
```

Gets all rules within a routing rule collection.

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
Parameter Sets: NoExpand
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

```yaml
Type: System.String
Parameter Sets: Expand
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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

### -RuleCollectionName
The network manager routing rule collection name.

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

### -RoutingConfigurationName
The network manager routing configuration name.

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRule

## NOTES

## RELATED LINKS

[New-AzNetworkManagerRoutingRule](./New-AzNetworkManagerRoutingRule.md)

[Remove-AzNetworkManagerRoutingRule](./Remove-AzNetworkManagerRoutingRule.md)

[Set-AzNetworkManagerRoutingRule](./Set-AzNetworkManagerRoutingRule.md)