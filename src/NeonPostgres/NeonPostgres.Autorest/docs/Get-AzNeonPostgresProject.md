---
external help file:
Module Name: Az.NeonPostgres
online version: https://learn.microsoft.com/powershell/module/az.neonpostgres/get-azneonpostgresproject
schema: 2.0.0
---

# Get-AzNeonPostgresProject

## SYNOPSIS
Get a Project

## SYNTAX

### List (Default)
```
Get-AzNeonPostgresProject -OrganizationName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNeonPostgresProject -Name <String> -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNeonPostgresProject -InputObject <INeonPostgresIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityOrganization
```
Get-AzNeonPostgresProject -Name <String> -OrganizationInputObject <INeonPostgresIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a Project

## EXAMPLES

### Example 1: List all Neon projects associated with a specific Neon organization
```powershell
Get-AzNeonPostgresProject -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

List all Neon projects associated with a specific Neon organization

### Example 2: Get Neon projects associated with a specific Neon organization
```powershell
Get-AzNeonPostgresProject -ProjectName "dawn-breeze-86932056" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

Get Neon projects associated with a specific Neon organization

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
The name of the Project

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityOrganization
Aliases: ProjectName

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IProject

## NOTES

## RELATED LINKS

