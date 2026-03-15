---
external help file: Az.Confluent-help.xml
Module Name: Az.confluent
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

### GetViaIdentityOrganization
```
Get-AzConfluentOrganizationEnvironment -EnvironmentId <String> -OrganizationInputObject <IConfluentIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConfluentOrganizationEnvironment -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConfluentOrganizationEnvironment -InputObject <IConfluentIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get Environment details by environment Id

## EXAMPLES

### Example 1: List all environments in the organization
```powershell
Get-AzConfluentOrganizationEnvironment -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
 Get-AzConfluentOrganizationEnvironment -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent

Name                  SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind        ResourceGroupName
----                  ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ----        -----------------
default                                                                                                                                                              Environment sharedrp-confluent
test-env-0                                                                                                                                                         Environment sharedrp-confluent
test-env-1                                                                                                                                                         Environment sharedrp-confluent
test-env-2                                                                                                                                                         Environment sharedrp-confluent
test-env-3                                                                                                                                                         Environment sharedrp-confluent
shekarTest                                                                                                                                                           Environment sharedrp-confluent
test-env-4                                                                                                                                                Environment sharedrp-confluent
praveen-test-env                                                                                                                                                     Environment sharedrp-confluent
env1136                                                                                                                                                              Environment sharedrp-confluent
testEnv1                                                                                                                                                             Environment sharedrp-confluent
```

This commands list all environments in an organization

### Example 2: Get Environment details by environment ID
```powershell
 Get-AzConfluentOrganizationEnvironment -EnvironmentId 'shekarTest' -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Id                            : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/shekarTes
                                t
Kind                          : Environment
MetadataCreatedTimestamp      : 12/19/2025 09:33:39 +00:00
MetadataDeletedTimestamp      :
MetadataResourceName          : crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv001
MetadataSelf                  : https://api.example.confluent.io/org/v2/environments/env-exampleenv001
MetadataUpdatedTimestamp      : 12/19/2025 09:33:39 +00:00
Name                          : shekarTest
ResourceGroupName             : sharedrp-confluent
StreamGovernanceConfigPackage : ESSENTIALS
SystemDataCreatedAt           :
SystemDataCreatedBy           :
SystemDataCreatedByType       :
SystemDataLastModifiedAt      :
SystemDataLastModifiedBy      :
SystemDataLastModifiedByType  :
Type                          : microsoft.confluent/organizations/environments
```

This commands fetches environment details of an environment by environment ID

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
Parameter Sets: GetViaIdentityOrganization, Get
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
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IScEnvironmentRecord

## NOTES

## RELATED LINKS
