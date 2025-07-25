if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserEnvironmentType')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserEnvironmentType.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserEnvironmentType' {
    It 'List'  {
        $listOfEnvTypes = Get-AzDevCenterUserEnvironmentType -Endpoint $env.endpoint -ProjectName $env.projectName
        $listOfEnvTypes.Count | Should -Be 1

        if ($Record -or $Live) {
            $listOfEnvTypes = Get-AzDevCenterUserEnvironmentType -DevCenterName $env.devCenterName -ProjectName $env.projectName
            $listOfEnvTypes.Count | Should -Be 1
        }
    
    }
}
