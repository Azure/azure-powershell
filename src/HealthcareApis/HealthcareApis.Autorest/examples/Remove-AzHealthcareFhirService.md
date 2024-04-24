### Example 1: Deletes a FHIR Service.
```powershell
Remove-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

Deletes a FHIR Service.

### Example 2: Deletes a FHIR Service.
```powershell
Get-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Remove-AzHealthcareFhirService
```

Deletes a FHIR Service.