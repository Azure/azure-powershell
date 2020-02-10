$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsRPHealth.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe "AzsServiceHealths" -Tags @('AzsServiceHealth', 'InfrastructureInsightsAdmin') {

    . $PSScriptRoot\Common.ps1
        
    it "TestListServiceHealths" -Skip:$('TestListServiceHealths' -in $global:SkippedTests) {
        $global:TestName = 'TestListServiceHealths'


        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        foreach ($RegionHealth in $RegionHealths) {
            $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
            foreach ($serviceHealth in $ServiceHealths) {
                ValidateAzsServiceHealth -ServiceHealth $serviceHealth
            }
        }
    }

    it "TestGetServiceHealth" -Skip:$('TestGetServiceHealth' -in $global:SkippedTests) {
        $global:TestName = 'TestGetServiceHealth'

        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        foreach ($RegionHealth in $RegionHealths) {
            $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
            foreach ($serviceHealth in $ServiceHealths) {
                $retrieved = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceHealth  $serviceHealth.RegistrationId
                AssertAzsServiceHealthsAreSame -Expected $serviceHealth -Found $retrieved
                break
            }
            break
        }
    }

    it "TestGetAllServiceHealths" -Skip:$('TestGetAllServiceHealths' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllServiceHealths'

        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        foreach ($RegionHealth in $RegionHealths) {
            $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
            foreach ($serviceHealth in $ServiceHealths) {
                $retrieved = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceHealth  $serviceHealth.RegistrationId
                AssertAzsServiceHealthsAreSame -Expected $serviceHealth -Found $retrieved
            }
        }
    }



    it "TestGetAllServiceHealths" -Skip:$('TestGetAllServiceHealths' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllServiceHealths'

        $RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
        foreach ($RegionHealth in $RegionHealths) {
            $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
            foreach ($serviceHealth in $ServiceHealths) {
                $retrieved = $serviceHealth | Get-AzsRPHealth
                AssertAzsServiceHealthsAreSame -Expected $serviceHealth -Found $retrieved
            }
        }
    }
}