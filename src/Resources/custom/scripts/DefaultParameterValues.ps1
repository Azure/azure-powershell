$exportsPath = Join-Path $PSScriptRoot "..\..\exports"
$cmdlets = (Get-ChildItem -Path $exportsPath -Include *.ps1 -Recurse).Name -replace ".ps1", ""
$cmdlets | %{$global:PSDefaultParameterValues[$_ + ":SubscriptionId"] = {(Get-AzContext).Subscription.Id}}
$cmdlets | %{$global:PSDefaultParameterValues[$_ + ":TenantId"] = {(Get-AzContext).Tenant.Id}}