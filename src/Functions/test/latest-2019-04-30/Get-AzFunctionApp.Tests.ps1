$TestRecordingFile = Join-Path $PSScriptRoot 'Functions.Scenario.Tests.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName


# Test variables
$resourceGroupNameWindows = "Functions-West-Europe-Win"
$resourceGroupNameLinux = "Functions-West-Europe-Linux"
$location = "West Europe"
$planNameWorkerTypeLinux = "Functions-West-Europe-Linux"
$planNameWorkerTypeWindows = "Functions-West-Europe-Windows"
$storageAccountWindows = "functionswinstorage"
$storageAccountLinux = "functionslinuxstorage"

$servicePlansToCreate = @(
    @{
        ResourceGroupName = $resourceGroupNameWindows
        Name = $planNameWorkerTypeWindows
        Location = $location
        MinimumWorkerCount = 1
        MaximumWorkerCount = 10
        Sku = "EP1"
        WorkerType = "Windows"
    },
    @{
        ResourceGroupName = $resourceGroupNameLinux
        Name = $planNameWorkerTypeLinux
        Location = $location
        MinimumWorkerCount = 1
        MaximumWorkerCount = 10
        Sku = "EP1"
        WorkerType = "Linux"
    }
)




Describe 'Get-AzFunctionApp' {

    BeforeAll {

    }

    AfterAll {
        Remove-AzResourceGroup -Name $resouceGroupName -Force
    }

    It 'GetAll' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BySubscriptionId' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByResourceGroupName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByLocation' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
