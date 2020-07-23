$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConnectedMachine.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzConnectedMachine' {
       
    It 'Remove a connected machine by name' {        
        $mahineName = "0.1.1907.16005"
        Remove-AzConnectedMachine -Name $mahineName -ResourceGroupName hybridrptest -SubscriptionId b5e4748c-f69a-467c-8749-e2f9c8cd3db0 
        {Get-AzConnectedMachine -Name $mahineName -ResourceGroupName hybridrptest -SubscriptionId b5e4748c-f69a-467c-8749-e2f9c8cd3db0 } | Should -Throw        
    }

    It 'Remove a connected machine by Input Object' {
        $machineName = "0.1.1907.16006"
        $machine = Get-AzConnectedMachine -Name $machineName -ResourceGroupName hybridrptest -SubscriptionId b5e4748c-f69a-467c-8749-e2f9c8cd3db0
        Remove-AzConnectedMachine -InputObject $machine
        {Get-AzConnectedMachine -Name $machineName -ResourceGroupName hybridrptest -SubscriptionId b5e4748c-f69a-467c-8749-e2f9c8cd3db0 } | Should -Throw        
    }

    It 'Remove a connected machine using pipelines ' {
        $machineName = "0.1.1907.17001"        
        Get-AzConnectedMachine -Name $machineName -ResourceGroupName hybridrptest -SubscriptionId b5e4748c-f69a-467c-8749-e2f9c8cd3db0 | Remove-AzConnectedMachine
        {Get-AzConnectedMachine -Name $machineName -ResourceGroupName hybridrptest -SubscriptionId b5e4748c-f69a-467c-8749-e2f9c8cd3db0 } | Should -Throw        
   }

}
