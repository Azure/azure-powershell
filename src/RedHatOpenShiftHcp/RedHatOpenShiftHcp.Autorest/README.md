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
# Track the PREVIEW API (merged + deployed to dev) so cmdlets send api-version=2026-09-01-preview.
commit: d218330c5a3b727df9504ba852e97259479e8fef
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/redhatopenshift/resource-manager/Microsoft.RedHatOpenShift/hcpopenshiftclusters/preview/2026-09-01-preview/openapi.json
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
  # --- C1 customization: hide the generated admin-credential cmdlet so a hand-written
  #     custom/Request-AzRedHatOpenShiftHcpClusterAdminCredential.ps1 replaces it.
  #     The custom cmdlet generates the keypair+CSR locally, calls this hidden cmdlet via
  #     Az.RedHatOpenShiftHcp.internal\Request-..., then splices the private key into the
  #     returned kubeconfig and merges it into the user's kubeconfig (AKS-style).
  #     Placed BEFORE the brand renames (like directive #4), so it MUST match the ORIGINAL
  #     pre-rename subject (HcpOpenShiftClusterAdminCredential), not the branded name.
  - where:
      verb: Request
      subject: HcpOpenShiftClusterAdminCredential
    hide: true

  # --- C4 customization: hide the generated version-list cmdlet so a custom
  #     custom/Get-AzRedHatOpenShiftHcpVersion.ps1 wrapper replaces it, adding
  #     -ControlPlane (distinct MAJOR.MINOR) and -NodePool (full X.Y.Z) views.
  #     Pre-rename subject (before the brand renames), like the C1 hide above.
  - where:
      verb: Get
      subject: HcpOpenShiftVersion
    hide: true

  # --- C2 customization: hide the generated cluster-create cmdlet so a custom
  #     custom/New-AzRedHatOpenShiftHcpCluster.ps1 wrapper replaces it (auto-derives the
  #     flat identity list from the operator maps + hardcodes the etcd KMS encryption type).
  #     Pre-rename subject, anchored + verb New so it matches ONLY the cluster create.
  - where:
      verb: New
      subject: ^HcpOpenShiftCluster$
    hide: true

  # --- C3 customization: hide the generated cluster-update cmdlet so a custom
  #     custom/Update-AzRedHatOpenShiftHcpCluster.ps1 wrapper replaces it (GET-merge the operator
  #     identity maps, resolve bare names, recompute the flat identity list = control-plane + service).
  - where:
      verb: Update
      subject: ^HcpOpenShiftCluster$
    hide: true

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

  # --- C5 customization: default table views. The generated default shows the (empty)
  #     SystemData* columns; these surface the useful flattened properties instead.
  #     Keyed on model-name (unaffected by the subject renames above).
  - where:
      model-name: HcpOpenShiftCluster
    set:
      format-table:
        properties:
          - Name
          - Location
          - ResourceGroupName
          - VersionId
          - ProvisioningState
          - ApiUrl
        labels:
          ResourceGroupName: Resource Group
          VersionId: Version
          ApiUrl: API Server
  - where:
      model-name: NodePool
    set:
      format-table:
        properties:
          - Name
          - VersionId
          - PlatformVMSize
          - Replica
          - ProvisioningState
        labels:
          VersionId: Version
          PlatformVMSize: VM Size
  - where:
      model-name: HcpOpenShiftVersion
    set:
      format-table:
        properties:
          - Name
          - ChannelGroup
          - Enabled
          - EndOfLifeTimestamp
        labels:
          ChannelGroup: Channel
          EndOfLifeTimestamp: End Of Life
  - where:
      model-name: ExternalAuth
    set:
      format-table:
        properties:
          - Name
          - IssuerUrl
          - ProvisioningState
        labels:
          IssuerUrl: Issuer
```
