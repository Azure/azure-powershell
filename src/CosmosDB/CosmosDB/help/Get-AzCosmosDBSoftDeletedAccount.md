---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version:
schema: 2.0.0
---

# Get-AzCosmosDBSoftDeletedAccount

## SYNOPSIS
Gets soft-deleted CosmosDB database accounts.

## SYNTAX

```
Get-AzCosmosDBSoftDeletedAccount -Location <String> [-ResourceGroupName <String>] [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzCosmosDBSoftDeletedAccount** cmdlet lists all soft-deleted CosmosDB database accounts in the specified location, or gets a specific soft-deleted account by name.

## EXAMPLES

### Example 1: List all soft-deleted accounts in a location
```powershell
Get-AzCosmosDBSoftDeletedAccount -Location "West US 2"
```

Lists all soft-deleted CosmosDB database accounts in the West US 2 location under the current subscription.

### Example 2: Get a specific soft-deleted account
```powershell
Get-AzCosmosDBSoftDeletedAccount -ResourceGroupName "myResourceGroup" -Location "West US 2" -Name "myDeletedAccount"
```

Gets the soft-deleted CosmosDB database account with the specified name in the given resource group and location.

## PARAMETERS

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
Location of the soft-deleted Cosmos DB database account.

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

### -Name
Name of the soft-deleted Cosmos DB database account.

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
Name of resource group.

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

### Microsoft.Azure.Management.CosmosDB.Models.PSSoftDeletedDatabaseAccountGetResult

## NOTES

## RELATED LINKS
