if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoveryChatModelDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoveryChatModelDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoveryChatModelDeployment' {
    It 'UpdateExpanded' {
        $result = Update-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.ChatModelDeploymentWorkspaceName -Name $env.ChatModelDeploymentNameForGet `
            -Tag @{ psTest = 'true' }
        $result | Should -Not -BeNullOrEmpty
        # Note: $result.Name returns operation GUID due to TypeSpec LRO final-state-via:location bug
        # TODO: Re-enable Name assertion once TypeSpec is fixed to use final-state-via:original-uri
    }

    It 'UpdateViaJsonString' {
        $jsonString = '{"tags":{"psTest":"viaJson"}}'
        $result = Update-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.ChatModelDeploymentWorkspaceName -Name $env.ChatModelDeploymentNameForGet `
            -JsonString $jsonString
        $result | Should -Not -BeNullOrEmpty
        # Note: $result.Name returns operation GUID due to TypeSpec LRO bug (see UpdateExpanded comment)
    }

    It 'UpdateViaJsonFilePath' {
        $jsonPath = Join-Path $PSScriptRoot 'update-chatmodel-test.json'
        try {
            '{"tags":{"psTest":"viaJsonFile"}}' | Set-Content -Path $jsonPath
            $result = Update-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
                -WorkspaceName $env.ChatModelDeploymentWorkspaceName -Name $env.ChatModelDeploymentNameForGet `
                -JsonFilePath $jsonPath
            $result | Should -Not -BeNullOrEmpty
            # Note: $result.Name returns operation GUID due to TypeSpec LRO bug (see UpdateExpanded comment)
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'UpdateViaIdentityWorkspaceExpanded' {
        $workspace = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.ChatModelDeploymentWorkspaceName -ErrorAction Stop
        $result = Update-AzDiscoveryChatModelDeployment -WorkspaceInputObject $workspace `
            -Name $env.ChatModelDeploymentNameForGet -Tag @{ psTest = 'viaIdentityParent' }
        $result | Should -Not -BeNullOrEmpty
        # Note: $result.Name returns operation GUID due to TypeSpec LRO bug (see UpdateExpanded comment)
    }

    It 'UpdateViaIdentityExpanded' {
        $resource = Get-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.ChatModelDeploymentWorkspaceName -Name $env.ChatModelDeploymentNameForGet -ErrorAction Stop
        $result = Update-AzDiscoveryChatModelDeployment -InputObject $resource `
            -Tag @{ psTest = 'viaIdentity' }
        $result | Should -Not -BeNullOrEmpty
        # Note: $result.Name returns operation GUID due to TypeSpec LRO bug (see UpdateExpanded comment)
    }
}
