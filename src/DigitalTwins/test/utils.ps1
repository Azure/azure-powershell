function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # For test DigitalTwinsEndpoint,you need to install model 'EventGrid', 'EventHub' and 'ServiceBus' first
    Write-host "For test DigitalTwinsEndpoint,you need to install model 'EventGrid', 'EventHub' and 'ServiceBus' first"
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $rstr1 = RandomString -allChars $false -len 6
    $rstr2 = RandomString -allChars $false -len 6
    $rstr3 = RandomString -allChars $false -len 6
    $rstr4 = RandomString -allChars $false -len 6
    $rstr5 = RandomString -allChars $false -len 6
    $rstr6 = RandomString -allChars $false -len 6
    $rstr7 = RandomString -allChars $false -len 6

    $null = $env.Add("eventHubEndpointType", "EventHub")
    $null = $env.Add("eventGridEndpointType", "EventGrid")
    $null = $env.Add("serviceBusEndpointType", "ServiceBus")
    $resourceGroup = 'youridigitaltwins-rg' + $rstr1
    $null = $env.Add("resourceGroup", $resourceGroup)
    $digitalTwins = 'youriDigitalTwins' + $rstr2
    $null = $env.Add("digitalTwins", $digitalTwins)
    $digitalTwins1 = 'youriDigitalTwins' + $rstr3
    $null = $env.Add("digitalTwins1", $digitalTwins1)
    $testDigitalTwinsName = 'youriDigitalTwins' + $rstr4
    $null = $env.Add("testDigitalTwinsName", $testDigitalTwinsName)
    $eventHubEndpointName = 'eventHubEndpointName' + $rstr5
    $null = $env.Add("eventHubEndpointName", $eventHubEndpointName)
    $eventGridEndpointName = 'eventGridEndpointName' + $rstr6
    $null = $env.Add("eventGridEndpointName", $eventGridEndpointName)
    $ServiceBusEndpointName = 'ServiceBusEndpointName' + $rstr7
    $null = $env.Add("ServiceBusEndpointName", $ServiceBusEndpointName)
    $null = $env.Add("location", "eastus")
    # Create the test group
    write-host "start to create test group"
    write-host $env.location
    New-AzResourceGroup -Name $resourceGroup -Location $env.location

    #Deploy eventbus eventgrid servicebus for test
    Write-Host -ForegroundColor Green "Deloying eventbus..." 
    $subscriptionId = $env.SubscriptionId

    $eventHubNameSpace = "eventHubNameSpace" + (RandomString -allChars $false -len 6)
    $eventHubName = "eventHubName" + (RandomString -allChars $false -len 6)
    $eventHubPolicy = "eventHubPolicy" + (RandomString -allChars $false -len 6)
    New-AzEventHubNamespace -ResourceGroupName $resourceGroup -NamespaceName $eventHubNameSpace -Location $env.location
    New-AzEventHub -ResourceGroupName $resourceGroup -Namespace $eventHubNameSpace -Name $eventHubName
    New-AzEventHubAuthorizationRule -ResourceGroupName $resourceGroup -Namespace $eventHubNameSpace -EventHub $eventHubName -Name $eventHubPolicy -Rights @("Send")
    $getAzEventHubKey = Get-AzEventHubKey -ResourceGroupName $resourceGroup -Namespace $eventHubNameSpace -EventHub $eventHubName -Name $eventHubPolicy
    $eventHubConnectionStringPrimaryKeyOri = $getAzEventHubKey.PrimaryConnectionString
    $eventHubConnectionStringPrimaryKey = ConvertTo-SecureString -string $eventHubConnectionStringPrimaryKeyOri -AsPlainText -Force | ConvertFrom-SecureString
    $null = $env.Add("eventHubConnectionStringPrimaryKey", $eventHubConnectionStringPrimaryKey)

    $eventGridName = "eventGridName" + (RandomString -allChars $false -len 6)
    $eventgrid = Get-Content .\test\deployment-templates\eventgrid\parameters.json | ConvertFrom-Json
    $eventgrid.parameters.eventGridName.value = $eventGridName
    Set-Content -Path .\test\deployment-templates\eventgrid\parameters.json -Value (ConvertTo-Json $eventgrid)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\eventgrid\template.json -TemplateParameterFile .\test\deployment-templates\eventgrid\parameters.json -Name nsg -ResourceGroupName $resourceGroup
    $getAzEventGridTopic = Get-AzEventGridTopic -ResourceGroupName $resourceGroup -Name $eventGridName
    $eventGridTopEndPoint = $GetAzEventGridTopic.EndPoint
    $getAzEventGridTopicKey = Get-AzEventGridTopicKey -ResourceGroupName $resourceGroup -Name $eventGridName
    $eventGridAccessKey1Ori = $getAzEventGridTopicKey.Key1
    $null = $env.Add("eventGridTopEndPoint", $eventGridTopEndPoint)
    $eventGridAccessKey1 =ConvertTo-SecureString -string $eventGridAccessKey1Ori -AsPlainText -Force | ConvertFrom-SecureString
    $null = $env.Add("eventGridAccessKey1", $eventGridAccessKey1)

    $serviceBusNameSpace = "serviceBusNameSpace" + (RandomString -allChars $false -len 6)
    $serviceBusTopicName = "serviceBusTopicName" + (RandomString -allChars $false -len 6)
    $serviceBusPolicy = "serviceBusPolicy" + (RandomString -allChars $false -len 6)
    New-AzServiceBusNamespace -ResourceGroupName $resourceGroup -Location $env.location -Name $serviceBusNameSpace
    New-AzServiceBusTopic -ResourceGroupName $resourceGroup -Namespace $serviceBusNameSpace -Name $serviceBusTopicName -EnablePartitioning $False
    New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroup -Namespace $serviceBusNameSpace -Topic $serviceBusTopicName -Name $serviceBusPolicy -Rights @("Send")
    $getAzServiceBusKey = Get-AzServiceBusKey -ResourceGroupName $resourceGroup -Namespace $serviceBusNameSpace -Topic $serviceBusTopicName -Name $serviceBusPolicy
    $serviceBusPrimaryConnectionStringOri = $getAzServiceBusKey.PrimaryConnectionString
    $serviceBusPrimaryConnectionString = ConvertTo-SecureString -string $serviceBusPrimaryConnectionStringOri  -AsPlainText -Force | ConvertFrom-SecureString
    $null = $env.Add("serviceBusPrimaryConnectionString", $serviceBusPrimaryConnectionString)

    Start-Sleep -Seconds 60
    Write-Host -ForegroundColor Green "eventhub eventgrid servicebus deploy completed."

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

