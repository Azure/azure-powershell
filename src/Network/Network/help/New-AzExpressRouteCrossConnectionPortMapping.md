---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azexpressroutecrossconnectionportmapping
schema: 2.0.0
---

# New-AzExpressRouteCrossConnectionPortMapping

## SYNOPSIS
Creates a source-to-target port mapping for an ExpressRoute cross-connection migration.

## SYNTAX

```
New-AzExpressRouteCrossConnectionPortMapping -SourcePortId <String> -TargetPortId <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzExpressRouteCrossConnectionPortMapping cmdlet creates an in-memory mapping object for the TargetPortMapping parameter of ExpressRoute cross-connection migration commands. It does not create Azure resources or send a migration request.

Both port identifiers are required. Use the provider-supplied values without assuming they are resource IDs or GUIDs. To describe multiple port pairs, pass an array of mapping objects to the migration command. The provider service validates whether those mappings are suitable for the proposed migration.

## EXAMPLES

### Example 1: Create two port mappings for validation
```powershell
$mappings = @(
	New-AzExpressRouteCrossConnectionPortMapping -SourcePortId 'source-primary' -TargetPortId 'target-primary'
	New-AzExpressRouteCrossConnectionPortMapping -SourcePortId 'source-secondary' -TargetPortId 'target-secondary'
)
Test-AzExpressRouteCrossConnectionMigration -ResourceGroupName 'provider-rg' -Name 'cross-connection' -TargetPeeringLocation 'Amsterdam' -TargetPortMapping $mappings
```

Builds local mapping objects and submits them to the validation operation. Replace the sample identifiers and location with provider-approved values.

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

### -SourcePortId
The source port identifier supplied by the provider.

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

### -TargetPortId
The target port identifier supplied by the provider.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCrossConnectionPortMapping

## NOTES

## RELATED LINKS

[Test-AzExpressRouteCrossConnectionMigration](Test-AzExpressRouteCrossConnectionMigration.md)
[Invoke-AzExpressRouteCrossConnectionPrepareMigration](Invoke-AzExpressRouteCrossConnectionPrepareMigration.md)
