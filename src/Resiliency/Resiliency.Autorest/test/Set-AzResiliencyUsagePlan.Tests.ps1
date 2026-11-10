if(($null -eq $TestName) -or ($TestName -contains 'Set-AzResiliencyUsagePlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzResiliencyUsagePlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzResiliencyUsagePlan' {
    BeforeAll {
        $planParameters = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; Name = $env.usagePlanName }
        function Assert-SetUsagePlan([object]$Plan) {
            $Plan.Name | Should -Be $env.usagePlanName
            $Plan.Location | Should -Be 'global'
            $Plan.PlanType | Should -Be 'Standard'
            $Plan.ProvisioningState | Should -Be 'Succeeded'
        }
    }

    It 'UpdateExpanded' {
        $plan = Set-AzResiliencyUsagePlan @planParameters -Location global -PlanType Standard -Tag @{ scenario = 'UpdateExpanded' }
        Assert-SetUsagePlan $plan
    }

    It 'Update' {
        $plan = Set-AzResiliencyUsagePlan @planParameters -Resource @{ Location = 'global'; PlanType = 'Standard' }
        Assert-SetUsagePlan $plan
    }

    It 'UpdateViaJsonFilePath' {
        $jsonFilePath = Join-Path $TestDrive 'usagePlan.json'
        @{ location = 'global'; properties = @{ planType = 'Standard' } } | ConvertTo-Json -Depth 5 | Set-Content $jsonFilePath
        $plan = Set-AzResiliencyUsagePlan @planParameters -JsonFilePath $jsonFilePath
        Assert-SetUsagePlan $plan
    }

    It 'UpdateViaJsonString' {
        $json = @{ location = 'global'; properties = @{ planType = 'Standard' } } | ConvertTo-Json -Depth 5
        $plan = Set-AzResiliencyUsagePlan @planParameters -JsonString $json
        Assert-SetUsagePlan $plan
    }
}
