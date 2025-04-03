---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/restore-azcosmosdbaccount
schema: 2.0.0
---

# Restore-AzCosmosDBAccount

## SYNOPSIS
Restores an existing CosmosDB account (live or deleted) to a given timestamp to a new account

## SYNTAX

```
Restore-AzCosmosDBAccount -RestoreTimestampInUtc <DateTime> -SourceDatabaseAccountName <String>
 -Location <String> -TargetResourceGroupName <String> -TargetDatabaseAccountName <String>
 [-DatabasesToRestore <PSDatabaseToRestore[]>] [-GremlinDatabasesToRestore <PSGremlinDatabaseToRestore[]>]
 [-TablesToRestore <PSTablesToRestore>] [-PublicNetworkAccess <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-DisableTtl <Boolean>] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new CosmosDB account by restoring an existing account with the given name and timestamp.

## EXAMPLES

### Example 1
```powershell
Restore-AzCosmosDBAccount -TargetResourceGroupName resourceGroupName -TargetDatabaseAccountName restored-account-name  -SourceDatabaseAccountName sourceDatabaseAccountName -RestoreTimestampInUtc 2020-07-20T17:19:25+0000 -Location "West US"
```

```output
Id                                 : /subscriptions/259fbb24-9bcd-4cfc-865c-fc33b22fe38a/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/restored-account-name
Name                               : restored-account-name
InstanceId                         : eeb45f7f-4c05-4b52-9f42-6807d8eb8703
Location                           : West US
Tags                               : {}
EnableCassandraConnector           :
EnableMultipleWriteLocations       : False
VirtualNetworkRules                : {}
FailoverPolicies                   : {restored-account-name-westus}
Locations                          : {restored-account-name-westus}
ReadLocations                      : {restored-account-name-westus}
WriteLocations                     : {restored-account-name-westus}
Capabilities                       : {}
ConsistencyPolicy                  : Microsoft.Azure.Management.CosmosDB.Models.ConsistencyPolicy
EnableAutomaticFailover            : False
IsVirtualNetworkFilterEnabled      : False
IpRules                            : {}
DatabaseAccountOfferType           : Standard
DocumentEndpoint                   : https://restored-account-name.documents.azure.com:443/
ProvisioningState                  : Succeeded
Kind                               : GlobalDocumentDB
ConnectorOffer                     :
DisableKeyBasedMetadataWriteAccess : False
PublicNetworkAccess                : Enabled
KeyVaultKeyUri                     :
PrivateEndpointConnections         :
EnableFreeTier                     : False
ApiProperties                      : Microsoft.Azure.Commands.CosmosDB.Models.PSApiProperties
EnableAnalyticalStorage            : False
BackupPolicy                       : Microsoft.Azure.Commands.CosmosDB.Models.PSBackupPolicy
RestoreParameters                  : Microsoft.Azure.Commands.CosmosDB.Models.PSRestoreParameters
CreateMode                         : Restore
```

{{ Creates a new CosmosDB account by restoring an existing account with the given name and timestamp. }}

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -DatabasesToRestore
The list of PSDatabaseToRestore objects which specify the subset of databases and collections to restore from the source account. (If not provided, all the databases will be restored)

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSDatabaseToRestore[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableTtl
Bool to indicate if restored account is going to have Time-To-Live disabled.
```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GremlinDatabasesToRestore
The list of PSGremlinDatabaseToRestore objects which specify the subset of databases and graphs to restore from the source account. (If not provided, all the databases will be restored)

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSGremlinDatabaseToRestore[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the source account from which restore is triggered.
This will also be the write region of the restored account

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

### -PublicNetworkAccess
Flag to allow/block public endpoint access the restored account. Possible values include: 'Enabled', 'Disabled'

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

### -RestoreTimestampInUtc
The timestamp to which the source account has to be restored to.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDatabaseAccountName
The name of the source database account of the restore.

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

### -TablesToRestore
The list of PSTableToRestore objects which specify the subset of tables to restore from the source account. (If not provided, all the tables will be restored)

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSTablesToRestore
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDatabaseAccountName
Name of the Cosmos DB database account.

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

### -TargetResourceGroupName
Name of resource group.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSDatabaseAccountGetResults

## NOTES

## RELATED LINKS
