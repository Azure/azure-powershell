$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzImageBuilderTemplate.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzImageBuilderTemplate' {
    It 'Name'-skip {
         $tag = @{key = 'Name'}
    }

    It 'UpdateExpanded' -skip {
        $tag = @{key = 'UpdateExpanded'}
    }

    It 'Update' -skip {
        $tag = @{key = 'Update'}
    }

    It 'InputObject'  {
        $tag = @{key = 'InputObject'}
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup
        Update-AzImageBuilderTemplate -InputObject $template -Tag $tag 
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup
        $template.Tag.Item("info") | Should -Be $tag.key
    }

    It 'UpdateViaIdentityExpanded' -skip {
        $tag = @{key = 'UpdateViaIdentityExpanded'}
    }

    It 'UpdateViaIdentity' -skip {
        $tag = @{key = 'UpdateViaIdentity'}
    }
}
