$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzImageBuilderTemplateRunOutput.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzImageBuilderRunOutput' {
    It 'List' -Skip {
        $resultsList = Get-AzImageBuilderTemplateRunOutput -ImageTemplateName $env.templateName -ResourceGroupName $env.rg
        $resultsList.Count | Should -BeGreaterThan 0
    }

    It 'Get' -Skip {
        $result = Get-AzImageBuilderTemplateRunOutput -ImageTemplateName $env.templateName -ResourceGroupName $env.rg -Name $env.runOutputName
        $result.Name | Should -Be $env.runOutputName
    }
}