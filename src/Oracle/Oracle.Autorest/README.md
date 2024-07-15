<!-- region Generated -->
# Az.Oracle
This directory contains the PowerShell module for the Oracle service.

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
For information on how to develop for `Az.Oracle`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
commit: cbbe228fd422db02b65e2748f83df5f2bcad7581
require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/oracle/resource-manager/readme.md

try-require: 
  - $(repo)/specification/oracle/resource-manager/readme.md

module-version: 0.1.0
title: Oracle
subject-prefix: $(service-name)
 
inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true
identity-correction-for-post: true

directive:
  # Model complex objects
  - model-cmdlet:
    - model-name: CustomerContact
  - model-cmdlet:
    - model-name: NsgCidr

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  # Remove APIs
  - where:
      subject: CloudExadataInfrastructureStorageCapacity|PrivateIpaddress|SystemVersion|VirtualNetworkAddress|AutonomousDatabaseWallet|ShrinkAutonomousDatabase|OracleSubscription
    remove: true
  - where:
      subject: AutonomousDatabaseBackUp
      verb: Update
    remove: true

  # Remove variants
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  - where:
      variant: ^Add$|^AddViaIdentity$|^Action$|^ActionViaIdentity$|^ActionViaIdentityCloudVMCluster$|^Switchover$|^SwitchoverViaIdentity$
    remove: true

  # Rename parameter
  - where:  
      parameter-name: ScheduledOperationScheduledStartTime
    set: 
      parameter-name: ScheduledStartTime
  - where:  
      parameter-name: ScheduledOperationScheduledStopTime
    set: 
      parameter-name: ScheduledStopTime
```
