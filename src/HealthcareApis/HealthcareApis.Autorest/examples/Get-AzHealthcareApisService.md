### Example 1: List the metadata of service instance.
```powershell
Get-AzHealthcareApisService
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

List the metadata of service instance.

### Example 2: List the metadata of service instance by resource group.
```powershell
Get-AzHealthcareApisService -ResourceGroupName azps_test_group
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

List the metadata of service instance by resource group.

### Example 3: Get the metadata of a service instance.
```powershell
Get-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Get the metadata of a service instance.