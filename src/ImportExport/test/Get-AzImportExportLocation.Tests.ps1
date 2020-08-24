$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzImportExportLocation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzImportExportLocation' {
    It 'List' {
        $location = Get-AzImportExportLocation 
        $location.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $location = Get-AzImportExportLocation -Name $env.location
        $location.Count | Should -Be 1
    }

    It 'GetViaIdentity' {
        $Id = "/providers/Microsoft.ImportExport/locations/$($env.location)"
        $location = Get-AzImportExportLocation -InputObject $Id
        $location.Count | Should -Be 1
    }
}
