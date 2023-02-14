### Example 1: Create or update the metadata of a service instance.
```powershell
<<<<<<< HEAD
New-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice -Kind 'fhir' -Location eastus2 -CosmosOfferThroughput 400
```

```output
=======
PS C:\> New-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice -Kind 'fhir' -Location eastus2 -CosmosOfferThroughput 400

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Create or update the metadata of a service instance.