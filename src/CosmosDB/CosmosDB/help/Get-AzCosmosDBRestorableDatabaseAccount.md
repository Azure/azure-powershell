---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbrestorabledatabaseaccount
schema: 2.0.0
---

# Get-AzCosmosDBRestorableDatabaseAccount

## SYNOPSIS
Gets the restorable database account object

## SYNTAX

```
Get-AzCosmosDBRestorableDatabaseAccount [-Location <String>] [-DatabaseAccountInstanceId <String>]
 [-DatabaseAccountName <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of all restorable database account objects in the given account, or a specific restorable database account object with the given instanceId and location

## EXAMPLES

### Example 1
```powershell
Get-AzCosmosDBRestorableDatabaseAccount
```

```output
Id                        : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/westus/restorableDatabaseAccounts/fb8f230e-bab0-452b-81cf-e32643ccc898
DatabaseAccountInstanceId : fb8f230e-bab0-452b-81cf-e32643ccc898
Location                  : West US
DatabaseAccountName       : deleted-account-1
CreationTime              : 8/2/2020 10:23:00 PM
DeletionTime              : 8/2/2020 10:26:13 PM
OldestRestorableTime      : 8/2/2020 10:23:00 PM
ApiType                   : Sql
RestorableLocations       : {West US, East US}

Id                        : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/eastus/restorableDatabaseAccounts/ff921125-e31c-4e8c-ae0a-20fe719baca6
DatabaseAccountInstanceId : ff921125-e31c-4e8c-ae0a-20fe719baca6
Location                  : East US
DatabaseAccountName       : deleted-account-2
CreationTime              : 8/2/2020 6:32:32 PM
DeletionTime              : 8/2/2020 6:34:48 PM
OldestRestorableTime      : 8/2/2020 6:32:32 PM
ApiType                   : Sql
RestorableLocations       : {Australia Southeast, East US, West US}

Id                        : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/westus/restorableDatabaseAccounts/c7b27ad9-3bc0-4955-8cc2-a81790e5c3b3
DatabaseAccountInstanceId : c7b27ad9-3bc0-4955-8cc2-a81790e5c3b3
Location                  : West US
DatabaseAccountName       : live-account-1
CreationTime              : 8/2/2020 6:34:35 PM
DeletionTime              :
OldestRestorableTime      : 8/2/2020 6:34:35 PM
ApiType                   : MongoDB
RestorableLocations       : {West US}
```

Lists all the restorable database accounts in the current subscription

### Example 1
```powershell
Get-AzCosmosDBRestorableDatabaseAccount -Location "West US" -DatabaseAccountInstanceId fb8f230e-bab0-452b-81cf-e32643ccc898
```

```output
Id                        : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/westus/restorableDatabaseAccounts/fb8f230e-bab0-452b-81cf-e32643ccc898
DatabaseAccountInstanceId : fb8f230e-bab0-452b-81cf-e32643ccc898
Location                  : West US
DatabaseAccountName       : deleted-account-1
CreationTime              : 8/2/2020 10:23:00 PM
DeletionTime              : 8/2/2020 10:26:13 PM
ApiType                   : Sql
RestorableLocations       : {West US, East US}
```

Gets the restorable database account with the given DatabaseInstanceId in the given ARM location  

## PARAMETERS

### -DatabaseAccountInstanceId
The instance Id of the CosmosDB database account.

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

### -DatabaseAccountName
Name of the Cosmos DB database account.

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

### -Location
Name of the Location in string.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.CosmosDB.Models.PSRestorableDatabaseAccountGetResult

## NOTES

## RELATED LINKS
