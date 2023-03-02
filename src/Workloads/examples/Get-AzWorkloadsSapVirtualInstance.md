### Example 1: {{ Add title here }}
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

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzWorkloadsSapVirtualInstance -ResourceGroupName DemoRGVIS -Name DRT
```

```output
Name ResourceGroupName Health  Environment ProvisioningState SapProduct State                Status  Location
---- ----------------- ------  ----------- ----------------- ---------- -----                ------  --------
DRT  DemoRGVIS         Healthy NonProd     Succeeded         S4HANA     RegistrationComplete Running eastus2euap
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
Get-AzWorkloadsSapVirtualInstance -ResourceGroupName DemoRGVIS -Name DRT
```

```output
Name ResourceGroupName Health  Environment ProvisioningState SapProduct State                Status  Location
---- ----------------- ------  ----------- ----------------- ---------- -----                ------  --------
DRT  DemoRGVIS         Healthy NonProd     Succeeded         S4HANA     RegistrationComplete Running eastus2euap
```

{{ Add description here }}