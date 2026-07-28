if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoveryTool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoveryTool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoveryTool' {
    It 'UpdateExpanded' {
        $original = Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -Tag @{ psTest = 'true' } | Out-Null
            $updated = Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'true'
        }
        finally {
            Update-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -Tag $originalTags | Out-Null
        }
    }

    It 'UpdateViaIdentityExpanded' {
        $resource = Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $resource.Tag) {
            foreach ($key in $resource.Tag.Keys) {
                $originalTags[$key] = $resource.Tag[$key]
            }
        }

        try {
            Update-AzDiscoveryTool -InputObject $resource -Tag @{ psTest = 'viaIdentity' } | Out-Null
            $updated = Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentity'
        }
        finally {
            Update-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -Tag $originalTags | Out-Null
        }
    }
    It 'UpdateViaJsonFilePath' {
        $original = Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonPath = Join-Path $PSScriptRoot 'update-tool-test.json'
            '{"tags":{"psTest":"viaJsonFile"}}' | Set-Content -Path $jsonPath
            Update-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -JsonFilePath $jsonPath | Out-Null
            $updated = Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJsonFile'
        }
        finally {
            Update-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -Tag $originalTags | Out-Null
            Remove-Item -Path (Join-Path $PSScriptRoot 'update-tool-test.json') -ErrorAction SilentlyContinue
        }
    }
    It 'UpdateViaJsonString' {
        $original = Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            $jsonString = '{"tags":{"psTest":"viaJson"}}'
            Update-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -JsonString $jsonString | Out-Null
            $updated = Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaJson'
        }
        finally {
            Update-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -Tag $originalTags | Out-Null
        }
    }}
