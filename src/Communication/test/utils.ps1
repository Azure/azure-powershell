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

    $rstr1 = RandomString -allChars $false -len 6
    $rstr2 = RandomString -allChars $false -len 6
    $env.Add("rstr1", $rstr1)
    $env.Add("rstr2", $rstr2)

    # Create the test group
    write-host "creating test resource group..."
    $resourceGroup = "testgroup" + $rstr1
    $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $resourceGroup -Location eastus

    # Create the resource name
    $resourceName = "acsResource" + $rstr1
    $env.Add("resourceName", $resourceName)

    # Add location values
    $dataLocation = "UnitedStates"
    $location = "Global"
    $env.Add("dataLocation", $dataLocation)
    $env.Add("location", $location)

    write-host "creating a persistent test resource..."
    # Create a persistent test resource
    $persistentResourceName = "persistentResourceName" + $rstr1
    $env.Add("persistentResourceName", $persistentResourceName)
    $persistentResource = New-AzCommunicationService -ResourceGroupName $resourceGroup -Name $persistentResourceName -DataLocation $dataLocation -Location $location

    $notificationHubConnectionString = "Endpoint=sb://contosonotificationhubnamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx="
    $notificationHubResourceId = "/subscriptions/73fc3588-3cef-4302-9e19-2d18b71ce0e5/resourcegroups/ContosoResourceProvider1/providers/Microsoft.NotificationHubs/namespaces/contosonotificationhubnamespace/notificationHubs/contosonotificationhub"
    $env.Add("notificationHubConnectionString", $notificationHubConnectionString)
    $env.Add("notificationHubResourceId", $notificationHubResourceId)

    # Add tag values
    $env.Add("exampleKey1", "ExampleKey1")
    $env.Add("exampleKey2", "ExampleKey2")
    $env.Add("exampleValue1", "ExampleValue1")
    $env.Add("exampleValue2", "ExampleValue2")

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Removing resourcegroup will clean all the resources created for testing.
    Remove-AzResourceGroup -Name $env.resourceGroup
}

