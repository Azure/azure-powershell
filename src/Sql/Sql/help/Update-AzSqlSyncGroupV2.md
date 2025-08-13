---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version:
schema: 2.0.0
---

# Update-AzSqlSyncGroupV2

## SYNOPSIS
Updates an Azure SQL Database Sync Group. 

## SYNTAX

```
Update-AzSqlSyncGroupV2 [-Name] <String> [-IntervalInSeconds <Int32>] [-DatabaseCredential <PSCredential>]
 [-SchemaFile <String>] [-UsePrivateLinkConnection <Boolean>] [-HubDatabaseAuthenticationType <String>]
 [-IdentityId <String>] [-ServerName] <String> [-DatabaseName] <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzSqlSyncGroupV2** cmdlet modifies properties of an Azure SQL Database Sync Group.

## EXAMPLES

### Example 1: Update a sync group for an Azure SQL Database.
```powershell
$credential = Get-Credential
Update-AzSqlSyncGroupV2 -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -Name "SyncGroup01" `
-HubDatabaseAuthenticationType "userAssigned" `
-IdentityId "/subscriptions/{subscriptionId}/resourceGroups/group1/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-umi" -IntervalInSeconds 100 -Schema ".\schema.json" | Format-List
```

```output
ResourceId                  : /subscriptions/{subscriptionId}/resourceGroups/{ResourceGroup01}/servers/{Server01}/databases/{Database01}/syncGroups/{SyncGroup01}
ResourceGroupName           : ResourceGroup01
ServerName                  : Server01
DatabaseName                : Database01
SyncGroupName               : SyncGroup01
SyncDatabaseId              : subscriptions/{subscriptionId}/resourceGroups/{syncDatabaseResourceGroup01}/servers/{syncDatabaseServer01}/databases/{syncDatabaseName01}
IntervalInSeconds           : 100
ConflictResolutionPolicy:   : HubWin
SyncState                   : NotReady
LastSyncTime                : 1/1/0001 12:00:00 AM
Schema                      :
Identity.Type               : UserAssigned
UserAssignedIdentities      : {
                                 "/subscriptions/{subscriptionId}/resourceGroups/group1/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-umi": {
                                     "clientId": "{clientId}",
                                     "principalId": "{principalId}"
                                 }
                              }
```

{{ Add example description here }}

## PARAMETERS

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseCredential
The SQL authentication credential of the hub database.

```yaml
Type: PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
SQL Database name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HubDatabaseAuthenticationType
The Database Authentication type of the hub database.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: password, userAssigned

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityId
The identity ID of the hub database in case of UAMI Authentication

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntervalInSeconds
The frequency (in seconds) of doing data synchronization.
Default is -1, which means the auto synchronization is not enabled.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The sync group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: SyncGroupName

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SchemaFile
The path of the schema file.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
SQL Database server name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UsePrivateLinkConnection
Whether to use a private link connection when connecting to the hub of this sync group.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

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
Type: SwitchParameter
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.DataSync.Model.AzureSqlSyncGroupModelV2

## NOTES

## RELATED LINKS

[New-AzSqlSyncGroupV2](./New-AzSqlSyncGroupV2.md)

[Remove-AzSqlSyncGroup](./Remove-AzSqlSyncGroup.md)

[Get-AzSqlSyncGroup](./Get-AzSqlSyncGroup.md)