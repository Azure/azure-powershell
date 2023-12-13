$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Install-AzConnectedMachinePatch.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Install-AzConnectedMachinePatch' {
    It 'InstallExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Install' {
        $all = @(Install-AzConnectedMachinePatch -ResourceGroupName $env.ResourceGroupName -Name 'testmachine' -MaximumDuration 'PT4H' -RebootSetting 'IfRequired' -WindowParameterClassificationsToInclude 'Critical')
        $all | Should -Not -BeNullOrEmpty
    }

    It 'InstallViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InstallViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
