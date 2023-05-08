<!-- region Generated -->
# Az.Purviewdata
This directory contains the PowerShell module for the Purviewdata service.

---
## Status
[![Az.Purviewdata](https://img.shields.io/powershellgallery/v/Az.Purviewdata.svg?style=flat-square&label=Az.Purviewdata "Az.Purviewdata")](https://www.powershellgallery.com/packages/Az.Purviewdata/)

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
branch: c599abd70c39fa417d97dc59cbf5822f44b47f11
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/purview/data-plane/Azure.Analytics.Purview.Scanning/preview/2021-10-01-preview/scanningService.json

root-module-name: $(prefix).Purview
module-version: 0.1.0
title: Purviewdata
subject-prefix: Purview
identity-correction-for-post: true 
nested-object-to-string: true
resourcegroup-append: true
endpoint-resource-id-key-name: AzurePurviewEndpointResourceId

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$|^Set$|^AddViaIdentity$|^Add$
    remove: true
# Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      variant: ^Create$
      subject: ^(?!.*(ClassificationRule|DataSource|KeyVaultConnection|Filter|Scan$|Trigger|ScanRuleset)).*
    remove: true
  - where:
      variant: ^CreateExpanded$
      subject: ^ClassificationRule$|^DataSource$|^KeyVaultConnection$|^Filter$|^Scan$|^Trigger$|^ScanRuleset$
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
      variant: ViaIdentity|ViaIdentity1
    remove: true
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
    - model-name: RegexClassificationRulePattern
    - model-name: AzureKeyVault
    - model-name: Filter
    - model-name: AzureSubscriptionDataSource
    - model-name: AzureResourceGroupDataSource
    - model-name: AzureSynapseWorkspaceDataSource
    - model-name: AdlsGen1DataSource
    - model-name: AdlsGen2DataSource
    - model-name: AmazonAccountDataSource
    - model-name: AmazonS3DataSource
    - model-name: AmazonSqlDataSource
    - model-name: AzureCosmosDbDataSource
    - model-name: AzureDataExplorerDataSource
    - model-name: AzureFileServiceDataSource
    - model-name: AzureSqlDatabaseDataSource
    - model-name: AmazonPostgreSqlDataSource
    - model-name: AzurePostgreSqlDataSource
    - model-name: SqlServerDatabaseDataSource
    - model-name: AzureSqlDatabaseManagedInstanceDataSource
    - model-name: AzureSqlDataWarehouseDataSource
    - model-name: AzureMySqlDataSource
    - model-name: AzureStorageDataSource
    - model-name: TeradataDataSource
    - model-name: OracleDataSource
    - model-name: SapS4HanaDataSource
    - model-name: SapEccDataSource
    - model-name: PowerBIDataSource
    - model-name: AzureSubscriptionCredentialScan
    - model-name: AzureSubscriptionMsiScan
    - model-name: AzureResourceGroupCredentialScan
    - model-name: AzureResourceGroupMsiScan
    - model-name: AzureSynapseWorkspaceCredentialScan
    - model-name: AzureSynapseWorkspaceMsiScan
    - model-name: AdlsGen1CredentialScan
    - model-name: AdlsGen1MsiScan
    - model-name: AdlsGen2CredentialScan
    - model-name: AdlsGen2MsiScan
    - model-name: AmazonAccountCredentialScan
    - model-name: AmazonS3CredentialScan
    - model-name: AmazonSqlCredentialScan
    - model-name: AzureCosmosDbCredentialScan
    - model-name: AzureDataExplorerCredentialScan
    - model-name: AzureDataExplorerMsiScan
    - model-name: AzureFileServiceCredentialScan
    - model-name: AzureSqlDatabaseCredentialScan
    - model-name: AzureSqlDatabaseMsiScan
    - model-name: AmazonPostgreSqlCredentialScan
    - model-name: AzurePostgreSqlCredentialScan
    - model-name: SqlServerDatabaseCredentialScan
    - model-name: AzureSqlDatabaseManagedInstanceCredentialScan
    - model-name: AzureSqlDatabaseManagedInstanceMsiScan
    - model-name: AzureSqlDataWarehouseCredentialScan
    - model-name: AzureSqlDataWarehouseMsiScan
    - model-name: AzureMySqlCredentialScan
    - model-name: AzureStorageCredentialScan
    - model-name: AzureStorageMsiScan
    - model-name: TeradataTeradataCredentialScan
    - model-name: OracleOracleCredentialScan
    - model-name: SapS4HanaSapS4HanaCredentialScan
    - model-name: SapEccSapEccCredentialScan
    - model-name: PowerBIDelegatedScan
    - model-name: PowerBIMsiScan
```
