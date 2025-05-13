if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmAvailabilitySet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmAvailabilitySet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmAvailabilitySet' -Tag 'LiveOnly'{
    It 'CreateExpanded' {
        {
            $result = New-AzScVmmAvailabilitySet -Name $env.AvailabilitySetName -AvailabilitySetName $env.AvailabilitySetName -ResourceGroupName $env.ResourceGroupEnableInvTest -VmmServerName $env.VmmServerName -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }
    
    It 'ListBySubscription - List' {
        {
            $result = Get-AzScVmmAvailabilitySet
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup - List1' {
        {
            $result = Get-AzScVmmAvailabilitySet -ResourceGroupName $env.ResourceGroupEnableInvTest
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Update' {
        $result = Update-AzScVmmAvailabilitySet -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.AvailabilitySetName -Tag @{tag1="value1"}
        $result.ProvisioningState | Should -Be 'Succeeded' 
        $result.Tag['tag1'] | Should -Be 'value1'
    }

    It 'Get' {
        {
            $result = Get-AzScVmmAvailabilitySet -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.AvailabilitySetName
            $result.Name | Should -Be $env.AvailabilitySetName
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzScVmmAvailabilitySet -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.AvailabilitySetName
        } | Should -Not -Throw
    }

    It 'CreateExpandedId' {
        {
            $result = New-AzScVmmAvailabilitySet -Name $env.AvailabilitySetName -AvailabilitySetName $env.AvailabilitySetName -ResourceGroupName $env.ResourceGroupEnableInvTest -VmmServerId $env.VmmServerEnableInvTestId -CustomLocationId $env.CustomLocationEnableInvTest -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzScVmmAvailabilitySet -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.AvailabilitySetName
        } | Should -Not -Throw
    }
}