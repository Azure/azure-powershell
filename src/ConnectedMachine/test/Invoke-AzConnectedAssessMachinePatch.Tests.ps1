$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzConnectedAssessMachinePatch.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzConnectedAssessMachinePatch' {
    It 'Assess' {
        $all = @(Invoke-AzConnectedAssessMachinePatch -Name $env.MachineName -ResourceGroupName $env.ResourceGroupName)
        $all | Should -Not -BeNullOrEmpty
    }

    It 'AssessViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
