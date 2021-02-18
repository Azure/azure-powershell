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
    Write-Host -ForegroundColor Yellow "WARNNING: Plese provide resource group with Azure Arc enabled Kubernetes."
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'eastus'

    # Can't Azure Arc enabled Kubernetes via powershell(Kubernetes model not released) and New-AzDeployment(The template file Can't exported.)
    # TODO: Kubernetes model be release or The template file can be export.
    $env.resourceGroup = 'connaks-rg-w9vlnp' # 'kubconfig-rg-' + (RandomString -allChars $false -len 6)
    # kubernetes in connaks-rg-w9vlnp
    $env.kubernetesName00 = 'connaks-d983yc' 
    $env.kubernetesName01 = 'connaks-dkc29c'

    $env.kubConf00 = 'kubconf-' + (RandomString -allChars $false -len 6) + '-test'
    $env.kubConf01 = 'kubconf-' + (RandomString -allChars $false -len 6) + '-test'


    Write-Host -ForegroundColor Green "Start creating kubernetes connected for test..."
    New-AzKubernetesConfiguration -Name $env.kubConf00 -ClusterName $env.kubernetesName00 -ResourceGroupName $env.resourceGroup -RepositoryUrl http://github.com/xxxx
    Write-Host -ForegroundColor Green "Kubernetes connected created successfully."
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}

