<!-- region Generated -->
# Az.OracleDatabase
This directory contains the PowerShell module for the OracleDatabase service.

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
For information on how to develop for `Az.OracleDatabase`, see [how-to.md](how-to.md).
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

module-version: 1.0.0
title: OracleDatabase
subject-prefix: $(service-name)
 
inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true
identity-correction-for-post: true

directive:
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
      subject: CloudExadataInfrastructureStorageCapacity|PrivateIpaddress|SystemVersion|VirtualNetworkAddress|ShrinkAutonomousDatabase|SwitchoverAutonomousDatabase|AutonomousDatabaseBackup|AutonomousDatabaseWallet|OracleSubscription
    remove: true
  - where:
      verb: Restore
    remove: true
```
