<!-- region Generated -->
# Az.RedHatOpenShiftHcp
This directory contains the PowerShell module for the RedHatOpenShiftHcp service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes
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
```