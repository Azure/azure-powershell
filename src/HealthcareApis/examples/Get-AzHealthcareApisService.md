### Example 1: List the metadata of service instance.
```powershell
PS C:\>  Get-AzHealthcareApisService

Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

List the metadata of service instance.

### Example 2: List the metadata of service instance by resource group.
```powershell
PS C:\> Get-AzHealthcareApisService -ResourceGroupName azps_test_group

Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

List the metadata of service instance by resource group.

### Example 3: Get the metadata of a service instance.
```powershell
PS C:\> Get-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice

Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Get the metadata of a service instance.