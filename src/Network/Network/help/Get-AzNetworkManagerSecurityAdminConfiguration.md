---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagersecurityadminconfiguration
schema: 2.0.0
---

# Get-AzNetworkManagerSecurityAdminConfiguration

## SYNOPSIS
Gets a network security admin configuration in a network manager.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerSecurityAdminConfiguration [-Name <String>] -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerSecurityAdminConfiguration -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerSecurityAdminConfiguration** cmdlet gets a security admin configuration in a network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerSecurityAdminConfiguration  -Name "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```
```output
Name               : TestSecConfig
Description        : DESCription
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/TestSecConfig
Type               : Microsoft.Network/networkManagers/securityAdminConfigurations
Etag               : "00000000-0000-0000-0000-000000000000"
ProvisioningState  : Succeeded
DeleteExistingNSGs :
ApplyOnNetworkIntentPolicyBasedServices:
SecurityType       :
SystemData         : {
                       "CreatedBy": "00000000-0000-0000-0000-000000000000",
                       "CreatedByType": "Application",
                       "CreatedAt": "2021-10-18T04:05:57",
                       "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                       "LastModifiedByType": "Application",
                       "LastModifiedAt": "2021-10-18T04:05:59"
                     }
```
Get a security admin configuration.

### Example 2
```powershell
Get-AzNetworkManagerSecurityAdminConfiguration -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```
```output
Name               : TestSecConfig
Description        : DESCription
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/TestSecConfig
Type               : Microsoft.Network/networkManagers/securityAdminConfigurations
Etag               : "00000000-0000-0000-0000-000000000000"
ProvisioningState  : Succeeded
DeleteExistingNSGs :
ApplyOnNetworkIntentPolicyBasedServices:
SecurityType       :
SystemData         : {
                       "CreatedBy": "00000000-0000-0000-0000-000000000000",
                       "CreatedByType": "Application",
                       "CreatedAt": "2021-10-18T04:05:57",
                       "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                       "LastModifiedByType": "Application",
                       "LastModifiedAt": "2021-10-18T04:05:59"
                     }

                     Name               : TestSecConfig2
Description        : DESCription
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/TestSecConfig2
Type               : Microsoft.Network/networkManagers/securityAdminConfigurations
Etag               : "00000000-0000-0000-0000-000000000000"
ProvisioningState  : Succeeded
DeleteExistingNSGs :
ApplyOnNetworkIntentPolicyBasedServices:
SecurityType       :
SystemData         : {
                       "CreatedBy": "00000000-0000-0000-0000-000000000000",
                       "CreatedByType": "Application",
                       "CreatedAt": "2021-10-18T04:05:57",
                       "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                       "LastModifiedByType": "Application",
                       "LastModifiedAt": "2021-10-18T04:05:59"
                     }
```
Gets all security admin configurations on a network manager.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityAdminConfiguration

## NOTES

## RELATED LINKS
[New-AzNetworkManagerSecurityAdminConfiguration](./New-AzNetworkManagerSecurityAdminConfiguration.md)

[Remove-AzNetworkManagerSecurityAdminConfiguration](./Remove-AzNetworkManagerSecurityAdminConfiguration.md)

[Set-AzNetworkManagerSecurityAdminConfiguration](./Set-AzNetworkManagerSecurityAdminConfiguration.md)
