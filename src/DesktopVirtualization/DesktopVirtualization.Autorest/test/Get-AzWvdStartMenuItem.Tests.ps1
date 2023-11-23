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

            $paint = $startMenuItems | Where-Object -Property Name -Match 'Paint'
                $paint[0].Name | Should -Be 'alecbUserSessionHP-DAG/Paint'
                $paint[0].FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
                $paint[0].IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
                $paint[0].IconIndex | Should -Be 0

            $paint = $startMenuItems | Where-Object -Property Name -Match 'Snip'
                $paint[0].Name | Should -Be 'alecbUserSessionHP-DAG/Snipping Tool'
                $paint[0].FilePath | Should -Be 'C:\windows\system32\SnippingTool.exe'
                $paint[0].IconPath | Should -Be 'C:\windows\system32\SnippingTool.exe'
                $paint[0].IconIndex | Should -Be 0
        }
        finally{
        }
    }
}
