### Example 1: List the properties of the specified FHIR Service.
```powershell
<<<<<<< HEAD
Get-AzHealthcareFhirService -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
=======
PS C:\> Get-AzHealthcareFhirService -ResourceGroupName azps_test_group -WorkspaceName azpshcws

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

List the properties of the specified FHIR Service.

### Example 2: Gets the properties of the specified FHIR Service.
```powershell
<<<<<<< HEAD
Get-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
=======
PS C:\> Get-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Gets the properties of the specified FHIR Service.