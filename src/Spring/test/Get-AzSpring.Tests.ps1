if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpring'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpring.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Get-AzSpring' {
    It 'List' {
        $springList = Get-AzSpring
        $springList.Count | Should -BeGreaterOrEqual 1
    }

    It 'List1' {
        $springList = Get-AzSpring -ResourceGroupName $env.resourceGroup
        $springList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' { 
        $spring = Get-AzSpring -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
        $spring.Name | Should -Be $env.standardSpringName01
    }

    It 'GetViaIdentity' {
        $spring = Get-AzSpring -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
        $springNew = Get-AzSpring -InputObject $spring
        $springNew.Name | Should -Be $env.standardSpringName01
    }
}
