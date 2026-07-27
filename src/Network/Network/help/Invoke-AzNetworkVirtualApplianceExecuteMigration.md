---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-aznetworkvirtualapplianceexecutemigration
schema: 2.0.0
---

# Invoke-AzNetworkVirtualApplianceExecuteMigration

## SYNOPSIS
Executes a previously prepared Network Virtual Appliance migration.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Invoke-AzNetworkVirtualApplianceExecuteMigration -ResourceGroupName <String> -Name <String>
 -MigrationType <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Invoke-AzNetworkVirtualApplianceExecuteMigration -ResourceId <String> -MigrationType <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Invoke-AzNetworkVirtualApplianceExecuteMigration** cmdlet performs the migration that was staged by `Invoke-AzNetworkVirtualAppliancePrepareMigration`.
Execution moves the Network Virtual Appliance (NVA) traffic and configuration onto the target OS version or the new internal load balancer (ILB) architecture.
After execution succeeds, run `Invoke-AzNetworkVirtualApplianceCommitMigration` to finalize the migration, or `Invoke-AzNetworkVirtualApplianceAbortMigration` to roll it back.

## EXAMPLES

### Example 1: Execute the ILB architecture migration
```powershell
Invoke-AzNetworkVirtualApplianceExecuteMigration -ResourceGroupName testRgName -Name testNvaName -MigrationType "MigrateToNewILBArchitecture"
```

This command executes the prepared migration to the new internal load balancer architecture for the network virtual appliance named "testNvaName" in the resource group "testRgName".

### Example 2: Execute a migration by resource ID
```powershell
$nva = Get-AzNetworkVirtualAppliance -ResourceGroupName testRgName -Name testNvaName
Invoke-AzNetworkVirtualApplianceExecuteMigration -ResourceId $nva.Id -MigrationType "MigrateToNewOSVersion"
```

This command executes the prepared OS version migration for the network virtual appliance identified by its resource ID.

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

### -MigrationType
The type of migration to execute.
Accepted values are `MigrateToNewOSVersion` and `MigrateToNewILBArchitecture`.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The Network Virtual Appliance name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases: VirtualApplianceName, NvaName, NetworkVirtualApplianceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource Id.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualAppliance

## NOTES

## RELATED LINKS

[Invoke-AzNetworkVirtualAppliancePrepareMigration](./Invoke-AzNetworkVirtualAppliancePrepareMigration.md)

[Invoke-AzNetworkVirtualApplianceCommitMigration](./Invoke-AzNetworkVirtualApplianceCommitMigration.md)

[Invoke-AzNetworkVirtualApplianceAbortMigration](./Invoke-AzNetworkVirtualApplianceAbortMigration.md)

[Get-AzNetworkVirtualAppliance](./Get-AzNetworkVirtualAppliance.md)
