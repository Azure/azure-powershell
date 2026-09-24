---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-azexpressroutecrossconnectionmigration
schema: 2.0.0
---

# Invoke-AzExpressRouteCrossConnectionMigration

## SYNOPSIS
Invokes the migration action for a provider-owned ExpressRoute cross-connection.

## SYNTAX

### ByName (Default)
```
Invoke-AzExpressRouteCrossConnectionMigration [-PortId <String>] [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -Name <String> -ResourceGroupName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByInputObject
```
Invoke-AzExpressRouteCrossConnectionMigration [-PortId <String>] [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -InputObject <PSExpressRouteCrossConnection>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByResourceId
```
Invoke-AzExpressRouteCrossConnectionMigration [-PortId <String>] [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The Invoke-AzExpressRouteCrossConnectionMigration cmdlet invokes the migrateCircuit service action. It executes only this action, not an end-to-end migration workflow. Preparation, BGP (Border Gateway Protocol) shutdown or restoration, health checks, commit, and rollback remain separate commands governed by the provider runbook.

This operation can affect connectivity. Use an approved maintenance window and provider-authorized Azure context. Optional PortId, TargetPeeringLocation, and TargetPortMapping values are passed to the service without inferring migration phase requirements. The command prompts for confirmation and returns the final health response after polling completes. Review FailureReason, ShouldRollback, and Details before proceeding; no recovery action is taken automatically.

ResourceId and InputObject must identify a provider cross-connection in the current subscription, not a customer circuit.

## EXAMPLES

### Example 1: Invoke migration for a selected port
```powershell
Invoke-AzExpressRouteCrossConnectionMigration -ResourceGroupName 'provider-rg' -Name 'cross-connection' -PortId 'source-port'
```

Requests the migration action after confirmation for the provider-selected port. Run this action only after the service-specific prerequisites and health checks have been satisfied.

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

[Invoke-AzExpressRouteCrossConnectionPrepareMigration](Invoke-AzExpressRouteCrossConnectionPrepareMigration.md)
[Get-AzExpressRouteCrossConnectionMigrationInfo](Get-AzExpressRouteCrossConnectionMigrationInfo.md)
[Invoke-AzExpressRouteCrossConnectionCommitMigration](Invoke-AzExpressRouteCrossConnectionCommitMigration.md)
[Invoke-AzExpressRouteCrossConnectionRollbackMigration](Invoke-AzExpressRouteCrossConnectionRollbackMigration.md)
