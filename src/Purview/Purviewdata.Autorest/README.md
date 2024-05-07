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
identity-correction-for-post: true 
nested-object-to-string: true
resourcegroup-append: true
endpoint-resource-id-key-name: AzurePurviewEndpointResourceId

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
    - CustomClassificationRule
    - RegexClassificationRulePattern
    - AzureKeyVault
    - Filter
    - AzureSubscriptionDataSource
    - AzureResourceGroupDataSource
    - AzureSynapseWorkspaceDataSource
    - AdlsGen1DataSource
    - AdlsGen2DataSource
    - AmazonAccountDataSource
    - AmazonS3DataSource
    - AmazonSqlDataSource
    - AzureCosmosDbDataSource
    - AzureDataExplorerDataSource
    - AzureFileServiceDataSource
    - AzureSqlDatabaseDataSource
    - AmazonPostgreSqlDataSource
    - AzurePostgreSqlDataSource
    - SqlServerDatabaseDataSource
    - AzureSqlDatabaseManagedInstanceDataSource
    - AzureSqlDataWarehouseDataSource
    - AzureMySqlDataSource
    - AzureStorageDataSource
    - TeradataDataSource
    - OracleDataSource
    - SapS4HanaDataSource
    - SapEccDataSource
    - PowerBIDataSource
    - AzureSubscriptionCredentialScan
    - AzureSubscriptionMsiScan
    - AzureResourceGroupCredentialScan
    - AzureResourceGroupMsiScan
    - AzureSynapseWorkspaceCredentialScan
    - AzureSynapseWorkspaceMsiScan
    - AdlsGen1CredentialScan
    - AdlsGen1MsiScan
    - AdlsGen2CredentialScan
    - AdlsGen2MsiScan
    - AmazonAccountCredentialScan
    - AmazonS3CredentialScan
    - AmazonSqlCredentialScan
    - AzureCosmosDbCredentialScan
    - AzureDataExplorerCredentialScan
    - AzureDataExplorerMsiScan
    - AzureFileServiceCredentialScan
    - AzureSqlDatabaseCredentialScan
    - AzureSqlDatabaseMsiScan
    - AmazonPostgreSqlCredentialScan
    - AzurePostgreSqlCredentialScan
    - SqlServerDatabaseCredentialScan
    - AzureSqlDatabaseManagedInstanceCredentialScan
    - AzureSqlDatabaseManagedInstanceMsiScan
    - AzureSqlDataWarehouseCredentialScan
    - AzureSqlDataWarehouseMsiScan
    - AzureMySqlCredentialScan
    - AzureStorageCredentialScan
    - AzureStorageMsiScan
    - TeradataTeradataCredentialScan
    - OracleOracleCredentialScan
    - SapS4HanaSapS4HanaCredentialScan
    - SapEccSapEccCredentialScan
    - PowerBIDelegatedScan
    - PowerBIMsiScan
```
