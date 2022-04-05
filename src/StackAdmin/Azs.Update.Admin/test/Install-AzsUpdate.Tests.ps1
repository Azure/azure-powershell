$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Install-AzsUpdate.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Install-AzsUpdate' {
    It 'TestInstallAzsUpdate' -skip:$('TestInstallAzsUpdate' -in $global:SkippedTests) {
        $global:TestName = 'TestInstallAzsUpdate'
        #$updates = Get-AzsUpdate -ResourceGroupName $global:ResourceGroupName -Location $Location | Where-Object -Property State -in "PreparationFailed","Ready","ReadyToInstall"
        $updates = Get-AzsUpdate | Where-Object -Property State -in "PreparationFailed","Ready","ReadyToInstall","HealthCheckFailed","DownloadFailed"
        if($updates -ne $null){
            Install-AzsUpdate -Name $updates.Name
            $updaterun = Get-AzsUpdateRun -UpdateName $updates.Name
            $updaterun | Should Not Be $null 
        }
    }
}
