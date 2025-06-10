---
external help file:
Module Name: Az.NeonPostgres
online version: https://learn.microsoft.com/powershell/module/az.neonpostgres/update-azneonpostgresproject
schema: 2.0.0
---

# Update-AzNeonPostgresProject

## SYNOPSIS
update a Project

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNeonPostgresProject -Name <String> -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Attribute <IAttributes[]>] [-BranchAttribute <IAttributes[]>]
 [-BranchDatabase <INeonDatabaseProperties[]>] [-BranchDatabaseName <String>]
 [-BranchEndpoint <IEndpointProperties[]>] [-BranchEntityName <String>] [-BranchParentId <String>]
 [-BranchProjectId <String>] [-BranchRole <INeonRoleProperties[]>] [-BranchRoleName <String>]
 [-Database <INeonDatabaseProperties[]>] [-DefaultEndpointSettingAutoscalingLimitMaxCu <Single>]
 [-DefaultEndpointSettingAutoscalingLimitMinCu <Single>] [-Endpoint <IEndpointProperties[]>]
 [-EntityName <String>] [-HistoryRetention <Int32>] [-PgVersion <Int32>] [-RegionId <String>]
 [-Role <INeonRoleProperties[]>] [-Storage <Int64>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNeonPostgresProject -InputObject <INeonPostgresIdentity> [-Attribute <IAttributes[]>]
 [-BranchAttribute <IAttributes[]>] [-BranchDatabase <INeonDatabaseProperties[]>]
 [-BranchDatabaseName <String>] [-BranchEndpoint <IEndpointProperties[]>] [-BranchEntityName <String>]
 [-BranchParentId <String>] [-BranchProjectId <String>] [-BranchRole <INeonRoleProperties[]>]
 [-BranchRoleName <String>] [-Database <INeonDatabaseProperties[]>]
 [-DefaultEndpointSettingAutoscalingLimitMaxCu <Single>]
 [-DefaultEndpointSettingAutoscalingLimitMinCu <Single>] [-Endpoint <IEndpointProperties[]>]
 [-EntityName <String>] [-HistoryRetention <Int32>] [-PgVersion <Int32>] [-RegionId <String>]
 [-Role <INeonRoleProperties[]>] [-Storage <Int64>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityOrganizationExpanded
```
Update-AzNeonPostgresProject -Name <String> -OrganizationInputObject <INeonPostgresIdentity>
 [-Attribute <IAttributes[]>] [-BranchAttribute <IAttributes[]>] [-BranchDatabase <INeonDatabaseProperties[]>]
 [-BranchDatabaseName <String>] [-BranchEndpoint <IEndpointProperties[]>] [-BranchEntityName <String>]
 [-BranchParentId <String>] [-BranchProjectId <String>] [-BranchRole <INeonRoleProperties[]>]
 [-BranchRoleName <String>] [-Database <INeonDatabaseProperties[]>]
 [-DefaultEndpointSettingAutoscalingLimitMaxCu <Single>]
 [-DefaultEndpointSettingAutoscalingLimitMinCu <Single>] [-Endpoint <IEndpointProperties[]>]
 [-EntityName <String>] [-HistoryRetention <Int32>] [-PgVersion <Int32>] [-RegionId <String>]
 [-Role <INeonRoleProperties[]>] [-Storage <Int64>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a Project

## EXAMPLES

### Example 1: Update the properties of an existing Neon project resource within Azure
```powershell
Update-AzNeonPostgresProject -Name "dawn-breeze-86932057" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000" -BranchDatabaseName "updated-db" -BranchEntityName "updated-entity" -BranchParentId "parent-branch-id" -BranchRoleName "admin" -PgVersion 17 -RegionId "centraluseuap" -Storage 10240 -HistoryRetention 7
```

Update the properties of an existing Neon project resource within Azure.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Attribute
Additional attributes for the entity

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IAttributes[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BranchAttribute
Additional attributes for the entity

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IAttributes[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BranchDatabase
Neon Databases associated with the branch

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonDatabaseProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BranchDatabaseName
Database name associated with the branch

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BranchEndpoint
Endpoints associated with the branch

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IEndpointProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BranchEntityName
Name of the resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BranchParentId
The ID of the parent branch

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BranchProjectId
The ID of the project this branch belongs to

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BranchRole
Roles associated with the branch

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonRoleProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BranchRoleName
Role name associated with the branch

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Database
Neon Databases associated with the project

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonDatabaseProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultEndpointSettingAutoscalingLimitMaxCu
Maximum compute units for autoscaling.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultEndpointSettingAutoscalingLimitMinCu
Minimum compute units for autoscaling.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
Endpoints associated with the project

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IEndpointProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityName
Name of the resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HistoryRetention
The retention period for project history in seconds.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonPostgresIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Project

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityOrganizationExpanded
Aliases: ProjectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonPostgresIdentity
Parameter Sets: UpdateViaIdentityOrganizationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Name of the Neon Organizations resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PgVersion
Postgres version for the project

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegionId
Region where the project is created

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
Roles associated with the project

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonRoleProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Storage
Data Storage bytes per hour for the project

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonPostgresIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IProject

## NOTES

## RELATED LINKS

