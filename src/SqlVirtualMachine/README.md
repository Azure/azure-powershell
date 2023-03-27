<!-- region Generated -->
# Az.SqlVirtualMachine
This directory contains the PowerShell module for the SqlVirtualMachine service.

---
## Status
[![Az.SqlVirtualMachine](https://img.shields.io/powershellgallery/v/Az.SqlVirtualMachine.svg?style=flat-square&label=Az.SqlVirtualMachine "Az.SqlVirtualMachine")](https://www.powershellgallery.com/packages/Az.SqlVirtualMachine/)

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
For information on how to develop for `Az.SqlVirtualMachine`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
branch: 0e20dd2e4e2a40e83840c30cce2efc4847fd9cb9
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/sqlvirtualmachine/resource-manager/readme.md

try-require: 
  - $(repo)/specification/sqlvirtualmachine/resource-manager/readme.powershell.md

inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true
identity-correction-for-post: true
	
directive:
  #1. [swagger] define password parameters as password type
  - from: swagger-document
    where: $.definitions..storageAccountPrimaryKey
    transform: $.format = "password"
  - from: swagger-document
    where: $.definitions..clusterBootstrapAccountPassword
    transform: $.format = "password"
  - from: swagger-document
    where: $.definitions..clusterOperatorAccountPassword
    transform: $.format = "password"
  - from: swagger-document
    where: $.definitions..sqlServiceAccountPassword
    transform: $.format = "password"
  - from: swagger-document
    where: $.definitions..sqlAuthUpdatePassword
    transform: $.format = "password"
  - from: swagger-document
    where: $.definitions.AutoBackupSettings.properties.password
    transform: $.format = "password"
  #2. [swagger] change the final-state-via to align with service response
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/redeploy"].post["x-ms-long-running-operation-options"]
    transform: $["final-state-via"] = "azure-async-operation"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/startAssessment"].post["x-ms-long-running-operation-options"]
    transform: $["final-state-via"] = "azure-async-operation"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/troubleshoot"].post["x-ms-long-running-operation-options"]
    transform: $["final-state-via"] = "azure-async-operation"  
  #3. [cmdlet] remove or simplify the subject prefix
  - where:  
      subject: ^SqlVirtualMachine$|^SqlVirtualMachineGroup$|^AvailabilityGroupListener$|^RedeploySqlVirtualMachine$
    set: 
      subject-prefix: ""
  - where:  
      subject-prefix: ^SqlVirtualMachine$
    set: 
      subject-prefix: SqlVM
  #4. [cmdlet] simplify subject 
  - where:  
      subject: ^SqlVirtualMachine$
    set: 
      subject: SqlVM
  - where:  
      subject: ^SqlVirtualMachineGroup$
    set: 
      subject: SqlVMGroup
  - where:  
      subject: ^RedeploySqlVirtualMachine$
    set: 
      subject: RedeploySqlVM
  - where:  
      subject: ^TroubleshootSqlVirtualMachineTroubleshoot$
    set: 
      subject: Troubleshoot
  - where:  
      subject: ^SqlVirtualMachineAssessment$
    set: 
      subject: Assessment
  #5. [cmdlet] remove unnecessary variants
  - where:
      variant: ^Create$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Troubleshoot$|^TroubleshootViaIdentity$|^UpdateViaIdentityExpanded$|^UpdateExpanded$
      subject: ^SqlVM$|^SqlVMGroup$|^AvailabilityGroupListener$
    remove: true
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Troubleshoot$|^TroubleshootViaIdentity$
      subject: ^RedeploySqlVM$|^Troubleshoot$
    remove: true
  #6. [cmdlet] remove set cmdlets
  - where:  
      subject: ^SqlVM$|^SqlVMGroup$|^AvailabilityGroupListener$
      verb: Set
    remove: true
  #7. [cmdlet] hide cmdlets for customization
  - where:  
      subject: ^SqlVM$
      verb: New|Update
    hide: true
  - where:  
      subject: ^SqlVMGroup$|^AvailabilityGroupListener$
      variant: ^CreateViaIdentity$
    hide: true
  - where:  
      subject: ^AvailabilityGroupListener$
      verb: New
    hide: true
  #8. [cmdlet] add model cmdlet
  - model-cmdlet:
    - AgReplica
    - MultiSubnetIPConfiguration
  #9. [parameter] rename parameters
  - where:  
      parameter-name: SqlVirtualMachineGroupName
    set: 
      parameter-name: SqlVMGroupName
  - where:  
      parameter-name: SqlServerLicenseType
    set: 
      parameter-name: LicenseType
  - where:  
      parameter-name: SqlImageOffer
    set: 
      parameter-name: Offer
  - where:  
      parameter-name: SqlImageSku
    set: 
      parameter-name: Sku
  - where:  
      parameter-name: SqlManagement
    set: 
      parameter-name: SqlManagementType
  - where:  
      parameter-name: WsfcDomainProfileClusterBootstrapAccount
    set: 
      parameter-name: ClusterBootstrapAccount
  - where:  
      parameter-name: WsfcDomainProfileClusterOperatorAccount
    set: 
      parameter-name: ClusterOperatorAccount
  - where:  
      parameter-name: WsfcDomainProfileClusterSubnetType
    set: 
      parameter-name: ClusterSubnetType
  - where:  
      parameter-name: WsfcDomainProfileDomainFqdn
    set:
      parameter-name: DomainFqdn
  - where:  
      parameter-name: WsfcDomainProfileFileShareWitnessPath
    set: 
      parameter-name: FileShareWitnessPath
  - where:  
      parameter-name: WsfcDomainProfileOuPath
    set: 
      parameter-name: OuPath
  - where:  
      parameter-name: WsfcDomainProfileSqlServiceAccount
    set: 
      parameter-name: SqlServiceAccount
  - where:  
      parameter-name: WsfcDomainProfileStorageAccountPrimaryKey
    set: 
      parameter-name: StorageAccountPrimaryKey
  - where:  
      parameter-name: WsfcDomainProfileStorageAccountUrl
    set: 
      parameter-name: StorageAccountUrl
  #10. [parameter] parameter alias
  - where:  
      subject: SqlVM
      parameter-name: Name
    set: 
      alias: SqlVMName
  - where:  
      subject: SqlVMGroup
      parameter-name: Name
    set: 
      alias: SqlVMGroupName
  - where:  
      parameter-name: SqlVMGroupName
    set: 
      alias: GroupName
  #11. [parameter] set parameter default value
  - where:  
      subject: AvailabilityGroupListener
      variant: ^CreateExpanded$
      parameter-name: Port
    set: 
      default:
        script: '1433'
  #12. [csharp] adjust a pattern string
  - from: SqlVirtualMachineManagementClient.cs
    where: $
    transform: return $.replace(/@\"\^\(\(\?!_\)\[\^\\\\\/\"\'\\\[\\\]\:\|\<\>\+\=;,\?\*\@\&\]\{1\,64\}\(\?\<\!\[\.\-\]\)\)\$\"/g, '@"^((?!_)[^\\\\/\"\"\'\\[\\]:|<>+=;,?*@&]{1,64}(?<![.-]))$"')
```
