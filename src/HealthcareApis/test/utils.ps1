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

    $apiService1 = RandomString -allChars $false -len 6
    $apiService2 = RandomString -allChars $false -len 6
    $env.Add("apiService1", $apiService1)
    $env.Add("apiService2", $apiService2)

    $apiWorkspace1 = RandomString -allChars $false -len 6
    $apiWorkspace2 = RandomString -allChars $false -len 6
    $apiWorkspace3 = RandomString -allChars $false -len 6
    $env.Add("apiWorkspace1", $apiWorkspace1)
    $env.Add("apiWorkspace2", $apiWorkspace2)
    $env.Add("apiWorkspace3", $apiWorkspace3)

    $dicom1 = RandomString -allChars $false -len 6
    $dicom2 = RandomString -allChars $false -len 6
    $env.Add("dicom1", $dicom1)
    $env.Add("dicom2", $dicom2)

    $fhirService1 = RandomString -allChars $false -len 6
    $fhirService2 = RandomString -allChars $false -len 6
    $fhirService3 = RandomString -allChars $false -len 6
    $env.Add("fhirService1", $fhirService1)
    $env.Add("fhirService2", $fhirService2)
    $env.Add("fhirService3", $fhirService3)

    $iotConnector1 = RandomString -allChars $false -len 6
    $iotConnector2 = RandomString -allChars $false -len 6
    $iotConnector3 = RandomString -allChars $false -len 6
    $env.Add("iotConnector1", $iotConnector1)
    $env.Add("iotConnector2", $iotConnector2)
    $env.Add("iotConnector3", $iotConnector3)

    $iotFhirDestination1 = RandomString -allChars $false -len 6
    $iotFhirDestination2 = RandomString -allChars $false -len 6
    $env.Add("iotFhirDestination1", $iotFhirDestination1)
    $env.Add("iotFhirDestination2", $iotFhirDestination2)

    $env.Add("location", "eastus2")

    # Create the test group
    write-host "start to create test group"
    $resourceGroup = "azpstestgroup-eus2"
    $env.Add("resourceGroup", $resourceGroup)

    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    New-AzHealthcareApisWorkspace -Name $env.apiWorkspace1 -ResourceGroupName $env.resourceGroup -Location $env.location
    New-AzHealthcareFhirService -Name $env.fhirService1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Location $env.location -Kind 'fhir-R4' -Authority "https://login.microsoftonline.com/$($env.Tenant)" -Audience "https://azpshcws-$($env.fhirService1).fhir.azurehealthcareapis.com"
    $arr = @()
    New-AzHealthcareIotConnector -Name $env.iotConnector1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Location $env.location -IngestionEndpointConfigurationConsumerGroup "sajob-01-portal_input-01_consumer_group" -IngestionEndpointConfigurationEventHubName "sajob01portaleventhub" -IngestionEndpointConfigurationFullyQualifiedEventHubNamespace "sdk-Namespace-4761" -DeviceMappingContent @{"templateType"="CollectionContent";"template"=$arr}

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.resourceGroup
}

