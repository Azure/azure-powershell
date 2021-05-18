$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStaticWebAppBuildAppSetting.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStaticWebAppBuildAppSetting' {
    It 'CreateExpanded' {
        {  New-AzStaticWebAppBuildAppSetting -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -EnvironmentName 'default'  -AppSetting @{'buildsetting1' = 'someval'; 'buildsetting2' = 'someval2' } } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        { 
          $setting = Get-AzStaticWebAppBuildAppSetting -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -EnvironmentName 'default' 
          New-AzStaticWebAppBuildAppSetting -InputObject $setting -AppSetting @{'buildsetting1' = 'someval'; 'buildsetting2' = 'someval2' } 
        } | Should -Not -Throw
    }
}
