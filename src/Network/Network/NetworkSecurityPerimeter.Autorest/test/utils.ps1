function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

$env = @{}
$templateKeyValues = @{}
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
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    $randomString = "t" + (RandomString -allChars $false -len 4)

    $envFilePath = (Join-Path $PSScriptRoot $envFile)

    $nspKeyValues = Get-Content $envFilePath  | ConvertFrom-Json -AsHashtable

    foreach ($item in $nspKeyValues.GetEnumerator()) {
        if ($env.Contains($item.Name)) {
            $env.($item.Name) = $item.Value
        }else{
            $env.Add($item.Name, $item.Value)
        }
    }
    $env.randomStr = $randomString

    #Create variable for template
    $tmpNsp1 =  $randomString + 't-nsp1'
    $tmpNspDelete =  $randomString + 't-nspD'
    $tmpProfile1 = 't-profile1'
    $tmpProfileDelete = 't-profileD'
    $tmpAccessRule = 't-ar'
    $tmpAssociation = 't-asn'
    $tmpPaasRp = $randomString + 't-paasRp'

    $tmpKeys = 'tmpNsp1', 'tmpProfile1', 'tmpAccessRule', 'tmpAssociation', 'tmpPaasRp', 'tmpProfileDelete', 'tmpNspDelete'
    $tmpValues = $tmpNsp1, $tmpProfile1, $tmpAccessRule, $tmpAssociation, $tmpPaasRp, $tmpProfileDelete, $tmpNspDelete

    for ($i = 0; $i -le ($tmpKeys.length - 1); $i += 1) {
        if ($templateKeyValues.Contains($tmpKeys[$i])) {
            $templateKeyValues.($tmpKeys[$i]) = $tmpValues[$i]
        }else{    
            $templateKeyValues.Add($tmpKeys[$i], $tmpValues[$i])
        }
    }

    echo $templateVariables

    (ConvertTo-Json $templateVariables) | echo

    (ConvertTo-Json $a) | echo


    Get-Content $envFilePath  | ConvertFrom-Json -AsHashtable

    set-content -Path (Join-Path $PSScriptRoot 'env.json') -Value (ConvertTo-Json $env)

    set-content -Path (Join-Path $PSScriptRoot 'localEnv.json') -Value (ConvertTo-Json $env)

    set-content -Path (Join-Path $PSScriptRoot 'templateVariables.json') -Value (ConvertTo-Json $templateVariables)

    
    Write-Host -ForegroundColor Magenta "Create resource group"

    # create resource group if it doesnt exists
    New-AzResourceGroup -Name $env.rgname -Location $env.location

    Write-Host -ForegroundColor Magenta "Deploying template"

    
    $templateInput = @{
        ResourceGroupName = $env.rgname
        TemplateFile = ".\test\NSPTemplate.json"
        nsp1Name $tmpNsp1
        nspDeleteName $tmpNspDelete
        profile1Name $tmpProfile1
        profileDeleteName $tmpProfileDelete
        accessRuleName $tmpAccessRule
        paasName $tmpPaasRp
        associationName $tmpAssociation
       }
    
    #deploy template
    $templateOutput = New-AzResourceGroupDeployment @templateInput

    Write-Host -ForegroundColor Magenta "Template deployed"

}
function cleanupEnv() {

    # Clean resources you create for testing
    
    Write-Host -ForegroundColor Magenta "Removing associations"

    #Remove association
    $remove_association = @{
        SecurityPerimeterName = $templateKeyValues.tmpNsp1
        ResourceGroupName = $env.rgname
        Name = $templateKeyValues.tmpAssociation
       }

    Remove-AzNetworkSecurityPerimeterAssociation @remove_association

    Write-Host -ForegroundColor Magenta "Sleep 60"

    Start-Sleep -Seconds 60

    Write-Host -ForegroundColor Magenta "Removing RG"

    #Remove resourceGroup
    Remove-AzResourceGroup -Name $env.rgname

    Write-Host -ForegroundColor Magenta "Removed RG"

}

