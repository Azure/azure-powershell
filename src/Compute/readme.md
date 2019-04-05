# AutoRest Configuration for Compute

> see https://aka.ms/autorest

``` yaml
require: 
  - $(this-folder)/../readme.azure.md
  - https://raw.githubusercontent.com/NelsonDaniel/azure-rest-api-specs/multiapi/specification/compute/resource-manager/readme.enable-multi-api.md
  - https://raw.githubusercontent.com/NelsonDaniel/azure-rest-api-specs/multiapi/specification/compute/resource-manager/readme.md

service-name: Compute
subject-prefix: ''
module-version: 0.0.1
skip-model-cmdlets: true
profile: 
  - 2019-03-01-hybrid
  - 2019-04-01-profile
directive: 
  - where:
      noun: VirtualMachineScaleSet(.*)
    set:
      noun: Vmss$1
  - where:
      noun: VirtualMachine(.*)
    set:
      noun: VM$1
  - where:
      noun: VM
      parameter-name: VmName
    set:
      parameter-name: Name