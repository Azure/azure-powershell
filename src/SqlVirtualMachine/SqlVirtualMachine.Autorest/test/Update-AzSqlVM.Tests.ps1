if (($null -eq $TestName) -or ($TestName -contains 'Update-AzSqlVM')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSqlVM.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSqlVM' {
    It 'UpdateExpanded' {
        $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location -SqlManagementType 'LightWeight'

        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'LightWeight'
        $sqlVM.SqlServerLicenseType | Should -Be 'PAYG'

        $sqlVM = Update-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -SqlManagementType 'Full' -Sku 'Standard' -LicenseType 'AHUB' -Tag @{'IT' = '8888' }

        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'Full'
        $sqlVM.SqlServerLicenseType | Should -Be 'AHUB'
        $sqlVM.tag.Count | Should -Be 1
        $sqlVM.tag["IT"] | Should -Be '8888'

        Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }

    It 'UpdateViaIdentityExpanded' {
        $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location -SqlManagementType 'LightWeight'

        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'LightWeight'
        $sqlVM.SqlServerLicenseType | Should -Be 'PAYG'
        $sqlVM.tag.Count | Should -Be 0

        $sqlVM = Update-AzSqlVM -InputObject $sqlVM -SqlManagementType 'Full' -Sku 'Standard' -LicenseType 'AHUB' -Tag @{'IT' = '8888' }

        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'Full'
        $sqlVM.SqlServerLicenseType | Should -Be 'AHUB'
        $sqlVM.tag.Count | Should -Be 1
        $sqlVM.tag["IT"] | Should -Be '8888'

        Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }
    
    It 'Update-AutopatchingEnable' {
        $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location

        $sqlVM = Update-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -AutoPatchingSettingDayOfWeek Thursday -AutoPatchingSettingMaintenanceWindowDuration 120 -AutoPatchingSettingMaintenanceWindowStartingHour 3 -AutoPatchingSettingEnable
                
        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'Full'
        $sqlVM.SqlServerLicenseType | Should -Be 'PAYG'
        
        $sqlVM1 = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Expand *
        $sqlVM1.AutoPatchingSettingDayOfWeek | Should -Be 'Thursday'
        $sqlVM1.AutoPatchingSettingMaintenanceWindowDuration | Should -Be 120
        $sqlVM1.AutoPatchingSettingMaintenanceWindowStartingHour | Should -Be 3
        $sqlVM1.AutoPatchingSettingEnable | Should -Be $true

        # Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }

    It 'Update-AssessmentSchedule' {
        # $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location -SqlManagementType 'Full'
       
        $sqlVM = Update-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -AssessmentSettingEnable `
        -ScheduleEnable -ScheduleDayOfWeek Sunday -ScheduleMonthlyOccurrence 2 -ScheduleStartTime "23:00"
                
        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'Full'
        $sqlVM.SqlServerLicenseType | Should -Be 'PAYG'
        
        $sqlVM1 = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Expand *
        $sqlVM1.AssessmentSettingEnable | Should -Be $true
        $sqlVM1.ScheduleEnable | Should -Be $true
        $sqlVM1.ScheduleDayOfWeek | Should -Be Sunday
        $sqlVM1.ScheduleMonthlyOccurrence | Should -Be 2
        $sqlVM1.ScheduleStartTime | Should -Be "23:00"

        # Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }
    
    It 'Update-AutobackupEnable' {
        # $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location -SqlManagementType 'Full'       
        $StorageAccountUrl = "https://veppalastorageacc.blob.core.windows.net/"
        $storageAccountPrimaryKey = "anaccesskey"
        $sqlVM = Update-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -AutoBackupSettingEnable `
        -AutoBackupSettingBackupScheduleType manual -AutoBackupSettingFullBackupFrequency Weekly -AutoBackupSettingFullBackupStartTime 5 -AutoBackupSettingFullBackupWindowHour 2 -AutoBackupSettingStorageAccessKey $storageAccountPrimaryKey -AutoBackupSettingStorageAccountUrl $StorageAccountUrl -AutoBackupSettingRetentionPeriod 10 -AutoBackupSettingLogBackupFrequency 60
                
        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'Full'
        $sqlVM.SqlServerLicenseType | Should -Be 'PAYG'
        
        $sqlVM1 = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Expand *
        $sqlVM1.AutoBackupSettingEnable | Should -Be $true
        $sqlVM1.AutoBackupSettingBackupScheduleType | Should -Be manual
        $sqlVM1.AutoBackupSettingFullBackupFrequency | Should -Be Weekly
        $sqlVM1.AutoBackupSettingFullBackupStartTime | Should -Be 5
        $sqlVM1.AutoBackupSettingFullBackupWindowHour | Should -Be 2
        $sqlVM1.AutoBackupSettingRetentionPeriod | Should -Be 10

        Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }

        It 'Update-AddSqlVMtoGroup' {
        # Assuming Group $env.SqlVMGroupId exists at this time and $env.SqlVMName_HA2 is created
        $pwd = 'P@ssw0rd!' # Replace with the original password
        $securepwd = ConvertTo-SecureString -String $pwd -AsPlainText -Force

        $sqlVM = Update-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName_HA2 `
        -SqlVirtualMachineGroupResourceId  $env.SqlVMGroupId `
        -WsfcDomainCredentialsClusterBootstrapAccountPassword $securepwd `
        -WsfcDomainCredentialsClusterOperatorAccountPassword $securepwd `
        -WsfcDomainCredentialsSqlServiceAccountPassword $securepwd      
        
        $sqlVM2 = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName_HA2 -Expand *
        $sqlVM2.GroupResourceId | Should -Be $env.SqlVMGroupId
    }
        
    It 'Update-RemoveSqlVMfromGroup' {                
        # Assuming $env.SqlVMName_HA2 is created already and added to Group $env.SqlVMGroupId 
        # If the test case fails, make sure Sql server is running before running test case
        $sqlVM = Update-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName_HA2 `
        -SqlVirtualMachineGroupResourceId  ''
        
        $sqlVM2 = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName_HA2 -Expand *
        $sqlVM2.GroupResourceId | Should -Be $null
        }
}

Describe 'Update-AzSqlVM-EntraAuth' -Tag 'LiveOnly' {
	It 'Update-AdAuthenticationEnable1' {
        $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location

        $sqlVM = Update-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -IdentityType 'UserAssigned' -ManagedIdentityClientId '6d81e2bc-dcc5-45c9-9327-1cfee9612933'
        # note: user assigned managed identity is associated to sql vm and it has the required permissions
        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2022-WS2022'
        $sqlVM.SqlManagement | Should -Be 'Full'
        
		Start-Sleep -Seconds 60
        $sqlVM1 = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Expand *
        $sqlVM1.AzureAdAuthenticationSettingClientId | Should -Be '6d81e2bc-dcc5-45c9-9327-1cfee9612933'
        
        # Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }
		
	It 'Update-AdAuthenticationEnable2' {
        $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location

        $sqlVM = Update-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -IdentityType 'SystemAssigned'
        # note: system managed identity is enabled on sql vm and it has the required permissions
        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2022-WS2022'
        $sqlVM.SqlManagement | Should -Be 'Full'
        
		Start-Sleep -Seconds 60
        $sqlVM2 = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Expand *		
        $sqlVM2.AzureAdAuthenticationSettingClientId | Should -Be ''
        
        # Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }
		
	It 'AdAuthenticationFailurescenario1' {
		$sqlVM = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
		# note: id 'random value' is not associated to sql vm so it throws the error
		{$sqlVM | Update-AzSqlVMADAuth -IdentityType 'UserAssigned' -ManagedIdentityClientId 'random value'} | Should -Throw		
	}
		
	It 'AdAuthenticationFailurescenario2' {
		$sqlVM = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
		# note: id '47c329a2-0bb1-48c5-9966-b84b957c6a77' is associated to sql vm but doesn't have required permissions. so it throws the error
		{$sqlVM | Update-AzSqlVMADAuth -IdentityType 'UserAssigned' -ManagedIdentityClientId '47c329a2-0bb1-48c5-9966-b84b957c6a77'} | Should -Throw		
	}
}
