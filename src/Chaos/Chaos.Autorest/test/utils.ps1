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

    $targetName1 = "microsoft-virtualmachine" # "a" + (RandomString -allChars $false -len 6)
    $experimentName1 = "azps-experiment-test" # "a" + (RandomString -allChars $false -len 6)
    $targetName2 = "microsoft-virtualmachine" # "a" + (RandomString -allChars $false -len 6)
    $experimentName2 = "a" + (RandomString -allChars $false -len 6)
    
    $env.Add("targetName1", $targetName1)
    $env.Add("experimentName1", $experimentName1)
    $env.Add("targetName2", $targetName2)
    $env.Add("experimentName2", $experimentName2)

    $executionId = "01A16FE8-7E5A-4F0E-BBA5-39A760547872"
    $env.Add("executionId", $executionId)

    $virtualMachine1 = "azpstest1"
    $env.Add("virtualMachine1", $virtualMachine1)

    $virtualMachine2 = "azpstest2"
    $env.Add("virtualMachine2", $virtualMachine2)

    $env.Add("location", "eastus")

    ########################## Before running Recode mode, make sure that the: 
    #  Create Virtual machine named azpstest1 and azpstest2
    #  Create targetName1 targetName2 in two VMs
    #  Create experimentName1 and capability in targetName1
    #  Give experimentName1 permission to VM azpstest1  (https://learn.microsoft.com/en-us/azure/chaos-studio/chaos-studio-quickstart-azure-portal#give-experiment-permission-to-your-vm)
    #  Run Start-* and Stop-* and copy executionId

    write-host "start to create test group"
    $resourceGroup = "azps_test_group_chaos"
    $env.Add("resourceGroup", $resourceGroup)

    # New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    $propertyTarget = @{"type" = "CertificateSubjectIssuer"; "subject" = "CN=example.subject" }
    $propertyTargetArr = @($propertyTarget)
    $identitiesTarget = @{"identities" = $propertyTargetArr }
    New-AzChaosTarget -Name $env.targetName2 -ParentResourceName $env.virtualMachine2 -ResourceGroupName $env.resourceGroup -Location $env.location -Property $identitiesTarget -ParentProviderNamespace Microsoft.Compute -ParentResourceType virtualMachines

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

