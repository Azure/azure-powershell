### Example 1: Update the metadata of a service instance.
```powershell
Update-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice -Tag @{"abc"="123"}
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Update the metadata of a service instance.

### Example 2: Update the metadata of a service instance.
```powershell
Get-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice | Update-AzHealthcareApisService -Tag @{"abc"="123"}
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Update the metadata of a service instance.