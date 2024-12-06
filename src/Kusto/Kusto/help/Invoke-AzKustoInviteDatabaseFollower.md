---
external help file: Az.Kusto-help.xml
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/invoke-azkustoinvitedatabasefollower
schema: 2.0.0
---

# Invoke-AzKustoInviteDatabaseFollower

## SYNOPSIS
Generates an invitation token that allows attaching a follower database to this database.

## SYNTAX

### InviteExpanded (Default)
```
Invoke-AzKustoInviteDatabaseFollower -ClusterName <String> -DatabaseName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -InviteeEmail <String>
 [-TableLevelSharingPropertyExternalTablesToExclude <String[]>]
 [-TableLevelSharingPropertyExternalTablesToInclude <String[]>]
 [-TableLevelSharingPropertyFunctionsToExclude <String[]>]
 [-TableLevelSharingPropertyFunctionsToInclude <String[]>]
 [-TableLevelSharingPropertyMaterializedViewsToExclude <String[]>]
 [-TableLevelSharingPropertyMaterializedViewsToInclude <String[]>]
 [-TableLevelSharingPropertyTablesToExclude <String[]>] [-TableLevelSharingPropertyTablesToInclude <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Invite
```
Invoke-AzKustoInviteDatabaseFollower -ClusterName <String> -DatabaseName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Parameter <IDatabaseInviteFollowerRequest> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InviteViaIdentityExpanded
```
Invoke-AzKustoInviteDatabaseFollower -InputObject <IKustoIdentity> -InviteeEmail <String>
 [-TableLevelSharingPropertyExternalTablesToExclude <String[]>]
 [-TableLevelSharingPropertyExternalTablesToInclude <String[]>]
 [-TableLevelSharingPropertyFunctionsToExclude <String[]>]
 [-TableLevelSharingPropertyFunctionsToInclude <String[]>]
 [-TableLevelSharingPropertyMaterializedViewsToExclude <String[]>]
 [-TableLevelSharingPropertyMaterializedViewsToInclude <String[]>]
 [-TableLevelSharingPropertyTablesToExclude <String[]>] [-TableLevelSharingPropertyTablesToInclude <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InviteViaIdentity
```
Invoke-AzKustoInviteDatabaseFollower -InputObject <IKustoIdentity> -Parameter <IDatabaseInviteFollowerRequest>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Generates an invitation token that allows attaching a follower database to this database.

## EXAMPLES

### Example 1: Invite a Follower to a Cluster database
```powershell
Invoke-AzKustoInviteDatabaseFollower -ClusterName "myCluster" -DatabaseName "myDatabase" -ResourceGroupName "myResourceGroup" -InviteeEmail "user@contoso.com"
```

Invite a user to follow database "myDatabase" in cluster "myCluster" in resource group "myResourceGroup"

## PARAMETERS

### -ClusterName
The name of the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: InviteExpanded, Invite
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
The name of the database in the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: InviteExpanded, Invite
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: InviteViaIdentityExpanded, InviteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InviteeEmail
The email of the invited user for which the follower invitation is generated.

```yaml
Type: System.String
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The request to invite a follower to a database.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDatabaseInviteFollowerRequest
Parameter Sets: Invite, InviteViaIdentity
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: InviteExpanded, Invite
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: InviteExpanded, Invite
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableLevelSharingPropertyExternalTablesToExclude
List of external tables to exclude from the follower database

```yaml
Type: System.String[]
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableLevelSharingPropertyExternalTablesToInclude
List of external tables to include in the follower database

```yaml
Type: System.String[]
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableLevelSharingPropertyFunctionsToExclude
List of functions to exclude from the follower database

```yaml
Type: System.String[]
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableLevelSharingPropertyFunctionsToInclude
List of functions to include in the follower database

```yaml
Type: System.String[]
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableLevelSharingPropertyMaterializedViewsToExclude
List of materialized views to exclude from the follower database

```yaml
Type: System.String[]
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableLevelSharingPropertyMaterializedViewsToInclude
List of materialized views to include in the follower database

```yaml
Type: System.String[]
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableLevelSharingPropertyTablesToExclude
List of tables to exclude from the follower database

```yaml
Type: System.String[]
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableLevelSharingPropertyTablesToInclude
List of tables to include in the follower database

```yaml
Type: System.String[]
Parameter Sets: InviteExpanded, InviteViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDatabaseInviteFollowerRequest

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
