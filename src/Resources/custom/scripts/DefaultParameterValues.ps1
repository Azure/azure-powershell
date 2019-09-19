$exportsPath = Join-Path $PSScriptRoot "..\..\exports"
$cmdlets = (Get-ChildItem -Path $exportsPath -Include *.ps1 -Recurse).Name -replace ".ps1", ""
$cmdlets | %{if (![string]::IsNullOrWhitespace($_)) {$global:PSDefaultParameterValues[$_ + ":SubscriptionId"] = {(Get-AzContext).Subscription.Id}}}
$cmdlets | %{if (![string]::IsNullOrWhitespace($_)) {$global:PSDefaultParameterValues[$_ + ":TenantId"] = {(Get-AzContext).Tenant.Id}}}
