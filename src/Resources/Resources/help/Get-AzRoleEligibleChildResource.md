---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azroleeligiblechildresource
schema: 2.0.0
---

# Get-AzRoleEligibleChildResource

## SYNOPSIS
Get the child resources of a resource on which user has eligible access

## SYNTAX

### Get (Default)
```
Get-AzRoleEligibleChildResource -Scope <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRoleEligibleChildResource -InputObject <IAuthorizationIdentity> [-Filter <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the child resources of a resource on which user has eligible access

## EXAMPLES

### Example 1: List all child resources
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
Get-AzRoleEligibleChildResource -Scope $scope
```

```output
Name                                               Type
----                                               ----
AnujRG                                             resourcegroup
ARPJ-TESTRG-01                                     resourcegroup
AnujRG2                                            resourcegroup
asghodke-rg                                        resourcegroup
```

Get all child resources of a resource `scope` that the calling user has eligible assignment(s) on.

### Example 2: List all child resources filtered by resource type
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
$filter = "resoureType eq 'resourcegroup'"
Get-AzRoleEligibleChildResource -Scope $scope -Filter $filter
```

```output
Name                                               Type
----                                               ----
AnujRG                                             resourcegroup
ARPJ-TESTRG-01                                     resourcegroup
AnujRG2                                            resourcegroup
asghodke-rg                                        resourcegroup
```

You can filter by subscriptions, resourceGroups or any resource type.

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

### -Filter
The filter to apply on the operation.
Use $filter=resourceType+eq+'Subscription' to filter on only resource of type = 'Subscription'.
Use $filter=resourceType+eq+'subscription'+or+resourceType+eq+'resourcegroup' to filter on resource of type = 'Subscription' or 'ResourceGroup'

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.IAuthorizationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the role management policy.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.IAuthorizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IEligibleChildResource

## NOTES

## RELATED LINKS
