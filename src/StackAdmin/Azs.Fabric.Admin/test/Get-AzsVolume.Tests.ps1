$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsVolume.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsVolume' {

    . $PSScriptRoot\StorageCommon.ps1

    BeforeEach {

        function ValidateVolume {
            param(
                [Parameter(Mandatory = $true)]
                $Volume
            )

            $Volume          | Should Not Be $null

            # Resource
            $Volume.Id       | Should Not Be $null
            $Volume.Location | Should Not Be $null
            $Volume.Name     | Should Not Be $null
            $Volume.Type     | Should Not Be $null

            # Volume
            $Volume.TotalCapacityGB      | Should Not Be $null
            $Volume.RemainingCapacityGB  | Should Not Be $null
            $Volume.HealthStatus         | Should Not Be $null
            $Volume.OperationalStatus    | Should Not Be $null
            $Volume.RepairStatus         | Should Not Be $null
            $Volume.Description          | Should Not Be $null
            $Volume.Action               | Should Not Be $null
            $Volume.VolumeLabel          | Should Not Be $null
        }

        function AssertVolumesAreSame {
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

                # Volume
                $Found.TotalCapacityGB      | Should Be $Expected.TotalCapacityGB
                $Found.RemainingCapacityGB  | Should Be $Expected.RemainingCapacityGB
                $Found.HealthStatus         | Should Be $Expected.HealthStatus
                $Found.OperationalStatus    | Should Be $Expected.OperationalStatus
                $Found.RepairStatus         | Should Be $Expected.RepairStatus
                $Found.Description          | Should Be $Expected.Description
                $Found.Action               | Should Be $Expected.Action
                $Found.VolumeLabel          | Should Be $Expected.VolumeLabel

            }
        }
    }

    AfterEach {
        $global:Client = $null
    }

    It "TestListVolumes" -Skip:$('TestListVolumes' -in $global:SkippedTests) {
        $global:TestName = 'TestListVolumes'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($storageSubSystem in $storageSubSystems) {
                $volumes = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                $volumes | Should Not Be $null
                foreach ($volume in $volumes) {
                    ValidateVolume $volume
                }
            }
        }
    }

    It "TestGetVolume" -Skip:$('TestGetVolume' -in $global:SkippedTests) {
        $global:TestName = 'TestGetVolume'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($storageSubSystem in $storageSubSystems) {
                $volumes = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                foreach ($volume in $volumes) {
                    $retrieved = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Name $volume.Name
                    AssertVolumesAreSame -Expected $volume -Found $retrieved
                    break
                }
                break
            }
            break
        }
    }

    It "TestGetAllVolumes" -Skip:$('TestGetAllVolumes' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllVolumes'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($storageSubSystem in $storageSubSystems) {
                $volumes = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                foreach ($volume in $volumes) {
                    $retrieved = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Name $volume.Name
                    AssertVolumesAreSame -Expected $volume -Found $retrieved
                }
            }
        }
    }

    It "TestGetInvaildVolume" -Skip:$('TestGetInvaildVolume' -in $global:SkippedTests) {
        $global:TestName = 'TestGetInvaildVolume'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($storageSubSystem in $storageSubSystems) {
                $invaildVolumeName = "invaildvolumename"
                $retrieved = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Name $invaildVolumeName
                $retrieved | Should Be $null
                break
            }
            break
        }
    }

    It "TestGetVolumeByInputObject" -Skip:$('TestGetVolumeByInputObject' -in $global:SkippedTests) {
        $global:TestName = 'TestGetVolumeByInputObject'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($storageSubSystem in $storageSubSystems) {
                $volume = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Top 1
                $retrieved = Get-AzsVolume -InputObject $volume
                AssertVolumesAreSame -Expected $volume -Found $retrieved
            }
        }
    }
}
