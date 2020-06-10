$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzImageBuilderRunOutput.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzImageBuilderRunOutput' {
    It 'List' {
        $resultsList = Get-AzImageBuilderRunOutput -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup
        $resultsList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $result = Get-AzImageBuilderRunOutput -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup -RunOutputName $env.Resources.RunOutputName.runOutputName20
        $result.Name | Should -Be $env.Resources.RunOutputName.runOutputName20
    }

    It 'GetViaIdentity' {
        $object = Get-AzImageBuilderRunOutput -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup -RunOutputName $env.Resources.RunOutputName.runOutputName20
        $result = Get-AzImageBuilderRunOutput -InputObject $object
        $result.Name | Should -Be $env.Resources.RunOutputName.runOutputName20
    }
}
