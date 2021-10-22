---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/set-aznetworkmanagersecurityadminrulecollection
schema: 2.0.0
---

# Set-AzNetworkManagerSecurityAdminRuleCollection

## SYNOPSIS
Updates a network manager security admin rule collection.

## SYNTAX

```
Set-AzNetworkManagerSecurityAdminRuleCollection -SecurityAdminConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String>
 -NetworkManagerSecurityAdminRuleCollection <PSNetworkManagerSecurityRuleCollection> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerSecurityAdminRuleCollection** cmdlet updates a network manager security admin rule collection.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-AzNetworkManagerSecurityAdminRuleCollection -SecurityAdminConfigurationName TestSecurityAdminConfigurationName -NetworkManagerName TestNMName -ResourceGroupName TestRGName -NetworkManagerSecurityAdminRuleCollection $NetworkManagerSecurityAdminRuleCollection
```

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
Accept wildcard characters: False
```

### -NetworkManagerSecurityAdminRuleCollection
The NetworkManagerSecurityAdminRuleCollection

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityRuleCollection
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -SecurityAdminConfigurationName
The network manager security admin configuration name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ConfigName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityRuleCollection

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityRuleCollection

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerSecurityAdminRuleCollection](./Get-AzNetworkManagerSecurityAdminRuleCollection.md)

[New-AzNetworkManagerSecurityAdminRuleCollection](./New-AzNetworkManagerSecurityAdminRuleCollection.md)

[Remove-AzNetworkManagerSecurityAdminRuleCollection](./Remove-AzNetworkManagerSecurityAdminRuleCollection.md)