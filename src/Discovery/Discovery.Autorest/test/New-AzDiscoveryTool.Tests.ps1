if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoveryTool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoveryTool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoveryTool' {
    It 'CreateExpanded' -Skip {
        # Skip: autorest codegen serializes the -DefinitionContent hashtable (free-form object type)
        # in a way the backend rejects. Complex nested objects (image, compute, code_environments)
        # don't round-trip correctly through hashtable→JSON serialization in the generated cmdlet.
        # Use CreateViaJsonString or CreateViaJsonFilePath instead.
    }

    It 'CreateViaJsonFilePath' {
        $jsonPath = Join-Path $PSScriptRoot 'new-tool-test.json'
        try {
            $env.ToolCreateJson | Set-Content -Path $jsonPath

            $result = New-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName `
                -Name $env.ToolNameForNewJsonFile -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.ToolNameForNewJsonFile
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaJsonString' {
        $result = New-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName `
            -Name $env.ToolNameForNew -SubscriptionId $env.SubscriptionId `
            -JsonString $env.ToolCreateJson -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ToolNameForNew
        $result.ProvisioningState | Should -Be 'Succeeded'
    }
}
