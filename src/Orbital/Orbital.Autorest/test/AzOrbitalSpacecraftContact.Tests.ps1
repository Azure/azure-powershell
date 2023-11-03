if(($null -eq $TestName) -or ($TestName -contains 'AzOrbitalSpacecraftContact'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzOrbitalSpacecraftContact.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzOrbitalSpacecraftContact' {
    It 'CreateExpanded' {
        {
            $dateS = Get-Date -Day 10 -Hour 20 -Minute 45 -Second 21
            $dateE = Get-Date -Day 10 -Hour 20 -Minute 53 -Second 54

            $config = New-AzOrbitalSpacecraftContact -Name $env.spacecraftContact -ResourceGroupName $env.resourceGroup -SpacecraftName $env.spacecraftNameSweden -ContactProfileId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Orbital/contactProfiles/$($env.contactProfileSweden)" -GroundStationName $env.groundStationName -ReservationStartTime $dateS -ReservationEndTime $dateE
            $config.Name | Should -Be $env.spacecraftContact
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzOrbitalSpacecraftContact -ResourceGroupName $env.resourceGroup -SpacecraftName $env.spacecraftNameSweden
            $config.Count | Should -BeGreaterThan 0
            } | Should -Not -Throw
    }
    It 'Get' {
        {
            $config = Get-AzOrbitalSpacecraftContact -Name $env.spacecraftContact -ResourceGroupName $env.resourceGroup -SpacecraftName $env.spacecraftNameSweden
            $config.Name | Should -Be $env.spacecraftContact
        } | Should -Not -Throw
    }

    It 'AzOrbitalAvailableSpacecraftContact-ListExpanded' {
        {
            $dateS = Get-Date -Day 10
            $dateE = Get-Date -Day 11

            $config = Get-AzOrbitalAvailableSpacecraftContact -Name $env.spacecraftNameSweden -ResourceGroupName $env.resourceGroup -EndTime $dateE -StartTime $dateS -GroundStationName $env.groundStationName -ContactProfileId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Orbital/contactProfiles/$($env.contactProfileSweden)"
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzOrbitalSpacecraftContact -Name $env.spacecraftContact -ResourceGroupName $env.resourceGroup -SpacecraftName $env.spacecraftNameSweden
        } | Should -Not -Throw
    }
}
