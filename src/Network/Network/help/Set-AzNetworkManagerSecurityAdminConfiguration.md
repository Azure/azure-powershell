---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# Set-AzNetworkManagerSecurityAdminConfiguration

## SYNOPSIS
Updates a network manager security admin configuration.

## SYNTAX

```
Set-AzNetworkManagerSecurityAdminConfiguration -NetworkManagerName <String> -ResourceGroupName <String>
 -NetworkManagerSecurityAdminConfiguration <PSNetworkManagerSecurityAdminConfiguration> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerSecurityAdminConfiguration** cmdlet updates a network manager security admin configuration.

## EXAMPLES

### Example 1
```powershell
PS C:\> $NetworkManagerSecurityConfiguration = Get-AzNetworkManagerSecurityAdminConfiguration  -Name "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRGName"
PS C:\> Set-AzNetworkManagerSecurityAdminConfiguration -NetworkManagerName TestNMName -ResourceGroupName TestRGName -NetworkManagerSecurityAdminConfiguration $NetworkManagerSecurityConfiguration
```

Updates a network manager security admin configuration.

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

### -NetworkManagerSecurityAdminConfiguration
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