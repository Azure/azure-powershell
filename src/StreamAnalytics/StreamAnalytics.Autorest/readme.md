<!-- region Generated -->
# Az.StreamAnalytics
This directory contains the PowerShell module for the StreamAnalytics service.

---
## Status
[![Az.StreamAnalytics](https://img.shields.io/powershellgallery/v/Az.StreamAnalytics.svg?style=flat-square&label=Az.StreamAnalytics "Az.StreamAnalytics")](https://www.powershellgallery.com/packages/Az.StreamAnalytics/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.8.1 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.StreamAnalytics`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: ec2cba2ff0953d431b88a9fd4922de76157119e0
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/streamanalytics/resource-manager/Microsoft.StreamAnalytics/preview/2020-03-01-preview/clusters.json
   
title: StreamAnalytics
module-version: 1.0.1
subject-prefix: StreamAnalytics

directive:
  # Remove cmdlet
  - where: 
      verb: Set
      subject: Cluster$
    remove: true
  # Remove parameter set name
  - where:
      verb: New
      subject: Cluster$
      variant: Create$|CreateViaIdentity$|CreateViaIdentityExpanded$
    remove: true
  - where:
      verb: Update
      subject: Cluster$
      variant: Update$|UpdateViaIdentity$
    remove: true
```
