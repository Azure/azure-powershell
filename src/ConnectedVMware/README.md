<!-- region Generated -->
# Az.ConnectedVMware
This directory contains the PowerShell module for the ConnectedVMware service.

---
## Status
[![Az.ConnectedVMware](https://img.shields.io/powershellgallery/v/Az.ConnectedVMware.svg?style=flat-square&label=Az.ConnectedVMware "Az.ConnectedVMware")](https://www.powershellgallery.com/packages/Az.ConnectedVMware/)

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
For information on how to develop for `Az.ConnectedVMware`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: bab2f4389eb5ca73cdf366ec0a4af3f3eb6e1f6d
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/preview/2022-01-10-preview/connectedvmware.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: ConnectedVMware
subject-prefix: $(service-name)
identity-correction-for-post: true
nested-object-to-string: true
resourcegroup-append: true

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correctiEXon-for-post: true

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
  # Rename Invoke-AzConnectedVMwareAssessVirtualMachinePatch to Invoke-AzConnectedVMwareVirtualMachineAssessPatch
  - where:
      verb: Invoke
      subject: AssessVirtualMachinePatch
    set:
      subject: VirtualMachineAssessPatch
  # Set the format of password in GuestCredential as password
  - from: swagger-document 
    where: $.definitions.GuestCredential.properties.password
    transform: $.format = "password"
  # Set the format of password in VICredential as password
  - from: swagger-document 
    where: $.definitions.VICredential.properties.password
    transform: $.format = "password"
  # Rename MetadataName in *-Az*HybridIdentityMetadata as Name
  # Set MetadataName as the alias of Name in *-Az*HybridIdentityMetadata
  - where:
      subject: HybridIdentityMetadata
      parameter-name: MetadataName
    set:
      parameter-name: Name
      alias: MetadataName
  # Rename Name in *-Az*MachineExtension as VirtualMachineName
  - where:
      subject: MachineExtension
      parameter-name: Name
    set:
      parameter-name: VirtualMachineName
  # Rename ExtensionName in *-Az*MachineExtension as Name
  # Set ExtensionName as the alias of Name in *-Az*MachineExtension
  - where:
      subject: MachineExtension
      parameter-name: ExtensionName
    set:
      parameter-name: Name
      alias: ExtensionName
  # Rename Force in delete operation to ForceDelete
  - where:
      verb: Remove
      parameter-name: Force
    set:
      parameter-name: ForceDeletion
  # Shorten cmdlet name
  - where:
      subject: VirtualMachine(.*)
    set:
      subject: VM$1
  - where:
      subject: VirtualNetwork(.*)
    set:
      subject: VNet$1
```
