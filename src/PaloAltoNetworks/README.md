<!-- region Generated -->
# Az.PaloAltoNetworks
This directory contains the PowerShell module for the PaloAltoNetworks service.

---
## Status
[![Az.PaloAltoNetworks](https://img.shields.io/powershellgallery/v/Az.PaloAltoNetworks.svg?style=flat-square&label=Az.PaloAltoNetworks "Az.PaloAltoNetworks")](https://www.powershellgallery.com/packages/Az.PaloAltoNetworks/)

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
For information on how to develop for `Az.PaloAltoNetworks`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 53f6cced1504a476ba001c9d7250ab195e9c299b
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/paloaltonetworks/resource-manager/PaloAltoNetworks.Cloudngfw/stable/2022-08-29/PaloAltoNetworks.Cloudngfw.json

title: PaloAltoNetworks
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true

# # Some of the parameters are of type Object and need to be expanded into a command for the convenience of the user
# # The following are commented out and their generated cmdlets may be renamed and custom logic
# # Do not delete this code
#   - model-cmdlet:
#       - IPAddress
#       - FrontendSetting
#       - NetworkProfile
#       - LogSettings

# We can exclude GlobalRulestack. All GlobalRulestack APIs are not in use.
  - where:
      subject: CertificateObjectGlobalRulestack
    remove: true
  - where:
      subject: CertificateObjectLocalRulestack
    remove: true
  - where:
      subject: FirewallGlobalRulestack
    remove: true
  - where:
      subject: FqdnListGlobalRulestack
    remove: true
  - where:
      subject: GlobalRulestack
    remove: true
  - where:
      subject: GlobalRulestackAdvancedSecurityObject
    remove: true
  - where:
      subject: GlobalRulestackAppId
    remove: true
  - where:
      subject: GlobalRulestackChangeLog
    remove: true
  - where:
      subject: GlobalRulestackCountry
    remove: true
  - where:
      subject: GlobalRulestackFirewall
    remove: true
  - where:
      subject: GlobalRulestackPredefinedUrlCategory
    remove: true
  - where:
      subject: GlobalRulestackSecurityService
    remove: true
  - where:
      subject: PrefixListGlobalRulestack
    remove: true
  - where:
      subject: CommitGlobalRulestack
    remove: true
  - where:
      subject: RevertGlobalRulestack
    remove: true
```
