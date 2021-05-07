$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStaticWebAppSetting.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStaticWebAppSetting' {
    It 'CreateExpanded' {
        { New-AzStaticWebAppSetting -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -AppSetting @{'function01' = 'value01'; 'function02' = 'value02' } } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        { 
          $setting = Get-AzStaticWebAppSetting -ResourceGroupName $env.resourceGroup -Name $env.staticweb01
          New-AzStaticWebAppSetting -InputObject $setting -AppSetting @{'function01' = 'value01'; 'function02' = 'value02' } 
        } | Should -Not -Throw
    }
}
