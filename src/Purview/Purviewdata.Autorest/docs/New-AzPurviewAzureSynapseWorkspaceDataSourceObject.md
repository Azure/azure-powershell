---
external help file:
Module Name: Az.Purview
online version: https://docs.microsoft.com/powershell/module/az.Purview/new-AzPurviewAzureSynapseWorkspaceDataSourceObject
schema: 2.0.0
---

# New-AzPurviewAzureSynapseWorkspaceDataSourceObject

## SYNOPSIS
Create an in-memory object for AzureSynapseWorkspaceDataSource.

## SYNTAX

```
New-AzPurviewAzureSynapseWorkspaceDataSourceObject -Kind <DataSourceType> [-CollectionReferenceName <String>]
 [-CollectionType <String>] [-DedicatedSqlEndpoint <String>] [-Location <String>] [-ResourceGroup <String>]
 [-ResourceName <String>] [-ServerlessSqlEndpoint <String>] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureSynapseWorkspaceDataSource.

## EXAMPLES

### Example 1: Create Azure Synapse workspace data source object
```powershell
PS C:\> New-AzPurviewAzureSynapseWorkspaceDataSourceObject -Kind 'AzureSynapseWorkspace' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -DedicatedSqlEndpoint 'g1euap.sql.azuresynapse.net' -ServerlessSqlEndpoint 'rg1euap-ondemand.sql.azuresynapse.net'

CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
DedicatedSqlEndpoint     : g1euap.sql.azuresynapse.net
Id                       :
Kind                     : AzureSynapseWorkspace
LastModifiedAt           :
Location                 :
Name                     :
ResourceGroup            :
ResourceName             :
Scan                     :
ServerlessSqlEndpoint    : rg1euap-ondemand.sql.azuresynapse.net
SubscriptionId           :
```

Create Azure Synapse workspace data source object

## PARAMETERS

### -CollectionReferenceName


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

### -CollectionType


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

### -DedicatedSqlEndpoint


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

### -Kind


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.DataSourceType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location


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

### -ResourceGroup


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

### -ResourceName


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

### -ServerlessSqlEndpoint


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

### -SubscriptionId


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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.AzureSynapseWorkspaceDataSource

## NOTES

ALIASES

## RELATED LINKS

