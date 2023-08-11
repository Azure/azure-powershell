---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/new-azsentinelbookmark
schema: 2.0.0
---

# New-AzSentinelBookmark

## SYNOPSIS
Create the bookmark.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSentinelBookmark -ResourceGroupName <String> -WorkspaceName <String> [-Id <String>]
 [-SubscriptionId <String>] [-DisplayName <String>] [-EventTime <DateTime>] [-IncidentInfoIncidentId <String>]
 [-IncidentInfoRelationName <String>] [-IncidentInfoSeverity <String>] [-IncidentInfoTitle <String>]
 [-Label <String[]>] [-Note <String>] [-Query <String>] [-QueryEndTime <DateTime>] [-QueryResult <String>]
 [-QueryStartTime <DateTime>] [-UpdatedByObjectId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzSentinelBookmark -InputObject <ISecurityInsightsIdentity> [-DisplayName <String>]
 [-EventTime <DateTime>] [-IncidentInfoIncidentId <String>] [-IncidentInfoRelationName <String>]
 [-IncidentInfoSeverity <String>] [-IncidentInfoTitle <String>] [-Label <String[]>] [-Note <String>]
 [-Query <String>] [-QueryEndTime <DateTime>] [-QueryResult <String>] [-QueryStartTime <DateTime>]
 [-UpdatedByObjectId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityWorkspaceExpanded
```
New-AzSentinelBookmark -WorkspaceInputObject <ISecurityInsightsIdentity> [-Id <String>]
 [-DisplayName <String>] [-EventTime <DateTime>] [-IncidentInfoIncidentId <String>]
 [-IncidentInfoRelationName <String>] [-IncidentInfoSeverity <String>] [-IncidentInfoTitle <String>]
 [-Label <String[]>] [-Note <String>] [-Query <String>] [-QueryEndTime <DateTime>] [-QueryResult <String>]
 [-QueryStartTime <DateTime>] [-UpdatedByObjectId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create the bookmark.

## EXAMPLES

### Example 1: Create a Bookmark
```powershell
$queryStartTime = (Get-Date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
$queryEndTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
New-AzSentinelBookmark -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -DisplayName "Incident Evidence" -Query "SecurityEvent | take 1" -QueryStartTime $queryStartTime -QueryEndTime $queryEndTime -EventTime $queryEndTime
```

```output
Created                      : 8/2/2023 9:34:31 AM
CreatedByEmail               : v-jiaji@microsoft.com
CreatedByName                : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId            : 6205f759-1234-453c-9712-34d7671bceff
DisplayName                  : Incident Evidence
Etag                         : "5a0a5305-0000-0100-0000-64ca23270000"
EventTime                    : 8/2/2023 9:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Bookmarks/70aaef57-7165-444b-959d-67e6668d57d0
IncidentInfoIncidentId       : 
IncidentInfoRelationName     : 
IncidentInfoSeverity         : 
IncidentInfoTitle            : 
Label                        : {}
Name                         : 70aaef57-7165-444b-959d-67e6668d57d0
Note                         : 
Query                        : SecurityEvent | take 1
QueryEndTime                 : 8/2/2023 9:00:00 AM
QueryResult                  : 
QueryStartTime               : 8/1/2023 9:00:00 AM
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/Bookmarks
Updated                      : 8/2/2023 9:34:31 AM
UpdatedByEmail               : v-jiaji@microsoft.com
UpdatedByName                : Joyer Jin (Wicresoft North America Ltd)
UpdatedByObjectId            : 6205f759-1234-453c-9712-34d7671bceff
```

This command creates a Bookmark.

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

### -DisplayName
The display name of the bookmark

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

### -EventTime
The bookmark event time

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Bookmark ID

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
Aliases: BookmarkId

Required: False
Position: Named
Default value: (New-Guid).Guid
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncidentInfoIncidentId
Incident Id

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

### -IncidentInfoRelationName
Relation Name

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

### -IncidentInfoSeverity
The severity of the incident

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

### -IncidentInfoTitle
The title of the incident

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Label
List of labels relevant to this bookmark

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Note
The notes of the bookmark

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

### -Query
The query of the bookmark.

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

### -QueryEndTime
The end time for the query

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryResult
The query result of the bookmark.

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

### -QueryStartTime
The start time for the query

```yaml
Type: System.DateTime
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdatedByObjectId
The object id of the user.

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

### -WorkspaceInputObject
Identity Parameter
To construct, see NOTES section for WORKSPACEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: CreateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IBookmark

## NOTES

## RELATED LINKS

