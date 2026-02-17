---
external help file:
Module Name: Az.Confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/get-azconfluentorganizationenvironment
schema: 2.0.0
---

# Get-AzConfluentOrganizationEnvironment

## SYNOPSIS
Get Environment details by environment Id

## SYNTAX

### List (Default)
```
Get-AzConfluentOrganizationEnvironment -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-PageSize <Int32>] [-PageToken <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzConfluentOrganizationEnvironment -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConfluentOrganizationEnvironment -InputObject <IConfluentIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityOrganization
```
Get-AzConfluentOrganizationEnvironment -EnvironmentId <String> -OrganizationInputObject <IConfluentIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get Environment details by environment Id

## EXAMPLES

### Example 1: List all environments in an organization
```powershell
Get-AzConfluentOrganizationEnvironment -ResourceGroupName azure-rg-test -OrganizationName confluentorg-01
```

```output
Id          Name              DisplayName       StreamGovernancePackage
--          ----              -----------       -----------------------
env-123456  production        Production Env    ESSENTIALS
env-234567  development       Development Env   ADVANCED
env-345678  staging           Staging Env       ESSENTIALS
```

This command lists all Confluent environments within the specified organization.

### Example 2: Get a specific environment by ID
```powershell
Get-AzConfluentOrganizationEnvironment -ResourceGroupName azure-rg-test -OrganizationName confluentorg-01 -Id env-123456
```

```output
Id          Name              DisplayName       StreamGovernancePackage
--          ----              -----------       -----------------------
env-123456  production        Production Env    ESSENTIALS
```

This command retrieves details of a specific Confluent environment by its ID.

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

### -EnvironmentId
Confluent environment id

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityOrganization
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
Parameter Sets: GetViaIdentityOrganization
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Organization resource name

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

### -PageSize
Pagination size

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageToken
An opaque pagination token to fetch the next set of records

```yaml
Type: System.String
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IScEnvironmentRecord

## NOTES

## RELATED LINKS

