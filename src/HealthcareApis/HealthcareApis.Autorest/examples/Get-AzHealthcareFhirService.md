### Example 1: List the properties of the specified FHIR Service.
```powershell
Get-AzHealthcareFhirService -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

List the properties of the specified FHIR Service.

### Example 2: Gets the properties of the specified FHIR Service.
```powershell
Get-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Gets the properties of the specified FHIR Service.