if(($null -eq $TestName) -or ($TestName -contains 'New-AzQuotaGroupQuotaLocationSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzQuotaGroupQuotaLocationSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzQuotaGroupQuotaLocationSetting' {
    BeforeAll {
        # Use values from env.json
        $script:tenantId = $env.Tenant
        $script:subscriptionId = $env.SubscriptionId
        $script:managementGroupId = "AzureClientToolsBAMI"  
        $script:groupQuotaName = "testlocation"
        $script:location = "eastus"
        $script:resourceProviderName = "Microsoft.Compute"
        $script:groupQuotaExists = $false
        
        # Check if group quota "testlocation" exists
        try {
            $existingQuota = Get-AzQuotaGroupQuota -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -ErrorAction SilentlyContinue
            if ($existingQuota) {
                $script:groupQuotaExists = $true
            }
        } catch {
            # Group quota doesn't exist
        }
        
        # If group quota doesn't exist, create it
        if (-not $script:groupQuotaExists) {
            try {
                $newQuota = New-AzQuotaGroupQuota -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -DisplayName "Test Location Group Quota"
                if ($newQuota) {
                    $script:groupQuotaExists = $true
                }
            } catch {
                Write-Host "Failed to create group quota: $($_.Exception.Message)"
            }
        }
    }

    It 'Create' {
        if ($script:groupQuotaExists) {
            # First check if the location setting already exists
            $existingSetting = $null
            try {
                $existingSetting = Get-AzQuotaGroupQuotaLocationSetting -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -ResourceProviderName $script:resourceProviderName -Location $script:location -ErrorAction SilentlyContinue
            } catch {
                # Location setting doesn't exist yet - that's expected
            }
            
            if ($existingSetting) {
                # Location setting already exists, verify it
                $existingSetting | Should -Not -BeNull
                $existingSetting.Name | Should -Be $script:location
            } else {
                # Create a location setting for the group quota using JsonString
                # NOTE: Initial PUT returns HTTP 201 success, but async operations may require human
                # intervention and can take indefinite time. We use -NoWait to skip polling.
                $jsonBody = @{
                    properties = @{
                        enforcementEnabled = "Enabled"
                    }
                } | ConvertTo-Json
                
                # Use -NoWait - don't wait for async operation as it may require human intervention
                # Just verify the request is accepted (no exception means success)
                { New-AzQuotaGroupQuotaLocationSetting -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -ResourceProviderName $script:resourceProviderName -Location $script:location -JsonString $jsonBody -NoWait } | Should -Not -Throw
            }
        } else {
            Set-ItResult -Skipped -Because "Group quota 'testlocation' could not be created or accessed"
        }
    }
}