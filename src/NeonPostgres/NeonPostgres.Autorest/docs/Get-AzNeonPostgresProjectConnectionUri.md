---
external help file:
Module Name: Az.NeonPostgres
online version: https://learn.microsoft.com/powershell/module/az.neonpostgres/get-azneonpostgresprojectconnectionuri
schema: 2.0.0
---

# Get-AzNeonPostgresProjectConnectionUri

## SYNOPSIS
Action to retrieve the connection URI for the Neon Database.

## SYNTAX

### GetExpanded (Default)
```
Get-AzNeonPostgresProjectConnectionUri -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-BranchId <String>] [-DatabaseName <String>]
 [-EndpointId <String>] [-IsPooled] [-ProjectId <String>] [-RoleName <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Get
```
Get-AzNeonPostgresProjectConnectionUri -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> -ConnectionUriParameter <IConnectionUriProperties> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNeonPostgresProjectConnectionUri -InputObject <INeonPostgresIdentity>
 -ConnectionUriParameter <IConnectionUriProperties> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzNeonPostgresProjectConnectionUri -InputObject <INeonPostgresIdentity> [-BranchId <String>]
 [-DatabaseName <String>] [-EndpointId <String>] [-IsPooled] [-ProjectId <String>] [-RoleName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityOrganization
```
Get-AzNeonPostgresProjectConnectionUri -OrganizationInputObject <INeonPostgresIdentity> -ProjectName <String>
 -ConnectionUriParameter <IConnectionUriProperties> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaIdentityOrganizationExpanded
```
Get-AzNeonPostgresProjectConnectionUri -OrganizationInputObject <INeonPostgresIdentity> -ProjectName <String>
 [-BranchId <String>] [-DatabaseName <String>] [-EndpointId <String>] [-IsPooled] [-ProjectId <String>]
 [-RoleName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonFilePath
```
Get-AzNeonPostgresProjectConnectionUri -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonString
```
Get-AzNeonPostgresProjectConnectionUri -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Action to retrieve the connection URI for the Neon Database.

## EXAMPLES

### Example 1: Retrieve the connection URI for a specific Neon Postgres database
```powershell
Get-AzNeonPostgresProjectConnectionUri -OrganizationName "NeonDemoOrgPS1" -ProjectName "dawn-breeze-86932057" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000" -BranchId "br-damp-bird-a82olmcu" -DatabaseName "neondb" -EndpointId "ep-spring-cake-a88oisqp" -RoleName "neondb_owner"
```

```output
BranchId            : br-damp-bird-a82olmcu
ConnectionStringUri : System.Security.SecureString
DatabaseName        : neondb
EndpointId          : ep-spring-cake-a88oisqp
IsPooled            : False
ProjectId           : dawn-breeze-86932057
RoleName            : neondb_owner
```

Retrieve the connection URI for a specific Neon Postgres database.

## PARAMETERS

### -BranchId
Branch Id associated with this connection

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionUriParameter
Connection uri parameters for the associated database

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IConnectionUriProperties
Parameter Sets: Get, GetViaIdentity, GetViaIdentityOrganization
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DatabaseName
Database name associated with this connection

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityOrganizationExpanded
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

### -EndpointId
the endpoint Id with this connection

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityOrganizationExpanded
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
Parameter Sets: GetViaIdentity, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsPooled
Indicates if the connection is pooled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonPostgresIdentity
Parameter Sets: GetViaIdentityOrganization, GetViaIdentityOrganizationExpanded
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
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectId
Project Id associated with this connection

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The name of the Project

```yaml
Type: System.String
Parameter Sets: Get, GetExpanded, GetViaIdentityOrganization, GetViaIdentityOrganizationExpanded, GetViaJsonFilePath, GetViaJsonString
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
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleName
The role name used for authentication

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityOrganizationExpanded
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
Type: System.String[]
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IConnectionUriProperties

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonPostgresIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IConnectionUriProperties

## NOTES

## RELATED LINKS

