if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoveryWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoveryWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoveryWorkspace' {
    It 'CreateExpanded' {
        New-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForNew -Location $env.location `
            -SupercomputerId @($env.SupercomputerIdForNew) `
            -WorkspaceIdentityId $env.UamiUksId `
            -WorkspaceSubnetId $env.Ws2SubnetId `
            -AgentSubnetId $env.Ws2AgentSubnetId `
            -PrivateEndpointSubnetId $env.Ws2PepSubnetId `
            -Tag @{'test' = 'powershell'; 'SkipAssociateKeyVaultToNsp' = 'True'; 'networkIsolation' = 'true'} -Confirm:$false | Out-Null

        $result = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForNew -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspaceNameForNew
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonFilePath' -Skip {
        $jsonPath = Join-Path $PSScriptRoot 'new-workspace-test.json'
        try {
            $json = @{
                location = $env.location
                properties = @{
                    supercomputerIds = @($env.SupercomputerIdForGet)
                    subnetId = $env.WsSubnetId
                    agentSubnetId = $env.WsAgentSubnetId
                    privateEndpointSubnetId = $env.WsPepSubnetId
                }
                identity = @{
                    type = 'UserAssigned'
                    userAssignedIdentities = @{ $env.UamiUksId = @{} }
                }
                tags = @{ test = 'powershell-jsonfile'; SkipAssociateKeyVaultToNsp = 'True'; networkIsolation = 'true' }
            } | ConvertTo-Json -Depth 10
            $json | Set-Content -Path $jsonPath

            $result = New-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
                -Name $env.WorkspaceNameForNewJsonFile -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.WorkspaceNameForNewJsonFile
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaJsonString' -Skip {
        $json = @{
            location = $env.location
            properties = @{
                supercomputerIds = @($env.SupercomputerIdForGet)
                subnetId = $env.WsSubnetId
                agentSubnetId = $env.WsAgentSubnetId
                privateEndpointSubnetId = $env.WsPepSubnetId
            }
            identity = @{
                type = 'UserAssigned'
                userAssignedIdentities = @{ $env.UamiUksId = @{} }
            }
            tags = @{ test = 'powershell-json'; SkipAssociateKeyVaultToNsp = 'True'; networkIsolation = 'true' }
        } | ConvertTo-Json -Depth 10

        $result = New-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForNewJson -SubscriptionId $env.SubscriptionId `
            -JsonString $json -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.WorkspaceNameForNewJson
    }
}
