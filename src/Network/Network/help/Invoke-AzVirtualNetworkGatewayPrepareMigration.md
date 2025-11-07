---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-azvirtualnetworkgatewaypreparemigration
schema: 2.0.0
---

# Invoke-AzVirtualNetworkGatewayPrepareMigration

## SYNOPSIS
Trigger prepare migration for virtual network gateway.

## SYNTAX

### ByName (Default)
```
Invoke-AzVirtualNetworkGatewayPrepareMigration -Name <String> -ResourceGroupName <String>
 -MigrationParameter <PSVirtualNetworkGatewayMigrationParameters> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByInputObject
```
Invoke-AzVirtualNetworkGatewayPrepareMigration -InputObject <PSVirtualNetworkGateway>
 -MigrationParameter <PSVirtualNetworkGatewayMigrationParameters> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceId
```
Invoke-AzVirtualNetworkGatewayPrepareMigration -ResourceId <String>
 -MigrationParameter <PSVirtualNetworkGatewayMigrationParameters> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Prepare migration for virtual network gateway.

## EXAMPLES

### Example 1
```powershell
$gateway = Get-AzVirtualNetworkGateway -Name "ContosoVirtualGateway" -ResourceGroupName "RGName" 
$migrationParams = New-AzVirtualNetworkGatewayMigrationParameter -MigrationType UpgradeDeploymentToStandardIP
Invoke-AzVirtualNetworkGatewayPrepareMigration -InputObject $gateway -MigrationParameter $migrationParams
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

### -InputObject
The virtualNetworkGateway

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGateway
Parameter Sets: ByInputObject
Aliases: VirtualNetworkGateway

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MigrationParameter
Migration parameters to be passed to invoke prepare migration

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGatewayMigrationParameters
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The virtual network gateway name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Azure resource ID of the virtual network gateway.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGateway

### Microsoft.Azure.Management.Network.Models.PSVirtualNetworkGatewayMigrationParameters

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGateway

## NOTES

## RELATED LINKS

[Get-AzVirtualNetworkGateway](./Get-AzVirtualNetworkGateway.md)

[Invoke-AzVirtualNetworkGatewayAbortMigration](./Invoke-AzVirtualNetworkGatewayAbortMigration.md)

[Invoke-AzVirtualNetworkGatewayExecuteMigration](./Invoke-AzVirtualNetworkGatewayExecuteMigration.md)

[Invoke-AzVirtualNetworkGatewayCommitMigration](./Invoke-AzVirtualNetworkGatewayCommitMigration.md)
