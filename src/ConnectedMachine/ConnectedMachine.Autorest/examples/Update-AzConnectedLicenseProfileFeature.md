### Example 1: Update an object to pass into license profile
```powershell
$productfeature = Update-AzConnectedLicenseProfileFeature -Name "Hotpatch" -SubscriptionStatus "Enable"
$productfeature | Should -Not -BeNullOrEmpty
```

Update an object to pass into license profile

