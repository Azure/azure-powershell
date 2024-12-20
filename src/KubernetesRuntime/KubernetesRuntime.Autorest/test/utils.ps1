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
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    # Install required modules
    Install-Module -Name Az.KubernetesConfiguration -AllowClobber -Scope CurrentUser -Force
    Install-Module -Name Az.ConnectedKubernetes -AllowClobber -Scope CurrentUser -Force
    Install-Module -Name Az.Aks -AllowClobber -Scope CurrentUser -Force
    Install-Module -Name Az.Resources -AllowClobber -Scope CurrentUser -RequiredVersion 6.16.2 -Force
    Import-Module Az.Resources
    Remove-Module Az.Resources.TestSupport

    # Prepare tested resources
    $aksName = RandomString -allChars $false -len 6
    # $aksName = "v7g9qa"

    $arcName = $aksName + "-arc"

    $env.Add("AksName", $aksName)
    $env.Add("ArcName", $arcName)
    $env.Add("Location", "eastus2euap")
    $resourceGroup = "k8sruntime-pwsh-test-rg-" + $env.AksName
    $env.Add("ResourceGroup", $resourceGroup)

    $sshKeyDir = "$([System.IO.Path]::GetTempPath())aksssh"

    $tempSshKeyPath = "$sshKeyDir/id_rsa"
    $env.Add("SshKeyPath", $tempSshKeyPath)

    write-host "1. start to create test group..."
    New-AzResourceGroup -Name $env.ResourceGroup -Location $env.location -Force

    write-host "2. az aks create..."
    if (Test-Path $sshKeyDir) {
        Remove-Item -Recurse -Force $sshKeyDir
    }
    New-Item -Path $sshKeyDir -Force -ItemType Directory
    

    ssh-keygen -b 2048 -t rsa -f $tempSshKeyPath -q -N '""'
    New-AzAksCluster -Name $env.AksName -ResourceGroupName $env.ResourceGroup -SshKeyValue "${tempSshKeyPath}.pub" -Location $env.Location

    write-host "3. az aks get-credentials..."
    Import-AzAksCredential -Name $env.AksName -ResourceGroupName $env.ResourceGroup -Force

    write-host "4. az connectedk8s connect..."
    New-AzConnectedKubernetes -ClusterName $env.ArcName -ResourceGroupName $env.ResourceGroup -Location $env.Location

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.resourceGroup
    # Remove-Item -Path $env.SshKeyPath
    # Remove-Item -Path ${env.SshKeyPath}.pub
}

