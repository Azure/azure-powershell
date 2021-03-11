<!-- region Generated -->
# Az.DataProtection
This directory contains the PowerShell module for the DataProtection service.

---
## Status
[![Az.DataProtection](https://img.shields.io/powershellgallery/v/Az.DataProtection.svg?style=flat-square&label=Az.DataProtection "Az.DataProtection")](https://www.powershellgallery.com/packages/Az.DataProtection/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.DataProtection`, see [how-to.md](how-to.md).
<!-- endregion -->

# My API 

This file contains the configuration for generating My API from the OpenAPI specification.

> see https://aka.ms/autorest

``` yaml
# it's the same options as command line options, just drop the double-dash!
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file: dataprotection_preview.json
title: DataProtection
directive:
  - where:
      verb: Get
      subject: BackupVaultResource.*
    hide: true
  - where:
      verb: Get
      subject: RecoveryPointList.*
    hide: true
  - where:
      verb: Set
    remove: true
  - where:
      verb: New
      subject: BackupInstance.*
    hide: true
  - where:
      verb: New
      subject: BackupPolicy.*
    hide: true
  - where:
      variant: ^CreateViaIdentity$|^Patch$|^PatchViaIdentity$|^Backup$|^BackupViaIdentity$|^TriggerViaIdentity|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: New
      subject: BackupVault
      variant: Create
    hide: true
  - no-inline:
    - UserFacingError
    - InnerError
    - BackupInstance
    - RestoreTargetInfo
    - PolicyParameters
    - SystemData
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBaseBackupPolicy Property', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBaseBackupPolicy Property');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerContext Trigger', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ITriggerContext Trigger');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupParameters BackupParameter', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupParameters BackupParameter');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPoint Property', 'public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPoint Property');
```

## Alternate settings

This section is only activated if the `--make-it-rain` switch is added to the command line

``` yaml $(make-it-rain)
namespace: MyCompany.Special.Rest
```
