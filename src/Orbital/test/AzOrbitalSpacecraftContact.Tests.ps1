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
    # It 'CreateExpanded' {
    #     {
    #         $dateS = Get-Date -Day 22
    #         $dateE = Get-Date -Day 23

    #         $config = New-AzOrbitalSpacecraftContact -Name $env.spacecraftContact -ResourceGroupName $env.resourceGroup -SpacecraftName $env.spacecraftName -ContactProfileId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Orbital/contactProfiles/$($env.contactProfile)" -GroundStationName "WESTUS2_1" -ReservationStartTime $dateS -ReservationEndTime $dateE
    #         $config.Name | Should -Be $env.spacecraftContact
    #     } | Should -Not -Throw
    # }

    It 'Get' {
        {
            $config = Get-AzOrbitalSpacecraftContact -Name $env.spacecraftContact -ResourceGroupName $env.resourceGroup -SpacecraftName $env.spacecraftName
            $config.Name | Should -Be $env.spacecraftContact
        } | Should -Not -Throw
    }

    It 'AzOrbitalAvailableSpacecraftContact-ListExpanded' {
        {
            $dateS = Get-Date -Day 22 -Month 7
            $dateE = Get-Date -Day 23 -Month 7

            $config = Get-AzOrbitalAvailableSpacecraftContact -Name $env.spacecraftName -ResourceGroupName $env.resourceGroup -EndTime $dateE -StartTime $dateS -GroundStationName WESTUS2_1 -ContactProfileId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Orbital/contactProfiles/$($env.contactProfile)"
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzOrbitalSpacecraftContact -Name $env.spacecraftContact -ResourceGroupName $env.resourceGroup -SpacecraftName $env.spacecraftName
        } | Should -Not -Throw
    }
}
