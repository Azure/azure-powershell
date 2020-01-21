$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsAcquiredPlan.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AcquiredPlan' {

    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidatePlanAcquisition {
            param(
                [Parameter(Mandatory = $true)]
                $PlanAcquisition
            )
            # Overall
            $PlanAcquisition                            | Should Not Be $null
            # Resource
            $PlanAcquisition.Id                         | Should Not Be $null
            # PlanAcquisition
            $PlanAcquisition.AcquisitionId              | Should Not Be $null
            $PlanAcquisition.AcquisitionTime            | Should Not Be $null
            $PlanAcquisition.PlanId                     | Should Not Be $null
            $PlanAcquisition.ProvisioningState          | Should Not Be $null
        }

        function AssertPlanAcquisitionsSame {
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
                $Found                            | Should Not Be $null
                # Resource
                $Found.Id                         | Should Be $Expected.Id
                # DelegatedProvider
                $Found.AcquisitionId              | Should Be $Found.AcquisitionId
                $Found.AcquisitionTime            | Should Be $Found.AcquisitionTime
                $Found.ExternalReferenceId        | Should Be $Found.ExternalReferenceId
                $Found.PlanId                     | Should Be $Found.PlanId
                $Found.ProvisioningState          | Should Be $Found.ProvisioningState
            }
        }
    }

    AfterEach {
        $global:Client = $null
    }

    It 'TestListAcquiredPlans' -Skip:$('TestListAcquiredPlans' -in $global:SkippedTests) {
        $global:TestName = 'TestListAcquiredPlans'
        $plans = Get-AzsSubscriptionPlan -TargetSubscriptionId $global:TargetSubscriptionId
        foreach ($plan in $plans) {
            ValidatePlanAcquisition $plan
        }
    }

    It 'TestGetAcquiredPlan' -Skip:$('TestGetAcquiredPlan' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAcquiredPlan'
        $plans = Get-AzsSubscriptionPlan -TargetSubscriptionId $global:subscriptionId
        foreach ($plan in $plans) {
            $plan2 = Get-AzsSubscriptionPlan -TargetSubscriptionId $global:subscriptionId -AcquisitionId $plan.AcquisitionId
            AssertPlanAcquisitionsSame $plan $plan2
        }
    }

    it "TestCreateThenDeleteAcquiredPlan" -Skip:$('TestCreateThenDeleteAcquiredPlan' -in $global:SkippedTests) {
        $global:TestName = "TestCreateThenDeleteAcquiredPlan"
        $plans = Get-AzsPlan
        $new = New-AzsSubscriptionPlan -AcquisitionId $global:acquisitionId -PlanId $plans[0].Id -TargetSubscriptionId $global:TargetSubscriptionId
        ValidatePlanAcquisition $new
        Remove-AzsSubscriptionPlan -PlanAcquisitionId $global:acquisitionId -TargetSubscriptionId $global:TargetSubscriptionId
        { Get-AzsSubscriptionPlan -AcquisitionId $global:acquisitionId -TargetSubscriptionId $global:TargetSubscriptionId -ErrorAction Stop } | Should Throw
    }

    It 'GetViaIdentity' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
