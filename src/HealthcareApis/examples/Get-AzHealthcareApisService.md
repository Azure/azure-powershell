### Example 1: List the metadata of service instance.
```powershell
<<<<<<< HEAD
Get-AzHealthcareApisService
```

```output
=======
PS C:\>  Get-AzHealthcareApisService

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

List the metadata of service instance.

### Example 2: List the metadata of service instance by resource group.
```powershell
<<<<<<< HEAD
Get-AzHealthcareApisService -ResourceGroupName azps_test_group
```

```output
=======
PS C:\> Get-AzHealthcareApisService -ResourceGroupName azps_test_group

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

List the metadata of service instance by resource group.

### Example 3: Get the metadata of a service instance.
```powershell
<<<<<<< HEAD
Get-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice
```

```output
=======
PS C:\> Get-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Get the metadata of a service instance.