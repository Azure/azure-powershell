---
external help file:
Module Name: Az.NeonPostgres
online version: https://learn.microsoft.com/powershell/module/az.neonpostgres/update-azneonpostgresbranch
schema: 2.0.0
---

# Update-AzNeonPostgresBranch

## SYNOPSIS
update a Branch

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNeonPostgresBranch -Name <String> -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Attribute <IAttributes[]>]
 [-Database <INeonDatabaseProperties[]>] [-DatabaseName <String>] [-Endpoint <IEndpointProperties[]>]
 [-EntityName <String>] [-ParentId <String>] [-ProjectId <String>] [-Role <INeonRoleProperties[]>]
 [-RoleName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNeonPostgresBranch -InputObject <INeonPostgresIdentity> [-Attribute <IAttributes[]>]
 [-Database <INeonDatabaseProperties[]>] [-DatabaseName <String>] [-Endpoint <IEndpointProperties[]>]
 [-EntityName <String>] [-ParentId <String>] [-ProjectId <String>] [-Role <INeonRoleProperties[]>]
 [-RoleName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityOrganizationExpanded
```
Update-AzNeonPostgresBranch -Name <String> -OrganizationInputObject <INeonPostgresIdentity>
 -ProjectName <String> [-Attribute <IAttributes[]>] [-Database <INeonDatabaseProperties[]>]
 [-DatabaseName <String>] [-Endpoint <IEndpointProperties[]>] [-EntityName <String>] [-ParentId <String>]
 [-ProjectId <String>] [-Role <INeonRoleProperties[]>] [-RoleName <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityProjectExpanded
```
Update-AzNeonPostgresBranch -Name <String> -ProjectInputObject <INeonPostgresIdentity>
 [-Attribute <IAttributes[]>] [-Database <INeonDatabaseProperties[]>] [-DatabaseName <String>]
 [-Endpoint <IEndpointProperties[]>] [-EntityName <String>] [-ParentId <String>] [-ProjectId <String>]
 [-Role <INeonRoleProperties[]>] [-RoleName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a Branch

## EXAMPLES

### Example 1: Update the properties of an existing branch
```powershell
Update-AzNeonPostgresBranch -Name "br-damp-bird-a82olmcu" -OrganizationName "NeonDemoOrgPS1" -ProjectName "dawn-breeze-86932057" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000" -DatabaseName "updated-db" -EntityName "updated-entity" -ParentId "parent-branch-id" -RoleName "admin"
```

Update the properties of an existing branch within a Neon Postgres project.

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

### -Database
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

### -DatabaseName
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
The name of the Branch

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityOrganizationExpanded, UpdateViaIdentityProjectExpanded
Aliases: BranchName

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

### -ParentId
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

### -ProjectId
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

### -ProjectInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonPostgresIdentity
Parameter Sets: UpdateViaIdentityProjectExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
The name of the Project

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: True
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

### -RoleName
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

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IBranch

## NOTES

## RELATED LINKS

