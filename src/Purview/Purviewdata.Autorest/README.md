<!-- region Generated -->
# Az.Purviewdata
This directory contains the PowerShell module for the Purviewdata service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Purviewdata`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: c599abd70c39fa417d97dc59cbf5822f44b47f11
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/purview/data-plane/Azure.Analytics.Purview.Scanning/preview/2021-10-01-preview/scanningService.json

root-module-name: $(prefix).Purview
module-version: 0.1.0
title: Purviewdata
subject-prefix: Purview
endpoint-resource-id-key-name: AzurePurviewEndpointResourceId

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^(Update|Check|Add|Set)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^CheckViaIdentityExpanded$
    remove: true
  - where:
      variant: ^Create$
      subject: ^(?!.*(ClassificationRule|DataSource|KeyVaultConnection|Filter|Scan$|Trigger|ScanRuleset)).*
    remove: true
  - where:
      variant: ^CreateExpanded$
      subject: ^ClassificationRule$|^DataSource$|^KeyVaultConnection$|^Filter$|^Scan$|^Trigger$|^ScanRuleset$
    remove: true
  - where:
      variant: ViaIdentity|ViaIdentity1
    remove: true
# Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public static Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.ScanAuthorizationType TeradataUserPass = @"TeradataTeradataUserPass";', 'public static Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.ScanAuthorizationType TeradataTeradataUserPass = @"TeradataTeradataUserPass";');
  - from: source-file-csharp
    where: $
    transform: $ = $.split("{Endpoint}").join("{endpoint}");
  - where:
        model-name: CustomClassificationRule
    set:      
        suppress-format: true
  - where:
        model-name: (.*)DataSource$
    set:      
        suppress-format: true
  - where:
        model-name: AzureKeyVault
    set:      
        suppress-format: true
  - where:
        model-name: Filter
    set:      
        suppress-format: true
  - where:
        model-name: ScanResult
    set:      
        suppress-format: true
  - where:
        model-name: (.*)Scan$
    set:      
        suppress-format: true
  - where:
        model-name: Trigger
    set:      
        suppress-format: true
  - where:
        model-name: (.*)ScanRuleset
    set:      
        suppress-format: true
  - where:
        model-name: (.*)SystemScanRuleset
    set:      
        suppress-format: true

  - model-cmdlet:
      - model-name: CustomClassificationRule
        cmdlet-name: New-AzPurviewCustomClassificationRuleObject
      - model-name: RegexClassificationRulePattern
        cmdlet-name: New-AzPurviewRegexClassificationRulePatternObject
      - model-name: AzureKeyVault
        cmdlet-name: New-AzPurviewAzureKeyVaultObject
      - model-name: Filter
        cmdlet-name: New-AzPurviewFilterObject
      - model-name: AzureSubscriptionDataSource
        cmdlet-name: New-AzPurviewAzureSubscriptionDataSourceObject
      - model-name: AzureResourceGroupDataSource
        cmdlet-name: New-AzPurviewAzureResourceGroupDataSourceObject
      - model-name: AzureSynapseWorkspaceDataSource
        cmdlet-name: New-AzPurviewAzureSynapseWorkspaceDataSourceObject
      - model-name: AdlsGen1DataSource
        cmdlet-name: New-AzPurviewAdlsGen1DataSourceObject
      - model-name: AdlsGen2DataSource
        cmdlet-name: New-AzPurviewAdlsGen2DataSourceObject
      - model-name: AmazonAccountDataSource
        cmdlet-name: New-AzPurviewAmazonAccountDataSourceObject
      - model-name: AmazonS3DataSource
        cmdlet-name: New-AzPurviewAmazonS3DataSourceObject
      - model-name: AmazonSqlDataSource
        cmdlet-name: New-AzPurviewAmazonSqlDataSourceObject
      - model-name: AzureCosmosDbDataSource
        cmdlet-name: New-AzPurviewAzureCosmosDbDataSourceObject
      - model-name: AzureDataExplorerDataSource
        cmdlet-name: New-AzPurviewAzureDataExplorerDataSourceObject
      - model-name: AzureFileServiceDataSource
        cmdlet-name: New-AzPurviewAzureFileServiceDataSourceObject
      - model-name: AzureSqlDatabaseDataSource
        cmdlet-name: New-AzPurviewAzureSqlDatabaseDataSourceObject
      - model-name: AmazonPostgreSqlDataSource
        cmdlet-name: New-AzPurviewAmazonPostgreSqlDataSourceObject
      - model-name: AzurePostgreSqlDataSource
        cmdlet-name: New-AzPurviewAzurePostgreSqlDataSourceObject
      - model-name: SqlServerDatabaseDataSource
        cmdlet-name: New-AzPurviewSqlServerDatabaseDataSourceObject
      - model-name: AzureSqlDatabaseManagedInstanceDataSource
        cmdlet-name: New-AzPurviewAzureSqlDatabaseManagedInstanceDataSourceObject
      - model-name: AzureSqlDataWarehouseDataSource
        cmdlet-name: New-AzPurviewAzureSqlDataWarehouseDataSourceObject
      - model-name: AzureMySqlDataSource
        cmdlet-name: New-AzPurviewAzureMySqlDataSourceObject
      - model-name: AzureStorageDataSource
        cmdlet-name: New-AzPurviewAzureStorageDataSourceObject
      - model-name: TeradataDataSource
        cmdlet-name: New-AzPurviewTeradataDataSourceObject
      - model-name: OracleDataSource
        cmdlet-name: New-AzPurviewOracleDataSourceObject
      - model-name: SapS4HanaDataSource
        cmdlet-name: New-AzPurviewSapS4HanaDataSourceObject
      - model-name: SapEccDataSource
        cmdlet-name: New-AzPurviewSapEccDataSourceObject
      - model-name: PowerBIDataSource
        cmdlet-name: New-AzPurviewPowerBIDataSourceObject
      - model-name: AzureSubscriptionCredentialScan
        cmdlet-name: New-AzPurviewAzureSubscriptionCredentialScanObject
      - model-name: AzureSubscriptionMsiScan
        cmdlet-name: New-AzPurviewAzureSubscriptionMsiScanObject
      - model-name: AzureResourceGroupCredentialScan
        cmdlet-name: New-AzPurviewAzureResourceGroupCredentialScanObject
      - model-name: AzureResourceGroupMsiScan
        cmdlet-name: New-AzPurviewAzureResourceGroupMsiScanObject
      - model-name: AzureSynapseWorkspaceCredentialScan
        cmdlet-name: New-AzPurviewAzureSynapseWorkspaceCredentialScanObject
      - model-name: AzureSynapseWorkspaceMsiScan
        cmdlet-name: New-AzPurviewAzureSynapseWorkspaceMsiScanObject
      - model-name: AdlsGen1CredentialScan
        cmdlet-name: New-AzPurviewAdlsGen1CredentialScanObject
      - model-name: AdlsGen1MsiScan
        cmdlet-name: New-AzPurviewAdlsGen1MsiScanObject
      - model-name: AdlsGen2CredentialScan
        cmdlet-name: New-AzPurviewAdlsGen2CredentialScanObject
      - model-name: AdlsGen2MsiScan
        cmdlet-name: New-AzPurviewAdlsGen2MsiScanObject
      - model-name: AmazonAccountCredentialScan
        cmdlet-name: New-AzPurviewAmazonAccountCredentialScanObject
      - model-name: AmazonS3CredentialScan
        cmdlet-name: New-AzPurviewAmazonS3CredentialScanObject
      - model-name: AmazonSqlCredentialScan
        cmdlet-name: New-AzPurviewAmazonSqlCredentialScanObject
      - model-name: AzureCosmosDbCredentialScan
        cmdlet-name: New-AzPurviewAzureCosmosDbCredentialScanObject
      - model-name: AzureDataExplorerCredentialScan
        cmdlet-name: New-AzPurviewAzureDataExplorerCredentialScanObject
      - model-name: AzureDataExplorerMsiScan
        cmdlet-name: New-AzPurviewAzureDataExplorerMsiScanObject
      - model-name: AzureFileServiceCredentialScan
        cmdlet-name: New-AzPurviewAzureFileServiceCredentialScanObject
      - model-name: AzureSqlDatabaseCredentialScan
        cmdlet-name: New-AzPurviewAzureSqlDatabaseCredentialScanObject
      - model-name: AzureSqlDatabaseMsiScan
        cmdlet-name: New-AzPurviewAzureSqlDatabaseMsiScanObject
      - model-name: AmazonPostgreSqlCredentialScan
        cmdlet-name: New-AzPurviewAmazonPostgreSqlCredentialScanObject
      - model-name: AzurePostgreSqlCredentialScan
        cmdlet-name: New-AzPurviewAzurePostgreSqlCredentialScanObject
      - model-name: SqlServerDatabaseCredentialScan
        cmdlet-name: New-AzPurviewSqlServerDatabaseCredentialScanObject
      - model-name: AzureSqlDatabaseManagedInstanceCredentialScan
        cmdlet-name: New-AzPurviewAzureSqlDatabaseManagedInstanceCredentialScanObject
      - model-name: AzureSqlDatabaseManagedInstanceMsiScan
        cmdlet-name: New-AzPurviewAzureSqlDatabaseManagedInstanceMsiScanObject
      - model-name: AzureSqlDataWarehouseCredentialScan
        cmdlet-name: New-AzPurviewAzureSqlDataWarehouseCredentialScanObject
      - model-name: AzureSqlDataWarehouseMsiScan
        cmdlet-name: New-AzPurviewAzureSqlDataWarehouseMsiScanObject
      - model-name: AzureMySqlCredentialScan
        cmdlet-name: New-AzPurviewAzureMySqlCredentialScanObject
      - model-name: AzureStorageCredentialScan
        cmdlet-name: New-AzPurviewAzureStorageCredentialScanObject
      - model-name: AzureStorageMsiScan
        cmdlet-name: New-AzPurviewAzureStorageMsiScanObject
      - model-name: SapS4HanaSapS4HanaCredentialScan
        cmdlet-name: New-AzPurviewSapS4HanaSapS4HanaCredentialScanObject
      - model-name: PowerBIDelegatedScan
        cmdlet-name: New-AzPurviewPowerBIDelegatedScanObject
      - model-name: PowerBIMsiScan
        cmdlet-name: New-AzPurviewPowerBIMsiScanObject
      - model-name: AdlsGen1ScanRuleset
        cmdlet-name: New-AzPurviewAdlsGen1ScanRulesetObject
      - model-name: AdlsGen2ScanRuleset
        cmdlet-name: New-AzPurviewAdlsGen2ScanRulesetObject
      - model-name: AmazonPostgreSqlScanRuleset
        cmdlet-name: New-AzPurviewAmazonPostgreSqlScanRulesetObject
      - model-name: AmazonS3ScanRuleset
        cmdlet-name: New-AzPurviewAmazonS3ScanRulesetObject
      - model-name: AmazonSqlScanRuleset
        cmdlet-name: New-AzPurviewAmazonSqlScanRulesetObject
      - model-name: AzureCosmosDbScanRuleset
        cmdlet-name: New-AzPurviewAzureCosmosDbScanRulesetObject
      - model-name: AzureDataExplorerScanRuleset
        cmdlet-name: New-AzPurviewAzureDataExplorerScanRulesetObject
      - model-name: AzureFileServiceScanRuleset
        cmdlet-name: New-AzPurviewAzureFileServiceScanRulesetObject
      - model-name: AzureMySqlScanRuleset
        cmdlet-name: New-AzPurviewAzureMySqlScanRulesetObject
      - model-name: AzurePostgreSqlScanRuleset
        cmdlet-name: New-AzPurviewAzurePostgreSqlScanRulesetObject
      - model-name: AzureSqlDatabaseManagedInstanceScanRuleset
        cmdlet-name: New-AzPurviewAzureSqlDatabaseManagedInstanceScanRulesetObject
      - model-name: AzureSqlDatabaseScanRuleset
        cmdlet-name: New-AzPurviewAzureSqlDatabaseScanRulesetObject
      - model-name: AzureSqlDataWarehouseScanRuleset
        cmdlet-name: New-AzPurviewAzureSqlDataWarehouseScanRulesetObject
      - model-name: AzureStorageScanRuleset
        cmdlet-name: New-AzPurviewAzureStorageScanRulesetObject
      - model-name: AzureSynapseWorkspaceScanRuleset
        cmdlet-name: New-AzPurviewAzureSynapseWorkspaceScanRulesetObject
      - model-name: SqlServerDatabaseScanRuleset
        cmdlet-name: New-AzPurviewSqlServerDatabaseScanRulesetObject
      - model-name: Trigger
        cmdlet-name: New-AzPurviewTriggerObject
```
