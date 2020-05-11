$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-Update-Remove-AzFunctionAppSetting.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzFunctionAppSetting, Update-AzFunctionAppSetting, and Remove-AzFunctionAppSetting E2E' {
    
    BeforeAll {
        $PSDefaultParameterValues["Disabled"] = $true
    }

    AfterAll {
        $PSDefaultParameterValues["Disabled"] = $false
    }

    It "Validate Get-AzFunctionAppSetting, Update-AzFunctionAppSetting and Delete-AzFunctionAppSetting" {

        $functionName = $env.functionNamePowerShell

        $appSetting1 = @{}
        $appSetting1.Add("MyAppSetting1", 456789)
        $appSetting1.Add("MyAppSetting2", "PowerShellRocks")

        $appSetting2 = @{}
        $appSetting2.Add("MyAppSetting3", 123456)
        $appSetting2.Add("MyAppSetting4", "PowerShellIsAwesome")

        try
        {
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                              -PlanName $env.planNameWorkerTypeWindows `
                              -StorageAccount $env.storageAccountWindows  `
                              -Runtime PowerShell

            # We can get the application setting in two different ways:
            # 1) (Get-AzFunctionApp).ApplicationSettings 
            # 2) Get-AzFunctionAppSetting
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $expectedAppSettings = $functionApp.ApplicationSettings

            # App settings via Get-AzFunctionAppSetting
            Write-Verbose "Validate '(Get-AzFunctionApp).ApplicationSettings'" -Verbose
            $appSettingsViaGetAzFunctionAppSetting = Get-AzFunctionAppSetting -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            ValidateAppSetting -ExpectedAppSetting $expectedAppSettings -ActualAppSetting $appSettingsViaGetAzFunctionAppSetting
            
            # App settings via Get-AzFunctionAppSetting
            Write-Verbose "Validate 'Get-AzFunctionAppSetting'" -Verbose
            $appSettingsViaGetAzFunctionAppSettingWithPiping = $functionApp | Get-AzFunctionAppSetting
            ValidateAppSetting -ExpectedAppSetting $expectedAppSettings -ActualAppSetting $appSettingsViaGetAzFunctionAppSettingWithPiping

            # Add new app settings
            Write-Verbose "Validate 'Update-AzFunctionAppSetting'" -Verbose
            $updatedAppSettings = Update-AzFunctionAppSetting -Name $functionName `
                                                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                                              -AppSetting $appSetting1
            foreach ($appSettingName in $appSetting1.Keys)
            {
                $updatedAppSettings[$appSettingName] | Should Be $appSetting1[$appSettingName]
            }

            # Update app settings using piping
            $updatedAppSettings2 = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium | 
                                    Update-AzFunctionAppSetting -AppSetting $appSetting2
            foreach ($appSettingName in $appSetting2.Keys)
            {
                $updatedAppSettings2[$appSettingName] | Should Be $appSetting2[$appSettingName]
            }

            # Delete first set of app settings
            Write-Verbose "Validate 'Remove-AzFunctionAppSetting'" -Verbose
            Remove-AzFunctionAppSetting -Name $functionName `
                                        -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                        -AppSettingName $appSetting1.Keys
            
            $appSettings = Get-AzFunctionAppSetting -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            
            foreach ($appSettingName in $appSetting1.Keys)
            {
                $appSettings.ContainsKey($appSettingName) | Should be $false
            }

            # Delete app settings using piping
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium | 
                Remove-AzFunctionAppSetting -AppSettingName $appSetting2.Keys
            $appSettings = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium | Get-AzFunctionAppSetting
            
            foreach ($appSettingName in $appSetting2.Keys)
            {
                $appSettings.ContainsKey($appSettingName) | Should be $false
            }
        }
        finally
        {
            Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue |
                Remove-AzFunctionApp -Force -ErrorAction SilentlyContinue
        }
    }
}
