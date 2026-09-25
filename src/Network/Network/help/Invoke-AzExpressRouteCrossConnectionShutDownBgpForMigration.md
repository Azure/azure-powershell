---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-azexpressroutecrossconnectionshutdownbgpformigration
schema: 2.0.0
---

# Invoke-AzExpressRouteCrossConnectionShutDownBgpForMigration

## SYNOPSIS
Shuts down BGP for a provider-led ExpressRoute cross-connection migration.

## SYNTAX

### ByName (Default)
```
Invoke-AzExpressRouteCrossConnectionShutDownBgpForMigration [-PortId <String>]
 [-TargetPeeringLocation <String>] [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>]
 -Name <String> -ResourceGroupName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

### ByInputObject
```
Invoke-AzExpressRouteCrossConnectionShutDownBgpForMigration [-PortId <String>]
 [-TargetPeeringLocation <String>] [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>]
 -InputObject <PSExpressRouteCrossConnection> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

### ByResourceId
```
Invoke-AzExpressRouteCrossConnectionShutDownBgpForMigration [-PortId <String>]
 [-TargetPeeringLocation <String>] [-TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]>]
 -ResourceId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The Invoke-AzExpressRouteCrossConnectionShutDownBgpForMigration cmdlet requests BGP (Border Gateway Protocol) shutdown for migration. This operation can disrupt connectivity. Run it only against an authorized provider cross-connection during the approved maintenance window and at the point specified by the provider runbook.

PortId, TargetPeeringLocation, and TargetPortMapping are optional API fields; supply the values required for the service's current migration state. The command prompts for confirmation, waits for completion, and returns the full health result. It does not migrate the circuit or restore BGP automatically. ResourceId and InputObject must refer to the current subscription.

## EXAMPLES

### Example 1: Preview BGP shutdown for a selected port
```powershell
Invoke-AzExpressRouteCrossConnectionShutDownBgpForMigration -ResourceGroupName 'provider-rg' -Name 'cross-connection' -PortId 'source-port' -WhatIf
```

Shows the intended target without sending a migration request. Remove WhatIf only when the provider runbook authorizes shutdown; the command then asks for confirmation.

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

[Invoke-AzExpressRouteCrossConnectionRestoreBgpForMigration](Invoke-AzExpressRouteCrossConnectionRestoreBgpForMigration.md)
[Get-AzExpressRouteCrossConnectionMigrationInfo](Get-AzExpressRouteCrossConnectionMigrationInfo.md)
