if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnOriginGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnOriginGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnOriginGroup' {
    It 'CreateExpanded' {
        $subId = $env.SubscriptionId
        $endpointName = 'e-clipstest-og01'
        $location = "westus"
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        }
        $originId = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName/origins/$($origin.Name)"
        $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET"
        $originGroup = @{
            Name = "originGroup1"
            healthProbeSetting = $healthProbeParametersObject
            Origin = @(@{ Id = $originId })
        }
        $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Cdn/profiles/$($env.ClassicCdnProfileName)/endpoints/$endpointName/origingroups/$($originGroup.Name)"

        Write-Host -ForegroundColor Green "Create endpoint: $endpointName"
        New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location `
            -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup | Out-Null

        # New
        Write-Host -ForegroundColor Green "New-AzCdnOriginGroup: originGroup2"
        $healthProbe2 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 120 -ProbePath "/check-health.aspx" -ProbeProtocol "Http" -ProbeRequestType "HEAD"
        $createdOG = New-AzCdnOriginGroup -EndpointName $endpointName -Name "originGroup2" -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HealthProbeSetting $healthProbe2 -Origin @(@{ Id = $originId })
        $createdOG.Name | Should -Be "originGroup2"
        $createdOG.HealthProbeSetting.ProbeIntervalInSecond | Should -Be 120
        $createdOG.HealthProbeSetting.ProbePath | Should -Be "/check-health.aspx"
        $createdOG.HealthProbeSetting.ProbeProtocol | Should -Be "Http"
        $createdOG.HealthProbeSetting.ProbeRequestType | Should -Be "HEAD"

        # Get - List
        Write-Host -ForegroundColor Green "Get-AzCdnOriginGroup - List"
        $originGroups = Get-AzCdnOriginGroup -EndpointName $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $originGroups.Count | Should -BeGreaterOrEqual 2

        # Get - by name
        Write-Host -ForegroundColor Green "Get-AzCdnOriginGroup - by name"
        $getOG = Get-AzCdnOriginGroup -Name "originGroup1" -EndpointName $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $getOG.Name | Should -Be "originGroup1"

        # Get - ViaIdentity
        Write-Host -ForegroundColor Green "Get-AzCdnOriginGroup - ViaIdentity"
        $getOG2 = Get-AzCdnOriginGroup -InputObject $getOG
        $getOG2.Name | Should -Be "originGroup1"

        # Update
        Write-Host -ForegroundColor Green "Update-AzCdnOriginGroup"
        $healthProbe3 = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 60 -ProbePath "/updated.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET"
        Update-AzCdnOriginGroup -EndpointName $endpointName -Name "originGroup2" -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HealthProbeSetting $healthProbe3 -Origin @(@{ Id = $originId })
        $updatedOG = Get-AzCdnOriginGroup -Name "originGroup2" -EndpointName $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $updatedOG.HealthProbeSetting.ProbeIntervalInSecond | Should -Be 60
        $updatedOG.HealthProbeSetting.ProbePath | Should -Be "/updated.aspx"

        # Remove
        Write-Host -ForegroundColor Green "Remove-AzCdnOriginGroup: originGroup2"
        Remove-AzCdnOriginGroup -EndpointName $endpointName -Name "originGroup2" -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }
}
