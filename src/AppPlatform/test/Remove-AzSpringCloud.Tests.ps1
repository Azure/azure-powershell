$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSpringCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzSpringCloud' {
    It 'Delete' {
        New-AzSpringCloud -ResourceGroupName $env.resourceGroup -Name $env.springName02 -Location $env.location2
        Remove-AzSpringCloud -ResourceGroupName $env.resourceGroup -Name $env.springName02
        $springList = Get-AzSpringCloud -ResourceGroupName $env.resourceGroup
        $springList.Name| Should -Not -Contain $env.springName02
    }

    It 'DeleteViaIdentity' {
        $spring = New-AzSpringCloud -ResourceGroupName $env.resourceGroup -Name $env.springName03 -Location $env.location2
        Remove-AzSpringCloud -InputObject $spring
        $springList = Get-AzSpringCloud -ResourceGroupName $env.resourceGroup
        $springList.Name| Should -Not -Contain $env.springName03
    }
}
