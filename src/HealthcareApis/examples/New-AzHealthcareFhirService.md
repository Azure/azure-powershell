### Example 1: Creates or updates a FHIR Service resource with the specified parameters.
```powershell
PS C:\> New-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Location eastus2 -Kind 'fhir-R4' -AuthenticationConfigurationAuthority "https://login.microsoftonline.com/{DirectoryID}" -AuthenticationConfigurationAudience "https://azpshcws-{FhirServiceName}.fhir.azurehealthcareapis.com"

Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Creates or updates a FHIR Service resource with the specified parameters.