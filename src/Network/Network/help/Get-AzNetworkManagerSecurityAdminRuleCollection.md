---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagersecurityadminrulecollection
schema: 2.0.0
---

# Get-AzNetworkManagerSecurityAdminRuleCollection

## SYNOPSIS
Gets a security admin rule collection in a network manager.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerSecurityAdminRuleCollection [-Name <String>] -SecurityAdminConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerSecurityAdminRuleCollection -Name <String> -SecurityAdminConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerSecurityAdminRuleCollection** cmdlet gets a security admin rule collection in a network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerSecurityAdminRuleCollection  -Name "TestRC" -SecurityAdminConfigurationName "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```
```output
Name              : TestRC
Description       : Sample rule Collection Description
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/TestSecConfig/ruleCollections/TestRC
Type              : Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections
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
Gets a rule collection with a security admin configuration.

### Example 2
```powershell
Get-AzNetworkManagerSecurityAdminRuleCollection  -SecurityAdminConfigurationName "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```
```output
Name              : TestRC
Description       : Sample rule Collection Description
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/TestSecConfig/ruleCollections/TestRC
Type              : Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections
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
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/TestSecConfig/ruleCollections/TestRC2
Type              : Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections
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
Gets all rule collections within a security admin configuration.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityAdminRuleCollection

## NOTES

## RELATED LINKS
[New-AzNetworkManagerSecurityAdminRuleCollection](./New-AzNetworkManagerSecurityAdminRuleCollection.md)

[Remove-AzNetworkManagerSecurityAdminRuleCollection](./Remove-AzNetworkManagerSecurityAdminRuleCollection.md)

[Set-AzNetworkManagerSecurityAdminRuleCollection](./Set-AzNetworkManagerSecurityAdminRuleCollection.md)