if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnOriginGroup' {
    It 'CreateExpanded' {
        $originGroupName = 'org-pstest060'

        $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" `
            -ProbeProtocol "Https" -ProbeRequestType "GET"
        $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
            -SampleSize 5 -SuccessfulSamplesRequired 4

        # New
        Write-Host -ForegroundColor Green "New AzFrontDoorCdnOriginGroup: $($originGroupName)"
        New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting

        # Get - List
        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnOriginGroup - List"
        $originGroups = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName
        $originGroups.Count | Should -BeGreaterOrEqual 1

        # Get - by name
        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnOriginGroup - by name"
        $originGroup = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        $originGroup.Name | Should -Be $originGroupName

        # Get - ViaIdentity
        Write-Host -ForegroundColor Green "Get AzFrontDoorCdnOriginGroup - ViaIdentity"
        $originGroup2 = Get-AzFrontDoorCdnOriginGroup -InputObject $originGroup
        $originGroup2.Name | Should -Be $originGroupName

        # Update
        Write-Host -ForegroundColor Green "Update AzFrontDoorCdnOriginGroup"
        $updateLoadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
            -SampleSize 5 -SuccessfulSamplesRequired 3
        Update-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName `
            -LoadBalancingSetting $updateLoadBalancingSetting
        $updatedOg = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        $updatedOg.LoadBalancingSetting.SuccessfulSamplesRequired | Should -Be 3

        # Update - ViaIdentity
        Write-Host -ForegroundColor Green "Update AzFrontDoorCdnOriginGroup - ViaIdentity"
        $ogObject = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        $revertLoadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
            -SampleSize 5 -SuccessfulSamplesRequired 4
        Update-AzFrontDoorCdnOriginGroup -LoadBalancingSetting $revertLoadBalancingSetting -InputObject $ogObject
        $updatedOg2 = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
        $updatedOg2.LoadBalancingSetting.SuccessfulSamplesRequired | Should -Be 4

        # Remove
        Write-Host -ForegroundColor Green "Remove AzFrontDoorCdnOriginGroup: $($originGroupName)"
        Remove-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName
    }
}
