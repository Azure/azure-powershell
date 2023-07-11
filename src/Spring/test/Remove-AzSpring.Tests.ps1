if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSpring'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSpring.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Remove-AzSpring' {
    It 'Delete' {
        Remove-AzSpring -ResourceGroupName $env.resourceGroup -Name $env.springName01
        $springList = Get-AzSpring -ResourceGroupName $env.resourceGroup
        $springList.Name| Should -Not -Contain $env.springName02
    }

    It 'DeleteViaIdentity' {
        $spring = New-AzSpring -ResourceGroupName $env.resourceGroup -Name $env.springName02 -Location $env.location2
        Remove-AzSpring -InputObject $spring
        $springList = Get-AzSpring -ResourceGroupName $env.resourceGroup
        $springList.Name| Should -Not -Contain $env.springName02
    }
}
