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
	$rg1 = ("rg" + (RandomString $false 5))
	$name1 = ("MSTest.MyTest" + (RandomString $false 5))
	New-AzResourceGroup -Name $rg1 -Location "West US" | Out-Null
    # For any resources you created for test, you should add it to $env here.
	$env['ResourceGroup'] = $rg1
	$env['CustomProvider'] = $name1
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
	if ($env.ResourceGroup -ne $null)
	{
		Remove-AzResourceGroup -Name $env.ResourceGroup | Out-Null
	}
}

