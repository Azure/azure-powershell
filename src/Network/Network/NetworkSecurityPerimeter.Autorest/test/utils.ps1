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
    $tmpProfile3 = 't-profile3'
    $tmpProfileDelete1 = 't-profileD1'
    $tmpProfileDelete2 = 't-profileD2'
    $tmpProfileDelBase1 = 't-prDelB1'
    $tmpProfileDelBase2 = 't-prDelB2'
    $tmpAccessRule1 = 't-ar1'
    $tmpAccessRule2 = 't-ar2'
    $tmpAccessRuleDelete1 = 't-arD1'
    $tmpAccessRuleDelete2 = 't-arD2'
    $tmpAssociation1 = 't-asn1'
    $tmpAssociationDelete1 = 't-asnD1'
    $tmpAssociationDelete2 = 't-asnD2'
    $tmpPaas1Rp = $randomString + 't-paas1Rp'
    $tmpPaas2Rp = $randomString + 't-paas2Rp'
    $tmpPaas3Rp = $randomString + 't-paas3Rp'
    $tmpPaas4Rp = $randomString + 't-paas4Rp'

    $tmpKeys = 'tmpNsp1','tmpNspDelBase1', 'tmpProfile1', 'tmpProfile2', 'tmpProfile3', 'tmpProfileDelBase1', 'tmpProfileDelBase2', 'tmpAccessRule1', 'tmpAccessRule2', 'tmpAccessRuleDelete1','tmpAccessRuleDelete2', 'tmpAssociation1', 'tmpAssociationDelete1', 'tmpAssociationDelete2', 'tmpPaas1Rp', 'tmpPaas2Rp','tmpPaas3Rp', 'tmpPaas4Rp','tmpProfileDelete1', 'tmpProfileDelete2', 'tmpNspDelete1', 'tmpNspDelete2'
    $tmpValues = $tmpNsp1, $tmpNspDelBase1, $tmpProfile1, $tmpProfile2, $tmpProfile3, $tmpProfileDelBase1, $tmpProfileDelBase2, $tmpAccessRule1, $tmpAccessRule2, $tmpAccessRuleDelete1, $tmpAccessRuleDelete2,  $tmpAssociation1, $tmpAssociationDelete1, $tmpAssociationDelete2, $tmpPaas1Rp, $tmpPaas2Rp,$tmpPaas3Rp, $tmpPaas4Rp,  $tmpProfileDelete1, $tmpProfileDelete2, $tmpNspDelete1, $tmpNspDelete2

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
    
    Write-Host -ForegroundColor Magenta "Create resource group"

    # create resource group if it doesnt exists
    New-AzResourceGroup -Name $env.rgname -Location $env.location

    Write-Host -ForegroundColor Magenta "Deploying template"

    
    $templateInput = @{
        ResourceGroupName = $env.rgname
        TemplateFile = ".\test\NSPTemplate.json"
        nsp1Name = $env.tmpNsp1
        nspDelBase1Name = $env.tmpNspDelBase1
        nspDelete1Name = $env.tmpNspDelete1
        nspDelete2Name = $env.tmpNspDelete2
        profile1Name = $env.tmpProfile1
        profile2Name = $env.tmpProfile2
        profile3Name = $env.tmpProfile3
        profileDelete1Name = $env.tmpProfileDelete1
        profileDelete2Name = $env.tmpProfileDelete2
        profileDelBase1Name = $env.tmpProfileDelBase1
        profileDelBase2Name = $env.tmpProfileDelBase2
        accessRule1Name = $env.tmpAccessRule1
        accessRule2Name = $env.tmpAccessRule2
        accessRuleDelete1Name = $env.tmpAccessRuleDelete1
        accessRuleDelete2Name = $env.tmpAccessRuleDelete2
        paas1Name = $env.tmpPaas1Rp
        paas2Name = $env.tmpPaas2Rp
        paas3Name = $env.tmpPaas3Rp
        paas4Name = $env.tmpPaas4Rp
        association1Name = $env.tmpAssociation1
        associationDelete1Name = $env.tmpAssociationDelete1
        associationDelete2Name = $env.tmpAssociationDelete2
       }
    
    #deploy template
    $templateOutput = New-AzResourceGroupDeployment @templateInput

    Write-Host -ForegroundColor Magenta "Template deployed"

}
function cleanupEnv() {

    # Clean resources you create for testing
    
    Write-Host -ForegroundColor Magenta "Removing associations"

    
    # Remove associations
    $remove_association1 = @{
        SecurityPerimeterName = $env.tmpNsp1
        ResourceGroupName = $env.rgname
        Name = $env.tmpAssociation1
       }

    Remove-AzNetworkSecurityPerimeterAssociation @remove_association1

    
    $remove_associationDelete1 = @{
        SecurityPerimeterName = $env.tmpNspDelBase1
        ResourceGroupName = $env.rgname
        Name = $env.tmpAssociationDelete1
    }

    Remove-AzNetworkSecurityPerimeterAssociation @remove_associationDelete1

    $remove_associationDelete2 = @{
        SecurityPerimeterName = $env.tmpNspDelBase1
        ResourceGroupName = $env.rgname
        Name = $env.tmpAssociationDelete2
    }

    Remove-AzNetworkSecurityPerimeterAssociation @remove_associationDelete2

    
    #Remove association created by testcase
    $remove_association2 = @{
        SecurityPerimeterName = $env.tmpNsp1
        ResourceGroupName = $env.rgname
        Name = $env.association1
    }


    Remove-AzNetworkSecurityPerimeterAssociation @remove_association2

    Write-Host -ForegroundColor Magenta "Done"


    $isDeleted = $false

    While(-Not $isDeleted){
        $isDeleted = $true

        Write-Host -ForegroundColor Magenta "Sleep 20"

        Start-Sleep -Seconds 20

        try{
             $isDeleted = $false
             Get-AzNetworkSecurityPerimeterAssociation @remove_association1
             continue
        }
        catch{
            $isDeleted = $true
        }

        try{
             $isDeleted = $false
             Get-AzNetworkSecurityPerimeterAssociation @remove_associationDelete1
             continue
        }
        catch{
            $isDeleted = $true
        }

        try{
             $isDeleted = $false
             Get-AzNetworkSecurityPerimeterAssociation @remove_associationDelete2
             continue
        }
        catch{
            $isDeleted = $true
        }

        try{
             $isDeleted = $false
             Get-AzNetworkSecurityPerimeterAssociation @remove_association2
             continue
        }
        catch{
            $isDeleted = $true
        }

    }

    Write-Host -ForegroundColor Magenta "Removing RG"

    #Remove resourceGroup
    Remove-AzResourceGroup -Name $env.rgname

    Write-Host -ForegroundColor Magenta "Removed RG"
}

