<!-- region Generated -->
# Az.Peering
This directory contains the PowerShell module for the Peering service.

---
## Status
[![Az.Peering](https://img.shields.io/powershellgallery/v/Az.Peering.svg?style=flat-square&label=Az.Peering "Az.Peering")](https://www.powershellgallery.com/packages/Az.Peering/)

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
For information on how to develop for `Az.Peering`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
branch: 5fc05d0f0b15cbf16de942cadce464b495c66a58
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/peering/resource-manager/Microsoft.Peering/stable/2022-10-01/peering.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Peering
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Change cmdlet verb: Invoke-AzPeeringInvokeLookingGlass -> Start-AzPeeringInvokeLookingGlass
  - where:
      verb: Invoke
      subject: ^InvokeLookingGlass$
    set:
      verb: Start
  # Change cmdlet subject: Get/New/Remove-AzPeeringPeerAsn -> Get/New/Remove-AzPeeringAsn
  - where:
      subject-prefix: Peering
      subject: PeerAsn
    set:
      subject: Asn
      subject-prefix: Peer
  # Some parameter is Array, so we need to change it and custom it
  - model-cmdlet:
      - ExchangeConnection
      - DirectConnection
      - ContactDetail
      - CheckServiceProviderAvailabilityInput
  # Change all parameters named SkuName(SkuName -> Sku) and add the alias SkuName to Sku
  - where:
      parameter-name: SkuName
    set:
      parameter-name: Sku
      alias: SkuName
  # Parameter information to be displayed after the command is returned
  # module-name source: .\azure-powershell\src\Peering\exports\Get-AzPeerAsn.ps1 Line 51 [IPeerAsn]
  - where:
      model-name: PeerAsn
    set:
      format-table:
        properties:
          - Name
          - PeerName
          - PropertiesPeerAsn
          - ResourceGroupName
          - ValidationState
```
