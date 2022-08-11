---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/set-aznetworkmanagersecurityadminconfiguration
schema: 2.0.0
---

# Set-AzNetworkManagerSecurityAdminConfiguration

## SYNOPSIS
Updates a network manager security admin configuration.

## SYNTAX

```
Set-AzNetworkManagerSecurityAdminConfiguration
 -InputObject <PSNetworkManagerSecurityAdminConfiguration> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerSecurityAdminConfiguration** cmdlet updates a network manager security admin configuration.

## EXAMPLES

### Example 1
```powershell
$NetworkManagerSecurityConfiguration = Get-AzNetworkManagerSecurityAdminConfiguration  -Name "psSecurityAdminConfig" -NetworkManagerName "psNetworkManager" -ResourceGroupName "psResourceGroup"
$NetworkManagerSecurityConfiguration.applyOnNetworkIntentPolicyBasedServices = @("None")
Set-AzNetworkManagerSecurityAdminConfiguration -InputObject $NetworkManagerSecurityConfiguration
```
```output
SecurityType                                :
ApplyOnNetworkIntentPolicyBasedServices     : {None}
ApplyOnNetworkIntentPolicyBasedServicesText : [
                                                "None"
                                              ]
DeleteExistingNSGs                          :
DisplayName                                 :
Description                                 : TestDescription
Type                                        : Microsoft.Network/networkManagers/securityAdminConfigurations
ProvisioningState                           : Succeeded
SystemData                                  : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText                              : {
                                                "CreatedBy": "jaredgorthy@microsoft.com",
                                                "CreatedByType": "User",
                                                "CreatedAt": "2022-08-07T23:58:54.8549506Z",
                                                "LastModifiedBy": "jaredgorthy@microsoft.com",
                                                "LastModifiedByType": "User",
                                                "LastModifiedAt": "2022-08-08T01:14:53.4574151Z"
                                              }
Name                                        : psSecurityAdminConfig
Etag                                        :
Id                                          : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityAdminConfigurations/psSecurityAdminConfig
```
Updates a network manager security admin configuration apply on network intent policy based services property.

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

### -InputObject
The NetworkManagerSecurityAdminConfiguration

```yaml
Type: PSNetworkManagerSecurityAdminConfiguration
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityAdminConfiguration

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityAdminConfiguration

## NOTES

## RELATED LINKS
[Get-AzNetworkManagerSecurityAdminConfiguration](./Get-AzNetworkManagerSecurityAdminConfiguration.md)

[New-AzNetworkManagerSecurityAdminConfiguration](./New-AzNetworkManagerSecurityAdminConfiguration.md)

[Remove-AzNetworkManagerSecurityAdminConfiguration](./Remove-AzNetworkManagerSecurityAdminConfiguration.md)