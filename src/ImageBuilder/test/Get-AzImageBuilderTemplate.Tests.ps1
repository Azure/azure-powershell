$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzImageBuilderTemplate.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzImageBuilderTemplate' {
    It 'List' {
        $templateList = Get-AzImageBuilderTemplate
        $templateList.Count | Should -BeGreaterOrEqual 1
    }
    It 'List1' {
        $templateList = Get-AzImageBuilderTemplate -ResourceGroupName $env.ResourceGroup
        $templateList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup
        $template.Name | Should -be $env.Resources.Template.templateName10
    }

    It 'GetViaIdentity' {
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup
        $newTemplate = Get-AzImageBuilderTemplate -InputObject $template
        $newTemplate.Name | Should -be $env.Resources.Template.templateName10
    }
}
