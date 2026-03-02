$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Suspend-AzStackHCIVMVirtualMachine.Recording.json'
$mockingPath = $null
$currentPath = $PSScriptRoot
while (-not $mockingPath -and $currentPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Filter 'HttpPipelineMocking.ps1' -File -ErrorAction SilentlyContinue
    $parentPath = Split-Path -Path $currentPath -Parent
    if (-not $parentPath -or $parentPath -eq $currentPath) {
        break
    }
    $currentPath = $parentPath
}
if (-not $mockingPath) {
    throw "HttpPipelineMocking.ps1 not found starting from path '$PSScriptRoot'."
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Suspend-AzStackHCIVMVirtualMachine' {
    It 'ByResourceId' {
        {
            $dummySubscriptionId = '00000000-0000-0000-0000-000000000000'
            $dummyResourceGroup  = 'dummy-resource-group'
            $dummyVmName         = 'dummy-vm'
            $resourceId = "/subscriptions/$dummySubscriptionId/resourceGroups/$dummyResourceGroup/providers/Microsoft.StackHCIVM/virtualMachines/$dummyVmName"

            Suspend-AzStackHCIVMVirtualMachine -ResourceId $resourceId -WhatIf
        } | Should -Not -Throw
    }

    It 'ByName' {
        {
            $dummySubscriptionId = '00000000-0000-0000-0000-000000000000'
            $dummyResourceGroup  = 'dummy-resource-group'
            $dummyVmName         = 'dummy-vm'

            Suspend-AzStackHCIVMVirtualMachine -Name $dummyVmName -ResourceGroupName $dummyResourceGroup -SubscriptionId $dummySubscriptionId -WhatIf
        } | Should -Not -Throw
    }
}
