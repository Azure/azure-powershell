if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoveryProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoveryProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoveryProject' {
    It 'CreateExpanded' {
        $result = New-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ProjectNameForNew -SubscriptionId $env.SubscriptionId `
            -Location $env.location `
            -StorageContainerId @($env.ExistingStorageContainerId) `
            -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ProjectNameForNew
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonString' {
        $json = @{
            location = $env.location
        } | ConvertTo-Json -Depth 10

        $result = New-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ProjectNameForNewJson -SubscriptionId $env.SubscriptionId `
            -JsonString $json -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ProjectNameForNewJson
    }

    It 'CreateViaJsonFilePath' {
        $jsonPath = Join-Path $PSScriptRoot 'new-project-test.json'
        try {
            $json = @{
                location = $env.location
            } | ConvertTo-Json -Depth 10
            $json | Set-Content -Path $jsonPath

            $result = New-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
                -WorkspaceName $env.WorkspaceNameForGet `
                -Name $env.ProjectNameForNewJsonFile -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.ProjectNameForNewJsonFile
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaIdentityWorkspaceExpanded' {
        $workspace = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = New-AzDiscoveryProject -WorkspaceInputObject $workspace `
            -Name $env.ProjectNameForNewViaPar `
            -Location $env.location `
            -StorageContainerId @($env.ExistingStorageContainerId) `
            -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ProjectNameForNewViaPar
    }
}
