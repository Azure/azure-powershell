---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azexpressroutecrossconnectionmigrationinfo
schema: 2.0.0
---

# Get-AzExpressRouteCrossConnectionMigrationInfo

## SYNOPSIS
Gets migration status and port health for a provider-owned ExpressRoute cross-connection.

## SYNTAX

### ByName (Default)
```
Get-AzExpressRouteCrossConnectionMigrationInfo -TargetPeeringLocation <String>
 -TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]> -Name <String> -ResourceGroupName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByInputObject
```
Get-AzExpressRouteCrossConnectionMigrationInfo -TargetPeeringLocation <String>
 -TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]> -InputObject <PSExpressRouteCrossConnection>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzExpressRouteCrossConnectionMigrationInfo -TargetPeeringLocation <String>
 -TargetPortMapping <PSExpressRouteCrossConnectionPortMapping[]> -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzExpressRouteCrossConnectionMigrationInfo cmdlet checks migration health using a target peering location and source-to-target port mappings. Unlike a simple resource read, this operation requires both target inputs and can run asynchronously. The cmdlet waits for completion unless AsJob is specified.

The result includes Status, Phase, FailureReason, ShouldRollback, preparation timestamps, NewSTag, NewCrossConnectionUrl, and nested port and peering metrics in Details. Service guidance is returned without automatically rolling back or advancing the migration. NewSTag and NewCrossConnectionUrl retain the string values returned by the service.

Use a provider-authorized Azure context. ResourceId and InputObject must identify a cross-connection in the current subscription.

## EXAMPLES

### Example 1: Inspect migration health from a pipeline object
```powershell
$mapping = New-AzExpressRouteCrossConnectionPortMapping -SourcePortId 'source-port' -TargetPortId 'target-port'
$result = Get-AzExpressRouteCrossConnection -ResourceGroupName 'provider-rg' -Name 'cross-connection' |
	Get-AzExpressRouteCrossConnectionMigrationInfo -TargetPeeringLocation 'Amsterdam' -TargetPortMapping $mapping
$result.Details.PortMigrationInfos
```

Checks health for the proposed mapping and displays per-port migration details. Interpret status and rollback guidance according to the provider runbook.

### Example 2: Check migration health in the background
```powershell
$mapping = New-AzExpressRouteCrossConnectionPortMapping -SourcePortId 'source-port' -TargetPortId 'target-port'
$job = Get-AzExpressRouteCrossConnectionMigrationInfo -ResourceId '/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/provider-rg/providers/Microsoft.Network/expressRouteCrossConnections/cross-connection' -TargetPeeringLocation 'Amsterdam' -TargetPortMapping $mapping -AsJob
$job | Wait-Job | Receive-Job
```

Runs the health operation as a job and retrieves its final result. The resource ID must belong to the selected Azure context's subscription.

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

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuitMigrationResult

## NOTES

## RELATED LINKS

[Test-AzExpressRouteCrossConnectionMigration](Test-AzExpressRouteCrossConnectionMigration.md)
[New-AzExpressRouteCrossConnectionPortMapping](New-AzExpressRouteCrossConnectionPortMapping.md)
