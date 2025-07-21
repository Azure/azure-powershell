---
external help file: Az.NeonPostgres-help.xml
Module Name: Az.NeonPostgres
online version: https://learn.microsoft.com/powershell/module/az.neonpostgres/get-azneonpostgresbranch
schema: 2.0.0
---

# Get-AzNeonPostgresBranch

## SYNOPSIS
Get a Branch

## SYNTAX

### List (Default)
```
Get-AzNeonPostgresBranch -OrganizationName <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityProject
```
Get-AzNeonPostgresBranch -Name <String> -ProjectInputObject <INeonPostgresIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityOrganization
```
Get-AzNeonPostgresBranch -Name <String> -ProjectName <String> -OrganizationInputObject <INeonPostgresIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNeonPostgresBranch -Name <String> -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNeonPostgresBranch -InputObject <INeonPostgresIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Branch

## EXAMPLES

### Example 1: List all branches resources within a specified project in Neon Postgres
```powershell
Get-AzNeonPostgresBranch -ProjectName "dawn-breeze-86932056" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Attribute                    : {{
                                 "name": "createdAt",
                                 "value": "May 12, 2025 8:02 AM"
                               }, {
                                 "name": "logicalSize",
                                 "value": "30785536"
                               }, {
                                 "name": "cpuUsedSec",
                                 "value": "0"
                               }, {
                                 "name": "computeTimeSeconds",
                                 "value": "0"
                               }…}
CreatedAt                    : May 12, 2025 8:02 AM
Database                     : 
DatabaseName                 : 
Endpoint                     : 
EntityId                     : br-damp-bird-a82olmcu
EntityName                   : main
Id                           : 
Name                         : 
ParentId                     : 
ProjectId                    : dawn-breeze-86932057
ProvisioningState            : idle
ResourceGroupName            : 
Role                         : 
RoleName                     : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         :
```

List all branches resources within a specified project in Neon Postgres

### Example 2: Get Branch resource details within a specified project in Neon Postgres
```powershell
Get-AzNeonPostgresBranch -Name "br-damp-bird-a82olmcu" -ProjectName "dawn-breeze-86932056" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Attribute                    : {{
                                 "name": "logicalSize",
                                 "value": "30785536"
                               }, {
                                 "name": "cpuUsedSec",
                                 "value": "0"
                               }, {
                                 "name": "computeTimeSeconds",
                                 "value": "0"
                               }, {
                                 "name": "activeTimeSeconds",
                                 "value": "0"
                               }…}
CreatedAt                    : May 12, 2025 8:02 AM
Database                     : 
DatabaseName                 : 
Endpoint                     : 
EntityId                     : br-damp-bird-a82olmcu
EntityName                   : main
Id                           : 
Name                         : 
ParentId                     : 
ProjectId                    : dawn-breeze-86932057
ProvisioningState            : Succeeded
ResourceGroupName            : 
Role                         : 
RoleName                     : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         :
```

Get Branch resource details within a specified project in Neon Postgres

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonPostgresIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: GetViaIdentityProject, GetViaIdentityOrganization, Get
Aliases: BranchName

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
Parameter Sets: GetViaIdentityOrganization
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonPostgresIdentity
Parameter Sets: GetViaIdentityProject
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
Parameter Sets: List, GetViaIdentityOrganization, Get
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
Parameter Sets: List, Get
Aliases:

Required: True
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
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
