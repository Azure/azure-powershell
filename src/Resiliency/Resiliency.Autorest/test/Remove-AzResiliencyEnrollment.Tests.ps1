if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzResiliencyEnrollment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzResiliencyEnrollment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzResiliencyEnrollment' {
    BeforeAll {
        $planParameters = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName }
        $usagePlanIdentity = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName }
        function New-TestEnrollment([string]$Name) {
            return Invoke-ResiliencyWithRetry { New-AzResiliencyEnrollment @planParameters -Name $Name -ServiceGroupId $env.enrollmentServiceGroupId }
        }
    }

    It 'Delete' {
        $name = "$($env.enrollmentName)-rm1"
        $null = New-TestEnrollment $name
        Remove-AzResiliencyEnrollment @planParameters -Name $name -PassThru | Should -BeTrue
        @(Get-AzResiliencyEnrollment @planParameters).Name | Should -Not -Contain $name
    }

    It 'DeleteViaIdentityUsagePlan' {
        $name = "$($env.enrollmentName)-rm2"
        $null = New-TestEnrollment $name
        Remove-AzResiliencyEnrollment -UsagePlanInputObject $usagePlanIdentity -Name $name -PassThru | Should -BeTrue
        @(Get-AzResiliencyEnrollment @planParameters).Name | Should -Not -Contain $name
    }

    It 'DeleteViaIdentity' {
        $name = "$($env.enrollmentName)-rm3"
        $enrollment = New-TestEnrollment $name
        Remove-AzResiliencyEnrollment -InputObject $enrollment -PassThru | Should -BeTrue
        @(Get-AzResiliencyEnrollment @planParameters).Name | Should -Not -Contain $name
    }
}
