### Example 1: Get the list of reserved resource type skus with location
```powershell
Get-AzReservationCatalog -SubscriptionId "10000000-aaaa-bbbb-cccc-100000000001" -Location "westus" -ReservedResourceType "VirtualMachine"
```

```output
ResourceType    Terms           Name                   Locations
------------    -----           ----                   ---------
virtualMachines {P1Y, P3Y, P5Y} Standard_B12ms         {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B16ms         {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B1ls          {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B1ms          {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B1s           {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B20ms         {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B2ms          {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B2s           {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B4ms          {westus}
```

This command gets a catlog of reserved resource type skus with location

### Example 2: Get the list of reserved resource type skus without location
```powershell
Get-AzReservationCatalog -SubscriptionId "10000000-aaaa-bbbb-cccc-100000000001" -ReservedResourceType "SuseLinux"
```

```output
ResourceType Terms           Name                            Locations
------------ -----           ----                            ---------
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_standard_3-4_vcpu_vm   
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_standard_1-2_vcpu_vm   
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_standard_5plus_vcpu_vm 
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_priority_1-2_vcpu_vm   
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_priority_5plus_vcpu_vm 
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_priority_3-4_vcpu_vm   
SuseLinux    {P1Y, P3Y, P5Y} sles_standard_5plus_vcpu_vm     
SuseLinux    {P1Y, P3Y, P5Y} sles_standard_3-4_vcpu_vm       
SuseLinux    {P1Y, P3Y, P5Y} sles_standard_1-2_vcpu_vm       
SuseLinux    {P1Y, P3Y, P5Y} sles_priority_6_vcpu_vm
SuseLinux    {P1Y, P3Y, P5Y} sles_priority_2-4_vcpu_vm       
SuseLinux    {P1Y, P3Y, P5Y} sles_priority_1_vcpu_vm
SuseLinux    {P1Y, P3Y, P5Y} sles_priority_8plus_vcpu_vm     
SuseLinux    {P1Y, P3Y, P5Y} sles_sap_priority_5plus_vcpu_vm 
SuseLinux    {P1Y, P3Y, P5Y} sles_sap_priority_1-2_vcpu_vm   
SuseLinux    {P1Y, P3Y, P5Y} sles_sap_priority_3-4_vcpu_vm 
```

This command gets a catlog of reserved resource type skus without location

### Example 3: Get the list of eligible 3pp reserved resource type skus with publisher id, offer id, plan id
```powershell
Get-AzReservationCatalog -SubscriptionId "10000000-aaaa-bbbb-cccc-100000000001" -ReservedResourceType "VirtualMachineSoftware" -PublisherId canonical -OfferId 0001-com-ubuntu-pro-xenial -PlanId pro-16_04-lts
```

```output
ResourceType           Terms           Name                                                          Locations
------------           -----           ----                                                          ---------
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.10core     
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.416core    
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.2core      
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.36core     
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.80core
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.72core
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.sharedcore
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.20core
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.40core
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.48core
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.4core
```

This command gets a catlog of eligible 3pp reserved resource type skus with publisher id, offer id, plan id
