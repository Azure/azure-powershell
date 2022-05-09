### Example 1: Update the metadata of a service instance.
```powershell
PS C:\> Update-AzHealthcareAPIsService -ResourceGroupName azps_test_group -Name azpsapiservice -Tag @{"abc"="123"}

Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Update the metadata of a service instance.

### Example 2: Update the metadata of a service instance.
```powershell
PS C:\> Get-AzHealthcareAPIsService -ResourceGroupName azps_test_group -Name azpsapiservice | Update-AzHealthcareAPIsService -Tag @{"abc"="123"}

Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Update the metadata of a service instance.