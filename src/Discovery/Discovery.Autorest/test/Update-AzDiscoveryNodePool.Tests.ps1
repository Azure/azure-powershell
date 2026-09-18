if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoveryNodePool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoveryNodePool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoveryNodePool' {
    It 'UpdateExpanded' {
        $original = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -Tag @{ psTest = 'true' } | Out-Null
            $updated = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'true'
        }
        finally {
            Update-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -Tag $originalTags | Out-Null
        }
    }
    It 'UpdateViaJsonString' {
        $original = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonString = '{"tags":{"psTest":"viaJson"}}'
            Update-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -JsonString $jsonString | Out-Null
            $updated = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJson'
        }
        finally {
            Update-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -Tag $originalTags | Out-Null
        }
    }
    It 'UpdateViaJsonFilePath' {
        $original = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonPath = Join-Path $PSScriptRoot 'update-nodepool-test.json'
            '{"tags":{"psTest":"viaJsonFile"}}' | Set-Content -Path $jsonPath
            Update-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -JsonFilePath $jsonPath | Out-Null
            $updated = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJsonFile'
        }
        finally {
            Update-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -Tag $originalTags | Out-Null
            Remove-Item -Path (Join-Path $PSScriptRoot 'update-nodepool-test.json') -ErrorAction SilentlyContinue
        }
    }
    It 'UpdateViaIdentitySupercomputerExpanded' {
        $supercomputer = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.NodePoolSupercomputerName -ErrorAction Stop
        $original = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
            -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryNodePool -SupercomputerInputObject $supercomputer `
                -Name $env.NodePoolNameForGet -Tag @{ psTest = 'viaIdentityParent' } | Out-Null
            $updated = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
                -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentityParent'
        }
        finally {
            Update-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
                -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet `
                -Tag $originalTags | Out-Null
        }
    }

    It 'UpdateViaIdentityExpanded' {
        $resource = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $resource.Tag) {
            foreach ($key in $resource.Tag.Keys) {
                $originalTags[$key] = $resource.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryNodePool -InputObject $resource -Tag @{ psTest = 'viaIdentity' } | Out-Null
            $updated = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentity'
        }
        finally {
            Update-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.NodePoolSupercomputerName -Name $env.NodePoolNameForGet -Tag $originalTags | Out-Null
        }
    }}
