---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualnetworkgatewaymigrationparameter
schema: 2.0.0
---

# New-AzVirtualNetworkGatewayMigrationParameter

## SYNOPSIS
Create migration parameters to trigger prepare migration for a virtual network gateway.

## SYNTAX

```
New-AzVirtualNetworkGatewayMigrationParameter -MigrationType <String> [-ResourceUrl <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Create migration parameters to trigger prepare migration for a virtual network gateway.

## EXAMPLES

### Example 1
```powershell
New-AzVirtualNetworkGatewayMigrationParameter -MigrationType UpgradeDeploymentToStandardIP
```

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

### -MigrationType
The migration type for the virtual network gateway.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: UpgradeDeploymentToStandardIP

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUrl
Reference to public IP resource url

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.Network.Models.PSVirtualNetworkGatewayMigrationParameters

## NOTES

## RELATED LINKS

[Invoke-AzVirtualNetworkGatewayPrepareMigration](./Invoke-AzVirtualNetworkGatewayPrepareMigration.md)
