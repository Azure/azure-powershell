$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedMachine.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzConnectedMachine' {
    
    It 'Get all connected machines in a subscription' {
        $machines = Get-AzConnectedMachine -SubscriptionId b5e4748c-f69a-467c-8749-e2f9c8cd3db0 
        $machines.Count | Should -Be 777
    }
    
    It 'Get all connected machines in a resource group' {
        $machines = Get-AzConnectedMachine -SubscriptionId b5e4748c-f69a-467c-8749-e2f9c8cd3db0 -ResourceGroupName hybridrptest
        $machines.Count | Should -Be 688
    }

    It 'Get a connected machine by machine name' {
        $machine = Get-AzConnectedMachine -SubscriptionId b5e4748c-f69a-467c-8749-e2f9c8cd3db0 -ResourceGroupName hybridrptest -Name 0.1.1907.23009
        $machine | Should -Not -Be $null
        $machine.Location | Should -MatchExactly "eastus2euap"
    }
    
}
