---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-aznetworkvirtualapplianceabortmigration
schema: 2.0.0
---

# Invoke-AzNetworkVirtualApplianceAbortMigration

## SYNOPSIS
Aborts an in-progress Network Virtual Appliance migration and rolls back to the original configuration.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Invoke-AzNetworkVirtualApplianceAbortMigration -ResourceGroupName <String> -Name <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Invoke-AzNetworkVirtualApplianceAbortMigration -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Invoke-AzNetworkVirtualApplianceAbortMigration** cmdlet cancels a Network Virtual Appliance (NVA) migration that has been prepared or executed but not yet committed.
Aborting the migration discards the staged target resources and returns the appliance to its original OS version or internal load balancer (ILB) architecture.
Once a migration has been committed with `Invoke-AzNetworkVirtualApplianceCommitMigration`, it can no longer be aborted.

## EXAMPLES

### Example 1: Abort a migration
```powershell
Invoke-AzNetworkVirtualApplianceAbortMigration -ResourceGroupName testRgName -Name testNvaName
```

This command aborts the in-progress migration for the network virtual appliance named "testNvaName" in the resource group "testRgName" and rolls it back to its original configuration.

### Example 2: Abort a migration by resource ID
```powershell
$nva = Get-AzNetworkVirtualAppliance -ResourceGroupName testRgName -Name testNvaName
Invoke-AzNetworkVirtualApplianceAbortMigration -ResourceId $nva.Id
```

This command aborts the in-progress migration for the network virtual appliance identified by its resource ID.

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

[Invoke-AzNetworkVirtualApplianceCommitMigration](./Invoke-AzNetworkVirtualApplianceCommitMigration.md)

[Get-AzNetworkVirtualAppliance](./Get-AzNetworkVirtualAppliance.md)
