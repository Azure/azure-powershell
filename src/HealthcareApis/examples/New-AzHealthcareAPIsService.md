### Example 1: Create or update the metadata of a service instance.
```powershell
PS C:\> New-AzHealthcareAPIsService -ResourceGroupName azps_test_group -Name azpsapiservice -Kind 'fhir' -Location eastus2 -CosmoDbConfigurationOfferThroughput 400

Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Create or update the metadata of a service instance.