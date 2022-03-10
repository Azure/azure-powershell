### Example 1: Patch FHIR Service details.
```powershell
PS C:\> Update-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}

Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Patch FHIR Service details.

### Example 2: Patch FHIR Service details.
```powershell
PS C:\>  Get-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareFhirService -Tag @{"123"="abc"}

Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Patch FHIR Service details.