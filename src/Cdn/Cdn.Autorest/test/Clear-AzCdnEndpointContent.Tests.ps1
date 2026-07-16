if(($null -eq $TestName) -or ($TestName -contains 'Clear-AzCdnEndpointContent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Clear-AzCdnEndpointContent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Clear-AzCdnEndpointContent' {
    It 'PurgeExpanded' {
        # Create endpoint for purge testing
        $endpointName = 'e-purgetest20260901'
        $profileName = $env.ClassicCdnProfileName
        $origin = @{ Name = "origin1"; HostName = "host1.hello.com" }
        Write-Host -ForegroundColor Green "Create endpoint for purge test: $endpointName"
        try {
            New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $profileName -Location $env.location -Origin $origin | Out-Null

            $contentPath = @("/movies/*","/pictures/pic1.jpg")

            # Purge content on endpoint should succeed
            Clear-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $env.ResourceGroupName -ContentPath $contentPath

            # Purge content on non-existing endpoint should fail
            { Clear-AzCdnEndpointContent -EndpointName "fakeEndpoint" -ProfileName $profileName -ResourceGroupName $env.ResourceGroupName -ContentPath $contentPath } | Should -Throw

            # Purge via ViaIdentity
            $endpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $env.ResourceGroupName
            Clear-AzCdnEndpointContent -ContentPath $contentPath -InputObject $endpoint

            # Stop endpoint, purge should fail
            Stop-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $profileName
            { Clear-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $env.ResourceGroupName -ContentPath $contentPath } | Should -Throw
        }
        finally {
            Remove-AzCdnEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $profileName -ErrorAction SilentlyContinue
        }
    }
}
