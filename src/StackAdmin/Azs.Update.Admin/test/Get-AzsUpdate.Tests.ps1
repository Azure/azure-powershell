$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsUpdate.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsUpdate' {

    BeforeEach {

        function ValidateScaleUnit {
            param(
                [Parameter(Mandatory = $true)]
                $Update
            )

            $Update          | Should Not Be $null

            # Resource
            $Update.Id       | Should Not Be $null
            $Update.Location | Should Not Be $null
            $Update.Name     | Should Not Be $null
            $Update.Type     | Should Not Be $null

            # update properties
            $Update.AvailabilityType      | Should Not Be $null
            $Update.Description           | Should Not Be $null
            $Update.DisplayName           | Should Not Be $null
            $Update.KbLink                | Should Not Be $null
            $Update.Name                  | Should Not Be $null
            $Update.PackagePath           | Should Not Be $null
            $Update.PackageSizeInMb       | Should Not Be $null
            $Update.PackageType           | Should Not Be $null
            $Update.Publisher             | Should Not Be $null
            $Update.ReleaseLink           | Should Not Be $null
            $Update.State                 | Should Not Be $null
            $Update.Version               | Should Not Be $null

        }
    }

    AfterEach {
        $global:Client = $null
    }

    It 'TestListAzsUpdates' -skip:$('TestListAzsUpdate' -in $global:SkippedTests) {
        $global:TestName = 'TestListAzsUpdate'
        $updates = Get-AzsUpdate -ResourceGroupName $global:ResourceGroupName -Location $Location
        $updates | Should Not Be $null
        foreach ($update in $updates) {
            ValidateScaleUnit -Update $update
        }
    }
}
