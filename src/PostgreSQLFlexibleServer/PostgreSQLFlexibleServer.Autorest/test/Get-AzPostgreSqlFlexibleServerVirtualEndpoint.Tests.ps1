if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPostgreSqlFlexibleServerVirtualEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerVirtualEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPostgreSqlFlexibleServerVirtualEndpoint' {
    It 'List' {
        try {
            $endpoints = Get-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            # Virtual endpoints may or may not be configured
            $endpoints | Should -Not -BeNull
            # If endpoints exist, verify their properties
            if ($endpoints -and $endpoints.Count -gt 0) {
                $endpoints[0].Name | Should -Not -BeNullOrEmpty
                $endpoints[0].EndpointType | Should -Not -BeNullOrEmpty
            }
        }
        catch {
            if ($_.Exception.Message -like "*ResourceNotFound*" -or $_.Exception.Message -like "*NotFound*") {
                Set-ItResult -Skipped -Because "Server or resource group not found"
            } else {
                throw
            }
        }
    }

    It 'Get' {
        try {
            $endpoints = Get-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            if ($endpoints -and $endpoints.Count -gt 0) {
                $firstEndpoint = $endpoints[0]
                $endpoint = Get-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -VirtualEndpointName $firstEndpoint.Name
                $endpoint | Should -Not -BeNullOrEmpty
                $endpoint.Name | Should -Be $firstEndpoint.Name
                $endpoint.EndpointType | Should -Be $firstEndpoint.EndpointType
            } else {
                # Skip if no virtual endpoints are configured
                Set-ItResult -Skipped -Because "No virtual endpoints configured on this server"
            }
        }
        catch {
            if ($_.Exception.Message -like "*ResourceNotFound*" -or $_.Exception.Message -like "*NotFound*") {
                Set-ItResult -Skipped -Because "Server or resource group not found"
            } else {
                throw
            }
        }
    }

    It 'GetViaIdentity' {
        try {
            $endpoints = Get-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            if ($endpoints -and $endpoints.Count -gt 0) {
                $firstEndpoint = $endpoints[0]
                $endpointViaIdentity = Get-AzPostgreSqlFlexibleServerVirtualEndpoint -InputObject $firstEndpoint
                $endpointViaIdentity | Should -Not -BeNullOrEmpty
                $endpointViaIdentity.Name | Should -Be $firstEndpoint.Name
            } else {
                Set-ItResult -Skipped -Because "No virtual endpoints configured on this server"
            }
        }
        catch {
            if ($_.Exception.Message -like "*ResourceNotFound*" -or $_.Exception.Message -like "*NotFound*") {
                Set-ItResult -Skipped -Because "Server or resource group not found"
            } else {
                throw
            }
        }
    }

        It 'GetViaIdentityFlexibleServer' {
            try {
                $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
                $endpoints = Get-AzPostgreSqlFlexibleServerVirtualEndpoint -FlexibleServerInputObject $server
                $endpoints | Should -Not -BeNull
                # Verify structure even if no endpoints are configured
                if ($endpoints -and $endpoints.Count -gt 0) {
                    $endpoints[0].EndpointType | Should -BeIn @('ReadWrite', 'ReadOnly')
                }
            }
            catch {
                if ($_.Exception.Message -like "*ResourceNotFound*" -or $_.Exception.Message -like "*NotFound*") {
                    Set-ItResult -Skipped -Because "Server or resource group not found"
                } else {
                    throw
                }
            }
        }
    }

