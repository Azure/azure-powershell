---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-azexpressroutecrossconnectioncommitmigration
schema: 2.0.0
---

# Invoke-AzExpressRouteCrossConnectionCommitMigration

## SYNOPSIS
Commits a provider-led ExpressRoute cross-connection migration.

## SYNTAX

### ByName (Default)
```
Invoke-AzExpressRouteCrossConnectionCommitMigration [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -Name <String> -ResourceGroupName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByInputObject
```
Invoke-AzExpressRouteCrossConnectionCommitMigration [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -InputObject <PSExpressRouteCrossConnection>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByResourceId
```
Invoke-AzExpressRouteCrossConnectionCommitMigration [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The Invoke-AzExpressRouteCrossConnectionCommitMigration cmdlet invokes the service's commit action and returns the final migration health response. Commit only after the provider's required migration steps, connectivity checks, and health checks are complete. Do not assume rollback remains available after commit; follow the provider's documented eligibility rules.

The command prompts for confirmation and supports WhatIf and AsJob. TargetPeeringLocation and TargetPortMapping are optional API fields. This action has no PortId parameter and does not automatically restore BGP (Border Gateway Protocol) or perform other migration steps. ResourceId and InputObject must identify a cross-connection in the current subscription of a provider-authorized Azure context.

## EXAMPLES

### Example 1: Commit a migration after provider health checks
```powershell
Invoke-AzExpressRouteCrossConnectionCommitMigration -ResourceId '/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/provider-rg/providers/Microsoft.Network/expressRouteCrossConnections/cross-connection'
```

Requests commit after confirmation. The sample resource ID must be replaced with the provider cross-connection ID in the selected subscription.

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

[Get-AzExpressRouteCrossConnectionMigrationInfo](Get-AzExpressRouteCrossConnectionMigrationInfo.md)
[Invoke-AzExpressRouteCrossConnectionRollbackMigration](Invoke-AzExpressRouteCrossConnectionRollbackMigration.md)
