---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-azexpressroutecrossconnectionpreparemigration
schema: 2.0.0
---

# Invoke-AzExpressRouteCrossConnectionPrepareMigration

## SYNOPSIS
Prepares a provider-owned ExpressRoute cross-connection for migration.

## SYNTAX

### ByName (Default)
```
Invoke-AzExpressRouteCrossConnectionPrepareMigration [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -Name <String> -ResourceGroupName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByInputObject
```
Invoke-AzExpressRouteCrossConnectionPrepareMigration [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -InputObject <PSExpressRouteCrossConnection>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByResourceId
```
Invoke-AzExpressRouteCrossConnectionPrepareMigration [-TargetPeeringLocation <String>]
 [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>] -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The Invoke-AzExpressRouteCrossConnectionPrepareMigration cmdlet invokes the service's preparation action and returns the completed migration health result. Supply target location and port mappings as required by the provider's approved migration runbook. These fields are optional in the API request; the service determines whether the current migration state permits the action.

Review PreparedAt, PrepareExpiryTime, FailureReason, ShouldRollback, and Details in the response before proceeding. This command does not shut down BGP (Border Gateway Protocol), migrate, or commit automatically. It prompts for confirmation and supports WhatIf and AsJob. Use a provider-authorized context and a cross-connection in its current subscription.

## EXAMPLES

### Example 1: Prepare a migration with explicit target inputs
```powershell
$mapping = New-AzExpressRouteCrossConnectionPortMapping -SourcePortId 'source-port' -TargetPortId 'target-port'
Invoke-AzExpressRouteCrossConnectionPrepareMigration -ResourceGroupName 'provider-rg' -Name 'cross-connection' -TargetPeeringLocation 'Amsterdam' -TargetPortMapping $mapping
```

Requests preparation after confirmation. Use provider-supplied identifiers and review the returned health result and preparation expiry before any later action.

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

[Test-AzExpressRouteCrossConnectionMigration](Test-AzExpressRouteCrossConnectionMigration.md)
[Get-AzExpressRouteCrossConnectionMigrationInfo](Get-AzExpressRouteCrossConnectionMigrationInfo.md)
[New-AzExpressRouteCrossConnectionPortMapping](New-AzExpressRouteCrossConnectionPortMapping.md)
