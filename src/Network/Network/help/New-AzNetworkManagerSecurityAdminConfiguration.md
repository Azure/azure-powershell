---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagersecurityadminconfiguration
schema: 2.0.0
---

# New-AzNetworkManagerSecurityAdminConfiguration

## SYNOPSIS
Creates a security admin configuration.

## SYNTAX

```
New-AzNetworkManagerSecurityAdminConfiguration -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> [-Description <String>]
 [-ApplyOnNetworkIntentPolicyBasedService <NetworkIntentPolicyBasedServiceType[]>] [-NetworkGroupAddressSpaceAggregationOption <String>][-DeleteExistingNSG]
 [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerSecurityAdminConfiguration** cmdlet creates a security admin configuration.

## EXAMPLES

### Example 1
```powershell
$ApplyOnNetworkIntentPolicyBasedService = @("None")
New-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager" -Name "psSecurityAdminConfig" -Description "TestDescription" -DeleteExistingNSG  -ApplyOnNetworkIntentPolicyBasedService $ApplyOnNetworkIntentPolicyBasedService -NetworkGroupAddressSpaceAggregationOption $NetworkGroupAddressSpaceAggregationOption
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
                                                "LastModifiedAt": "2022-08-07T23:59:12.5789979Z"
                                              }
Name                                        : psSecurityAdminConfig
Etag                                        :
Id                                          : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityAdminConfigurations/psSecurityAdminConfig
```

Creates a security admin configuration that will delete existing NSGs and not apply on NIP based services.

### Example 2
```powershell
$ApplyOnNetworkIntentPolicyBasedService = @("All")
New-AzNetworkManagerSecurityAdminConfiguration -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager" -Name "psSecurityAdminConfig" -Description "TestDescription" -ApplyOnNetworkIntentPolicyBasedService $ApplyOnNetworkIntentPolicyBasedService
```

```output
SecurityType                                :
ApplyOnNetworkIntentPolicyBasedServices     : {All}
ApplyOnNetworkIntentPolicyBasedServicesText : [
                                                "All"
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
                                                "LastModifiedAt": "2022-08-08T00:01:21.391989Z"
                                              }
Name                                        : psSecurityAdminConfig
Etag                                        :
Id                                          : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityAdminConfigurations/psSecurityAdminConfig
```

Creates a security admin configuration that will apply on NIP based services.

## PARAMETERS

### -ApplyOnNetworkIntentPolicyBasedService
ApplyOnNetworkIntentPolicyBasedServices.

```yaml
Type: Microsoft.Azure.Commands.Network.NewAzNetworkManagerSecurityAdminConfigurationCommand+NetworkIntentPolicyBasedServiceType[]
Parameter Sets: (All)
Aliases:
Accepted values: None, All, AllowRulesOnly

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -DeleteExistingNSG
DeleteExistingNSGs Flag.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Description
Description.

```yaml
Type: System.String
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
Type: System.Management.Automation.SwitchParameter
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
Type: System.String
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
Accept wildcard characters: True
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

### System.String[]

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityAdminConfiguration

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerSecurityAdminConfiguration](./Get-AzNetworkManagerSecurityAdminConfiguration.md)

[Remove-AzNetworkManagerSecurityAdminConfiguration](./Remove-AzNetworkManagerSecurityAdminConfiguration.md)

[Set-AzNetworkManagerSecurityAdminConfiguration](./Set-AzNetworkManagerSecurityAdminConfiguration.md)