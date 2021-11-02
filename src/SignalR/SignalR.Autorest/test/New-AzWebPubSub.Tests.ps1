$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWebPubSub.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzWebPubSub' {
    Context "CreateExpanded" {
        It 'CreateExpandedWithMinimulParameters' {
            $name = $env.WpsPrefix + 'new-wps-' + "CreateExpandedWithMinimulParameters"

            $wps = New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -Location 'eastus' -SkuName Standard_S1

            $wps.ProvisioningState | Should -Be "Succeeded"
        }

        It 'CreateExpandedWithMoreParameters' {
            $name = $env.WpsPrefix + 'new-wps-' + "CreateExpandedWithMoreParameters"

            $wps = New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -Location 'eastus' -SkuName Standard_S1 -IdentityType SystemAssigned -LiveTraceEnabled true -LiveTraceCategory @{ Name='ConnectivityLogs' ; Enabled = 'true' }, @{ Name='MessageLogs' ; Enabled = 'true' }

            $wps.ProvisioningState | Should -Be "Succeeded"
            $wps.LiveTraceEnabled | Should -Be $True
            $wps.LiveTraceCategory | Should -HaveCount 2
            $wps.LiveTraceCategory[0].Name | Should -Be 'ConnectivityLogs'
            $wps.LiveTraceCategory[0].Enabled | Should -Be 'true'
            $wps.LiveTraceCategory[1].Name | Should -Be 'MessageLogs'
            $wps.LiveTraceCategory[1].Enabled | Should -Be 'true'
        }
    }
}
