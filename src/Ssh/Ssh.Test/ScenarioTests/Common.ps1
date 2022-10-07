function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

function Get-RandomArcName
{
    return 'arc-' + (RandomString -allChars $false -len 6)
}

function Get-RandomVmName
{
    return 'vm-' + (RandomString -allChars $false -len 6)
}

function Get-RandomResourceGroupName 
{
    return 'rg-' + (RandomString -allChars $false -len 6)
}

function Get-PasswordForVM
{
    return (RandomString -allChars $false -len 4) + "-" + (RandomString -allChars $false -len 4) + (Get-Random -Minimum 100 -Maximum 999)
}

function IsPlayback
{
	return [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback
}


function Get-AzAccessToken {
    $Account = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Account
    $AzureEnv = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[[Microsoft.Azure.Commands.Common.Authentication.Abstractions.EnvironmentName]::AzureCloud]
    $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
    $PromptBehavior = [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never
    $Token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($account, $AzureEnv, $tenantId, $null, $promptBehavior, $null)
    return $Token.AccessToken
}

function installArcAgent() {
    
    if ($IsMacOS) {
        throw "Arc Server Tests can't run on macOS because they require the azcmagent."
    }

    # Install azcmagent
    if ($IsLinux) {
        # Download the installation package
        Invoke-RestMethod -Uri https://aka.ms/azcmagent -OutFile ~/install_linux_azcmagent.sh -UseBasicParsing

        # Install the hybrid agent
        bash ~/install_linux_azcmagent.sh | ForEach-Object {
            Write-Host $_
        }

        # Set executable path
        return "azcmagent"
    } else {
        Invoke-RestMethod -Uri https://aka.ms/AzureConnectedMachineAgent -OutFile AzureConnectedMachineAgent.msi -UseBasicParsing

        # Install the package
        msiexec /i AzureConnectedMachineAgent.msi /l*v installationlog.txt /qn | ForEach-Object {
            Write-Host $_
        }

        # Set executable path
       return "$env:ProgramFiles\AzureConnectedMachineAgent\azcmagent.exe"
    }
}


function Start-Agent {
    [CmdletBinding()]
    param (
        # Machine name
        [Parameter(Mandatory)]
        [string]
        $MachineName,

        # Resource Group name
        [Parameter(Mandatory)]
        [string]
        $ResourceGroupName,

        # Subscription ID
        [Parameter(Mandatory)]
        [string]
        $SubscriptionId,

        # Tenant ID
        [Parameter(Mandatory)]
        [string]
        $TenantId,

        # Arc Agent Path
        [Parameter(Mandatory)]
        [string]
        $Agent
    )
    
    $azcmagentArgs = @(
        'connect'
        '--resource-group'
        $ResourceGroupName
        '--tenant-id'
        $TenantId
        '--location'
        'eastus'
        '--subscription-id'
        $SubscriptionId
        '--access-token'
        (Get-AzAccessToken)
        '--resource-name'
        $MachineName
    )

    Write-Host "Starting Agent..." -ForegroundColor Cyan
    if ($IsLinux) {
        return sudo $Agent @azcmagentArgs 
    }
    & $Agent @azcmagentArgs
}

function Stop-Agent {
    [CmdletBinding()]
    param (
        # Path to agent
        [Parameter(Mandatory)]
        [string]
        $AgentPath
    )

    Write-Host "Stopping Agent..." -ForegroundColor Cyan
    if ($IsLinux) {
        return sudo $AgentPath disconnect --access-token (Get-AzAccessToken)
    }
    & $AgentPath disconnect --access-token (Get-AzAccessToken)
}
