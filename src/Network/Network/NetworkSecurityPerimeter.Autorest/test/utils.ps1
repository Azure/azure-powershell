function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

$env = @{}
$templateVariables = @{}
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
    $tmpNspDelBase1 =  $randomString + 't-nspDelB1'
    $tmpNspDelete1 =  $randomString + 't-nspD1'
    $tmpNspDelete2 =  $randomString + 't-nspD2'
    $tmpProfile1 = 't-profile1'
    $tmpProfile2 = 't-profile2'
    $tmpProfileDelete1 = 't-profileD1'
    $tmpProfileDelete2 = 't-profileD2'
    $tmpProfileDelBase1 = 't-prDelB1'
    $tmpProfileDelBase2 = 't-prDelB2'
    $tmpAccessRule1 = 't-ar1'
    $tmpAccessRuleDelete1 = 't-arD1'
    $tmpAccessRuleDelete2 = 't-arD2'
    $tmpAssociation1 = 't-asn1'
    $tmpAssociationDelete1 = 't-asnD1'
    $tmpAssociationDelete2 = 't-asnD2'
    $tmpPaas1Rp = $randomString + 't-paas1Rp'
    $tmpPaas2Rp = $randomString + 't-paas2Rp'
    $tmpPaas3Rp = $randomString + 't-paas3Rp'

    $tmpKeys = 'tmpNsp1','tmpNspDelBase1', 'tmpProfile1', 'tmpProfile2', 'tmpProfileDelBase1', 'tmpProfileDelBase2', 'tmpAccessRule1','tmpAccessRuleDelete1','tmpAccessRuleDelete2', 'tmpAssociation1', 'tmpAssociationDelete1', 'tmpAssociationDelete2', 'tmpPaas1Rp', 'tmpPaas2Rp','tmpPaas3Rp', 'tmpProfileDelete1', 'tmpProfileDelete2', 'tmpNspDelete1', 'tmpNspDelete2'
    $tmpValues = $tmpNsp1, $tmpNspDelBase1, $tmpProfile1, $tmpProfile2, $tmpProfileDelBase1, $tmpProfileDelBase2, $tmpAccessRule1, $tmpAccessRuleDelete1, $tmpAccessRuleDelete2,  $tmpAssociation1, $tmpAssociationDelete1, $tmpAssociationDelete2, $tmpPaas1Rp, $tmpPaas2Rp,$tmpPaas3Rp, $tmpProfileDelete1, $tmpProfileDelete2, $tmpNspDelete1, $tmpNspDelete2

    for ($i = 0; $i -le ($tmpKeys.length - 1); $i += 1) {
        if ($templateVariables.Contains($tmpKeys[$i])) {
            $templateVariables.($tmpKeys[$i]) = $tmpValues[$i]
        }else{    
            $templateVariables.Add($tmpKeys[$i], $tmpValues[$i])
        }
    }

    for ($i = 0; $i -le ($tmpKeys.length - 1); $i += 1) {
        if ($env.Contains($tmpKeys[$i])) {
            $env.($tmpKeys[$i]) = $tmpValues[$i]
        }else{
            $env.Add($tmpKeys[$i], $tmpValues[$i])
        }
    }


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
        nsp1Name = $tmpNsp1
        nspDelBase1Name = $tmpNspDelBase1
        nspDelete1Name = $tmpNspDelete1
        nspDelete2Name = $tmpNspDelete2
        profile1Name = $tmpProfile1
        profile2Name = $tmpProfile2
        profileDelete1Name = $tmpProfileDelete1
        profileDelete2Name = $tmpProfileDelete2
        profileDelBase1Name = $tmpProfileDelBase1
        profileDelBase2Name = $tmpProfileDelBase2
        accessRule1Name = $tmpAccessRule1
        accessRuleDelete1Name = $tmpAccessRuleDelete1
        accessRuleDelete2Name = $tmpAccessRuleDelete2
        paas1Name = $tmpPaas1Rp
        paas2Name = $tmpPaas2Rp
        paas3Name = $tmpPaas3Rp
        association1Name = $tmpAssociation1
        associationDelete1Name = $tmpAssociationDelete1
        associationDelete2Name = $tmpAssociationDelete2
       }
    
    #deploy template
    $templateOutput = New-AzResourceGroupDeployment @templateInput

    Write-Host -ForegroundColor Magenta "Template deployed"

}
function cleanupEnv() {

    # Clean resources you create for testing
    
    Write-Host -ForegroundColor Magenta "Removing associations"

    #Remove association
    $remove_association1 = @{
        SecurityPerimeterName = $templateVariables.tmpNsp1
        ResourceGroupName = $env.rgname
        Name = $templateVariables.tmpAssociation1
       }

    Remove-AzNetworkSecurityPerimeterAssociation @remove_association1

    $remove_associationDelete1 = @{
        SecurityPerimeterName = $templateVariables.tmpNspDelBase1
        ResourceGroupName = $env.rgname
        Name = $templateVariables.tmpAssociationDelete1
    }

    Remove-AzNetworkSecurityPerimeterAssociation @remove_associationDelete1

    $remove_associationDelete2 = @{
        SecurityPerimeterName = $templateVariables.tmpNspDelBase1
        ResourceGroupName = $env.rgname
        Name = $templateVariables.tmpAssociationDelete2
    }

    Remove-AzNetworkSecurityPerimeterAssociation @remove_associationDelete2

    Write-Host -ForegroundColor Magenta "Sleep 60"

    Start-Sleep -Seconds 60

    Write-Host -ForegroundColor Magenta "Removing RG"

    #Remove resourceGroup
    Remove-AzResourceGroup -Name $env.rgname

    Write-Host -ForegroundColor Magenta "Removed RG"

}

