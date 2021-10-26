if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLabServicesLab'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLabServicesLab.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)
Describe 'Get-AzLabServicesLab' {
    It 'List' {
         Get-AzLabServicesLab | Should -Not -BeNullOrEmpty
    }
    
    It 'List with Resource Group' {
        Get-AzLabServicesLab -ResourceGroupName $ENV:ResourceGroupName | Should -Not -BeNullOrEmpty
    }

   It 'Get' {
        Get-AzLabServicesLab -ResourceGroupName $ENV:ResourceGroupName -Name $ENV:LabName | Select-Object -Property Name | Should -Be "@{Name=$($ENV:LabName)}"
    }

    It 'LabPlan' {
        $plan = Get-AzLabServicesLabPlan -Name $ENV:LabPlanName -ResourceGroupName $ENV:ResourceGroupName
        Get-AzLabServicesLab -LabPlan $plan -Name $ENV:LabName | Select-Object -Property Name | Should -Be "@{Name=$($ENV:LabName)}"
    }
    
    It 'ResourceId' -skip {        
        Get-AzLabServicesLab -ResourceId "/subscriptions/$($ENV:SubscriptionId)/resourceGroups/$($ENV:ResourceGroupName)/providers/Microsoft.LabServices/labs/$($ENV:LabName)" | Select-Object -Property Name | Should -Be "@{Name=$($ENV:LabName)}"
    }

    It 'Name with wildcard' {
        Get-AzLabServicesLab -ResourceGroupName $ENV:ResourceGroupName -Name $ENV:LabNameLike | Select-Object -Property Name | Should -Be "@{Name=$($ENV:LabName)}"
    }
}
