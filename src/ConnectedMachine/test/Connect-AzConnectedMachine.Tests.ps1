  
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Connect-AzConnectedMachine.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Connect-AzConnectedMachine' {
    BeforeAll {
        if ($TestMode -eq 'playback') {
            Write-Host "Connect-AzConnectedMachine tests can only be run live. Skipping..."
            $SkipAll = $true

            # All `It` calls will have -Skip:$true
            $PSDefaultParameterValues["It:Skip"] = $true
            return
        }

        if ($IsMacOS) {
            Write-Host "Connect-AzConnectedMachine tests can only be run on Windows or Linux. Skipping..."
            $SkipAll = $true

            # All `It` calls will have -Skip:$true
            $PSDefaultParameterValues["It:Skip"] = $true
            return
        }

        $Account = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Account
        $AzureEnv = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[[Microsoft.Azure.Commands.Common.Authentication.Abstractions.EnvironmentName]::AzureCloud]
        $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
        $PromptBehavior = [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never
        $Token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($account, $AzureEnv, $tenantId, $null, $promptBehavior, $null)
        $AccessToken = $Token.AccessToken
    }

    AfterAll {
        # Reset PSDefaultParameterValues
        if ($PSDefaultParameterValues["It:Skip"]) {
            $PSDefaultParameterValues.Remove("It:Skip")
        }
    }

    BeforeEach {
        if ($SkipAll) {
            return
        }

        $commonParams = @{
            Name = (New-Guid).Guid
            ResourceGroupName = $env.ResourceGroupName
        }
    }

    AfterEach {
        if ($SkipAll) {
            return
        }

        if ($IsLinux) {
            return sudo $env.azcmagentPath disconnect --access-token $AccessToken
        }
        & $env.azcmagentPath disconnect --access-token $AccessToken
    }

    It 'Can connect a machine to an existing resource group' {
        $machine = Connect-AzConnectedMachine @commonParams -Location $env.location -Tag @{ Owner = "Contoso" }

        $machine | Should -Not -Be $null
        $machine.Location | Should -MatchExactly $env.location
        $machine.Tag["Owner"] | Should -Be "Contoso"
    }

    It 'Can connect a machine to an existing resource group using a PSSession' -Skip:($IsLinux) {
        # This is only supported on Windows
        try {
            $pssession = New-PSSession -ComputerName localhost
        }
        catch {
            Enable-PSRemoting -Force
            $pssession = New-PSSession -ComputerName localhost -EnableNetworkAccess
        }

        $machine = Connect-AzConnectedMachine @commonParams -Location $env.location -PSSession $pssession

        $machine | Should -Not -Be $null
        $machine.Location | Should -MatchExactly $env.location
    }
}