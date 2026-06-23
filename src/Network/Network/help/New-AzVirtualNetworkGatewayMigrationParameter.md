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

### Example 1: Create migration parameters for upgrading to standard IP
```powershell
New-AzVirtualNetworkGatewayMigrationParameter -MigrationType UpgradeDeploymentToStandardIP
```

Creates migration parameters to upgrade the virtual network gateway deployment from basic IP to standard IP.

### Example 2: Create migration parameters for upgrading to dual stack
```powershell
New-AzVirtualNetworkGatewayMigrationParameter -MigrationType UpgradeGatewayToDualStack
```

Creates migration parameters to upgrade the virtual network gateway to dual stack (IPv4 + IPv6).

### Example 3: Create migration parameters for point-to-site profile migration
```powershell
New-AzVirtualNetworkGatewayMigrationParameter -MigrationType MigrateGatewayForPointToSiteProfile
```

Creates migration parameters to migrate the virtual network gateway point-to-site profile.

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
Accepted values: UpgradeDeploymentToStandardIP, UpgradeGatewayToDualStack, MigrateGatewayForPointToSiteProfile

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
