if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnOrigin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnOrigin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnOrigin' {
    It 'CreateExpanded' {
        $subId = $env.SubscriptionId
        $endpointName = 'e-clipstest-origin01'
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
        Write-Host -ForegroundColor Green "New-AzCdnOrigin: origin2"
        $newOrigin = New-AzCdnOrigin -Name "origin2" -HostName "host2.hello.com" -EndpointName $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $newOrigin.Name | Should -Be "origin2"
        $newOrigin.HostName | Should -Be "host2.hello.com"

        # Get - List
        Write-Host -ForegroundColor Green "Get-AzCdnOrigin - List"
        $origins = Get-AzCdnOrigin -EndpointName $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $origins.Count | Should -BeGreaterOrEqual 2

        # Get - by name
        Write-Host -ForegroundColor Green "Get-AzCdnOrigin - by name"
        $getOrigin = Get-AzCdnOrigin -Name "origin1" -EndpointName $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $getOrigin.Name | Should -Be "origin1"
        $getOrigin.HostName | Should -Be "host1.hello.com"

        # Get - ViaIdentity
        Write-Host -ForegroundColor Green "Get-AzCdnOrigin - ViaIdentity"
        $getOrigin2 = Get-AzCdnOrigin -InputObject $getOrigin
        $getOrigin2.Name | Should -Be "origin1"

        # Update
        Write-Host -ForegroundColor Green "Update-AzCdnOrigin"
        $updatedOrigin = Update-AzCdnOrigin -Name "origin1" -EndpointName $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -HostName "www.azure.com" -HttpPort 456 -HttpsPort 789
        $updatedOrigin.HostName | Should -Be "www.azure.com"
        $updatedOrigin.HttpPort | Should -Be 456
        $updatedOrigin.HttpsPort | Should -Be 789

        # Update - ViaIdentity
        Write-Host -ForegroundColor Green "Update-AzCdnOrigin - ViaIdentity"
        $updatedOrigin2 = Update-AzCdnOrigin -HostName "www.azure.com" -HttpPort 123 -HttpsPort 666 -InputObject $updatedOrigin
        $updatedOrigin2.HttpPort | Should -Be 123
        $updatedOrigin2.HttpsPort | Should -Be 666

        # Remove
        Write-Host -ForegroundColor Green "Remove-AzCdnOrigin: origin2"
        Remove-AzCdnOrigin -Name "origin2" -EndpointName $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }
}
