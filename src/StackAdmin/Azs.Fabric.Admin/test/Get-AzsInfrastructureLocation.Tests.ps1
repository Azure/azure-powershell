$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsInfrastructureLocation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsInfrastructureLocation' {

    . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateFabricLocation {
                param(
                    [Parameter(Mandatory = $true)]
                    $FabricLocation
                )

                $FabricLocation          | Should Not Be $null

                # Resource
                $FabricLocation.Id       | Should Not Be $null
                $FabricLocation.Location | Should Not Be $null
                $FabricLocation.Name     | Should Not Be $null
                $FabricLocation.Type     | Should Not Be $null

            }

            function AssertFabricLocationsAreSame {
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
                    $Found.Location         | Should Be $Expected.Location
                    $Found.Name             | Should Be $Expected.Name
                    $Found.Type             | Should Be $Expected.Type

                }
            }
        }

        AfterEach {
            $global:Client = $null
        }

        It "TestListFabricLocations" -Skip:$('TestListFabricLocations' -in $global:SkippedTests) {
            $global:TestName = 'TestListFabricLocations'
            $fabricLocations = Get-AzsInfrastructureLocation -ResourceGroupName $global:ResourceGroupName
            $fabricLocations | Should Not Be $null
            foreach ($fabricLocation in $fabricLocations) {
                ValidateFabricLocation -FabricLocation $fabricLocation
            }
        }

        It "TestGetFabricLocation" -Skip:$('TestGetFabricLocation' -in $global:SkippedTests) {
            $global:TestName = 'TestGetFabricLocation'

            $fabricLocations = Get-AzsInfrastructureLocation -ResourceGroupName $global:ResourceGroupName
            foreach ($fabricLocation in $fabricLocations) {
                $retrieved = Get-AzsInfrastructureLocation -ResourceGroupName $global:ResourceGroupName
                AssertFabricLocationsAreSame -Expected $fabricLocation -Found $retrieved
                break
            }
        }

        It "TestGetAllFabricLocations" -Skip:$('TestGetAllFabricLocations' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllFabricLocations'

            $fabricLocations = Get-AzsInfrastructureLocation -ResourceGroupName $global:ResourceGroupName
            foreach ($fabricLocation in $fabricLocations) {
                $retrieved = Get-AzsInfrastructureLocation -ResourceGroupName $global:ResourceGroupName
                AssertFabricLocationsAreSame -Expected $fabricLocation -Found $retrieved
            }
        }
}
