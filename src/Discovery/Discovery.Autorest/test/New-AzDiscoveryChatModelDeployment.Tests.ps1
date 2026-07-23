if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoveryChatModelDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoveryChatModelDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoveryChatModelDeployment' {
    It 'CreateExpanded' {
        $result = New-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ChatModelDeploymentNameForNew -SubscriptionId $env.SubscriptionId `
            -Location $env.location `
            -ModelName 'gpt-4o' -ModelFormat 'OpenAI' `
            -SkuName 'GlobalStandard' -Capacity 1 `
            -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ChatModelDeploymentNameForNew
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonString' {
        $json = @{
            location = $env.location
            properties = @{
                modelFormat = 'OpenAI'
                modelName = 'gpt-4o'
            }
        } | ConvertTo-Json -Depth 10

        $result = New-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ChatModelDeploymentNameForNewJson -SubscriptionId $env.SubscriptionId `
            -JsonString $json -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ChatModelDeploymentNameForNewJson
    }

    It 'CreateViaJsonFilePath' {
        $jsonPath = Join-Path $PSScriptRoot 'new-chatmodel-test.json'
        try {
            $json = @{
                location = $env.location
                properties = @{
                    modelFormat = 'OpenAI'
                    modelName = 'gpt-4o'
                }
            } | ConvertTo-Json -Depth 10
            $json | Set-Content -Path $jsonPath

            $result = New-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
                -WorkspaceName $env.WorkspaceNameForGet `
                -Name $env.ChatModelDeploymentNameForNewJsonFile -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.ChatModelDeploymentNameForNewJsonFile
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaIdentityWorkspaceExpanded' {
        $workspace = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = New-AzDiscoveryChatModelDeployment -WorkspaceInputObject $workspace `
            -Name $env.ChatModelDeploymentNameForNewViaPar `
            -Location $env.location `
            -ModelName 'gpt-4o' -ModelFormat 'OpenAI' `
            -SkuName 'GlobalStandard' -Capacity 1 `
            -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ChatModelDeploymentNameForNewViaPar
    }
}
