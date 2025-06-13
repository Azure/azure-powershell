---
external help file: Az.NeonPostgres-help.xml
Module Name: Az.NeonPostgres
online version: https://learn.microsoft.com/powershell/module/az.neonpostgres/get-azneonpostgresorganization
schema: 2.0.0
---

# Get-AzNeonPostgresOrganization

## SYNOPSIS
Get a OrganizationResource

## SYNTAX

### List (Default)
```
Get-AzNeonPostgresOrganization [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNeonPostgresOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzNeonPostgresOrganization -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNeonPostgresOrganization -InputObject <INeonPostgresIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a OrganizationResource

## EXAMPLES

### Example 1: Get Neon Organization Details
```powershell
Get-AzNeonPostgresOrganization -SubscriptionId 5d9a6cc3-4e60-4b41-be79-d28f0a01074e
```

```output
Location      Name                       SystemDataCreatedAt   SystemDataCreatedBy           SystemDataCreatedByType Sy
                                                                                                                     st
                                                                                                                     em
                                                                                                                     Da
                                                                                                                     ta
                                                                                                                     La
                                                                                                                     st
                                                                                                                     Mo
                                                                                                                     di
                                                                                                                     fi
                                                                                                                     ed
                                                                                                                     At
--------      ----                       -------------------   -------------------           ----------------------- --
eastus2       org123                     25-Oct-24 5:59:50 AM  deepkan@contoso.com        User                    25
eastus2       Sr-Neon-Org-Prod           25-Oct-24 10:04:14 AM john.dev@contoso.com       User                    25
eastus2       Sr-Neon-Org-Prod-2         25-Oct-24 10:16:08 AM neondevuser@company.com    User                    25
eastus2       ProdNeonOrg-1              29-Oct-24 5:02:55 AM  alluri@testneon.com        User                    29
```

This command will get all organization details for a subscription id

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
Name of the Neon Organizations resource

```yaml
Type: System.String
Parameter Sets: Get
Aliases: OrganizationName

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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IOrganizationResource

## NOTES

## RELATED LINKS
