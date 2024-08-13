---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-aznetworkmanagersecurityuserconfiguration
schema: 2.0.0
---

# Set-AzNetworkManagerSecurityUserConfiguration

## SYNOPSIS
Updates a network manager security user configuration.

## SYNTAX

```
Set-AzNetworkManagerSecurityUserConfiguration -InputObject <PSNetworkManagerSecurityUserConfiguration>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerSecurityUserConfiguration** cmdlet updates a network manager security user configuration.

## EXAMPLES

### Example 1
```powershell
$NetworkManagerSecurityConfiguration = Get-AzNetworkManagerSecurityUserConfiguration  -Name "psSecurityUserConfig" -NetworkManagerName "psNetworkManager" -ResourceGroupName "psResourceGroup"
Set-AzNetworkManagerSecurityUserConfiguration -InputObject $NetworkManagerSecurityConfiguration
```

```output
DisplayName                                 :
Description                                 : TestDescription
Type                                        : Microsoft.Network/networkManagers/securityUserConfigurations
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
Name                                        : psSecurityUserConfig
Etag                                        :
Id                                          : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityUserConfigurations/psSecurityUserConfig
```

Updates a network manager security user configuration.

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
The NetworkManagerSecurityUserConfiguration

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserConfiguration
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserConfiguration

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserConfiguration

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerSecurityUserConfiguration](./Get-AzNetworkManagerSecurityUserConfiguration.md)

[New-AzNetworkManagerSecurityUserConfiguration](./New-AzNetworkManagerSecurityUserConfiguration.md)

[Remove-AzNetworkManagerSecurityUserConfiguration](./Remove-AzNetworkManagerSecurityUserConfiguration.md)