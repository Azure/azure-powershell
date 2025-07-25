<!-- region Generated -->
# Az.Attestation
This directory contains the PowerShell module for the Attestation service.

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
For information on how to develop for `Az.Attestation`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 49761e90136044aa164e59d3dc8da0a66644f239
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/attestation/resource-manager/Microsoft.Attestation/stable/2020-10-01/attestation.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Attestation
subject-prefix: $(service-name)
identity-correction-for-post: true
nested-object-to-string: true
resourcegroup-append: true

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correctiEXon-for-post: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Install$|^InstallViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Remove the *-*PrivateEndpointConnection cmdlet
  - where:
      subject: PrivateEndpointConnection
    remove: true
  # Rename *-AttestationProviderDefault -> *-AttestationDefaultProvider
  - where:
      subject: AttestationProviderDefault
    set:
      subject: AttestationDefaultProvider
  # Rename ProviderName in *-AttestationProvider as Name and keep it as alias
  - where:
      subject: AttestationProvider
      parameter-name: ProviderName
    set:
      parameter-name: Name
      alias: ProviderName
  # Hide New-AzAttestationProvider to customize PolicySigningCertificateKey as PolicySigningCertificateKeyPath
  - where:
      subject: AttestationProvider
      verb: New
    hide: true
  
```
