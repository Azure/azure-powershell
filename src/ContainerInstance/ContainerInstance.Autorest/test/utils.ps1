function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,
 
        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )
 
    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}
 
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.resourceGroupName = "test-rg" + (RandomString -allChars $false -len 5)
    $env.location = "eastus"
    $env.containerGroupName = "bez-test-cg"
    $env.containerGroupName1 = "test-cg" + (RandomString -allChars $false -len 5)
    $env.containerGroupName2 = "test-cg" + (RandomString -allChars $false -len 5)
    $env.containerGroupName3 = "test-cg" + (RandomString -allChars $false -len 5)
    $env.containerGroupName4 = "test-cg" + (RandomString -allChars $false -len 5)
    $env.containerGroupName5 = "test-cg" + (RandomString -allChars $false -len 5)
    $env.regularContainerGroupName = "test-cg" + (RandomString -allChars $false -len 5)
    $env.spotContainerGroupName = "test-cg" + (RandomString -allChars $false -len 5)
    $env.regularPriorityContainerGroupName = "test-regular-priority-cg" + (RandomString -allChars $false -len 5)
    $env.spotPriorityContainerGroupName = "test-spot-priority-cg" + (RandomString -allChars $false -len 5)
    $env.confidentialContainerGroupName = "test-confidential-containergroup"
    $env.reusedContainerGroupName = "pool-reused-containergroup"
 
    $env.containerGroupProfileName = "bez-test-cgp"
    $env.containerGroupProfileName1 = "test-cgp" + (RandomString -allChars $false -len 5)
    $env.containerGroupProfileName2 = "test-cgp" + (RandomString -allChars $false -len 5)
    $env.spotContainerGroupProfileName = "test-cgp" + (RandomString -allChars $false -len 5)
    $env.spotPriorityContainerGroupProfileName = "test-spot-priority-cgp" + (RandomString -allChars $false -len 5)
    $env.confidentialContainerGroupProfileName = "test-confidential-containergroupprofile" + (RandomString -allChars $false -len 5)
 
    $env.containerInstanceName = "bez-test-ci"
    $env.reusedContainerInstanceName = "testcg"
    $env.image = "mcr.microsoft.com/azuredocs/aci-helloworld:latest"
    $env.osType = "Linux"
    $env.requestCpu = 1.0
    $env.requestMemoryInGb = 1.5
    $env.restartPolicy = "Never"
    $env.port1 = 8000
    $env.port2 = 8001
    $env.regularPriority = "Regular"
    $env.spotPriority = "Spot"
    $env.confidentialSku = "confidential"
    $env.confidentialComputePropertyCcePolicy = 'eyJhbGxvd19hbGwiOiB0cnVlLCAiY29udGFpbmVycyI6IHsibGVuZ3RoIjogMCwgImVsZW1lbnRzIjogbnVsbH19'
 
    $env.containerGroupProfileId = "/subscriptions/da28f5e5-aa45-46fe-90c8-053ca49ab4b5/resourceGroups/azcliresources/providers/Microsoft.ContainerInstance/containerGroupProfiles/testcg"
    $env.containerGroupProfileRevision = 1
    $env.standbyPoolProfileId = "/subscriptions/da28f5e5-aa45-46fe-90c8-053ca49ab4b5/resourceGroups/azcliresources/providers/Microsoft.StandbyPool/standbyContainerGroupPools/testpool"
 
    # Create some resource for test.
    Write-Debug "Create resource group for test"
    New-AzResourceGroup -Name $env.resourceGroupName -Location $env.location
 
    Write-Debug "Create container group for test"
    $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image $env.image -RequestCpu $env.requestCpu -RequestMemoryInGb $env.requestMemoryInGb
    $container1 = New-AzContainerInstanceObject -Name "${env.containerInstanceName}1" -Image $env.image -RequestCpu $env.requestCpu -RequestMemoryInGb $env.requestMemoryInGb
    $container2 = New-AzContainerInstanceObject -Name "${env.containerInstanceName}2" -Image $env.image -RequestCpu $env.requestCpu -RequestMemoryInGb $env.requestMemoryInGb
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupName -Location $env.location -Container $container -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name "$($env.containerGroupName)-remove1" -Location $env.location -Container $container1 -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name "$($env.containerGroupName)-remove2" -Location $env.location -Container $container2 -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.regularContainerGroupName -Location $env.location -Container $container1 -Priority $env.regularPriority -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.spotContainerGroupName -Location $env.location -Container $container1 -Priority $env.spotPriority -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name "$($env.regularContainerGroupName)-remove1" -Location $env.location -Container $container1 -Priority $env.regularPriority -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name "$($env.regularContainerGroupName)-remove2" -Location $env.location -Container $container1 -Priority $env.regularPriority -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name "$($env.spotContainerGroupName)-remove1" -Location $env.location -Container $container1 -Priority $env.spotPriority -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name "$($env.spotContainerGroupName)-remove2" -Location $env.location -Container $container1 -Priority $env.spotPriority -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.confidentialContainerGroupName -Location $env.location -Container $container1 -Sku $env.confidentialSku -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name "$($env.confidentialContainerGroupName)-remove1" -Location $env.location -Container $container1 -Sku $env.confidentialSku -OsType $env.osType
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name "$($env.confidentialContainerGroupName)-remove2" -Location $env.location -Container $container1 -Sku $env.confidentialSku -OsType $env.osType
 
    Write-Debug "Create container group profile for test"
    New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupProfileName -Location $env.location -Container $container -OsType $env.osType
    New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name "$($env.containerGroupProfileName)-remove1" -Location $env.location -Container $container1 -OsType $env.osType
    New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name "$($env.containerGroupProfileName)-remove2" -Location $env.location -Container $container2 -OsType $env.osType
    New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name "$($env.spotContainerGroupProfileName)-remove1" -Location $env.location -Container $container1 -Priority $env.spotPriority -OsType $env.osType
    New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name "$($env.spotContainerGroupProfileName)-remove2" -Location $env.location -Container $container1 -Priority $env.spotPriority -OsType $env.osType
    New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name "$($env.confidentialContainerGroupProfileName)-remove1" -Location $env.location -Container $container1 -Sku $env.confidentialSku -OsType $env.osType
    New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name "$($env.confidentialContainerGroupProfileName)-remove2" -Location $env.location -Container $container1 -Sku $env.confidentialSku -OsType $env.osType
 
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroupName
}