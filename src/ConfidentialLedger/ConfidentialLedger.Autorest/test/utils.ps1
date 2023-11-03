function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.Location = 'southcentralus'

    $env.Add('AadPrincipalRole', 'Administrator')
    $env.Add('AadPrincipalId', '34621747-6fc8-4771-a2eb-72f31c461f2e')
    $env.Add('AadPrincipalTenantId', 'bce123b9-2b7b-4975-8360-5ca0b9b1cd08')

    $env.Add('CertPrincipalRole', 'Reader')
    $env.Add('CertPrincipalCert', '-----BEGIN CERTIFICATE-----MIIBsjCCATigAwIBAgIUZWIbyG79TniQLd2UxJuU74tqrKcwCgYIKoZIzj0EAwMwEDEOMAwGA1UEAwwFdXNlcjAwHhcNMjEwMzE2MTgwNjExWhcNMjIwMzE2MTgwNjExWjAQMQ4wDAYDVQQDDAV1c2VyMDB2MBAGByqGSM49AgEGBSuBBAAiA2IABBiWSo/j8EFit7aUMm5lF+lUmCu+IgfnpFD+7QMgLKtxRJ3aGSqgS/GpqcYVGddnODtSarNE/HyGKUFUolLPQ5ybHcouUk0kyfA7XMeSoUA4lBz63Wha8wmXo+NdBRo39qNTMFEwHQYDVR0OBBYEFPtuhrwgGjDFHeUUT4nGsXaZn69KMB8GA1UdIwQYMBaAFPtuhrwgGjDFHeUUT4nGsXaZn69KMA8GA1UdEwEB/wQFMAMBAf8wCgYIKoZIzj0EAwMDaAAwZQIxAOnozm2CyqRwSSQLls5r+mUHRGRyXHXwYtM4Dcst/VEZdmS9fqvHRCHbjUlO/+HNfgIwMWZ4FmsjD3wnPxONOm9YdVn/PRD7SsPRPbOjwBiE4EBGaHDsLjYAGDSGi7NJnSkA-----END CERTIFICATE-----')

    $env.Add('LedgerType', 'Public')
    $env.Add('Tag0', 'additional properties 0')
    $env.Add('Tag1', 'additional property 1')
    $env.Add('Tag2', 'additional property 2')

    # Ledger names.
    # More than one is required as setupEnv runs once before all tests, so some tests need to
    # create their own ledger to avoid conflicts.
    $ledgerName = 'pwsh-' + (RandomString -allChars $false -len 13)
    $newLedgerName = 'pwsh-new-' + (RandomString -allChars $false -len 9)
    $removeLedgerName = 'pwsh-remove-' + (RandomString -allChars $false -len 6)
    $availableName = 'pwsh-avail-' + (RandomString -allChars $false -len 7)

    $env.Add('LedgerName', $ledgerName)
    $env.Add('NewLedgerName', $newLedgerName)
    $env.Add('RemoveLedgerName', $removeLedgerName)
    $env.Add('AvailableName', $availableName)

    # Create resource group
    Write-Host -ForegroundColor Green 'Start creating Resource Group for test...'
    $env.ResourceGroup = 'aclpwsh-rg-' + (RandomString -allChars $false -len 7)
    New-AzResourceGroup -Name $env.ResourceGroup -Location $env.Location
    Write-Host -ForegroundColor Green 'Resource Group created successfully.'

    Write-Host -ForegroundColor Green 'Start creating Confidential Ledger for test...'
    New-AzConfidentialLedger `
        -Name $env.LedgerName `
        -ResourceGroupName $env.ResourceGroup `
        -SubscriptionId $env.SubscriptionId `
        -AadBasedSecurityPrincipal `
            @{
                LedgerRoleName=$env.AadPrincipalRole; 
                PrincipalId=$env.AadPrincipalId; 
                TenantId=$env.AadPrincipalTenantId
            } `
        -CertBasedSecurityPrincipal `
            @{
                Cert=$env.CertPrincipalCert; 
                LedgerRoleName=$env.CertPrincipalRole
            } `
        -LedgerType $env.LedgerType `
        -Location $env.Location `
        -Tag @{Tag0=$env.Tag0}
    Write-Host -ForegroundColor Green 'Confidential Ledger created successfully.'

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host -ForegroundColor Green 'Start deleting Confidential Ledger for test...'
    Remove-AzConfidentialLedger -Name $env.LedgerName -ResourceGroupName $env.ResourceGroup
    Write-Host -ForegroundColor Green 'Confidential Ledger deleted successfully.'

    Write-Host -ForegroundColor Green 'Start deleting Resource Group for test...'
    Remove-AzResourceGroup -Name $env.ResourceGroup
    Write-Host -ForegroundColor Green 'Resource Group deleted successfully.'
}

