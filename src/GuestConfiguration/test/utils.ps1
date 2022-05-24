function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
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
    # For any resources you created for test, you should add it to $env here.
    $guestConfigName = RandomString -allChars $false -len 6
    $assignmentName = RandomString -allChars $false -len 6
    $reportName = RandomString -allChars $false -len 6
    
    $resourcegroupName = "ps-$(RandomString -allChars $false -len 4)-rg"
    $location = "westcentralus"
    $rg = New-AzResourceGroup -Location $location -Name $resourcegroupName

    $vmName = "ps-$(RandomString -allChars $false -len 4)-vm"
    $vmssName = "ps-$(RandomString -allChars $false -len 4)-vmss"
    $vmAdmin = "ps-$(RandomString -allChars $false -len 4)-admin"
    $vmPwd = ConvertTo-SecureString "$(RandomString -allChars $false -len 4)Pw.@0" -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential ($vmAdmin, $vmPwd)
    
    $vm = New-AzVM -Name $vmName -Credential $credential -ResourceGroupName $resourcegroupName
    $vmss = New-AzVmss -VMScaleSetName $vmssName -Credential $credential -ResourceGroupName $resourcegroupName

    # Cache variable
    $guestConfigName = $env.AddWithCache("guestConfigName", $guestConfigName, $UsePreviousConfigForRecord)
    $assignmentName = $env.AddWithCache("assignmentName", $assignmentName, $UsePreviousConfigForRecord)
    $reportName = $env.AddWithCache("reportName", $reportName, $UsePreviousConfigForRecord)

    $resourcegroupName = $env.AddWithCache("resourcegroupName", $resourcegroupName, $UsePreviousConfigForRecord)
    $location = $env.AddWithCache("location", $location, $UsePreviousConfigForRecord)
    $rg = $env.AddWithCache("rg", $rg, $UsePreviousConfigForRecord)

    $vmName = $env.AddWithCache("vmName", $vmName, $UsePreviousConfigForRecord)
    $vmssName = $env.AddWithCache("vmssName", $vmssName, $UsePreviousConfigForRecord)
    $vmAdmin = $env.AddWithCache("vmAdmin", $vmAdmin, $UsePreviousConfigForRecord)
    $vmPwd = $env.AddWithCache("vmPwd", $vmPwd, $UsePreviousConfigForRecord)
    $credential = $env.AddWithCache("credential", $credential, $UsePreviousConfigForRecord)

    $vm = $env.AddWithCache("vm", $vm, $UsePreviousConfigForRecord)
    $vmss = $env.AddWithCache("vmss", $vmss, $UsePreviousConfigForRecord)

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourcegroupName
}

