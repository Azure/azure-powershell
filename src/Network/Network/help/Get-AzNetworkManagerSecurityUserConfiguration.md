---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanagersecurityuserconfiguration
schema: 2.0.0
---

# Get-AzNetworkManagerSecurityUserConfiguration

## SYNOPSIS
Gets a network security user configuration in a network manager.

## SYNTAX

### ByList (Default)
```
Get-AzNetworkManagerSecurityUserConfiguration -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByName
```
Get-AzNetworkManagerSecurityUserConfiguration -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzNetworkManagerSecurityUserConfiguration -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerSecurityUserConfiguration** cmdlet gets a security user configuration in a network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerSecurityUserConfiguration  -Name "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

```output
Name               : TestSecConfig
Description        : Description
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityUserConfigurations/TestSecConfig
Type               : Microsoft.Network/networkManagers/securityUserConfigurations
Etag               : "00000000-0000-0000-0000-000000000000"
ProvisioningState  : Succeeded
SystemData         : {
                       "CreatedBy": "00000000-0000-0000-0000-000000000000",
                       "CreatedByType": "Application",
                       "CreatedAt": "2021-10-18T04:05:57",
                       "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                       "LastModifiedByType": "Application",
                       "LastModifiedAt": "2021-10-18T04:05:59"
                     }
```

Get a security user configuration.

### Example 2
```powershell
Get-AzNetworkManagerSecurityUserConfiguration -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

```output
Name               : TestSecConfig
Description        : Description
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityUserConfigurations/TestSecConfig
Type               : Microsoft.Network/networkManagers/securityUserConfigurations
Etag               : "00000000-0000-0000-0000-000000000000"
ProvisioningState  : Succeeded
SystemData         : {
                       "CreatedBy": "00000000-0000-0000-0000-000000000000",
                       "CreatedByType": "Application",
                       "CreatedAt": "2021-10-18T04:05:57",
                       "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                       "LastModifiedByType": "Application",
                       "LastModifiedAt": "2021-10-18T04:05:59"
                     }

                     Name               : TestSecConfig2
Description        : Description
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityUserConfigurations/TestSecConfig2
Type               : Microsoft.Network/networkManagers/securityUserConfigurations
Etag               : "00000000-0000-0000-0000-000000000000"
ProvisioningState  : Succeeded
SystemData         : {
                       "CreatedBy": "00000000-0000-0000-0000-000000000000",
                       "CreatedByType": "Application",
                       "CreatedAt": "2021-10-18T04:05:57",
                       "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                       "LastModifiedByType": "Application",
                       "LastModifiedAt": "2021-10-18T04:05:59"
                     }
```

Gets all security user configurations on a network manager.

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
NetworkManager SecurityUserConfiguration Id

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: SecurityUserConfigurationId

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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserConfiguration

## NOTES

## RELATED LINKS

[New-AzNetworkManagerSecurityUserConfiguration](./New-AzNetworkManagerSecurityUserConfiguration.md)

[Remove-AzNetworkManagerSecurityUserConfiguration](./Remove-AzNetworkManagerSecurityUserConfiguration.md)

[Set-AzNetworkManagerSecurityUserConfiguration](./Set-AzNetworkManagerSecurityUserConfiguration.md)
