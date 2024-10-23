$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConnectedMachineExtension.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Import-Module "$PSScriptRoot/helper.psm1" -Force

Describe 'New-AzConnectedMachineExtension' {

    It 'Create' {
        $customSplat = @{
            MachineName = $env.MachineName
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.Location
            Name = "networkWatcher"
        }
    
        $customSplat.ExtensionType = "NetworkWatcherAgentWindows"
        $customSplat.Publisher = "Microsoft.Azure.NetworkWatcher"
        $customSplat.TypeHandlerVersion = "1.4.2798.3"
        $customSplat.Settings = @{
            CommandToExecute = "dir"
        }
        $all = (New-AzConnectedMachineExtension @customSplat)
        $all | Should -Not -BeNullOrEmpty
    }
}
