---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-aznetworkvirtualappliancepreparemigration
schema: 2.0.0
---

# Invoke-AzNetworkVirtualAppliancePrepareMigration

## SYNOPSIS
Prepares a Network Virtual Appliance for migration to a new OS version or to the new internal load balancer (ILB) architecture.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Invoke-AzNetworkVirtualAppliancePrepareMigration -ResourceGroupName <String> -Name <String>
 -MigrationType <String> [-MarketPlaceVersion <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Invoke-AzNetworkVirtualAppliancePrepareMigration -ResourceId <String> -MigrationType <String>
 [-MarketPlaceVersion <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Invoke-AzNetworkVirtualAppliancePrepareMigration** cmdlet starts the preparation phase of a Network Virtual Appliance (NVA) migration.
Preparation is the first step of the migration workflow and provisions the resources that are required for the target configuration without affecting the running appliance.
Use `MigrateToNewILBArchitecture` to prepare an appliance for the new internal load balancer architecture, or `MigrateToNewOSVersion` to prepare an upgrade to a new marketplace OS version.
After preparation completes, run `Invoke-AzNetworkVirtualApplianceExecuteMigration` to perform the migration.

## EXAMPLES

### Example 1: Prepare an NVA for the new ILB architecture
```powershell
Invoke-AzNetworkVirtualAppliancePrepareMigration -ResourceGroupName testRgName -Name testNvaName -MigrationType "MigrateToNewILBArchitecture"
```

This command prepares the network virtual appliance named "testNvaName" in the resource group "testRgName" for migration to the new internal load balancer architecture.

### Example 2: Prepare an NVA for a new OS version by resource ID
```powershell
$nva = Get-AzNetworkVirtualAppliance -ResourceGroupName testRgName -Name testNvaName
Invoke-AzNetworkVirtualAppliancePrepareMigration -ResourceId $nva.Id -MigrationType "MigrateToNewOSVersion" -MarketPlaceVersion "1.0.1"
```

This command prepares the network virtual appliance identified by its resource ID for migration to the marketplace OS version "1.0.1".

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

### -MarketPlaceVersion
The marketplace version to migrate to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MigrationType
The type of migration to prepare.
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

[Invoke-AzNetworkVirtualApplianceExecuteMigration](./Invoke-AzNetworkVirtualApplianceExecuteMigration.md)

[Invoke-AzNetworkVirtualApplianceCommitMigration](./Invoke-AzNetworkVirtualApplianceCommitMigration.md)

[Invoke-AzNetworkVirtualApplianceAbortMigration](./Invoke-AzNetworkVirtualApplianceAbortMigration.md)

[Get-AzNetworkVirtualAppliance](./Get-AzNetworkVirtualAppliance.md)
