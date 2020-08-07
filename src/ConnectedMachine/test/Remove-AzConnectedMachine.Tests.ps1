$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConnectedMachine.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzConnectedMachine' {
    BeforeAll {
        $machineName = $env.MachineName2

        if ($TestMode -ne 'playback' -and $IsMacOS) {
            Write-Host "Live Remove-AzConnectedMachine tests can only be run on Windows and Linux. Skipping..."
            $SkipAll = $true

            # All `It` calls will have -Skip:$true
            $PSDefaultParameterValues["It:Skip"] = $true
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

        $Location = $env.location

        if ($TestMode -eq 'playback') {
            # Skip starting azcmagent
            return
        }

        $azcmagentArgs = @(
            'connect'
            '--resource-group'
            $env.ResourceGroupName
            '--tenant-id'
            $TenantId
            '--location'
            $env.location
            '--subscription-id'
            $env.SubscriptionId
            '--access-token'
            $AccessToken
            '--resource-name'
            $machineName
        )

        if ($IsLinux) {
            return sudo $env.azcmagentPath @azcmagentArgs 
        }
        & $env.azcmagentPath @azcmagentArgs
    }

    AfterEach {
        if ($SkipAll) {
            return
        }

        if ($TestMode -eq 'playback') {
            # Skip stopping azcmagent
            return
        }

        if ($IsLinux) {
            return sudo $env.azcmagentPath disconnect --access-token $AccessToken
        }
        & $env.azcmagentPath disconnect --access-token $AccessToken
    }

    It 'Remove a connected machine by name' {
        Remove-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName
        { Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName } | Should -Throw
    }

    It 'Remove a connected machine by Input Object' {
        $machine = Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName
        Remove-AzConnectedMachine -InputObject $machine
        { Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName } | Should -Throw
    }

    It 'Remove a connected machine using pipelines' {
        # Tests include -SubscriptionId automatically but it causes
        # piping to fail. This temporarily removes that default value for
        # this test.
        $before = $PSDefaultParameterValues["*:SubscriptionId"]
        $PSDefaultParameterValues.Remove("*:SubscriptionId")
        try {
            Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName | Remove-AzConnectedMachine
            { Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName } | Should -Throw
        } finally {
            $PSDefaultParameterValues["*:SubscriptionId"] = $before
        }
   }
}
