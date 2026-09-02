if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoveryBookshelf'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoveryBookshelf.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoveryBookshelf' {
    It 'UpdateExpanded' {
        $original = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -Tag @{ psTest = 'true'; SkipAssociateKeyVaultToNsp = 'True' } | Out-Null
            $updated = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'true'
        }
        finally {
            Update-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -Tag $originalTags | Out-Null
        }
    }

    It 'UpdateViaIdentityExpanded' {
        $resource = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $resource.Tag) {
            foreach ($key in $resource.Tag.Keys) {
                $originalTags[$key] = $resource.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryBookshelf -InputObject $resource -Tag @{ psTest = 'viaIdentity'; SkipAssociateKeyVaultToNsp = 'True' } | Out-Null
            $updated = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentity'
        }
        finally {
            Update-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -Tag $originalTags | Out-Null
        }
    }
    It 'UpdateViaJsonFilePath' {
        $original = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonPath = Join-Path $PSScriptRoot 'update-bookshelf-test.json'
            '{"tags":{"psTest":"viaJsonFile","SkipAssociateKeyVaultToNsp":"True"}}' | Set-Content -Path $jsonPath
            Update-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -JsonFilePath $jsonPath | Out-Null
            $updated = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJsonFile'
        }
        finally {
            Update-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -Tag $originalTags | Out-Null
            Remove-Item -Path (Join-Path $PSScriptRoot 'update-bookshelf-test.json') -ErrorAction SilentlyContinue
        }
    }
    It 'UpdateViaJsonString' {
        $original = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonString = '{"tags":{"psTest":"viaJson","SkipAssociateKeyVaultToNsp":"True"}}'
            Update-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -JsonString $jsonString | Out-Null
            $updated = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJson'
        }
        finally {
            Update-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -Tag $originalTags | Out-Null
        }
    }}
