function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.ResourceGroupName = 'az-sdk-test-powershell-rg-' + (RandomString -allChars $false -len 6)
    $env.Location = 'eastus2euap'
    $env.MachineName = (RandomString -allChars $false -len 6)
    $env.PrivateLinkScopeName = 'scope-' + (RandomString -allChars $false -len 6)
    New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location | Out-Null

    if ($IsMacOS) {
        throw "Tests can't run on macOS because they require the azcmagent."
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
        $env.azcmagentPath = "azcmagent"
    } else {
        Invoke-RestMethod -Uri https://aka.ms/AzureConnectedMachineAgent -OutFile AzureConnectedMachineAgent.msi -UseBasicParsing

        # Install the package
        msiexec /i AzureConnectedMachineAgent.msi /l*v installationlog.txt /qn | ForEach-Object {
            Write-Host $_
        }

        # Set executable path
        $env.azcmagentPath = "$env:ProgramFiles\AzureConnectedMachineAgent\azcmagent.exe"
    }

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    Set-Content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroupName
}
