$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStaticWebAppBuildFunctionAppSetting.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStaticWebAppBuildFunctionAppSetting' {
    It 'CreateExpanded' {
        { New-AzStaticWebAppBuildFunctionAppSetting -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -EnvironmentName 'default'  -AppSetting @{'buildsetting1' = 'someval'; 'buildsetting2' = 'someval2' } } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        { 
          $setting = Get-AzStaticWebAppBuildFunctionAppSetting -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -EnvironmentName 'default' 
          New-AzStaticWebAppBuildFunctionAppSetting -InputObject $setting -AppSetting @{'buildsetting1' = 'someval'; 'buildsetting2' = 'someval2' } 
        } | Should -Not -Throw
    }
}
