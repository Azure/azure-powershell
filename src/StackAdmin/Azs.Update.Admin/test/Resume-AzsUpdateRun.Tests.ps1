$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Resume-AzsUpdateRun.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Resume-AzsUpdateRun' {
    It 'TestResumeAzsUpdateRun' -skip:$('TestResumeAzsUpdateRun' -in $global:SkippedTests) {
        $global:TestName = 'TestResumeAzsUpdateRun'
        $updates = Get-AzsUpdate | Where-Object -Property State -in "PreparationFailed","HealthCheckFailed","InstallationFailed"
        if($updates -ne $null){
            $oldupdaterun = Get-AzsUpdateRun -UpdateName $updates[0].Name
            Resume-AzsUpdateRun -UpdateName $updates[0].Name -Name $oldupdaterun.Name
            $updaterun = Get-AzsUpdateRun -UpdateName $updates[0].Name
            $updaterun | Should Not Be $null
        }
    }
}
