# AutoRest Configuration for Compute

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/compute/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/compute/resource-manager/readme.md

subject-prefix: ''
module-version: 0.0.1
skip-model-cmdlets: true
profile: 
  - hybrid-2019
  - latest-2019-04-01
directive: 
  - where: 
      verb: Get
      subject: .*All
    set: 
      hide: true
  - where:
      subject: VirtualMachineScaleSet(.*)
    set:
      subject: Vmss$1
  - where:
      subject: VirtualMachine(.*)
    set:
      subject: VM$1
  - where:
      subject: VM
      parameter-name: VmName
    set:
      parameter-name: Name
```