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

InModuleScope Azs.InfrastructureInsights.Admin {

    Describe "Alerts" -Tags @('Alert', 'InfrastructureInsightsAdmin') {

        BeforeEach {

            function ValidateAlert {

                param(

                    [Parameter(Mandatory = $true)]

                    $Alert

                )

                $Alert          | Should Not Be $null

                # Resource
                $Alert.Id       | Should Not Be $null
                $Alert.Location | Should Not Be $null
                $Alert.Name     | Should Not Be $null
                $Alert.Type     | Should Not Be $null

                # Alert
                $Alert.AlertId                         | Should Not Be $null
                $Alert.AlertProperty                   | Should Not Be $null
                $Alert.CreatedTimestamp                | Should Not Be $null
                $Alert.Description                     | Should Not Be $null
                $Alert.FaultTypeId                     | Should Not Be $null
                $Alert.ImpactedResourceDisplayName     | Should Not Be $null
                $Alert.ImpactedResourceId              | Should Not Be $null
                $Alert.LastUpdatedTimestamp            | Should Not Be $null
                $Alert.Remediation                     | Should Not Be $null
                $Alert.ResourceProviderRegistrationId  | Should Not Be $null
                $Alert.Severity                        | Should Not Be $null
                $Alert.State                           | Should Not Be $null
                $Alert.Title                           | Should Not Be $null
            }

            function AssertAlertsAreSame {
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

                    # Alert
                    $Found.AlertId                         | Should Be $Expected.AlertId

                    if ($Expected.AlertProperties -eq $null) {

                        $Found.AlertProperties             | Should Be $null

                    }

                    else {

                        $Found.AlertProperties             | Should Not Be $null

                        $Found.AlertProperties.Count       | Should Be $Expected.AlertProperties.Count

                    }



                    $Found.ClosedByUserAlias               | Should Be $Expected.ClosedByUserAlias

                    $Found.ClosedTimestamp                 | Should Be $Expected.ClosedTimestamp

                    $Found.CreatedTimestamp                | Should Be $Expected.CreatedTimestamp



                    if ($Expected.Description -eq $null) {

                        $Found.Description                 | Should Be $null

                    }

                    else {

                        $Found.Description                 | Should Not Be $null

                        $Found.Description.Count           | Should Be $Expected.Description.Count

                    }



                    $Found.FaultId                         | Should Be $Expected.FaultId

                    $Found.FaultTypeId                     | Should Be $Expected.FaultTypeId

                    $Found.ImpactedResourceDisplayName     | Should Be $Expected.ImpactedResourceDisplayName

                    $Found.ImpactedResourceId              | Should Be $Expected.ImpactedResourceId

                    $Found.LastUpdatedTimestamp            | Should Be $Expected.LastUpdatedTimestamp



                    if ($Expected.Remediation -eq $null) {

                        $Found.Remediation                 | Should Be $null

                    }

                    else {

                        $Found.Remediation                 | Should Not Be $null

                        $Found.Remediation.Count           | Should Be $Expected.Remediation.Count

                    }



                    $Found.ResourceProviderRegistrationId  | Should Be $Expected.ResourceProviderRegistrationId

                    $Found.ResourceRegistrationId          | Should Be $Expected.ResourceRegistrationId

                    $Found.Severity                        | Should Be $Expected.Severity

                    $Found.State                           | Should Be $Expected.State

                    $Found.Title                           | Should Be $Expected.Title



                }

            }

        }

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
}
