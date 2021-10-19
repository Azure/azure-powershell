---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagersecurityuserconfiguration
schema: 2.0.0
---

# Get-AzNetworkManagerSecurityUserConfiguration

## SYNOPSIS
Gets a security user configuration in a network manager.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerSecurityUserConfiguration [-Name <String>] -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerSecurityUserConfiguration -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerSecurityUserConfiguration** cmdlet gets a security user configuration in a network manager.

## EXAMPLES

### Example 1
### Example 1
```powershell
Expand
PS C:\> Get-AzNetworkManagerSecurityUserConfiguration  -Name "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

### Example 2
```powershell
NoExpand
PS C:\> Get-AzNetworkManagerSecurityUserConfiguration -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityConfiguration

## NOTES

## RELATED LINKS

[New-AzNetworkManagerSecurityUserConfiguration](./New-AzNetworkManagerSecurityUserConfiguration.md)

[Remove-AzNetworkManagerSecurityUserConfiguration](./Remove-AzNetworkManagerSecurityUserConfiguration.md)

[Set-AzNetworkManagerSecurityUserConfiguration](./Set-AzNetworkManagerSecurityUserConfiguration.md)