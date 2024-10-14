# Managed Identity Best Practices

## Overview
This document provides a cmdlet best practice for supporting Managed Identity in Azure PowerShell. 
- New cmdlets are required to follow the best practices. If any further discussion is needed, please contact [Azure PowerShell team](mailto: azdevxps@microsoft.com);
- For existing cmdlets, we are strongly recommended to keep aligned with the best practice. Please contact [Azure PowerShell team](mailto: azdevxps@microsoft.com) to make a proper migration plan. 

## Applicability
Resources supported Managed Identity in management plane with common type definition in [managedidentity.json](https://github.com/Azure/azure-rest-api-specs/blob/main/specification/common-types/resource-management/v5/managedidentity.json).

## Cmdlet Syntax

### New- Cmdlet Design Practices
Use `[EnableSystemAssignedIdentity <SwitchParameter>]` to enable system-assigned identity and `[UserAssignedIdentity <string[]>]` to add user-assigned identities.

```powershell
New-AzResource ... -EnableSystemAssignedIdentity -UserAssignedIdentity <id1>, <id2>
```

- If `EnableSystemAssignedIdentity` is present, IdentityType is set up as `SystemAssigned`, which enables system-assigned identity;
- If `UserAssignedIdentity` is provided, IdentityType is set up as `UserAssigned`, which adds user-assigned identities by provided value;
- If `EnableSystemAssignedIdentity` and `UserAssignedIdentity` both are not presented, IdentityType is set up as `None`;
- If `EnableSystemAssignedIdentity` is present and `UserAssignedIdentity` is provided, IdentityType is set up as `SystemAssigned,UserAssigned`, which enables system-assigned identity and adds user-assigned identities by provided value;

### Update- Cmdlet Design Practices
Use `[EnableSystemAssignedIdentity <bool>]` to enable or disable system-assigned identity and `[UserAssignedIdentity <string[]>]` to set user-assigned identities.
#### Update System-assigned Identity
```powershell
Update-AzResource ... -EnableSystemAssignedIdentity $false
```
If `EnableSystemAssignedIdentity` is provided, $false disables system-assigned identity and $true enables system-assigned identity. If `EnableSystemAssignedIdentity` is not provided, it means no change happens on system-assigned identity.

#### Update User-assigned Identity
```powershell
Update-AzResource ... -UserAssignedIdentity <id1>, <id2>
```
If `UserAssignedIdentity` is provided, user-assigned identities will be overridden as the value of `UserAssignedIdentity`; If `UserAssignedIdentity` is not provided, it means keep user-assigned identity as previous value. 

#### Remove User-assigned Identity
```powershell
Update-AzResource ... -UserAssignedIdentity @()
```
Especially, setting `UserAssignedIdentity` as empty collection removes all existing user-assigned identities.

### Set- Cmdlet Design Practices
The design practices of Set- Cmdlet depends on if cmdlet will set properties that are not provided as empty or default value,
- If yes, please follow [New- Cmdlet Design Practices](#New--Cmdlet-Design-Practices);
- Otherwise, please follow [Update- Cmdlet Design Practices](#Update--Cmdlet-Design-Practices). 

## Migration for Existing Cmdlets
Please contact [Azure PowerShell team](mailto: azdevxps@microsoft.com) to make a proper migration plan. 

## Frequently Asked Question
### Is it required to set the type of UserAssignedIdentity as string array if service only supports one user assigned identity?
We are recommended to use string array as the type of UserAssignedIdentity with following reasons:
- string array matches the swagger definition of `UserAssignedIdentity`;
- string array is inclusive of a single string;
- No syntax changes if service supports one more user assigned identity in future;
- Service will provide correct error response if customer reaches the count limitation of `UserAssignedIdentity` ideally, which means no harm.

### How to disable transforming IdentityType and UserAssignedIdentity to avoid breaking changes when migrate from autorest.powershell v3 to v4.
See details at [here](https://github.com/Azure/autorest.powershell/blob/main/docs/migration-from-v3-to-v4.md#how-to-mitigate-the-breaking-changes-of-managed-identity-best-practice-alignment).

### What should I do to mitigate one patch operation which is reported to parameter IdentityType can not be transformed as the best practice design?

autorest.powershell is unable to transform IdentityType as the best practice design for certain reasons. To mitigate this issue,
- Include a customization script to transform the parameter IdentityType to EnableSystemAssignedIdentity by `get` + `patch` update for this type of operation. The following are the detailed steps on how to accomplish this.
  - disable transformation for the operation which reported error in README.md by
  ```
  disable-transform-identity-type-for-operation:
    - Operation_id
  ```
  - hide the corresponding Update cmdlet in directive by
  ```
   -  where:
        verb: Update
        subject: {Subject-Name}
      hide: true
  ```
  - run `autorest` and `./build-module.ps1`
  - manually change IdentityType to EnableSystemAssignedIdentity<bool> in `Update-Az{ModuleName}{Subject-Name}` like
  ```
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.{ModuleName}.Category('Body')]
      [System.Nullable[System.Boolean]]
      # Decides if enable a system assigned identity for the resource.
      ${EnableSystemAssignedIdentity},
  ```
  - calculate the value of IdentityType as swagger defined in process block, see [instance](https://github.com/Azure/azure-powershell/blob/827001c79c4416e0b74f5857c2ad72b7932b1f9a/src/Astro/Astro.Autorest/custom/Update-AzAstroOrganization.ps1#L269) for Update-Az{ModuleName}{Subject-Name}.
