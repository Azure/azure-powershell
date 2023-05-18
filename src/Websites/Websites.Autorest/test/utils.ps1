function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # NOTE:Need manually steps.
    # 1. create the domain for use in the test before runing test. Help link:https://learn.microsoft.com/en-us/azure/static-web-apps/custom-domain#configure-dns-provider
    # 2. Invite user join static web domian.

    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'Central US'
    # For any resources you created for test, you should add it to $env here.
    # Important security
    $env.githubAccessToken = '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'
    $env.repositoryUrl = 'https://github.com/LucasYao93/blazor-starter'
    $env.branch00 = 'lucas/dev'
    $env.branch01 = 'lucas/dev01'
    $env.branch02 = 'lucas/dev02'
    # Other resource for use in the test.
    # Generate some random strings for use in the test.
    $env.staticweb00 = "staticweb-" + (RandomString -allChars $false -len 6)
    $env.staticweb01 = "staticweb-" + (RandomString -allChars $false -len 6)
    $env.staticweb02 = "staticweb-" + (RandomString -allChars $false -len 6)
    $env.staticweb03 = "staticweb-" + (RandomString -allChars $false -len 6)
    Create the test group
    Write-Host -ForegroundColor Green "start to create test group"
    $env.resourceGroup = 'staticweb-rg-' + (RandomString -allChars $false -len 6)
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # Deploy app serivce plan for use in the test.
    Write-Host -ForegroundColor Green "Deploy app serivce plan for use in the test"
    $env.serverfarmsName01 = "serverfarmsName-" + (RandomString -allChars $false -len 6)
    $serverfarmsParam01 = Get-Content .\test\deployment-templates\appservice-plan\parameters.json | ConvertFrom-Json
    $serverfarmsParam01.parameters.serverfarms_name.value = $env.serverfarmsName01
    Set-Content -Path .\test\deployment-templates\appservice-plan\parameters.json -Value (ConvertTo-Json $serverfarmsParam01)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\appservice-plan\template.json -TemplateParameterFile .\test\deployment-templates\appservice-plan\parameters.json -Name $env.serverfarmsName01 -ResourceGroupName $env.resourceGroup
    $env.appServiceplanId01 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Web/serverFarms/$($env.serverfarmsName01)"
    
    $env.serverfarmsName02 = "serverfarmsName-" + (RandomString -allChars $false -len 6)
    $serverfarmsParam02 = Get-Content .\test\deployment-templates\appservice-plan\parameters.json | ConvertFrom-Json
    $serverfarmsParam02.parameters.serverfarms_name.value = $env.serverfarmsName02
    Set-Content -Path .\test\deployment-templates\appservice-plan\parameters.json -Value (ConvertTo-Json $serverfarmsParam02)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\appservice-plan\template.json -TemplateParameterFile .\test\deployment-templates\appservice-plan\parameters.json -Name $env.serverfarmsName02 -ResourceGroupName $env.resourceGroup
    $env.appServiceplanId02 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Web/serverFarms/$($env.serverfarmsName02)"

    # Deploy function app for use in the test.
    Write-Host -ForegroundColor Green "Deploy function app for use in the test"
    $env.functionAppName01 = "functionApp-" + (RandomString -allChars $false -len 6)
    $functionAppParam01 = Get-Content .\test\deployment-templates\function-app\parameters.json | ConvertFrom-Json
    $functionAppParam01.parameters.sites_funcapp_test_name.value = $env.functionAppName01
    $functionAppParam01.parameters.serverfarms_externalid.value = $env.appServiceplanId01
    Set-Content -Path .\test\deployment-templates\function-app\parameters.json -Value (ConvertTo-Json $functionAppParam01)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\function-app\template.json -TemplateParameterFile .\test\deployment-templates\function-app\parameters.json -Name $env.functionAppName01 -ResourceGroupName $env.resourceGroup
    $env.functionAppId01 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Web/sites/$($env.functionAppName01)"

    $env.functionAppName02 = "functionApp-" + (RandomString -allChars $false -len 6)
    $functionAppParam02 = Get-Content .\test\deployment-templates\function-app\parameters.json | ConvertFrom-Json
    $functionAppParam02.parameters.sites_funcapp_test_name.value = $env.functionAppName02
    $functionAppParam02.parameters.serverfarms_externalid.value = $env.appServiceplanId02
    Set-Content -Path .\test\deployment-templates\function-app\parameters.json -Value (ConvertTo-Json $functionAppParam02)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\function-app\template.json -TemplateParameterFile .\test\deployment-templates\function-app\parameters.json -Name $env.functionAppName02 -ResourceGroupName $env.resourceGroup
    $env.functionAppId02 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Web/sites/$($env.functionAppName02)"

    # Create two static webs for use in the test.
    Write-Host -ForegroundColor Green "Create tow static webs for use in the test."
    New-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -Location $env.location `
                       -RepositoryUrl $env.repositoryUrl -RepositoryToken $env.githubAccessToken -Branch $env.branch00 `
                       -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard'

    New-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -Location $env.location `
                       -RepositoryUrl $env.repositoryUrl -RepositoryToken $env.githubAccessToken -Branch $env.branch01 `
                       -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard'

    
    # Register funtion app for static web.
    Write-Host "Register funtion app for static web."
    Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -FunctionAppName $env.functionAppName01 -FunctionAppResourceId $env.functionAppId01 -FunctionAppRegion $env.location

    # Test for web jobs of the app service.
    # Cannot deploy use resource template json. We have to create resource for use in test via the azure portal.
    # 1. create resource group.
    # 2. create  App Service plan. ref:https://learn.microsoft.com/en-us/azure/app-service/overview-hosting-plans
    # 3. create  App Service. ref:https://learn.microsoft.com/en-us/azure/app-service/
    # 4. deployment slot. ref: https://learn.microsoft.com/en-us/azure/app-service/deploy-staging-slots
    # 5. Create webjob for app and slot.
    
    Write-Host -ForegroundColor Green "start to create test group"
    $env.webJobResourceGroup = "webjob-rg-test"
    New-AzResourceGroup -Name $env.webJobResourceGroup -Location $env.location
    # Create follow resources via the azure portal.
    $env.servicePlan = "servicePlan-test01"
    $env.webApp = "appService-test01"
    $env.slot = "slot01"
    $env.continuousJob01 = "continuousjob-01"
    $env.continuousJob02 = "continuousjob-02"
    $env.slotcontinuousJob03 = "slotcontinuousjob-03"
    $env.slotcontinuousJob04 = "slotcontinuousjob-04"
    $env.triggeredJob01 = "triggeredjob-01"
    $env.triggeredJob02 = "triggeredjob-02"
    $env.slottriggeredJob03 = "slottriggeredjob-03"
    $env.slottriggeredJob04 = "slottriggeredjob-04"
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
    Remove-AzResourceGroup -Name $env.webJobResourceGroup
}

