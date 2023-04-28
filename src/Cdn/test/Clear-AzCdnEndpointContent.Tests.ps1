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
        $contentPath = @("/movies/*","/pictures/pic1.jpg") 

        # Purge content on endpoint should succeed
        Clear-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentPath $contentPath
        # Purge content on non-existing endpoint should fail
        { Clear-AzCdnEndpointContent -EndpointName "fakeEndpoint" -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentPath $contentPath } | Should -Throw
        # Purge content on endpoint with invalid content paths should fail
        { Clear-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentPath "invalidpath!" } | Should -Throw
        # Purge content on stopped endpoint should fail
        Stop-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
        { Clear-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentPath $contentPath } | Should -Throw
        
        Start-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
    }

    It 'Purge' {
        $contentPath = @{ ContentPath = @("/movies/*","/pictures/pic1.jpg") }

        # Purge content on endpoint should succeed
        Clear-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentFilePath $contentPath
        # Purge content on non-existing endpoint should fail
        { Clear-AzCdnEndpointContent -EndpointName "fakeEndpoint" -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentFilePath $contentPath } | Should -Throw
        # Purge content on endpoint with invalid content paths should fail
        { Clear-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentFilePath @{ ContentPath = "invalidpath!" } } | Should -Throw
        # Purge content on stopped endpoint should fail
        Stop-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
        { Clear-AzCdnEndpointContent -EndpointName $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -ContentFilePath $contentPath } | Should -Throw
        
        Start-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
    }

    It 'PurgeViaIdentityExpanded' {
        $PSDefaultParameterValues['Disabled'] = $true
        $contentPath = @("/movies/*","/pictures/pic1.jpg") 

        # Purge content on endpoint should succeed
        $endpoint = Get-AzCdnEndpoint -Name $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId
        $endpoint | Clear-AzCdnEndpointContent -ContentPath $contentPath
        # Purge content on endpoint with invalid content paths should fail
        { $endpoint | Clear-AzCdnEndpointContent -ContentPath "invalidpath!" } | Should -Throw
        # Purge content on stopped endpoint should fail
        Stop-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
        { $endpoint | Clear-AzCdnEndpointContent -ContentPath $contentPath } | Should -Throw

        Start-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
    }

    It 'PurgeViaIdentity' {
        $PSDefaultParameterValues['Disabled'] = $true
        $contentPath = @{ ContentPath = @("/movies/*","/pictures/pic1.jpg") }

        # Purge content on endpoint should succeed
        $endpoint = Get-AzCdnEndpoint -Name $env.VerizonEndpointName -ProfileName $env.VerizonCdnProfileName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId
        $endpoint | Clear-AzCdnEndpointContent -ContentFilePath $contentPath
        # Purge content on endpoint with invalid content paths should fail
        { $endpoint | Clear-AzCdnEndpointContent -ContentFilePath @{ ContentPath = "invalidpath!" } } | Should -Throw
        # Purge content on stopped endpoint should fail
        Stop-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
        { $endpoint | Clear-AzCdnEndpointContent -ContentFilePath $contentPath } | Should -Throw

        Start-AzCdnEndpoint -Name $env.VerizonEndpointName -ResourceGroupName $env.ResourceGroupName -ProfileName $env.VerizonCdnProfileName 
    }
}
