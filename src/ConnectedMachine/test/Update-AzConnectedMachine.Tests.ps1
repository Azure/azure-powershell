if(($null -eq $TestName) -or ($TestName -contains 'Update-AzConnectedMachine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConnectedMachine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

BeforeAll {    
    if ($TestMode -ne 'playback' -and $IsMacOS) {
        Write-Host "Live tests can only be run on Windows and Linux. Skipping..."
        $SkipAll = $true

        # All `It` calls will have -Skip:$true
        $PSDefaultParameterValues["It:Skip"] = $true
    }
}

AfterAll {
    # Reset PSDefaultParameterValues
    if ($PSDefaultParameterValues["It:Skip"]) {
        $PSDefaultParameterValues.Remove("It:Skip")
    }
}

BeforeEach {
    if ($SkipAll) {
        return
    }

    $machineName = $env.MachineName
    $resourceGroupName = $env.ResourceGroupName
    $scopeName = $env.PrivateLinkScopeName
    $location = $env.Location

    if ($TestMode -eq 'playback') {
        # Skip starting azcmagent
        return
    }

    Start-Agent -MachineName $machineName -Env $env
}

AfterEach {
    if ($SkipAll) {
        return
    }

    if ($TestMode -eq 'playback') {
        # Skip stopping azcmagent
        return
    }

    Stop-Agent -AgentPath $env.azcmagentPath
}

Describe 'Update-AzConnectedMachine' {
    New-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName -PublicNetworkAccess "Enabled" -Location $location

    $scope = Get-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName

    $updatedMachine = Update-AzConnectedMachine -Name surface -ResourceGroupName az-sdk-test -PrivateLinkScopeResourceId $scope.Id -WindowsConfigurationPatchSettingsAssessmentMode "AutomaticByOS"

    $updatedMachine.PrivateLinkScopeResourceId | Should -Be $scope.Id

    $updatedMachine.WindowsConfigurationPatchSettingsAssessmentMode | Should -Be "AutomaticByOS"

    $updatedMachine = Update-AzConnectedMachine -Name surface -ResourceGroupName az-sdk-test -PrivateLinkScopeResourceId $null

    $updatedMachine.PrivateLinkScopeResourceId | Should -Be ""
}
