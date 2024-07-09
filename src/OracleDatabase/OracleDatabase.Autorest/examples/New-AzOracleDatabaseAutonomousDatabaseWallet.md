### Example 1: Generates wallet on an Autonomous Database resource
```powershell
[SecureString]$password = ConvertTo-SecureString -String "PowerShellTestPass123" -AsPlainText -Force

New-AzOracleDatabaseAutonomousDatabaseWallet -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -Password $password -GenerateType "walletType" -IsRegional $true
```

Generates wallet on an Autonomous Database resource.
For more information, execute `Get-Help New-AzOracleDatabaseAutonomousDatabaseWallet`