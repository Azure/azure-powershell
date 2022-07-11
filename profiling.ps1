$ErrorActionPreference = 'SilentlyContinue'
$WarningPreference = 'SilentlyContinue'

function Get-RandomString {
    $l = 3..12 | Get-Random
    return -join (97..122 | Get-Random -Count $l | ForEach-Object {[char]$_})
}

function Get-RandomCommand {
    $i = 0..3 | Get-Random
    $verb = @('Get', 'Set', 'New', 'Remove')[$i]
    return "$verb-Az$(Get-RandomString)"
}

# test 1: how long to run
$commands = 1..200 | ForEach-Object { Get-RandomCommand }

$commands | ForEach-Object { Invoke-Expression $_ }

import-module ./artifacts/Debug/Az.Accounts/Az.Accounts.psd1

$commands | ForEach-Object { Invoke-Expression $_ }

[Microsoft.Azure.Commands.Profile.Utilities.CommandNotFoundHelper]::EnableFuzzyString = $false

$commands | ForEach-Object { Invoke-Expression $_ }


# # Test 2: how long initialization takes
# New-AzKeyVaultStorageAccount
# New-AzKeyVaultKey
# Import-Module ./artifacts/Debug/Az.Accounts/Az.Accounts.psd1
# New-AzKeyVaultStorageAccount
# New-AzKeyVaultKey
# [Microsoft.Azure.Commands.Profile.Utilities.CommandNotFoundHelper]::EnableFuzzyString = $false
# New-AzKeyVaultStorageAccount
# New-AzKeyVaultKey
