$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzSpringCloud' {
    It 'List' {
        $springList = Get-AzSpringCloud
        $springList.Count | Should -BeGreaterOrEqual 1
    }

    It 'List1' {
        $springList = Get-AzSpringCloud -ResourceGroupName $env.resourceGroup
        $springList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' { 
        $spring = Get-AzSpringCloud -ResourceGroupName $env.resourceGroup -Name $env.springName00
        $spring.Name | Should -Be $env.springName00
    }

    It 'GetViaIdentity' {
        $spring = Get-AzSpringCloud -ResourceGroupName $env.resourceGroup -Name $env.springName00
        $springNew = Get-AzSpringCloud -InputObject $spring
        $springNew.Name | Should -Be $env.springName00
    }
}
