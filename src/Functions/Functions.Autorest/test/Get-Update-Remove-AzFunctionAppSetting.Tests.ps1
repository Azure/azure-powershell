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

$env:FunctionsTestMode = $true

Describe 'Get-AzFunctionAppSetting, Update-AzFunctionAppSetting, and Remove-AzFunctionAppSetting E2E' {

    BeforeAll {
        $planName = $env.planNameWorkerTypeWindows
        Write-Verbose "Plan name: $planName" -Verbose

        $resourceGroupName = $env.resourceGroupNameWindowsPremium
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose

        $storageAccountName = $env.storageAccountWindows
        Write-Verbose "Storage account name: $storageAccountName" -Verbose
    }

    It "Validate Get-AzFunctionAppSetting, Update-AzFunctionAppSetting and Delete-AzFunctionAppSetting" {

        $appName = $env.functionNamePowerShellNew1
        Write-Verbose "App name: $appName" -Verbose

        $appSetting1 = @{}
        $appSetting1.Add("MyAppSetting1", 456789)
        $appSetting1.Add("MyAppSetting2", "PowerShellRocks")

        $appSetting2 = @{}
        $appSetting2.Add("MyAppSetting3", 123456)
        $appSetting2.Add("MyAppSetting4", "PowerShellIsAwesome")

        try
        {
            Write-Verbose "Create function app with custom app settings" -Verbose
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName `
                              -PlanName $planName `
                              -StorageAccount $storageAccountName  `
                              -Runtime PowerShell `
                              -RuntimeVersion 7.4 `
                              -FunctionsVersion 4

            # We can get the application setting in two different ways:
            # 1) (Get-AzFunctionApp).ApplicationSettings 
            # 2) Get-AzFunctionAppSetting
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $expectedAppSettings = $functionApp.ApplicationSettings

            # App settings via Get-AzFunctionAppSetting
            Write-Verbose "Validate '(Get-AzFunctionApp).ApplicationSettings'" -Verbose
            $appSettingsViaGetAzFunctionAppSetting = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $resourceGroupName
            ValidateAppSetting -ExpectedAppSetting $expectedAppSettings -ActualAppSetting $appSettingsViaGetAzFunctionAppSetting
            
            # App settings via Get-AzFunctionAppSetting
            Write-Verbose "Validate 'Get-AzFunctionAppSetting'" -Verbose
            $appSettingsViaGetAzFunctionAppSettingInputObject = Get-AzFunctionAppSetting -InputObject $functionApp
            ValidateAppSetting -ExpectedAppSetting $expectedAppSettings -ActualAppSetting $appSettingsViaGetAzFunctionAppSettingInputObject

            # Add new app settings
            Write-Verbose "Validate 'Update-AzFunctionAppSetting'" -Verbose
            $updatedAppSettings = Update-AzFunctionAppSetting -Name $appName `
                                                              -ResourceGroupName $resourceGroupName `
                                                              -AppSetting $appSetting1
            foreach ($appSettingName in $appSetting1.Keys)
            {
                $updatedAppSettings[$appSettingName] | Should Be $appSetting1[$appSettingName]
            }

            # Update app settings InputObject
            Write-Verbose "Validate 'Update-AzFunctionAppSetting -InputObject'" -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $updatedAppSettings2 = Update-AzFunctionAppSetting -InputObject $functionApp -AppSetting $appSetting2
            foreach ($appSettingName in $appSetting2.Keys)
            {
                $updatedAppSettings2[$appSettingName] | Should Be $appSetting2[$appSettingName]
            }

            # Delete first set of app settings
            Write-Verbose "Validate 'Remove-AzFunctionAppSetting'" -Verbose
            Remove-AzFunctionAppSetting -Name $appName `
                                        -ResourceGroupName $resourceGroupName `
                                        -AppSettingName $appSetting1.Keys
            
            $appSettings = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $resourceGroupName
            
            foreach ($appSettingName in $appSetting1.Keys)
            {
                $appSettings.ContainsKey($appSettingName) | Should be $false
            }

            Write-Verbose "Validate 'Remove-AzFunctionAppSetting -InputObject'" -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            Remove-AzFunctionAppSetting -InputObject $functionApp -AppSettingName $appSetting2.Keys

            Write-Verbose "Validate that the app settings were removed" -Verbose
            $appSettings = Get-AzFunctionAppSetting -InputObject $functionApp
            
            foreach ($appSettingName in $appSetting2.Keys)
            {
                $appSettings.ContainsKey($appSettingName) | Should be $false
            }
        }
        finally
        {
            Write-Verbose "Cleaning up the function app..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Write-Verbose "Removing function app $appName using -InputObject" -Verbose
                Remove-AzFunctionApp -InputObject $functionApp -Force #-ErrorAction SilentlyContinue
            }
        }
    }
}
