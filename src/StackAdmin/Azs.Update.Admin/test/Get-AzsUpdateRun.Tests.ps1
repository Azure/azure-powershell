$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsUpdateRun.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsUpdateRun' {

     function ValidateScaleUnit {
            param(
                [Parameter(Mandatory = $true)]
                $UpdateRun
            )

            $UpdateRun          | Should Not Be $null

            # Resource
            $UpdateRun.Id       | Should Not Be $null
            $UpdateRun.Location | Should Not Be $null
            $UpdateRun.Name     | Should Not Be $null
            $UpdateRun.Type     | Should Not Be $null

            # update properties
            $UpdateRun.ProgressDescription      | Should Not Be $null
            $UpdateRun.ProgressName             | Should Not Be $null
            $UpdateRun.ProgressStatus           | Should Not Be $null
            $UpdateRun.ProgressStep             | Should Not Be $null
            $UpdateRun.State                    | Should Not Be $null
           
    }

    AfterEach {
        $global:Client = $null
    }

    It 'TestGetAzsUpdateRun' -skip:$('TestGetAzsUpdateRun' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAzsUpdateRun'
        $updates = Get-AzsUpdate -ResourceGroupName $global:ResourceGroupName -Location $Location | Where-Object -Property State -in "PreparationFailed","Preparing","Installing","Installed","InstallationFailed"

        if($updates -ne $null){
            foreach ($update in $updates) {
                $updaterun = Get-AzsUpdateRun -UpdateName $update.Name
                ValidateScaleUnit -UpdateRun $updaterun
            }
        }
    }
}
