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
    Write-Host -ForegroundColor Yellow "WARNING: Expected that the user has kubeconfig and cluster-admin access as well helm3 installed, please check if installed Helm3 and Kubectl."
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.resourceGroup = 'connaks-rg-' + (RandomString -allChars $false -len 6)
    $env.location = 'eastus'
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.Location

    $connaksName00 = 'connaks-' + (RandomString -allChars $false -len 6)
    $connaksName01 = 'connaks-' + (RandomString -allChars $false -len 6)
    $connaksName02 = 'connaks-' + (RandomString -allChars $false -len 6)
    $connaksName03 = 'connaks-' + (RandomString -allChars $false -len 6)
    $env.Add('connaksName00', $connaksName00)
    $env.Add('connaksName01', $connaksName01)
    $env.Add('connaksName02', $connaksName02)
    $env.Add('connaksName03', $connaksName03)

    $kubeContext = 'portal-aks-t01'
    $env.Add('kubeContext', $kubeContext)
    New-AzConnectedKubernetes -ClusterName $env.connaksName00 -ResourceGroupName $env.resourceGroup -Location $env.location
    New-AzConnectedKubernetes -ClusterName $env.connaksName01 -ResourceGroupName $env.resourceGroup -Location $env.location -KubeConfig $HOME\.kube\config -KubeContext $kubeContext

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroup
}

