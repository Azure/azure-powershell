---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/new-azhorizondbmicrosoftentraadministrator
schema: 2.0.0
---

# New-AzHorizonDbMicrosoftEntraAdministrator

## SYNOPSIS
Create or replaces a PostgreSQL role that is a member of azure_pg_admin and mapped to a Microsoft Entra principal.

## SYNTAX

### CreateExpanded (Default)
```
New-AzHorizonDbMicrosoftEntraAdministrator -ClusterName <String> -ObjectId <String>
 -ResourceGroupName <String> -PrincipalName <String> -PrincipalType <String> [-SubscriptionId <String>]
 [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityClusterExpanded
```
New-AzHorizonDbMicrosoftEntraAdministrator -ClusterInputObject <IHorizonDbIdentity> -ObjectId <String>
 -PrincipalName <String> -PrincipalType <String> [-TenantId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzHorizonDbMicrosoftEntraAdministrator -ClusterName <String> -ObjectId <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzHorizonDbMicrosoftEntraAdministrator -ClusterName <String> -ObjectId <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or replaces a PostgreSQL role that is a member of azure_pg_admin and mapped to a Microsoft Entra principal.

## EXAMPLES

### Example 1: Create a Microsoft Entra group administrator
```powershell
New-AzHorizonDbMicrosoftEntraAdministrator -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -ObjectId '11111111-1111-1111-1111-111111111111' -PrincipalName 'database.administrators@contoso.com' -PrincipalType 'Group' -TenantId '22222222-2222-2222-2222-222222222222' | Format-List -Property Name, PrincipalName, PrincipalType, TenantId, ProvisioningState
```

```output
Name              : 11111111-1111-1111-1111-111111111111
PrincipalName     : database.administrators@contoso.com
PrincipalType     : Group
TenantId          : 22222222-2222-2222-2222-222222222222
ProvisioningState : Provisioning
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

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

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

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

### -ObjectId
The Microsoft Entra object identifier of the principal mapped to the PostgreSQL role, represented as an RFC 4122 GUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalName
The display name or user principal name of the Microsoft Entra principal to map to the PostgreSQL role.
For users, this is typically the user principal name, such as admin@contoso.com.
For groups, this is the group display name.
For service principals, this is the application display name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalType
The type of Microsoft Entra principal to map to the PostgreSQL role.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The identifier of the Microsoft Entra tenant containing the principal to map, represented as an RFC 4122 GUID.
If omitted, this value defaults to the tenant of the subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IMicrosoftEntraAdministrator

## NOTES

## RELATED LINKS

