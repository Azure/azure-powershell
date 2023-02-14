### Example 1: Update the metadata of a service instance.
```powershell
<<<<<<< HEAD
Update-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice -Tag @{"abc"="123"}
```

```output
=======
PS C:\> Update-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice -Tag @{"abc"="123"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Update the metadata of a service instance.

### Example 2: Update the metadata of a service instance.
```powershell
<<<<<<< HEAD
Get-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice | Update-AzHealthcareApisService -Tag @{"abc"="123"}
```

```output
=======
PS C:\> Get-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice | Update-AzHealthcareApisService -Tag @{"abc"="123"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Update the metadata of a service instance.