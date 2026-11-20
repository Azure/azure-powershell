---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/get-azhorizondbmicrosoftentraadministrator
schema: 2.0.0
---

# Get-AzHorizonDbMicrosoftEntraAdministrator

## SYNOPSIS
Gets information about a PostgreSQL role that is a member of azure_pg_admin and mapped to a Microsoft Entra principal.

## SYNTAX

### List (Default)
```
Get-AzHorizonDbMicrosoftEntraAdministrator -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHorizonDbMicrosoftEntraAdministrator -ClusterName <String> -ObjectId <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHorizonDbMicrosoftEntraAdministrator -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCluster
```
Get-AzHorizonDbMicrosoftEntraAdministrator -ClusterInputObject <IHorizonDbIdentity> -ObjectId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about a PostgreSQL role that is a member of azure_pg_admin and mapped to a Microsoft Entra principal.

## EXAMPLES

### Example 1: List Microsoft Entra administrators
```powershell
Get-AzHorizonDbMicrosoftEntraAdministrator -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, PrincipalName, PrincipalType, TenantId, ProvisioningState
```

```output
Name              : 33333333-3333-3333-3333-333333333333
PrincipalName     : admin@contoso.com
PrincipalType     : User
TenantId          : 22222222-2222-2222-2222-222222222222
ProvisioningState : Succeeded

Name              : 44444444-4444-4444-4444-444444444444
PrincipalName     : horizondb-automation@contoso.com
PrincipalType     : ServicePrincipal
TenantId          : 22222222-2222-2222-2222-222222222222
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a Microsoft Entra administrator
```powershell
Get-AzHorizonDbMicrosoftEntraAdministrator -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -ObjectId '11111111-1111-1111-1111-111111111111' | Format-List -Property Name, PrincipalName, PrincipalType, TenantId, ProvisioningState
```

```output
Name              : 11111111-1111-1111-1111-111111111111
PrincipalName     : Database Administrators
PrincipalType     : Group
TenantId          : 22222222-2222-2222-2222-222222222222
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

## PARAMETERS

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the HorizonDB cluster.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ObjectId
The Microsoft Entra object identifier of the principal mapped to the PostgreSQL role, represented as an RFC 4122 GUID.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCluster
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IMicrosoftEntraAdministrator

## NOTES

## RELATED LINKS

