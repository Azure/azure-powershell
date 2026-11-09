if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzResiliencyUsagePlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzResiliencyUsagePlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzResiliencyUsagePlan' {
    BeforeAll {
        $planParameters = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName }
    }

    It 'Delete' {
        $name = "$($env.usagePlanName)-rm1"
        $null = New-AzResiliencyUsagePlan @planParameters -Name $name -Location global -PlanType Standard
        Remove-AzResiliencyUsagePlan @planParameters -Name $name -PassThru | Should -BeTrue
        @(Get-AzResiliencyUsagePlan @planParameters).Name | Should -Not -Contain $name
    }

    It 'DeleteViaIdentity' {
        $name = "$($env.usagePlanName)-rm2"
        $plan = New-AzResiliencyUsagePlan @planParameters -Name $name -Location global -PlanType Standard
        Remove-AzResiliencyUsagePlan -InputObject $plan -PassThru | Should -BeTrue
        @(Get-AzResiliencyUsagePlan @planParameters).Name | Should -Not -Contain $name
    }
}
