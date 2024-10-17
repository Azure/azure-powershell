if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserEnvironmentLog')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserEnvironmentLog.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterUserEnvironmentLog' {
    It 'Get' {
        if ($Record -or $Live) {
            Get-AzDevCenterUserEnvironmentLog -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10 -OperationId "4d48a4d5-7edc-437d-9bfa-30e9b4328f68"
        }
    }

}
