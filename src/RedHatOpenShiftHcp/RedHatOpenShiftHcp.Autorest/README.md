<!-- region Generated -->
# Az.RedHatOpenShiftHcp
This directory contains the PowerShell module for the RedHatOpenShiftHcp service.

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
For information on how to develop for `Az.RedHatOpenShiftHcp`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
commit: dfe87dc096ec04b9b521a8de69feb197608d55ea
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/redhatopenshift/resource-manager/Microsoft.RedHatOpenShift/hcpopenshiftclusters/stable/2026-10-01/openapi.json
# For a new RP, the version is 0.1.0
module-version: 0.1.0
title: RedHatOpenShiftHcp
service-name: RedHatOpenShiftHcp
# subject-prefix: '' is INTENTIONAL (kindly do not change to $(service-name)).
#
# A cmdlet name is composed as:   Verb - prefix + subject-prefix + subject
# The shared readme.azure.noprofile.md sets prefix: Az and defaults subject-prefix to
# $(service-name). This RP's subjects already contain "Hcp"/"OpenShift" (operation group
# HcpOpenShiftClusters -> subject HcpOpenShiftCluster), so the default prefix doubles tokens:
#
#   Get-Az + RedHatOpenShiftHcp + HcpOpenShiftCluster
#         = Get-AzRedHatOpenShiftHcpHcpOpenShiftCluster      # "Hcp"/"OpenShift" x2 (not good)
#
# Fix: subject-prefix: '' AND brand each noun explicitly via the `subject` renames
# in the directive block below.
#
#   HcpOpenShiftCluster -> RedHatOpenShiftHcpCluster  =>  Get-AzRedHatOpenShiftHcpCluster
subject-prefix: ''

directive:
  # --- Common clean-up directives (required for most RPs) ---
  # 1. (DISABLED on purpose) We KEEP the non-expanded Create/Update parameter sets —
  #    the variant that accepts the whole request body as a single object parameter
  #    (-Parameter/-Body), alongside the -Expanded (flattened) and -Json* variants.
  #    Re-enable the directive below to prune the whole-object sets.
  # - where:
  #     variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
  #   remove: true
  # 2. For New-* cmdlets, ViaIdentity is not required.
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  # 3. Remove the Set-* cmdlets (autogen convention: Set-* -> New-*/Update-*).
  - where:
      verb: Set
    remove: true
  # 4. Product decision: do NOT ship the OperatorIdentityRoleSet cmdlet. Remove the whole
  #    subject (all variants: Get/List/GetViaIdentity*). Matched on the ORIGINAL pre-rename
  #    subject and placed before the brand renames, so there is nothing left for a rename
  #    to match (its rename directive is removed accordingly).
  - where:
      subject: HcpOperatorIdentityRoleSet
    remove: true

  # --- Brand the nouns via subject renames (NOT via subject-prefix) ---
  # kindly refer to "empty subject-prefix" comment above
  # ORDER MATTERS: the two credential subjects start with "HcpOpenShiftCluster",
  # so rename them BEFORE the bare HcpOpenShiftCluster rename (where: subject is an
  # unanchored regex and would otherwise match them). See pitfalls below.
  - where:
      subject: HcpOpenShiftClusterAdminCredential      # verb Request -> Request-Az...
    set:
      subject: RedHatOpenShiftHcpClusterAdminCredential
  - where:
      subject: HcpOpenShiftClusterCredentials          # verb Revoke  -> Revoke-Az... (plural!)
    set:
      subject: RedHatOpenShiftHcpClusterCredentials
  - where:
      subject: HcpOpenShiftCluster
    set:
      subject: RedHatOpenShiftHcpCluster
  - where:
      subject: HcpOpenShiftVersion
    set:
      subject: RedHatOpenShiftHcpVersion
  # (OperatorIdentityRoleSet rename removed — the subject is deleted by directive #4 above.)
  - where:
      subject: NodePool
    set:
      subject: RedHatOpenShiftHcpNodePool
  - where:
      subject: ExternalAuth
    set:
      subject: RedHatOpenShiftHcpExternalAuth

  # --- Fix the CS0102 -Client parameter collision on the ExternalAuth cmdlets ---
  - where:
      subject: RedHatOpenShiftHcpExternalAuth
      parameter-name: Client
    set:
      parameter-name: ClientProfile
```
