### Example 1: Deletes a FHIR Service.
```powershell
PS C:\> Remove-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws

```

Deletes a FHIR Service.

### Example 2: Deletes a FHIR Service.
```powershell
PS C:\> Get-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Remove-AzHealthcareFhirService

```

Deletes a FHIR Service.