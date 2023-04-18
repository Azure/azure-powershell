---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewazuresubscriptionmsiscanobject
schema: 2.0.0
---

# New-AzPurviewAzureSubscriptionMsiScanObject

## SYNOPSIS
Create an in-memory object for AzureSubscriptionMsiScan.

## SYNTAX

```
New-AzPurviewAzureSubscriptionMsiScanObject [-CollectionReferenceName <String>] [-CollectionType <String>]
 [-ConnectedViaReferenceName <String>] [-CredentialReferenceName <String>] [-CredentialType <String>]
 [-ResourceType <IExpandingResourceScanPropertiesResourceTypes>] [-ScanRulesetName <String>]
 [-ScanRulesetType <String>] [-Worker <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureSubscriptionMsiScan.

## EXAMPLES

### Example 1: Create Azure resource sub Msi scan object
```powershell
New-AzPurviewAzureSubscriptionMsiScanObject -Kind 'AzureSubscriptionMsi' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference'
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   :
CredentialType            :
Id                        :
Kind                      : AzureSubscriptionMsi
LastModifiedAt            :
Name                      :
ResourceType              : {
                            }
Result                    :
ScanRulesetName           :
ScanRulesetType           :
Worker                    :
```

Create Azure resource sub Msi scan object

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

### -ConnectedViaReferenceName


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

### -CredentialReferenceName


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

### -CredentialType


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

### -ResourceType
To construct, see NOTES section for RESOURCETYPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesResourceTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScanRulesetName


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

### -ScanRulesetType


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

### -Worker


```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.AzureSubscriptionMsiScan

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


RESOURCETYPE <IExpandingResourceScanPropertiesResourceTypes>: 
  - `[AdlGen1ScanRulesetName <String>]`: 
  - `[AdlGen1ScanRulesetType <String>]`: 
  - `[AdlGen2ScanRulesetName <String>]`: 
  - `[AdlGen2ScanRulesetType <String>]`: 
  - `[AdlsGen1CredentialReferenceName <String>]`: 
  - `[AdlsGen1CredentialType <String>]`: 
  - `[AdlsGen1ResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AdlsGen1ResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AdlsGen1ResourceNameFilterResource <List<String>>]`: 
  - `[AdlsGen2CredentialReferenceName <String>]`: 
  - `[AdlsGen2CredentialType <String>]`: 
  - `[AdlsGen2ResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AdlsGen2ResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AdlsGen2ResourceNameFilterResource <List<String>>]`: 
  - `[AmazonAccountCredentialReferenceName <String>]`: 
  - `[AmazonAccountCredentialType <String>]`: 
  - `[AmazonAccountResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AmazonAccountResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AmazonAccountResourceNameFilterResource <List<String>>]`: 
  - `[AmazonAccountScanRulesetName <String>]`: 
  - `[AmazonAccountScanRulesetType <String>]`: 
  - `[AmazonPostgreSqlCredentialReferenceName <String>]`: 
  - `[AmazonPostgreSqlCredentialType <String>]`: 
  - `[AmazonPostgreSqlResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AmazonPostgreSqlResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AmazonPostgreSqlResourceNameFilterResource <List<String>>]`: 
  - `[AmazonPostgreSqlScanRulesetName <String>]`: 
  - `[AmazonPostgreSqlScanRulesetType <String>]`: 
  - `[AmazonS3CredentialReferenceName <String>]`: 
  - `[AmazonS3CredentialType <String>]`: 
  - `[AmazonS3ResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AmazonS3ResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AmazonS3ResourceNameFilterResource <List<String>>]`: 
  - `[AmazonS3ScanRulesetName <String>]`: 
  - `[AmazonS3ScanRulesetType <String>]`: 
  - `[AmazonSqlCredentialReferenceName <String>]`: 
  - `[AmazonSqlCredentialType <String>]`: 
  - `[AmazonSqlResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AmazonSqlResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AmazonSqlResourceNameFilterResource <List<String>>]`: 
  - `[AmazonSqlScanRulesetName <String>]`: 
  - `[AmazonSqlScanRulesetType <String>]`: 
  - `[AzureCosmoDbScanRulesetName <String>]`: 
  - `[AzureCosmoDbScanRulesetType <String>]`: 
  - `[AzureCosmosDbCredentialReferenceName <String>]`: 
  - `[AzureCosmosDbCredentialType <String>]`: 
  - `[AzureCosmosDbResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureCosmosDbResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureCosmosDbResourceNameFilterResource <List<String>>]`: 
  - `[AzureDataExplorerCredentialReferenceName <String>]`: 
  - `[AzureDataExplorerCredentialType <String>]`: 
  - `[AzureDataExplorerResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureDataExplorerResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureDataExplorerResourceNameFilterResource <List<String>>]`: 
  - `[AzureDataExplorerScanRulesetName <String>]`: 
  - `[AzureDataExplorerScanRulesetType <String>]`: 
  - `[AzureFileServiceCredentialReferenceName <String>]`: 
  - `[AzureFileServiceCredentialType <String>]`: 
  - `[AzureFileServiceResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureFileServiceResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureFileServiceResourceNameFilterResource <List<String>>]`: 
  - `[AzureFileServiceScanRulesetName <String>]`: 
  - `[AzureFileServiceScanRulesetType <String>]`: 
  - `[AzureMySqlCredentialReferenceName <String>]`: 
  - `[AzureMySqlCredentialType <String>]`: 
  - `[AzureMySqlResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureMySqlResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureMySqlResourceNameFilterResource <List<String>>]`: 
  - `[AzureMySqlScanRulesetName <String>]`: 
  - `[AzureMySqlScanRulesetType <String>]`: 
  - `[AzurePostgreSqlCredentialReferenceName <String>]`: 
  - `[AzurePostgreSqlCredentialType <String>]`: 
  - `[AzurePostgreSqlResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzurePostgreSqlResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzurePostgreSqlResourceNameFilterResource <List<String>>]`: 
  - `[AzurePostgreSqlScanRulesetName <String>]`: 
  - `[AzurePostgreSqlScanRulesetType <String>]`: 
  - `[AzureResourceGroupCredentialReferenceName <String>]`: 
  - `[AzureResourceGroupCredentialType <String>]`: 
  - `[AzureResourceGroupResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureResourceGroupResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureResourceGroupResourceNameFilterResource <List<String>>]`: 
  - `[AzureResourceGroupScanRulesetName <String>]`: 
  - `[AzureResourceGroupScanRulesetType <String>]`: 
  - `[AzureSqlDataWarehouseCredentialReferenceName <String>]`: 
  - `[AzureSqlDataWarehouseCredentialType <String>]`: 
  - `[AzureSqlDataWarehouseResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureSqlDataWarehouseResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureSqlDataWarehouseResourceNameFilterResource <List<String>>]`: 
  - `[AzureSqlDataWarehouseScanRulesetName <String>]`: 
  - `[AzureSqlDataWarehouseScanRulesetType <String>]`: 
  - `[AzureSqlDatabaseCredentialReferenceName <String>]`: 
  - `[AzureSqlDatabaseCredentialType <String>]`: 
  - `[AzureSqlDatabaseManagedInstanceCredentialReferenceName <String>]`: 
  - `[AzureSqlDatabaseManagedInstanceCredentialType <String>]`: 
  - `[AzureSqlDatabaseManagedInstanceResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureSqlDatabaseManagedInstanceResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureSqlDatabaseManagedInstanceResourceNameFilterResource <List<String>>]`: 
  - `[AzureSqlDatabaseManagedInstanceScanRulesetName <String>]`: 
  - `[AzureSqlDatabaseManagedInstanceScanRulesetType <String>]`: 
  - `[AzureSqlDatabaseResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureSqlDatabaseResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureSqlDatabaseResourceNameFilterResource <List<String>>]`: 
  - `[AzureSqlDatabaseScanRulesetName <String>]`: 
  - `[AzureSqlDatabaseScanRulesetType <String>]`: 
  - `[AzureStorageCredentialReferenceName <String>]`: 
  - `[AzureStorageCredentialType <String>]`: 
  - `[AzureStorageResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureStorageResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureStorageResourceNameFilterResource <List<String>>]`: 
  - `[AzureStorageScanRulesetName <String>]`: 
  - `[AzureStorageScanRulesetType <String>]`: 
  - `[AzureSubscriptionCredentialReferenceName <String>]`: 
  - `[AzureSubscriptionCredentialType <String>]`: 
  - `[AzureSubscriptionResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureSubscriptionResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureSubscriptionResourceNameFilterResource <List<String>>]`: 
  - `[AzureSubscriptionScanRulesetName <String>]`: 
  - `[AzureSubscriptionScanRulesetType <String>]`: 
  - `[AzureSynapseCredentialReferenceName <String>]`: 
  - `[AzureSynapseCredentialType <String>]`: 
  - `[AzureSynapseResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureSynapseResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureSynapseResourceNameFilterResource <List<String>>]`: 
  - `[AzureSynapseScanRulesetName <String>]`: 
  - `[AzureSynapseScanRulesetType <String>]`: 
  - `[AzureSynapseWorkspaceCredentialReferenceName <String>]`: 
  - `[AzureSynapseWorkspaceCredentialType <String>]`: 
  - `[AzureSynapseWorkspaceResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[AzureSynapseWorkspaceResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[AzureSynapseWorkspaceResourceNameFilterResource <List<String>>]`: 
  - `[AzureSynapseWorkspaceScanRulesetName <String>]`: 
  - `[AzureSynapseWorkspaceScanRulesetType <String>]`: 
  - `[NoneCredentialReferenceName <String>]`: 
  - `[NoneCredentialType <String>]`: 
  - `[NoneResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[NoneResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[NoneResourceNameFilterResource <List<String>>]`: 
  - `[NoneScanRulesetName <String>]`: 
  - `[NoneScanRulesetType <String>]`: 
  - `[OracleCredentialReferenceName <String>]`: 
  - `[OracleCredentialType <String>]`: 
  - `[OracleResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[OracleResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[OracleResourceNameFilterResource <List<String>>]`: 
  - `[OracleScanRulesetName <String>]`: 
  - `[OracleScanRulesetType <String>]`: 
  - `[PowerBiCredentialReferenceName <String>]`: 
  - `[PowerBiCredentialType <String>]`: 
  - `[PowerBiResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[PowerBiResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[PowerBiResourceNameFilterResource <List<String>>]`: 
  - `[PowerBiScanRulesetName <String>]`: 
  - `[PowerBiScanRulesetType <String>]`: 
  - `[SapEccCredentialReferenceName <String>]`: 
  - `[SapEccCredentialType <String>]`: 
  - `[SapEccResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[SapEccResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[SapEccResourceNameFilterResource <List<String>>]`: 
  - `[SapEccScanRulesetName <String>]`: 
  - `[SapEccScanRulesetType <String>]`: 
  - `[SapS4HanaCredentialReferenceName <String>]`: 
  - `[SapS4HanaCredentialType <String>]`: 
  - `[SapS4HanaResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[SapS4HanaResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[SapS4HanaResourceNameFilterResource <List<String>>]`: 
  - `[SapS4HanaScanRulesetName <String>]`: 
  - `[SapS4HanaScanRulesetType <String>]`: 
  - `[SqlServerDatabaseCredentialReferenceName <String>]`: 
  - `[SqlServerDatabaseCredentialType <String>]`: 
  - `[SqlServerDatabaseResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[SqlServerDatabaseResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[SqlServerDatabaseResourceNameFilterResource <List<String>>]`: 
  - `[SqlServerDatabaseScanRulesetName <String>]`: 
  - `[SqlServerDatabaseScanRulesetType <String>]`: 
  - `[TeradataCredentialReferenceName <String>]`: 
  - `[TeradataCredentialType <String>]`: 
  - `[TeradataResourceNameFilterExcludePrefix <List<String>>]`: 
  - `[TeradataResourceNameFilterIncludePrefix <List<String>>]`: 
  - `[TeradataResourceNameFilterResource <List<String>>]`: 
  - `[TeradataScanRulesetName <String>]`: 
  - `[TeradataScanRulesetType <String>]`: 

## RELATED LINKS

