. ("$PSScriptRoot\helper.ps1")
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
    $env.subscriptionId = (Get-AzContext).Subscription.Id
    $env.tenant = (Get-AzContext).Tenant.Id
    $env.Add('principalObjectId','97deab6c-e478-40b4-b4da-e7d9353dc1e8')
    # For any resources you created for test, you should add it to $env here.
    $rstr01 = 'staaccount' + (RandomLetters -len 6 -lowerCase $true)
    $rstr011 = 'staaccount' + (RandomLetters -len 6 -lowerCase $true)
    $env.Add('staaccountName', $rstr01)
    $env.Add('staaccountName01', $rstr011)

    $rstr02 = 'eventhubspace-' + (RandomString -allChars $false -len 6)
    $rstr021 = 'eventhubspace-' + (RandomString -allChars $false -len 6)
    $rstr022 = 'eventhubspace-' + (RandomString -allChars $false -len 6)
    $rstr03 = 'eventhubname-' + (RandomString -allChars $false -len 6)
    $rstr031 = 'eventhubname-' + (RandomString -allChars $false -len 6)
    $rstr032 = 'eventhubname-' + (RandomString -allChars $false -len 6)
    $env.Add('eventHubSpaceName', $rstr02)
    $env.Add('eventHubSpaceName01', $rstr021)
    $env.Add('eventHubSpaceName02', $rstr022)
    $env.Add('eventHubName', $rstr03)
    $env.Add('eventHubName01', $rstr031)
    $env.Add('eventHubName02', $rstr032)

    $rstr04 = 'iothubname-' + (RandomString -allChars $false -len 6)
    $env.Add('iotHubName', $rstr04)

    $rstr05 = 'tsi-env' + (RandomString -allChars $false -len 6)
    $rstr051 = 'tsi-env' + (RandomString -allChars $false -len 6)
    $env.Add('tsiEnvName', $rstr05)
    $env.Add('tsiEnvName01', $rstr051)

    $rstr06 = 'tsi-es' + (RandomString -allChars $false -len 6)
    $rstr061 = 'tsi-es' + (RandomString -allChars $false -len 6)
    $env.Add('tsiEsName', $rstr06)
    $env.Add('tsiEsName01', $rstr061)

    $rstr07 = 'tsi-ap' + (RandomString -allChars $false -len 6)
    $rstr071 = 'tsi-ap' + (RandomString -allChars $false -len 6)
    $env.Add('accessPolicy', $rstr07)
    $env.Add('accessPolicy01', $rstr071)

    $rstr08 = 'tsirds' + (RandomLetters -len 6 -lowerCase $true)
    $rstr081 = 'tsirds' + (RandomLetters -len 6 -lowerCase $true)
    $env.Add('referenceDataSet', $rstr08)
    $env.Add('referenceDataSet01', $rstr081)

    # Generate some random strings for use in the test.
    $rstrenv01 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstrenv02 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstrenv03 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstrenv04 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstrenv05 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstrenv06 = 'rstr-' + (RandomString -allChars $false -len 6)
    $env.Add('rstrenv01', $rstrenv01)
    $env.Add('rstrenv02', $rstrenv02)
    $env.Add('rstrenv03', $rstrenv03)
    $env.Add('rstrenv04', $rstrenv04)
    $env.Add('rstrenv05', $rstrenv05)
    $env.Add('rstrenv06', $rstrenv06)

    $rstres01 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstres02 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstres03 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstres04 = 'rstr-' + (RandomString -allChars $false -len 6)
    $env.Add('rstres01', $rstres01)
    $env.Add('rstres02', $rstres02)
    $env.Add('rstres03', $rstres03)
    $env.Add('rstres04', $rstres04)

    $rstrap01 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstrap02 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstrap03 = 'rstr-' + (RandomString -allChars $false -len 6)
    $env.Add('rstrap01', $rstrap01)
    $env.Add('rstrap02', $rstrap02)
    $env.Add('rstrap03', $rstrap03)

    $rstrds01 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstrds02 = 'rstr-' + (RandomString -allChars $false -len 6)
    $env.Add('rstrds01', $rstrds01)
    $env.Add('rstrds02', $rstrds02)


    $rstr30 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstr31 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstr32 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstr33 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstr34 = 'rstr-' + (RandomString -allChars $false -len 6)
    $rstr35 = 'rstr-' + (RandomString -allChars $false -len 6)
    $env.Add('rstr30', $rstr30)
    $env.Add('rstr31', $rstr31)
    $env.Add('rstr32', $rstr32)
    $env.Add('rstr33', $rstr33)
    $env.Add('rstr34', $rstr34)
    $env.Add('rstr35', $rstr35)

    # create resource group for test.
    $resourceGroup = 'tsi-test-' + (RandomString -allChars $false -len 6)
    $Location = 'eastus2'
    Write-Host -ForegroundColor Green 'Start creating resource group for test...'
    New-AzResourceGroup -Name $resourceGroup -Location $Location
    $env.Add('resourceGroup', $resourceGroup)
    $env.Add('location', $Location)
    Write-Host -ForegroundColor Green 'Resource group created successfully.'
    
    Write-Host -ForegroundColor Green '--------------------------------------------'
    Write-Host -ForegroundColor Green 'Start deploying resources for testing.'
    # create storage account for test.
    $staAccountParam = (CreateStaAccount -staAccountName $env.staaccountName -resourceGroup $env.resourceGroup -location $env.location -Sku Standard_GRS)
    $staAccountParam01 = (CreateStaAccount -staAccountName $env.staaccountName01 -resourceGroup $env.resourceGroup -location $env.location -Sku Standard_GRS)
    $env.Add('staaccountName01_key', $staAccountParam01.accountKey)

    # create eventhub for test.
    $eventHubParam = (CreateEventHub -eventHubSpaceName $env.eventHubSpaceName -eventHubName $env.eventHubName -resourceGroup $env.resourceGroup -location $env.location)
    $eventHubParam01 = (CreateEventHub -eventHubSpaceName $env.eventHubSpaceName01 -eventHubName $env.eventHubName01 -resourceGroup $env.resourceGroup -location $env.location)
    $eventHubParam02 = (CreateEventHub -eventHubSpaceName $env.eventHubSpaceName02 -eventHubName $env.eventHubName02 -resourceGroup $env.resourceGroup -location $env.location)
    $env.Add('eventHubName02_id', $eventHubParam02.eventhub.id)
    $env.Add('eventHubName02_key', $eventHubParam02.eventHubKey)

    # create iothub for test.
    $iotHubParam = @{iotHubName=$env.iotHubName}
    $iothub = (CreateIotHub -iotHubParamObj $iotHubParam -resourceGroup $env.resourceGroup -location $env.location)
    $env.Add('iotHubName_id', $iothub.iotHub.id)
    $env.Add('iotHubName_key', $iothub.iotHubKey)


    # create TimeSeriesInsightsEnvironment for test.
    $tsiEnvParamObj = @{TsiEnvName = $env.tsiEnvName;Kind='Gen1'; SkuName='S1'; Location=$env.location}
    $tsiEnvParamObj01 = @{TsiEnvName = $env.tsiEnvName01;Kind='Gen2'; SkuName='L1'; Location=$env.location}
    $tsiEnv = (GetOrCreateTsiEnv -forceCreate $true -tsiEnvParamObj $tsiEnvParamObj -resourceGroup $env.resourceGroup)
    $tsiEnv01 = (GetOrCreateTsiEnv -forceCreate $true -tsiEnvParamObj $tsiEnvParamObj01 -resourceGroup $env.resourceGroup -staccountParamObj $staAccountParam)
    
    # create AzTimeSeriesInsightsEventSource(Kind:EventHub) for test.
    $tsiEs = (CreateTsiEventSource -tsiEevntSourceName $env.tsiEsName -resourceGroup $env.resourceGroup -tsiEnv $tsiEnv -eventhubParam $eventHubParam)
    $tsiEs01 = (CreateTsiEventSource -tsiEevntSourceName $env.tsiEsName01 -resourceGroup $env.resourceGroup -tsiEnv $tsiEnv01 -eventhubParam $eventHubParam01)

    # create AzTimeSeriesInsightsAccessPolicy for test.
    Write-Host -ForegroundColor Green 'Start creating AzTimeSeriesInsightsAccessPolicy for test...'
    $role = 'Reader'
    New-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup -PrincipalObjectId $env.principalObjectId -Role $role -Name $env.accessPolicy
    New-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $env.tsiEnvName01 -ResourceGroupName $env.resourceGroup -PrincipalObjectId $env.principalObjectId -Role $role -Name $env.accessPolicy01
    Write-Host -ForegroundColor Green 'AzTimeSeriesInsightsAccessPolicy created successfully.'

    # create AzTimeSeriesInsightsAccessPolicy for test.
    Write-Host -ForegroundColor Green 'Start creating AzTimeSeriesInsightsReferenceDataSet for test...'
    $mykeyproperties = @{ "name" = "device01"; "type" = "Double"}
    New-AzTimeSeriesInsightsReferenceDataSet -EnvironmentName $env.tsiEnvName -Name $env.referenceDataSet -ResourceGroupName $env.resourceGroup -Location $env.location -DataStringComparisonBehavior Ordinal -KeyProperty $mykeyproperties
    Write-Host -ForegroundColor Green 'AzTimeSeriesInsightsReferenceDataSet created successfully.'

    Write-Host -ForegroundColor Green 'Deployment complete.'
    Write-Host -ForegroundColor Green '--------------------------------------------'

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

