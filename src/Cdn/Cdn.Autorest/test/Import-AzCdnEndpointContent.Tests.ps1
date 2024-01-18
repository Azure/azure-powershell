if(($null -eq $TestName) -or ($TestName -contains 'Import-AzCdnEndpointContent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Import-AzCdnEndpointContent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Import-AzCdnEndpointContent'  {
    It 'LoadExpanded' {
        $contentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg") 

        # Load content on endpoint should succeed
        Import-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentPath $contentPath
        # Load content on non-existing endpoint should fail
        { Import-AzCdnEndpointContent -EndpointName "fakeEndpoint" -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentPath $contentPath } | Should -Throw
        # Load content on endpoint with invalid content paths should fail
        { Import-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentPath "/movies/*" } | Should -Throw
        # Load content on stopped endpoint should fail
        Stop-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
        { Import-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentPath $contentPath } | Should -Throw
    }

    It 'Load' {
        Start-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
        $contentPath = @{ ContentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg") }

        # Load content on endpoint should succeed
        Import-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentFilePath $contentPath
        # Load content on non-existing endpoint should fail
        { Import-AzCdnEndpointContent -EndpointName "fakeEndpoint" -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentFilePath $contentPath } | Should -Throw
        # Load content on endpoint with invalid content paths should fail
        { Import-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentFilePath @{ ContentPath = "/movies/*" } } | Should -Throw
        # Load content on stopped endpoint should fail
        Stop-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
        { Import-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentFilePath $contentPath } | Should -Throw
    }

    It 'LoadViaIdentityExpanded' {
        Start-AzCdnEndpoint -SubscriptionId $env.SubscriptionId -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 

        $contentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg") 

        # Load content on endpoint should succeed
        $endpoint = Get-AzCdnEndpoint -Name $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName
        Import-AzCdnEndpointContent -ContentPath $contentPath -InputObject $endpoint
        # Load content on endpoint with invalid content paths should fail
        { Import-AzCdnEndpointContent -ContentPath "/movies/*" -InputObject $endpoint} | Should -Throw
        # Load content on stopped endpoint should fail
        Stop-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
        { $endpoint | Import-AzCdnEndpointContent -ContentPath $contentPath } | Should -Throw
    }

    It 'LoadViaIdentity' {
        Start-AzCdnEndpoint -SubscriptionId $env.SubscriptionId -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 

        $contentPath = @{ ContentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg") }

        # Load content on endpoint should succeed
        $endpoint = Get-AzCdnEndpoint -Name $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName
        Import-AzCdnEndpointContent -ContentFilePath $contentPath -InputObject $endpoint
        # Load content on endpoint with invalid content paths should fail
        { Import-AzCdnEndpointContent -ContentFilePath @{ ContentPath = "/movies/*" } -InputObject $endpoint } | Should -Throw
        # Load content on stopped endpoint should fail
        Stop-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
        { Import-AzCdnEndpointContent -ContentFilePath $contentPath -InputObject $endpoint } | Should -Throw

        # For other tests, need to start the endpoint
        Start-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
    }
}
