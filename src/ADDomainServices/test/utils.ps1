function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'westus'
    # For any resources you created for test, you should add it to $env here.

    Write-Host -ForegroundColor Green "Create test group..."
    $ResourceGroupName = 'youriADDomain-rg-' + (RandomString -allChars $false -len 6)
    Write-Host $ResourceGroupName
    New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

    $null = $env.Add('ResourceGroupName', $ResourceGroupName)
    Write-Host -ForegroundColor Green 'The test group create completed.'

    write-host "Deploy NSG template"
    $networkSecurityGroups_name = 'youriNSG' + (RandomString -allChars $false -len 6)
    $networkSecurityGroupParam = Get-Content .\test\deployment-templates\networkSecurityGroup\parameters.json | ConvertFrom-Json
    $networkSecurityGroupParam.parameters.networkSecurityGroups_name.Value = $networkSecurityGroups_name
    set-content -Path .\test\deployment-templates\networkSecurityGroup\parameters.json -Value (ConvertTo-Json $networkSecurityGroupParam)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\networkSecurityGroup\template.json -TemplateParameterFile .\test\deployment-templates\networkSecurityGroup\parameters.json -Name vn -ResourceGroupName $ResourceGroupName
    write-host "The NSG create completed."

    write-host "Deploy Vnet template"
    $virtualNetworks_name = 'youriNTW' + (RandomString -allChars $false -len 6)
    $networkSecurityGroups_externalid = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($ResourceGroupName)/providers/Microsoft.Network/networkSecurityGroups/$($networkSecurityGroups_name)"
    $virtualNetworksParam = Get-Content .\test\deployment-templates\virtual-network\parameters.json | ConvertFrom-Json
    $virtualNetworksParam.parameters.virtualNetworks_name.Value = $virtualNetworks_name
    $virtualNetworksParam.parameters.networkSecurityGroups_externalid.Value = $networkSecurityGroups_externalid
    set-content -Path .\test\deployment-templates\virtual-network\parameters.json -Value (ConvertTo-Json $virtualNetworksParam)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\virtual-network\template.json -TemplateParameterFile .\test\deployment-templates\virtual-network\parameters.json -Name vn -ResourceGroupName $ResourceGroupName
    write-host "The NSG create completed."

    $SubnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($ResourceGroupName)/providers/Microsoft.Network/virtualNetworks/$($virtualNetworks_name)/subnets/default"
    $ADdomainName = "youriADDomainTest" + (RandomString -allChars $false -len 6)
    $ADDomainNameCom = "youriAdDomain.com"
    $TlsV1Status1 = "Disabled"
    $TlsV1Status2 = "Enabled"
    $null = $env.Add('ADdomainName', $ADdomainName)
    $null = $env.Add('SubnetId', $SubnetId)
    $null = $env.Add('ADDomainNameCom', $ADDomainNameCom)
    $null = $env.Add('TlsV1Status1', $TlsV1Status1)
    $null = $env.Add('TlsV1Status2', $TlsV1Status2)


    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}

