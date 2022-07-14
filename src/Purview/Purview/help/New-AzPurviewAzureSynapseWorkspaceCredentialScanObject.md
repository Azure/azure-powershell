---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://docs.microsoft.com/powershell/module/az.Purview/new-AzPurviewAzureSynapseWorkspaceCredentialScanObject
schema: 2.0.0
---

# New-AzPurviewAzureSynapseWorkspaceCredentialScanObject

## SYNOPSIS
Create an in-memory object for AzureSynapseWorkspaceCredentialScan.

## SYNTAX

```
New-AzPurviewAzureSynapseWorkspaceCredentialScanObject -Kind <ScanAuthorizationType>
 [-CollectionReferenceName <String>] [-CollectionType <String>] [-ConnectedViaReferenceName <String>]
 [-CredentialReferenceName <String>] [-CredentialType <CredentialType>]
 [-ResourceType <IExpandingResourceScanPropertiesResourceTypes>] [-ScanRulesetName <String>]
 [-ScanRulesetType <ScanRulesetType>] [-Worker <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureSynapseWorkspaceCredentialScan.

## EXAMPLES

### Example 1: Create Azure Synapse Workspace Credential scan object
```powershell
New-AzPurviewAzureSynapseWorkspaceCredentialScanObject -Kind 'AzureSynapseWorkspaceCredential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialType 'ServicePrincipal' -CredentialReferenceName 'svcp' -ScanRulesetName 'AzureSynapseSQL' -ScanRulesetType 'System'
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : svcp
CredentialType            : ServicePrincipal
Id                        :
Kind                      : AzureSynapseWorkspaceCredential
LastModifiedAt            :
Name                      :
ResourceType              : {
                            }
Result                    :
ScanRulesetName           : AzureSynapseSQL
ScanRulesetType           : System
Worker                    :
```

Create Azure Synapse Workspace Credential scan object

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.CredentialType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.ScanAuthorizationType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
To construct, see NOTES section for RESOURCETYPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IExpandingResourceScanPropertiesResourceTypes
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.ScanRulesetType
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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.AzureSynapseWorkspaceCredentialScan

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


RESOURCETYPE `<IExpandingResourceScanPropertiesResourceTypes>`: 
  - `[AdlGen1ScanRulesetName <String>]`: 
  - `[AdlGen1ScanRulesetType <ScanRulesetType?>]`: 
  - `[AdlGen2ScanRulesetName <String>]`: 
  - `[AdlGen2ScanRulesetType <ScanRulesetType?>]`: 
  - `[AdlsGen1CredentialReferenceName <String>]`: 
  - `[AdlsGen1CredentialType <CredentialType?>]`: 
  - `[AdlsGen1ResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AdlsGen1ResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AdlsGen1ResourceNameFilterResource <String[]>]`: 
  - `[AdlsGen2CredentialReferenceName <String>]`: 
  - `[AdlsGen2CredentialType <CredentialType?>]`: 
  - `[AdlsGen2ResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AdlsGen2ResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AdlsGen2ResourceNameFilterResource <String[]>]`: 
  - `[AmazonAccountCredentialReferenceName <String>]`: 
  - `[AmazonAccountCredentialType <CredentialType?>]`: 
  - `[AmazonAccountResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AmazonAccountResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AmazonAccountResourceNameFilterResource <String[]>]`: 
  - `[AmazonAccountScanRulesetName <String>]`: 
  - `[AmazonAccountScanRulesetType <ScanRulesetType?>]`: 
  - `[AmazonPostgreSqlCredentialReferenceName <String>]`: 
  - `[AmazonPostgreSqlCredentialType <CredentialType?>]`: 
  - `[AmazonPostgreSqlResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AmazonPostgreSqlResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AmazonPostgreSqlResourceNameFilterResource <String[]>]`: 
  - `[AmazonPostgreSqlScanRulesetName <String>]`: 
  - `[AmazonPostgreSqlScanRulesetType <ScanRulesetType?>]`: 
  - `[AmazonS3CredentialReferenceName <String>]`: 
  - `[AmazonS3CredentialType <CredentialType?>]`: 
  - `[AmazonS3ResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AmazonS3ResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AmazonS3ResourceNameFilterResource <String[]>]`: 
  - `[AmazonS3ScanRulesetName <String>]`: 
  - `[AmazonS3ScanRulesetType <ScanRulesetType?>]`: 
  - `[AmazonSqlCredentialReferenceName <String>]`: 
  - `[AmazonSqlCredentialType <CredentialType?>]`: 
  - `[AmazonSqlResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AmazonSqlResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AmazonSqlResourceNameFilterResource <String[]>]`: 
  - `[AmazonSqlScanRulesetName <String>]`: 
  - `[AmazonSqlScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureCosmoDbScanRulesetName <String>]`: 
  - `[AzureCosmoDbScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureCosmosDbCredentialReferenceName <String>]`: 
  - `[AzureCosmosDbCredentialType <CredentialType?>]`: 
  - `[AzureCosmosDbResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureCosmosDbResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureCosmosDbResourceNameFilterResource <String[]>]`: 
  - `[AzureDataExplorerCredentialReferenceName <String>]`: 
  - `[AzureDataExplorerCredentialType <CredentialType?>]`: 
  - `[AzureDataExplorerResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureDataExplorerResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureDataExplorerResourceNameFilterResource <String[]>]`: 
  - `[AzureDataExplorerScanRulesetName <String>]`: 
  - `[AzureDataExplorerScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureFileServiceCredentialReferenceName <String>]`: 
  - `[AzureFileServiceCredentialType <CredentialType?>]`: 
  - `[AzureFileServiceResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureFileServiceResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureFileServiceResourceNameFilterResource <String[]>]`: 
  - `[AzureFileServiceScanRulesetName <String>]`: 
  - `[AzureFileServiceScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureMySqlCredentialReferenceName <String>]`: 
  - `[AzureMySqlCredentialType <CredentialType?>]`: 
  - `[AzureMySqlResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureMySqlResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureMySqlResourceNameFilterResource <String[]>]`: 
  - `[AzureMySqlScanRulesetName <String>]`: 
  - `[AzureMySqlScanRulesetType <ScanRulesetType?>]`: 
  - `[AzurePostgreSqlCredentialReferenceName <String>]`: 
  - `[AzurePostgreSqlCredentialType <CredentialType?>]`: 
  - `[AzurePostgreSqlResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzurePostgreSqlResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzurePostgreSqlResourceNameFilterResource <String[]>]`: 
  - `[AzurePostgreSqlScanRulesetName <String>]`: 
  - `[AzurePostgreSqlScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureResourceGroupCredentialReferenceName <String>]`: 
  - `[AzureResourceGroupCredentialType <CredentialType?>]`: 
  - `[AzureResourceGroupResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureResourceGroupResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureResourceGroupResourceNameFilterResource <String[]>]`: 
  - `[AzureResourceGroupScanRulesetName <String>]`: 
  - `[AzureResourceGroupScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureSqlDataWarehouseCredentialReferenceName <String>]`: 
  - `[AzureSqlDataWarehouseCredentialType <CredentialType?>]`: 
  - `[AzureSqlDataWarehouseResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureSqlDataWarehouseResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureSqlDataWarehouseResourceNameFilterResource <String[]>]`: 
  - `[AzureSqlDataWarehouseScanRulesetName <String>]`: 
  - `[AzureSqlDataWarehouseScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureSqlDatabaseCredentialReferenceName <String>]`: 
  - `[AzureSqlDatabaseCredentialType <CredentialType?>]`: 
  - `[AzureSqlDatabaseManagedInstanceCredentialReferenceName <String>]`: 
  - `[AzureSqlDatabaseManagedInstanceCredentialType <CredentialType?>]`: 
  - `[AzureSqlDatabaseManagedInstanceResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureSqlDatabaseManagedInstanceResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureSqlDatabaseManagedInstanceResourceNameFilterResource <String[]>]`: 
  - `[AzureSqlDatabaseManagedInstanceScanRulesetName <String>]`: 
  - `[AzureSqlDatabaseManagedInstanceScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureSqlDatabaseResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureSqlDatabaseResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureSqlDatabaseResourceNameFilterResource <String[]>]`: 
  - `[AzureSqlDatabaseScanRulesetName <String>]`: 
  - `[AzureSqlDatabaseScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureStorageCredentialReferenceName <String>]`: 
  - `[AzureStorageCredentialType <CredentialType?>]`: 
  - `[AzureStorageResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureStorageResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureStorageResourceNameFilterResource <String[]>]`: 
  - `[AzureStorageScanRulesetName <String>]`: 
  - `[AzureStorageScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureSubscriptionCredentialReferenceName <String>]`: 
  - `[AzureSubscriptionCredentialType <CredentialType?>]`: 
  - `[AzureSubscriptionResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureSubscriptionResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureSubscriptionResourceNameFilterResource <String[]>]`: 
  - `[AzureSubscriptionScanRulesetName <String>]`: 
  - `[AzureSubscriptionScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureSynapseCredentialReferenceName <String>]`: 
  - `[AzureSynapseCredentialType <CredentialType?>]`: 
  - `[AzureSynapseResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureSynapseResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureSynapseResourceNameFilterResource <String[]>]`: 
  - `[AzureSynapseScanRulesetName <String>]`: 
  - `[AzureSynapseScanRulesetType <ScanRulesetType?>]`: 
  - `[AzureSynapseWorkspaceCredentialReferenceName <String>]`: 
  - `[AzureSynapseWorkspaceCredentialType <CredentialType?>]`: 
  - `[AzureSynapseWorkspaceResourceNameFilterExcludePrefix <String[]>]`: 
  - `[AzureSynapseWorkspaceResourceNameFilterIncludePrefix <String[]>]`: 
  - `[AzureSynapseWorkspaceResourceNameFilterResource <String[]>]`: 
  - `[AzureSynapseWorkspaceScanRulesetName <String>]`: 
  - `[AzureSynapseWorkspaceScanRulesetType <ScanRulesetType?>]`: 
  - `[NoneCredentialReferenceName <String>]`: 
  - `[NoneCredentialType <CredentialType?>]`: 
  - `[NoneResourceNameFilterExcludePrefix <String[]>]`: 
  - `[NoneResourceNameFilterIncludePrefix <String[]>]`: 
  - `[NoneResourceNameFilterResource <String[]>]`: 
  - `[NoneScanRulesetName <String>]`: 
  - `[NoneScanRulesetType <ScanRulesetType?>]`: 
  - `[OracleCredentialReferenceName <String>]`: 
  - `[OracleCredentialType <CredentialType?>]`: 
  - `[OracleResourceNameFilterExcludePrefix <String[]>]`: 
  - `[OracleResourceNameFilterIncludePrefix <String[]>]`: 
  - `[OracleResourceNameFilterResource <String[]>]`: 
  - `[OracleScanRulesetName <String>]`: 
  - `[OracleScanRulesetType <ScanRulesetType?>]`: 
  - `[PowerBiCredentialReferenceName <String>]`: 
  - `[PowerBiCredentialType <CredentialType?>]`: 
  - `[PowerBiResourceNameFilterExcludePrefix <String[]>]`: 
  - `[PowerBiResourceNameFilterIncludePrefix <String[]>]`: 
  - `[PowerBiResourceNameFilterResource <String[]>]`: 
  - `[PowerBiScanRulesetName <String>]`: 
  - `[PowerBiScanRulesetType <ScanRulesetType?>]`: 
  - `[SapEccCredentialReferenceName <String>]`: 
  - `[SapEccCredentialType <CredentialType?>]`: 
  - `[SapEccResourceNameFilterExcludePrefix <String[]>]`: 
  - `[SapEccResourceNameFilterIncludePrefix <String[]>]`: 
  - `[SapEccResourceNameFilterResource <String[]>]`: 
  - `[SapEccScanRulesetName <String>]`: 
  - `[SapEccScanRulesetType <ScanRulesetType?>]`: 
  - `[SapS4HanaCredentialReferenceName <String>]`: 
  - `[SapS4HanaCredentialType <CredentialType?>]`: 
  - `[SapS4HanaResourceNameFilterExcludePrefix <String[]>]`: 
  - `[SapS4HanaResourceNameFilterIncludePrefix <String[]>]`: 
  - `[SapS4HanaResourceNameFilterResource <String[]>]`: 
  - `[SapS4HanaScanRulesetName <String>]`: 
  - `[SapS4HanaScanRulesetType <ScanRulesetType?>]`: 
  - `[SqlServerDatabaseCredentialReferenceName <String>]`: 
  - `[SqlServerDatabaseCredentialType <CredentialType?>]`: 
  - `[SqlServerDatabaseResourceNameFilterExcludePrefix <String[]>]`: 
  - `[SqlServerDatabaseResourceNameFilterIncludePrefix <String[]>]`: 
  - `[SqlServerDatabaseResourceNameFilterResource <String[]>]`: 
  - `[SqlServerDatabaseScanRulesetName <String>]`: 
  - `[SqlServerDatabaseScanRulesetType <ScanRulesetType?>]`: 
  - `[TeradataCredentialReferenceName <String>]`: 
  - `[TeradataCredentialType <CredentialType?>]`: 
  - `[TeradataResourceNameFilterExcludePrefix <String[]>]`: 
  - `[TeradataResourceNameFilterIncludePrefix <String[]>]`: 
  - `[TeradataResourceNameFilterResource <String[]>]`: 
  - `[TeradataScanRulesetName <String>]`: 
  - `[TeradataScanRulesetType <ScanRulesetType?>]`: 

## RELATED LINKS

## RELATED LINKS
