$ErrorActionPreference = 'SilentlyContinue'
$WarningPreference = 'SilentlyContinue'

# test 1: how long to run
for ($i = 0; $i -ne 2000; $i++) {
    Get-AzKeyVaultCat
}

ipmo ./artifacts/Debug/Az.Accounts/Az.Accounts.psd1

for ($i = 0; $i -ne 2000; $i++) {
    Get-AzKeyVaultCat
}


# Test 2: how long initialization takes
# Get-AzKeyVault
# Get-AzKeyVault
# Get-AzKeyVault
# Get-AzKeyVault
# Get-AzKeyVault
# ipmo ./artifacts/Debug/Az.Accounts/Az.Accounts.psd1
# Get-AzKeyVault
# Get-AzKeyVault
# Get-AzKeyVault
# Get-AzKeyVault
# Get-AzKeyVault
