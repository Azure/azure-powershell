---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagersecurityuserrule
schema: 2.0.0
---

# Get-AzNetworkManagerSecurityUserRule

## SYNOPSIS
Gets a security user rule in a network manager.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerSecurityUserRule [-Name <String>] -RuleCollectionName <String>
 -SecurityUserConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerSecurityUserRule -Name <String> -RuleCollectionName <String>
 -SecurityUserConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerSecurityUserRule** cmdlet gets a security user rule in a network manager.

## EXAMPLES

### Example 1
```powershell
Expand
PS C:\> Get-AzNetworkManagerSecurityUserRule  -Name "testRule" -RuleCollectionName "TestRC" -SecurityAdminConfigurationName "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

### Example 2
```powershell
NoExpand
PS C:\> Get-AzNetworkManagerSecurityUserRule  -RuleCollectionName "TestRC" -SecurityAdminConfigurationName "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

{{ Add example description here }}

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
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Expand
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
The network manager security user rule collection name.

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

### -SecurityUserConfigurationName
The network manager security user configuration name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseUserRule

## NOTES

## RELATED LINKS

[New-AzNetworkManagerSecurityUserRule](./New-AzNetworkManagerSecurityUserRule.md)

[Remove-AzNetworkManagerSecurityUserRule](./Remove-AzNetworkManagerSecurityUserRule.md)

[Set-AzNetworkManagerSecurityUserRule](./Set-AzNetworkManagerSecurityUserRule.md)