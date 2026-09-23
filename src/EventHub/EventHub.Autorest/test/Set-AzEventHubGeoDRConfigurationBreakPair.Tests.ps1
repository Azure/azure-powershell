if (($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHubGeoDRConfigurationBreakPair')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHubGeoDRConfigurationBreakPair.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

function Set-AzEventHubGeoDRConfigurationBreakPairWithRetry {
    [CmdletBinding(DefaultParameterSetName = 'Break')]
    param(
        [Parameter(ParameterSetName = 'Break', Mandatory = $true)]
        [string]$Name,

        [Parameter(ParameterSetName = 'Break', Mandatory = $true)]
        [string]$ResourceGroupName,

        [Parameter(ParameterSetName = 'Break', Mandatory = $true)]
        [string]$NamespaceName,

        [Parameter(ParameterSetName = 'BreakViaIdentity', Mandatory = $true)]
        [object]$InputObject
    )

    $maxAttempts = 6
    for ($attempt = 1; $attempt -le $maxAttempts; $attempt++) {
        try {
            if ($PSCmdlet.ParameterSetName -eq 'Break') {
                return Set-AzEventHubGeoDRConfigurationBreakPair -Name $Name -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName
            }

            return Set-AzEventHubGeoDRConfigurationBreakPair -InputObject $InputObject
        }
        catch {
            if ($_.Exception.Message -match 'MetadataDROperationInProgressConflict' -and $attempt -lt $maxAttempts) {
                Start-TestSleep 30
                continue
            }

            throw
        }
    }
}

function New-AzEventHubGeoDRConfigurationWithRetry {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$Name,

        [Parameter(Mandatory = $true)]
        [string]$ResourceGroupName,

        [Parameter(Mandatory = $true)]
        [string]$NamespaceName,

        [Parameter(Mandatory = $true)]
        [string]$PartnerNamespace
    )

    $maxAttempts = 6
    for ($attempt = 1; $attempt -le $maxAttempts; $attempt++) {
        try {
            return New-AzEventHubGeoDRConfiguration -Name $Name -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName -PartnerNamespace $PartnerNamespace
        }
        catch {
            if ($_.Exception.Message -match 'MetadataDROperationInProgressConflict' -and $attempt -lt $maxAttempts) {
                Start-TestSleep 30
                continue
            }

            throw
        }
    }
}

function Get-AzEventHubGeoDRConfigurationReadyForBreak {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$Name,

        [Parameter(Mandatory = $true)]
        [string]$ResourceGroupName,

        [Parameter(Mandatory = $true)]
        [string]$NamespaceName,

        [Parameter(Mandatory = $true)]
        [string]$PartnerNamespace
    )

    $maxAttempts = 6
    for ($attempt = 1; $attempt -le $maxAttempts; $attempt++) {
        $drConfig = Get-AzEventHubGeoDRConfiguration -Name $Name -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName

        if ($drConfig.ProvisioningState -eq 'Succeeded' -and $drConfig.Role -eq 'Primary' -and -not [string]::IsNullOrWhiteSpace($drConfig.PartnerNamespace)) {
            return $drConfig
        }

        if ([string]::IsNullOrWhiteSpace($drConfig.PartnerNamespace) -and $attempt -lt $maxAttempts) {
            $null = New-AzEventHubGeoDRConfigurationWithRetry -Name $Name -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName -PartnerNamespace $PartnerNamespace
        }

        if ($attempt -lt $maxAttempts) {
            Start-TestSleep 10
        }
    }

    return $drConfig
}

Describe 'Set-AzEventHubGeoDRConfigurationBreakPair' {
    It 'Break' -skip:$($env.secondaryLocation -eq '') {
        $drConfig = Get-AzEventHubGeoDRConfigurationReadyForBreak -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -PartnerNamespace $env.secondaryNamespaceResourceId

        Set-AzEventHubGeoDRConfigurationBreakPairWithRetry -InputObject $drConfig

        while ($drConfig.ProvisioningState -ne "Succeeded") {
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            Start-TestSleep 10
        }

        $drConfig.Name | Should -Be $env.alias
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.Role | Should -Be "Primary"

        $drConfig = New-AzEventHubGeoDRConfigurationWithRetry -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -PartnerNamespace $env.secondaryNamespaceResourceId

        while ($drConfig.ProvisioningState -ne "Succeeded") {
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            Start-TestSleep 10
        }
    }

    It 'BreakViaIdentity' -skip:$($env.secondaryLocation -eq '') {
        $drConfig = Get-AzEventHubGeoDRConfigurationReadyForBreak -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -PartnerNamespace $env.secondaryNamespaceResourceId

        Set-AzEventHubGeoDRConfigurationBreakPairWithRetry -InputObject $drConfig

        do {
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            Start-TestSleep 10
        } while ($drConfig.ProvisioningState -ne "Succeeded")

        $drConfig.Name | Should -Be $env.alias
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.PartnerNamespace | Should -Be ""
        $drConfig.Role | Should -Be "PrimaryNotReplicating"

        $drConfig = New-AzEventHubGeoDRConfigurationWithRetry -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -PartnerNamespace $env.secondaryNamespaceResourceId

        while ($drConfig.ProvisioningState -ne "Succeeded") {
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            Start-TestSleep 10
        }
    }
}
