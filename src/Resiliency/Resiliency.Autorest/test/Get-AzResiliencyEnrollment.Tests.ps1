if(($null -eq $TestName) -or ($TestName -contains 'Get-AzResiliencyEnrollment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResiliencyEnrollment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzResiliencyEnrollment' {
    BeforeAll {
        $planParameters = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName }
        $usagePlanIdentity = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName }
    }

    It 'List' {
        $enrollments = @(Get-AzResiliencyEnrollment @planParameters)
        $enrollments.Name | Should -Contain $env.enrollmentName
    }

    It 'GetViaIdentityUsagePlan' {
        $enrollment = Get-AzResiliencyEnrollment -UsagePlanInputObject $usagePlanIdentity -Name $env.enrollmentName
        $enrollment.Name | Should -Be $env.enrollmentName
        $enrollment.ServiceGroupId | Should -Be $env.serviceGroupId
    }

    It 'Get' {
        $enrollment = Get-AzResiliencyEnrollment @planParameters -Name $env.enrollmentName
        $enrollment.Name | Should -Be $env.enrollmentName
        $enrollment.ServiceGroupId | Should -Be $env.serviceGroupId
        $enrollment.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'GetViaIdentity' {
        $identity = $usagePlanIdentity + @{ EnrollmentName = $env.enrollmentName }
        $enrollment = Get-AzResiliencyEnrollment -InputObject $identity
        $enrollment.Name | Should -Be $env.enrollmentName
        $enrollment.ServiceGroupId | Should -Be $env.serviceGroupId
    }
}
