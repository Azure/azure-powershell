$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsRegionHealth.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe "RegionHealths" -Tags @('RegionHealth', 'InfrastructureInsightsAdmin') {

    . $PSScriptRoot\Common.ps1

    it "TestListRegionHealths" -Skip:$('TestListRegionHealths' -in $global:SkippedTests) {
        $global:TestName = 'TestListRegionHealths'

        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        $RegionHealths | Should Not Be $null
        foreach($RegionHealth in $RegionHealths) {
            ValidateRegionHealth -Region $RegionHealth
        }
    }


    it "TestGetRegionHealth" -Skip:$('TestGetRegionHealth' -in $global:SkippedTests) {
        $global:TestName = 'TestGetRegionHealth'

        $RegionHealths = Get-AzsRegionHealth -Location $global:Location  -ResourceGroupName $global:ResourceGroupName
        foreach($RegionHealth in $RegionHealths) {
            $retrieved = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
            AssertRegionHealthsAreSame -Expected $RegionHealth -Found $retrieved
            return
        }
    }

    it "TestGetAllRegionHealths" -Skip:$('TestGetAllRegionHealths' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllRegionHealths'

        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        foreach($RegionHealth in $RegionHealths) {
            $retrieved = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
            AssertRegionHealthsAreSame -Expected $RegionHealth -Found $retrieved
        }
    }

    it "TestGetAllRegionHealths" -Skip:$('TestGetAllRegionHealths' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllRegionHealths'


        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        foreach($RegionHealth in $RegionHealths) {

            $retrieved = $RegionHealth | Get-AzsRegionHealth
            AssertRegionHealthsAreSame -Expected $RegionHealth -Found $retrieved
        }
    }
}