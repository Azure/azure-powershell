### Example 1: Get a list of the Virtual Instance(s) for SAP solutions (VIS)

```powershell
Get-AzWorkloadsSapVirtualInstance
```

```output
Name ResourceGroupName Health  Environment ProvisioningState SapProduct State                Status  Location
---- ----------------- ------  ----------- ----------------- ---------- -----                ------  --------
DRT  DemoRGVIS         Healthy NonProd     Succeeded         S4HANA     RegistrationComplete Running eastus2euap
DRT  DemoRGVIS01       Healthy NonProd     Succeeded         S4HANA     RegistrationComplete Running eastus2euap
DRT  DemoRGVIS02       Healthy NonProd     Succeeded         S4HANA     RegistrationComplete Running eastus2euap
```

This command will list all the Virtual instances for SAP solutions from your subscriptions along with their health, status, state and other parameters of the VIS

### Example 2: Get an overview of any one Virtual Instance(s) for SAP solutions (VIS)

```powershell
Get-AzWorkloadsSapVirtualInstance -ResourceGroupName DemoRGVIS -Name DRT
```

```output
Name ResourceGroupName Health  Environment ProvisioningState SapProduct State                Status  Location
---- ----------------- ------  ----------- ----------------- ---------- -----                ------  --------
DRT  DemoRGVIS         Healthy NonProd     Succeeded         S4HANA     RegistrationComplete Running eastus2euap
```

This command will list a specific Virtual instance for SAP solutions resource along with it's health, status, state and other parameters of the VIS

### Example 3: Get an overview of the Virtual Instance(s) for SAP solutions (VIS) with resource ID
```powershell
Get-AzWorkloadsSapVirtualInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/DemoRGVIS/providers/Microsoft.Workloads/sapVirtualInstances/DRT
```

```output
Name ResourceGroupName Health  Environment ProvisioningState SapProduct State                Status  Location
---- ----------------- ------  ----------- ----------------- ---------- -----                ------  --------
DRT  DemoRGVIS         Healthy NonProd     Succeeded         S4HANA     RegistrationComplete Running eastus2euap
```

This command will list a specific Virtual instance for SAP solutions resource along with it's health, status, state and other parameters of the VIS by using the Azure resource ID of the VIS