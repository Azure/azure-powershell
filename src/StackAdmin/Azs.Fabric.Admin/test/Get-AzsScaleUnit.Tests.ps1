$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsScaleUnit.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsScaleUnit' {
    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateScaleUnit {
            param(
                [Parameter(Mandatory = $true)]
                $ScaleUnit
            )

            $ScaleUnit          | Should Not Be $null

            # Resource
            $ScaleUnit.Id       | Should Not Be $null
            $ScaleUnit.Location | Should Not Be $null
            $ScaleUnit.Name     | Should Not Be $null
            $ScaleUnit.Type     | Should Not Be $null

            # Scale Unit
            $ScaleUnit.LogicalFaultDomain      | Should Not Be $null
            $ScaleUnit.ScaleUnitType           | Should Not Be $null
            $ScaleUnit.State                   | Should Not Be $null
            $ScaleUnit.TotalCapacityCore       | Should Not Be $null
            $ScaleUnit.TotalCapacityMemoryGb   | Should Not Be $null
        }

        function AssertScaleUnitsAreSame {
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

                # Scale Unit
                $Found.LogicalFaultDomain  | Should Be $Expected.LogicalFaultDomain
                $Found.Model               | Should Be $Expected.Model


                if ($Expected.Nodes -eq $null) {
                    $Found.Nodes        | Should be $null
                }
                else {
                    $Found.Nodes        | Should not be $null
                    $Found.Nodes.Count  | Should be $Expected.Nodes.Count
                }

                $Found.ScaleUnitType  | Should Be $Expected.ScaleUnitType
                $Found.State          | Should Be $Expected.State
                $Found.TotalCapacityCores     | Should be $Expected.TotalCapacityCores
                $Found.TotalCapacityMemoryGb  | Should be $Expected.TotalCapacityMemoryGb
            }
        }
    }

    AfterEach {
        $global:Client = $null
    }


    it "TestListScaleUnits" -Skip:$('TestListScaleUnits' -in $global:SkippedTests) {
        $global:TestName = 'TestListScaleUnits'
        $ScaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
        $ScaleUnits | Should Not Be $null
        foreach ($ScaleUnit in $ScaleUnits) {
            ValidateScaleUnit -ScaleUnit $ScaleUnit
        }
    }


    it "TestGetScaleUnit" -Skip:$('TestGetScaleUnit' -in $global:SkippedTests) {
        $global:TestName = 'TestGetScaleUnit'

        $ScaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
        foreach ($ScaleUnit in $ScaleUnits) {
            $retrieved = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $ScaleUnit.Name
            AssertScaleUnitsAreSame -Expected $ScaleUnit -Found $retrieved
            break
        }
    }

    it "TestGetAllScaleUnits" -Skip:$('TestGetAllScaleUnits' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllScaleUnits'

        $ScaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
        foreach ($ScaleUnit in $ScaleUnits) {
            $retrieved = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $ScaleUnit.Name
            AssertScaleUnitsAreSame -Expected $ScaleUnit -Found $retrieved
        }
    }
}