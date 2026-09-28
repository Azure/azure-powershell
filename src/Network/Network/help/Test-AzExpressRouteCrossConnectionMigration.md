---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/test-azexpressroutecrossconnectionmigration
schema: 2.0.0
---

# Test-AzExpressRouteCrossConnectionMigration

## SYNOPSIS
Validates a provider-led ExpressRoute cross-connection migration.

## SYNTAX

### ByName (Default)
```
Test-AzExpressRouteCrossConnectionMigration -TargetPeeringLocation <String>
 -TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]> -Name <String> -ResourceGroupName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByInputObject
```
Test-AzExpressRouteCrossConnectionMigration -TargetPeeringLocation <String>
 -TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]> -InputObject <PSExpressRouteCrossConnection>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByResourceId
```
Test-AzExpressRouteCrossConnectionMigration -TargetPeeringLocation <String>
 -TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]> -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Test-AzExpressRouteCrossConnectionMigration cmdlet validates a proposed target peering location and source-to-target port mappings for a provider-owned ExpressRoute cross-connection. It waits for the validation operation to complete and returns a typed result with the service's Status value, not a Boolean.

Both target inputs are required. Use an Azure context authorized to operate on the provider cross-connection. ResourceId and InputObject must identify a cross-connection in the current subscription, not a customer circuit or a peering child resource. Validation does not prepare, migrate, commit, or roll back the connection.

## EXAMPLES

### Example 1: Validate proposed port mappings
```powershell
$mapping = New-AzExpressRouteCrossConnectionPortMapping -SourcePortId 'source-port' -TargetPortId 'target-port'
Test-AzExpressRouteCrossConnectionMigration -ResourceGroupName 'provider-rg' -Name 'cross-connection' -TargetPeeringLocation 'Amsterdam' -TargetPortMapping $mapping
```

Validates the provider-supplied mapping and location without advancing the migration. Replace the sample port identifiers with values from the provider's migration runbook.

## PARAMETERS

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
The target peering location to validate or check.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
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

Required: True
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

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuitMigrationValidationResult

## NOTES

## RELATED LINKS

[New-AzExpressRouteCrossConnectionPortMapping](New-AzExpressRouteCrossConnectionPortMapping.md)
[Get-AzExpressRouteCrossConnectionMigrationInfo](Get-AzExpressRouteCrossConnectionMigrationInfo.md)
