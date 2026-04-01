if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnEndpoint' {
    It 'CreateExpanded' {
        $endpointName = 'e-clipstest310-24-09-01'
        $origin = @{
            Name = "origin1"
            HostName = "host1.hello.com"
        }
        $location = "westus"

        # New
        Write-Host -ForegroundColor Green "New AzCdnEndpoint: $endpointName"
        $endpoint = New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.ClassicCdnProfileName -Location $location -Origin $origin
        $endpoint.Name | Should -Be $endpointName
        $endpoint.Location | Should -Be $location
        $endpoint.Origin.Name | Should -Be $origin.Name
        $endpoint.Origin.HostName | Should -Be $origin.HostName

        # Get - List
        Write-Host -ForegroundColor Green "Get AzCdnEndpoint - List"
        $endpoints = Get-AzCdnEndpoint -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $endpoints.Count | Should -BeGreaterOrEqual 1

        # Get - by name
        Write-Host -ForegroundColor Green "Get AzCdnEndpoint - by name"
        $getEndpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $getEndpoint.Name | Should -Be $endpointName

        # Get - ViaIdentity
        Write-Host -ForegroundColor Green "Get AzCdnEndpoint - ViaIdentity"
        $getEndpoint2 = Get-AzCdnEndpoint -InputObject $getEndpoint
        $getEndpoint2.Name | Should -Be $endpointName

        # Update
        Write-Host -ForegroundColor Green "Update AzCdnEndpoint"
        Update-AzCdnEndpoint -Name $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName -Tag @{ Tag1 = 11; Tag2 = 22 }
        $updatedEndpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $updatedEndpoint.Tag["Tag1"] | Should -Be "11"

        # Update - ViaIdentity
        Write-Host -ForegroundColor Green "Update AzCdnEndpoint - ViaIdentity"
        Update-AzCdnEndpoint -Tag @{ Tag1 = 33 } -InputObject $updatedEndpoint
        $updatedEndpoint2 = Get-AzCdnEndpoint -Name $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $updatedEndpoint2.Tag["Tag1"] | Should -Be "33"

        # Stop
        Write-Host -ForegroundColor Green "Stop AzCdnEndpoint"
        Stop-AzCdnEndpoint -Name $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $stoppedEndpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $stoppedEndpoint.ResourceState | Should -Be "Stopped"

        # Start
        Write-Host -ForegroundColor Green "Start AzCdnEndpoint"
        Start-AzCdnEndpoint -Name $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $startedEndpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $startedEndpoint.ResourceState | Should -Be "Running"

        # Remove
        Write-Host -ForegroundColor Green "Remove AzCdnEndpoint: $endpointName"
        Remove-AzCdnEndpoint -Name $endpointName -ProfileName $env.ClassicCdnProfileName -ResourceGroupName $env.ResourceGroupName
    }
}
