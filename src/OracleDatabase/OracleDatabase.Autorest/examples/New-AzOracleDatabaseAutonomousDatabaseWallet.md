### Example 1: Generate wallet on an Autonomous Database resource
```powershell
[SecureString]$password = ConvertTo-SecureString -String "PowerShellTestPass123" -AsPlainText -Force

New-AzOracleDatabaseAutonomousDatabaseWallet -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -Password $password -GenerateType "walletType" -IsRegional $true
```

Generate wallet on an Autonomous Database resource.
For more information, execute `Get-Help New-AzOracleDatabaseAutonomousDatabaseWallet`.