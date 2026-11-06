<!-- region Generated -->
# Az.NetworkSecurity
This directory contains the PowerShell module for the NetworkSecurity service.

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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 5.5.4 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.NetworkSecurity`, see [how-to.md](how-to.md).
<!-- endregion -->

# Az.NetworkSecurity

Azure PowerShell management cmdlets for Microsoft.NetworkSecurity.

The module name and cmdlet design are provisional pending design review.
The service is in private preview. Subscriptions require the
`Microsoft.NetworkSecurity/NeuroShieldPreview` AFEC feature.

## AutoRest Configuration

> see https://aka.ms/autorest

```yaml
commit: f2d8237a043f0ac3cbe11741f19ebed60f1248cc
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/networksecurity/resource-manager/Microsoft.NetworkSecurity/neuroShield/preview/2026-10-01-preview/neuroShield.json

module-version: 0.1.0
title: NetworkSecurity
service-name: NetworkSecurity
subject-prefix: NetworkSecurity
resourcegroup-append: true

directive:
  - where:
      verb: Set
    remove: true
  - where:
      verb: Update
      subject: NeuroShieldProtectedResource
    remove: true
  - where:
      verb: Get
      subject: NeuroShieldOperationStatuses
    set:
      subject: NeuroShieldOperationStatus
  - where:
      verb: Invoke
      subject: ExecuteNeuroShieldMitigation
    set:
      subject: NeuroShieldMitigationExecution
  - where:
      verb: Invoke
      subject: MitigateNeuroShieldFinding
    set:
      subject: NeuroShieldFindingMitigation
  - where:
      verb: Invoke
      subject: RollbackNeuroShieldFinding
    set:
      subject: NeuroShieldFindingRollback
  - where:
      verb: Invoke
      subject: RollbackNeuroShieldMitigation
    set:
      subject: NeuroShieldMitigationRollback
  - where:
      verb: Start
      subject: NeuroShieldProtectedResourceInventoryUpload
    set:
      verb: Invoke
```
