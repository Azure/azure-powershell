function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.ResourceGroupName = 'ytongtest'
    $env.ResourceGroupNameProfile = 'PayGo_cmdlet'
    $env.Location = 'eastus'
    $env.MachineName = 'testmachine'
    $env.MachineNameSA = 'WIN-A3C7NS0B144'
    $env.MachineNamePaygo = 'WIN-IAH3TLSP7A8'
    $env.PrivateLinkScopeName = 'myScope3'
    $env.RunCommandName = 'myRunCommand3'
    $env.Script = 'Write-Host Hello World!'
    $env.EsuLicenseName = 'myEsuLicense2'
    $env.PrivateLinkScopeUri = '/subscriptions/b24cc8ee-df4f-48ac-94cf-46edf36b0fae/resourceGroups/ytongtest/providers/Microsoft.HybridCompute/privateLinkScopes/myScope3'
    $env.ExtensionName = 'networkWatcher'
    $env.PerimeterName = 'a12ebbfe-c600-4964-b1aa-1b302b91d074.testAssociation'
    $env.LicenseResourceId = '/subscriptions/b24cc8ee-df4f-48ac-94cf-46edf36b0fae/resourceGroups/ytongtest/providers/Microsoft.HybridCompute/licenses/myLicense'
    $env.LicenseResourceIdProfile = '/subscriptions/b24cc8ee-df4f-48ac-94cf-46edf36b0fae/resourceGroups/edyoung/providers/Microsoft.HybridCompute/licenses/myLicense' 

    #New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location | Out-Null

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
    #Remove-AzResourceGroup -Name $env.ResourceGroupName
}
