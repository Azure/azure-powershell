---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-azexpressroutecrossconnectionrestorebgpformigration
schema: 2.0.0
---

# Invoke-AzExpressRouteCrossConnectionRestoreBgpForMigration

## SYNOPSIS
Restores BGP for a provider-led ExpressRoute cross-connection migration.

## SYNTAX

### ByName (Default)
```
Invoke-AzExpressRouteCrossConnectionRestoreBgpForMigration [-PortId <String>] [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -Name <String> -ResourceGroupName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByInputObject
```
Invoke-AzExpressRouteCrossConnectionRestoreBgpForMigration [-PortId <String>] [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -InputObject <PSExpressRouteCrossConnection>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByResourceId
```
Invoke-AzExpressRouteCrossConnectionRestoreBgpForMigration [-PortId <String>] [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The Invoke-AzExpressRouteCrossConnectionRestoreBgpForMigration cmdlet invokes the service action to restore BGP (Border Gateway Protocol) during migration. Follow the provider runbook for the correct port identifier, phase, and health checks. This action changes routing state and requires confirmation by default.

The command accepts optional PortId, TargetPeeringLocation, and TargetPortMapping values, waits for the service operation to complete, and returns typed migration health information. It does not commit or roll back the migration. Review the returned status and per-port metrics before proceeding. Use a provider-authorized Azure context; resource IDs and input objects must belong to its current subscription.

## EXAMPLES

### Example 1: Restore BGP for a provider-selected port
```powershell
Invoke-AzExpressRouteCrossConnectionRestoreBgpForMigration -ResourceGroupName 'provider-rg' -Name 'cross-connection' -PortId 'target-port'
```

Requests BGP restoration after confirmation. Replace the port identifier with the one required by the provider for the current migration phase.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -AsJob
Run the command in the background.

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

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
The cross-connection to migrate.

```yaml
Type: PSExpressRouteCrossConnection
Parameter Sets: ByInputObject
Aliases: ExpressRouteCrossConnection

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The cross-connection name.

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PortId
The provider port identifier for this migration action.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group containing the cross-connection.

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The cross-connection resource ID in the current subscription.

```yaml
Type: String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetPeeringLocation
The target peering location for this migration action.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetPortMapping
The source-to-target port mappings created with New-AzExpressRouteCrossConnectionPortMapping.

```yaml
Type: PSExpressRouteCrossConnectionPortMapping[]
Parameter Sets: (All)
Aliases:

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCrossConnection

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuitMigrationResult

## NOTES

## RELATED LINKS

[Invoke-AzExpressRouteCrossConnectionShutDownBgpForMigration](Invoke-AzExpressRouteCrossConnectionShutDownBgpForMigration.md)
[Get-AzExpressRouteCrossConnectionMigrationInfo](Get-AzExpressRouteCrossConnectionMigrationInfo.md)
