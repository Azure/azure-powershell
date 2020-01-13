$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsStorageSubSystem.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsStorageSubSystem' {

    . $PSScriptRoot\StorageCommon.ps1

    BeforeEach {

        function ValidateStorageSubSystem {
            param(
                [Parameter(Mandatory = $true)]
                $StorageSubSystem
            )

            $StorageSubSystem          | Should Not Be $null

            # Resource
            $StorageSubSystem.Id       | Should Not Be $null
            $StorageSubSystem.Location | Should Not Be $null
            $StorageSubSystem.Name     | Should Not Be $null
            $StorageSubSystem.Type     | Should Not Be $null

            # Storage Subsystem
            $StorageSubSystem.TotalCapacityGB      | Should Not Be $null
            $StorageSubSystem.RemainingCapacityGB  | Should Not Be $null
            $StorageSubSystem.HealthStatus         | Should Not Be $null
            $StorageSubSystem.OperationalStatus    | Should Not Be $null
            $StorageSubSystem.RebalanceStatus      | Should Not Be $null
        }

        function AssertStorageSubSystemsAreSame {
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

                # Storage System
                $Found.TotalCapacityGB      | Should Be $Expected.TotalCapacityGB
                $Found.RemainingCapacityGB  | Should Be $Expected.RemainingCapacityGB
                $Found.HealthStatus         | Should Be $Expected.HealthStatus
                $Found.OperationalStatus    | Should Be $Expected.OperationalStatus
                $Found.RebalanceStatus      | Should Be $Expected.RebalanceStatus
            }
        }
    }

    AfterEach {
        $global:Client = $null
    }

    It "TestListStorageSubSystems" -Skip:$('TestListStorageSubSystems' -in $global:SkippedTests) {
        $global:TestName = 'TestListStorageSubSystems'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $StorageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            $StorageSubSystems | Should Not Be $null
            foreach ($StorageSubSystem in $StorageSubSystems) {
                ValidateStorageSubSystem -StorageSubSystem $StorageSubSystem
            }
        }
    }

    It "TestGetStorageSubSystem" -Skip:$('TestGetStorageSubSystem' -in $global:SkippedTests) {
        $global:TestName = 'TestGetStorageSubSystem'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $StorageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($StorageSubSystem in $StorageSubSystems) {
                $retrieved = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -Name $StorageSubSystem.Name
                AssertStorageSubSystemsAreSame -Expected $StorageSubSystem -Found $retrieved
                break
            }
            break
        }
    }

    It "TestGetAllStorageSubSystems" -Skip:$('TestGetAllStorageSubSystems' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllStorageSubSystems'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $StorageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name
            foreach ($StorageSubSystem in $StorageSubSystems) {
                $retrieved = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -Name $StorageSubSystem.Name
                AssertStorageSubSystemsAreSame -Expected $StorageSubSystem -Found $retrieved
            }
        }
    }

    It "TestGetInvaildStorageSubSystem" -Skip:$('TestGetInvaildStorageSubSystem' -in $global:SkippedTests) {
        $global:TestName = 'TestGetInvaildStorageSubSystem'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $invaildStorageSubSystemName = "invaildstoragesubsystemname"
            $retrieved = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -Name $invaildStorageSubSystemName
            $retrieved | Should Be $null
            break
        }
    }

    It "TestGetStorageSubSystemByInputObject" -Skip:$('TestGetStorageSubSystemByInputObject' -in $global:SkippedTests) {
        $global:TestName = 'TestGetStorageSubSystemByInputObject'

        $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $global:Location
        foreach ($scaleUnit in $scaleUnits) {
            $StorageSubSystem = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $global:Location -ScaleUnit $scaleUnit.Name -Top 1
            $retrieved = Get-AzsStorageSubSystem -InputObject $StorageSubSystem
            AssertStorageSubSystemsAreSame -Expected $StorageSubSystem -Found $retrieved
        }
    }
}
