$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsLocation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Location' {

    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateLocation {
            param(
                [Parameter(Mandatory = $true)]
                $Location
            )
            # Overall
            $Location               | Should Not Be $null
            # Resource
            $Location.Id            | Should Not Be $null
            $Location.Name          | Should Not Be $null
            # Location
            $Location.DisplayName   | Should Not Be $null
            $Location.Latitude      | Should Not Be $null
            $Location.Longitude     | Should Not Be $null
        }

        function AssertLocationsSame {
            param(
                [Parameter(Mandatory = $true)]
                $Expected,
                [Parameter(Mandatory = $true)]
                $Found
            )
            if ($Expected -eq $null) {
                $Found | Should Be $null
            }
            else {
                $Found                  | Should Not Be $null
                # Resource
                $Found.Id               | Should Be $Expected.Id
                $Found.Name             | Should Be $Expected.Name
                # Location
                $Found.DisplayName      | Should Be $Expected.DisplayName
                $Found.Latitude         | Should Be $Expected.Latitude
                $Found.Longitude        | Should Be $Expected.Longitude
            }
        }
    }

    AfterEach {
        $global:Client = $null
    }

    it "TestListLocations" -Skip:$('TestListLocations' -in $global:SkippedTests) {
        $global:TestName = 'TestListLocations'
        $allLocations = Get-AzsLocation
        $global:ResourceGroupNames = New-Object  -TypeName System.Collections.Generic.HashSet[System.String]
        foreach ($Location in $allLocations) {
            ValidateLocation $location
        }
    }

    it "TestGetAllLocations" -Skip:$('TestGetAllLocations' -in $global:SkippedTests) {
        $global:TestName = "TestGetAllLocations"
        $allLocations = Get-AzsLocation
        foreach ($Location in $allLocations) {
            $location2 = Get-AzsLocation -Name $location.Name
            AssertLocationsSame $location $location2
        }
    }

    it "TestGetLocation" -Skip:$('TestGetLocation' -in $global:SkippedTests) {
        $global:TestName = 'TestGetLocation'
        $Location = (Get-AzsLocation)[0]
        $Location | Should Not Be $null
        $Location2 = Get-AzsLocation -Name $Location.Name
        AssertLocationsSame $Location $Location2
    }

    It 'GetViaIdentity' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
