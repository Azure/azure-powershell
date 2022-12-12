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
    # For any resources you created for test, you should add it to $env here.

    Install-Module Az.KeyVault -RequiredVersion 2.0.0 -Force
    Import-Module -Name Az.KeyVault
    Import-Module -Name Az.ManagedServiceIdentity

    $tag1 = RandomString -allChars $false -len 4
    $tag2 = RandomString -allChars $false -len 4
    $location = "westus2"
    $identityName1 = 'pwshtestid1'
    $identityName2 = 'pwshtestid2'
    $cmkkey1name = 'testkey1'
    $cmkkey2name = 'testkey2'
    $pwshKeyVault = 'pwsh-loadtesting-kv'+$tag1
    $env.Add("location", $location)
    $env.Add("identityName1", $identityName1)
    $env.Add("identityName2", $identityName2)
    $env.Add("cmkkey1name", $cmkkey1name)
    $env.Add("cmkkey2name", $cmkkey2name)
    $env.Add("pwshKeyVault", $pwshKeyVault)

    # Name for non-CMK enabled resource
    $loadTestResource1 = "pwsh-loadtesting" + $tag1
    $loadTestResource2 = "pwsh-loadtesting" + $tag2
    $resourceGroup = "pwsh-test-rg" + $tag1
    $env.Add("loadTestResource1", $loadTestResource1)
    $env.Add("loadTestResource2", $loadTestResource2)
    $env.Add("resourceGroup", $resourceGroup)
    
    Write-Host -ForegroundColor Green "Creating new resource group:" $env.resourceGroup
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # Deploy managed identity for test
    Write-Host -ForegroundColor Green "Deloying Managed identities -" $identityName1 "," $identityName2 
    $miPara = Get-Content .\test\deployment-templates\managed-identity\parameters.json | ConvertFrom-Json
    $miPara.parameters.idname1.value = $identityName1
    $miPara.parameters.idname2.value = $identityName2
    $miPara.parameters.location.value = $location
    set-content -Path .\test\deployment-templates\managed-identity\parameters.json -Value (ConvertTo-Json $miPara)
    $null = New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\managed-identity\template.json -TemplateParameterFile .\test\deployment-templates\managed-identity\parameters.json -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Green "Deloyment of Managed identity succeeded."
    
    $mi1 = Get-AzUserAssignedIdentity -Name $identityName1 -ResourceGroupName $env.resourceGroup
    $mi2 = Get-AzUserAssignedIdentity -Name $identityName2 -ResourceGroupName $env.resourceGroup

    # Deploy keyvault for test
    Write-Host -ForegroundColor Green "Deloying Key Vault:" $pwshKeyVault
    $kvPara = Get-Content .\test\deployment-templates\key-vault\parameters.json | ConvertFrom-Json
    $kvPara.parameters.name.value = $pwshKeyVault
    $kvPara.parameters.location.value = $location
    $kvPara.parameters.tenant.value = $env.Tenant
    $kvPara.parameters.mi1ObjectId.value = $mi1.PrincipalId
    $kvPara.parameters.mi2ObjectId.value = $mi2.PrincipalId
    set-content -Path .\test\deployment-templates\key-vault\parameters.json -Value (ConvertTo-Json $kvPara)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\key-vault\template.json -TemplateParameterFile .\test\deployment-templates\key-vault\parameters.json -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Green "Deployment of Key Vault" $pwshKeyVault "succeeded."

    # $kv = Get-AzKeyVault -ResourceGroupName $resourceGroup -VaultName $pwshKeyVault
    $key1 = Add-AzKeyVaultKey -VaultName $pwshKeyVault -Name $cmkkey1name -Destination 'Software'
    $key2 = Add-AzKeyVaultKey -VaultName $pwshKeyVault -Name $cmkkey2name -Destination 'Software'
    Write-Host -ForegroundColor Green "CMK Key 1:" $key1.Id
    Write-Host -ForegroundColor Green "CMK Key 2:" $key2.Id
    
    $id1 = Get-AzUserAssignedIdentity -Name $identityName1 -ResourceGroupName $env.resourceGroup
    $id2 = Get-AzUserAssignedIdentity -Name $identityName2 -ResourceGroupName $env.resourceGroup
    Write-Host -ForegroundColor Green "UAMI 1:" $id1.Id
    Write-Host -ForegroundColor Green "UAMI 2:" $id2.Id

    $env.Add("cmkkeyid1", $key1.Id)
    $env.Add("cmkkeyid2", $key2.Id)
    $env.Add("identityid1", $id1.Id)
    $env.Add("identityid2", $id2.Id)
    
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host -ForegroundColor Green "Deleting the resource group:" $env.resourceGroup
    $null = Remove-AzResourceGroup -Name $env.resourceGroup
}

