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
    # IMPORTANT: This function executes in -Record mode. The env.json values need to be populated here manually.
    $envFile = Get-Content -Path (Join-Path -Path $PSScriptRoot -ChildPath 'env.json') | ConvertFrom-Json
    $env.Add("tenant", (Get-AzContext).Tenant.Id)
    $env.Add("subscriptionID", (Get-AzContext).Subscription.Id)
    $env.Add("resourceGroupName", $envFile.resourceGroupName)
    $env.Add("customLocationName", $envFile.customLocationName)
    $env.Add("customLocationID", $envFile.customLocationID)
    $env.Add("lnetID", $envFile.lnetID)
    $env.Add("clusterName", $envFile.clusterName)
    $env.Add("location", $envFile.location)
    $env.Add("mocVnetName", $envFile.mocVnetName)
    $env.Add("tempProvisionedClusterControlPlaneIP", $envFile.tempProvisionedClusterControlPlaneIP)
    $env.Add("testAADGroupName", $envFile.testAADGroupName)
    $env.Add("testGroupOID", (Get-AzADGroup -DisplayName $env.testAADGroupName).Id)
    # Create random identifiers for resources to avoid resource conflicts when tests are ran one after another.
    Import-Module (Join-Path -Path $PSScriptRoot -ChildPath 'AzAksArcTestHelper.psm1')
    $uniqueNumbers = Get-RandomNumbers -Count 3
    # Nodepool names must be lowercase and can only contain letters and numbers.
    $env.Add("updatePool1", "updatepool1$($uniqueNumbers[0])")
    $env.Add("updatePool2", "updatepool2$($uniqueNumbers[1])")
    $env.Add("newPool1", "newpool1$($uniqueNumbers[0])")
    $env.Add("newPool2", "newpool2$($uniqueNumbers[1])")
    $env.Add("newPool3", "newpool3$($uniqueNumbers[2])")
    $env.Add("rmPool1", "rmpool1$($uniqueNumbers[0])")
    $env.Add("rmPool2", "rmpool2$($uniqueNumbers[1])")
    $env.Add("newCluster1", "newCluster1$($uniqueNumbers[0])")
    $env.Add("newCluster2", "newCluster2$($uniqueNumbers[1])")
    $env.Add("newCluster3", "newCluster3$($uniqueNumbers[2])")
    $env.Add("updateCluster", "updateCluster$($uniqueNumbers[0])")
    $env.Add("upgradeCluster1", "upgradeCluster1$($uniqueNumbers[0])")
    $env.Add("upgradeCluster2", "upgradeCluster2$($uniqueNumbers[1])")
    # Create a provisioned cluster to be used by all tests if it doesn't already exist.
    $cluster = $null
    try {
        $cluster = Get-AzAksArcCluster `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName
    } catch {
        if (!($_.Exception.Message -like "*ResourceNotFound*")) {
            throw $_
        }
    }
    $sshPath = Join-Path -Path $PSScriptRoot -ChildPath "test-rsa"
    if (!(Test-Path -Path $sshPath)) {
        apt update
        apt install openssh-client
        # Requires running pwsh in the autorest Linux container.
        # Below PowerShell 7.3, the double quotes need to be in single quotes like '""' due to earlier versions
        # dropping "" as a parameter.
        ssh-keygen -t rsa -b 4096 -N "" -C "" -f $sshPath
    }
    $ssh = (Get-Content -Path "${sshPath}.pub" -Raw).Trim()
    if ($null -eq $cluster) {
        # The default control plane IP is selected from an available IP range in the logical network.
        New-AzAksArcCluster `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName  `
            -CustomLocationName $env.customLocationName `
            -VnetId $env.lnetID `
            -SshKeyValue $ssh
    }
}
function cleanupEnv() {
    # Please clean up your test resources manually. 
    # This is so we can use the same provisioned cluster every time we run test-module.ps1 and to prevent having to 
    # recreate the provisioned cluster for every test-module.ps1 call.
}