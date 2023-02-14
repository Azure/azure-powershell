### Example 1: Creates or updates a FHIR Service resource with the specified parameters.
```powershell
<<<<<<< HEAD
New-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Location eastus2 -Kind 'fhir-R4' -Authority "https://login.microsoftonline.com/{DirectoryID}" -Audience "https://azpshcws-{FhirServiceName}.fhir.azurehealthcareapis.com"
```

```output
=======
PS C:\> New-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Location eastus2 -Kind 'fhir-R4' -Authority "https://login.microsoftonline.com/{DirectoryID}" -Audience "https://azpshcws-{FhirServiceName}.fhir.azurehealthcareapis.com"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Creates or updates a FHIR Service resource with the specified parameters.