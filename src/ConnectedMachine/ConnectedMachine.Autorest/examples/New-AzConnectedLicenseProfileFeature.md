### Example 1: Create an object to pass into license profile
```powershell
$productfeature = New-AzConnectedLicenseProfileFeature -Name "Hotpatch" -SubscriptionStatus "Enable"
$productfeature | Should -Not -BeNullOrEmpty
```

Create an object to pass into license profile
