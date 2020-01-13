$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsDrive.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsDrive' {

    . $PSScriptRoot\StorageCommon.ps1

    BeforeEach {

        function ValidateDrive {
            param(
                [Parameter(Mandatory = $true)]
                $Volume
            )

            $Drive          | Should Not Be $null

            # Resource
            $Drive.Id       | Should Not Be $null
            $Drive.Location | Should Not Be $null
            $Drive.Name     | Should Not Be $null
            $Drive.Type     | Should Not Be $null

            # Drive
            $Drive.StorageNode        | Should Not Be $null
            $Drive.SerialNumber       | Should Not Be $null
            $Drive.HealthStatus       | Should Not Be $null
            $Drive.OperationalStatus  | Should Not Be $null
            $Drive.Usage              | Should Not Be $null
            $Drive.PhysicalLocation   | Should Not Be $null
            $Drive.Model              | Should Not Be $null
            $Drive.FirmwareVersion    | Should Not Be $null
            $Drive.IsIndicationEnabled| Should Not Be $null
            $Drive.Manufacturer       | Should Not Be $null
            $Drive.StoragePool        | Should Not Be $null
            $Drive.MediaType          | Should Not Be $null
            $Drive.CapacityGB         | Should Not Be $null
            $Drive.Description        | Should Not Be $null
            $Drive.Action             | Should Not Be $null
        }

        function AssertDrivesAreSame {
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

                # Drive
                $Found.StorageNode        | Should Be $Expected.StorageNode
                $Found.SerialNumber       | Should Be $Expected.SerialNumber
                $Found.HealthStatus       | Should Be $Expected.HealthStatus
                $Found.OperationalStatus  | Should Be $Expected.OperationalStatus
                $Found.Usage              | Should Be $Expected.Usage
                $Found.PhysicalLocation   | Should Be $Expected.PhysicalLocation
                $Found.Model              | Should Be $Expected.Model
                $Found.FirmwareVersion    | Should Be $Expected.FirmwareVersion
                $Found.IsIndicationEnabled| Should Be $Expected.IsIndicationEnabled
                $Found.Manufacturer       | Should Be $Expected.Manufacturer 
                $Found.StoragePool        | Should Be $Expected.StoragePool
                $Found.MediaType          | Should Be $Expected.MediaType
                $Found.CapacityGB         | Should Be $Expected.CapacityGB
                $Found.Description        | Should Be $Expected.Description
                $Found.Action             | Should Be $Expected.Action

            }
        }
    }

    AfterEach {
        $global:Client = $null
    }

    It "TestListDrives" -Skip:$('TestListDrives' -in $global:SkippedTests) {
        $global:TestName = 'TestListDrives'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($storageSubSystem in $storageSubSystems) {
                $drives = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                $drives | Should Not Be $null
                foreach ($drive in $drives) {
                    ValidateDrive $drive
                }
            }
        }
    }

    It "TestGetDrive" -Skip:$('TestGetDrive' -in $global:SkippedTests) {
        $global:TestName = 'TestGetDrive'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($storageSubSystem in $storageSubSystems) {
                $drives = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                foreach ($drive in $drives) {
                    $retrieved = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Name $drive.Name
                    AssertDrivesAreSame -Expected $drive -Found $retrieved
                    break
                }
                break
            }
            break
        }
    }

    It "TestGetAllDrives" -Skip:$('TestGetAllDrives' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllDrives'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($storageSubSystem in $storageSubSystems) {
                $drives = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                foreach ($drive in $drives) {
                    $retrieved = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Name $drive.Name
                    AssertDrivesAreSame -Expected $drive -Found $retrieved
                }
            }
        }
    }

    It "TestGetInvaildDrive" -Skip:$('TestGetInvaildDrive' -in $global:SkippedTests) {
        $global:TestName = 'TestGetInvaildDrive'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($storageSubSystem in $storageSubSystems) {
                $invaildDriveName = "invailddrivename"
                $retrieved = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Name $invaildDriveName
                $retrieved | Should Be $null
                break
            }
            break
        }
    }

    It "TestGetDriveByInputObject" -Skip:$('TestGetDriveByInputObject' -in $global:SkippedTests) {
        $global:TestName = 'TestGetDriveByInputObject'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $storageSubSystems = Get-AzsStorageSubSystem -ScaleUnit $scaleUnit.Name
            foreach ($storageSubSystem in $storageSubSystems) {
                $drive = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Top 1
                $retrieved = Get-AzsDrive -InputObject $drive
                AssertDrivesAreSame -Expected $drive -Found $retrieved
            }
        }
    }
}
