### Example 1: Patch FHIR Service details.
```powershell
<<<<<<< HEAD
Update-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}
```

```output
=======
PS C:\> Update-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Patch FHIR Service details.

### Example 2: Patch FHIR Service details.
```powershell
<<<<<<< HEAD
Get-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareFhirService -Tag @{"123"="abc"}
```

```output
=======
PS C:\>  Get-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareFhirService -Tag @{"123"="abc"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Patch FHIR Service details.