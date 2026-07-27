---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-aznetworkvirtualappliancecommitmigration
schema: 2.0.0
---

# Invoke-AzNetworkVirtualApplianceCommitMigration

## SYNOPSIS
Commits a Network Virtual Appliance migration, finalizing the move to the target configuration.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Invoke-AzNetworkVirtualApplianceCommitMigration -ResourceGroupName <String> -Name <String>
 -MigrationType <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Invoke-AzNetworkVirtualApplianceCommitMigration -ResourceId <String> -MigrationType <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Invoke-AzNetworkVirtualApplianceCommitMigration** cmdlet finalizes a Network Virtual Appliance (NVA) migration that was executed by `Invoke-AzNetworkVirtualApplianceExecuteMigration`.
Committing the migration removes the resources associated with the previous configuration and completes the transition to the new OS version or the new internal load balancer (ILB) architecture.
This step cannot be undone; use `Invoke-AzNetworkVirtualApplianceAbortMigration` before committing if you need to roll back.

## EXAMPLES

### Example 1: Commit the ILB architecture migration
```powershell
Invoke-AzNetworkVirtualApplianceCommitMigration -ResourceGroupName testRgName -Name testNvaName -MigrationType "MigrateToNewILBArchitecture"
```

This command commits the migration to the new internal load balancer architecture for the network virtual appliance named "testNvaName" in the resource group "testRgName".

### Example 2: Commit a migration by resource ID
```powershell
$nva = Get-AzNetworkVirtualAppliance -ResourceGroupName testRgName -Name testNvaName
Invoke-AzNetworkVirtualApplianceCommitMigration -ResourceId $nva.Id -MigrationType "MigrateToNewOSVersion"
```

This command commits the OS version migration for the network virtual appliance identified by its resource ID.

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
The type of migration to commit.
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

[Invoke-AzNetworkVirtualApplianceExecuteMigration](./Invoke-AzNetworkVirtualApplianceExecuteMigration.md)

[Invoke-AzNetworkVirtualApplianceAbortMigration](./Invoke-AzNetworkVirtualApplianceAbortMigration.md)

[Get-AzNetworkVirtualAppliance](./Get-AzNetworkVirtualAppliance.md)
