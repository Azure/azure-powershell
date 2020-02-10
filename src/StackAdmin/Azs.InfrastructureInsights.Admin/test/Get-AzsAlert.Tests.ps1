$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsAlert.Recording.json'
$currentPath = $PSScriptRoot

while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe "Alerts" -Tags @('Alert', 'InfrastructureInsightsAdmin') {

    . $PSScriptRoot\Common.ps1

    it "TestListAlerts" -Skip:$('TestListAlerts' -in $global:SkippedTests) {

        $global:TestName = 'TestListAlerts'

        $Alerts = Get-AzsAlert -ResourceGroupName $global:ResourceGroupName -Location $global:Location

        foreach ($Alert in $Alerts) {
            ValidateAlert -Alert $Alert
        }
    }

    it "TestGetAlert" -Skip:$('TestGetAlert' -in $global:SkippedTests) {

        $global:TestName = 'TestGetAlert'

        $Regions = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName -Location $global:Location

        foreach ($Region in $Regions) {

            $Alerts = Get-AzsAlert -ResourceGroupName $global:ResourceGroupName -Location $Region.Name

            foreach ($Alert in $Alerts) {

                $retrieved = Get-AzsAlert -Location $Region.Name -Name $Alert.AlertId
                AssertAlertsAreSame -Expected $Alert -Found $retrieved
                return
            }
        }
    }

    it "TestGetAllAlerts" -Skip:$('TestGetAllAlerts' -in $global:SkippedTests) {

        $global:TestName = 'TestGetAllAlerts'

        $Regions = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName -Location $global:Location

        foreach ($Region in $Regions) {

            $Alerts = Get-AzsAlert -ResourceGroupName $global:ResourceGroupName -Location $Region.Name

            foreach ($Alert in $Alerts) {
                $retrieved = Get-AzsAlert -Location $Region.Name -Name $Alert.AlertId

                AssertAlertsAreSame -Expected $Alert -Found $retrieved
            }
        }
    }

    it "TestGetAllAlerts" -Skip:$('TestGetAllAlerts' -in $global:SkippedTests) {

        $global:TestName = 'TestGetAllAlerts'
             
        $Regions = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName -Location $global:Location

        foreach ($Region in $Regions) {

            $Alerts = Get-AzsAlert -ResourceGroupName $global:ResourceGroupName -Location $Region.Name

            foreach ($Alert in $Alerts) {
                $retrieved = $Alert | Get-AzsAlert
                AssertAlertsAreSame -Expected $Alert -Found $retrieved

            }
        }
    }
}