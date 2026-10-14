$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdStartMenuItem.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdStartMenuItem' {
    It 'List' {
        try{
            $startMenuItems = Get-AzWvdStartMenuItem -SubscriptionId $env.SubscriptionId `
                                        -ResourceGroupName $env.ResourceGroupPersistent `
                                        -ApplicationGroupName $env.PersistentDesktopAppGroup

            $taskManager = $startMenuItems | Where-Object -Property Name -Match 'Task Manager'
                $taskManager[0].Name | Should -Match 'Task Manager$'
                $taskManager[0].FilePath | Should -Be 'C:\Windows\system32\taskmgr.exe'
                $taskManager[0].IconPath | Should -Be 'C:\Windows\system32\Taskmgr.exe'
        }
        finally{
        }
    }
}
