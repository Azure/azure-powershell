if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoveryWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoveryWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoveryWorkspace' {
    It 'UpdateExpanded' {
        $original = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -Tag @{ psTest = 'true'; SkipAssociateKeyVaultToNsp = 'True'; networkIsolation = 'true' } | Out-Null
            $updated = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'true'
        }
        finally {
            Update-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -Tag $originalTags | Out-Null
        }
    }

    It 'UpdateViaIdentityExpanded' {
        $resource = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $resource.Tag) {
            foreach ($key in $resource.Tag.Keys) {
                $originalTags[$key] = $resource.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryWorkspace -InputObject $resource -Tag @{ psTest = 'viaIdentity'; SkipAssociateKeyVaultToNsp = 'True'; networkIsolation = 'true' } | Out-Null
            $updated = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentity'
        }
        finally {
            Update-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -Tag $originalTags | Out-Null
        }
    }
    It 'UpdateViaJsonFilePath' {
        $original = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonPath = Join-Path $PSScriptRoot 'update-workspace-test.json'
            '{"tags":{"psTest":"viaJsonFile","SkipAssociateKeyVaultToNsp":"True","networkIsolation":"true"}}' | Set-Content -Path $jsonPath
            Update-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -JsonFilePath $jsonPath | Out-Null
            $updated = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJsonFile'
        }
        finally {
            Update-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -Tag $originalTags | Out-Null
            Remove-Item -Path (Join-Path $PSScriptRoot 'update-workspace-test.json') -ErrorAction SilentlyContinue
        }
    }
    It 'UpdateViaJsonString' {
        $original = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonString = '{"tags":{"psTest":"viaJson","SkipAssociateKeyVaultToNsp":"True","networkIsolation":"true"}}'
            Update-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -JsonString $jsonString | Out-Null
            $updated = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJson'
        }
        finally {
            Update-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -Tag $originalTags | Out-Null
        }
    }}
