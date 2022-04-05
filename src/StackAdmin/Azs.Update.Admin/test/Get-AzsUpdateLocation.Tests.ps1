$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsUpdateLocation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsUpdateLocation' {

     function ValidateScaleUnit {
            param(
                [Parameter(Mandatory = $true)]
                $UpdateLocation
            )

            $UpdateLocation          | Should Not Be $null

            # Resource
            $UpdateLocation.Id       | Should Not Be $null
            $UpdateLocation.Location | Should Not Be $null
            $UpdateLocation.Name     | Should Not Be $null
            $UpdateLocation.Type     | Should Not Be $null

            # update properties
            $UpdateLocation.CurrentOemVersion      | Should Not Be $null
            $UpdateLocation.CurrentVersion         | Should Not Be $null
            $UpdateLocation.HardwareModel          | Should Not Be $null
            $UpdateLocation.LastChecked            | Should Not Be $null
            $UpdateLocation.OemFamily              | Should Not Be $null
            $UpdateLocation.PackageVersion         | Should Not Be $null
            $UpdateLocation.State                  | Should Not Be $null
    }

    AfterEach {
        $global:Client = $null
    }

    It 'TestGetAzsUpdateLocation' -skip:$('TestGetAzsUpdateLocation' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAzsUpdateLocation'
        $updatelocations = Get-AzsUpdateLocation -ResourceGroupName $global:ResourceGroupName -Location $Location
        $updatelocations | Should Not Be $null
        foreach ($updatelocation in $updatelocations) {
            ValidateScaleUnit -UpdateLocation $updatelocation
        }
    }
}
