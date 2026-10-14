if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoveryProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoveryProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoveryProject' {
    It 'UpdateExpanded' {
        $original = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -Tag @{ psTest = 'true' } | Out-Null
            $updated = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'true'
        }
        finally {
            Update-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -Tag $originalTags | Out-Null
        }
    }
    It 'UpdateViaJsonString' {
        $original = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonString = '{"tags":{"psTest":"viaJson"}}'
            Update-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -JsonString $jsonString | Out-Null
            $updated = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJson'
        }
        finally {
            Update-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -Tag $originalTags | Out-Null
        }
    }
    It 'UpdateViaJsonFilePath' {
        $original = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonPath = Join-Path $PSScriptRoot 'update-project-test.json'
            '{"tags":{"psTest":"viaJsonFile"}}' | Set-Content -Path $jsonPath
            Update-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -JsonFilePath $jsonPath | Out-Null
            $updated = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJsonFile'
        }
        finally {
            Update-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -Tag $originalTags | Out-Null
            Remove-Item -Path (Join-Path $PSScriptRoot 'update-project-test.json') -ErrorAction SilentlyContinue
        }
    }
    It 'UpdateViaIdentityWorkspaceExpanded' {
        $workspace = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.ProjectWorkspaceName -ErrorAction Stop
        $original = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryProject -WorkspaceInputObject $workspace `
                -Name $env.ProjectNameForGet -Tag @{ psTest = 'viaIdentityParent' } | Out-Null
            $updated = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
                -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentityParent'
        }
        finally {
            Update-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
                -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet `
                -Tag $originalTags | Out-Null
        }
    }

    It 'UpdateViaIdentityExpanded' {
        $resource = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $resource.Tag) {
            foreach ($key in $resource.Tag.Keys) {
                $originalTags[$key] = $resource.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryProject -InputObject $resource -Tag @{ psTest = 'viaIdentity' } | Out-Null
            $updated = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentity'
        }
        finally {
            Update-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.ProjectWorkspaceName -Name $env.ProjectNameForGet -Tag $originalTags | Out-Null
        }
    }}
