$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzImageBuilderCustomizerObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzImageBuilderCustomizerObject' {
    It 'WindowsUpdateCustomizer' {
        $searchCriterion = "BrowseOnly=0 and IsInstalled=0"
        $filters = ("BrowseOnly", "IsInstalled")
        $updateLimit = 100
        $customizerName = 'WindowsUpdate'
        $customizer = New-AzImageBuilderCustomizerObject -WindowsUpdateCustomizer -Filter $filters -SearchCriterion $searchCriterion -UpdateLimit $updateLimit -CustomizerName $customizerName
        $customizer.Name | Should -Be $customizerName
    }

    It 'FileCustomizer' {
        $customizerName = 'downloadBuildArtifacts'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $destination = 'c:\\buildArtifacts\\index.html'
        $sourceUri = 'https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/index.html'
        $customizer = New-AzImageBuilderCustomizerObject -FileCustomizer -CustomizerName $customizerName -Sha256Checksum  $sha256Checksum -Destination $destination -SourceUri $sourceUri
        $customizer.Name | Should -Be $customizerName
    }

    It 'ShellCustomizer' {
        $customizerName = 'downloadBuildArtifacts'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
        $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum  $sha256Checksum
        $customizer.Name | Should -Be $customizerName
    }

    It 'PowerShellCustomizer' {
        $customizerName = 'settingUpMgmtAgtPath'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $inline = @("mkdir c:\\buildActions", "echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt") 
        $customizer = New-AzImageBuilderCustomizerObject -PowerShellCustomizer -CustomizerName $customizerName -RunElevated $false -Sha256Checksum $sha256Checksum -Inline $inline
        $customizer.Name | Should -Be $customizerName
    }

    It 'RestartCustomizer' {
        $customizerName = 'WindowsRestart'
        $restartCommand = 'shutdown /f /r /t 0 /c \"packer restart\"'
        $restartCheckCommand = 'powershell -command "& {Write-Output "restarted."}"' 
        $restartTimeout = "10m" 
        $customizer = New-AzImageBuilderCustomizerObject -RestartCustomizer -CustomizerName $customizerName -RestartCommand $restartCommand -RestartCheckCommand $restartCheckCommand -RestartTimeout $restartTimeout
        $customizer.Name | Should -Be $customizerName
    }
}
