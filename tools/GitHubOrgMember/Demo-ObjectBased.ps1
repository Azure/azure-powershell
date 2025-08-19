# Demonstration of Object-Based GitHub Organization Membership Checker

Write-Host "🚀 Object-Based Azure Membership Checker Demo" -ForegroundColor Cyan
Write-Host "=" * 50 -ForegroundColor Cyan

# Example 1: Simple membership check
Write-Host "`n📋 Example 1: Simple Check" -ForegroundColor Yellow
$result = .\Check-AzureOrgMembership.ps1 "vidai-msft" -Quiet 2>$null
Write-Host "User: $($result.Username)"
Write-Host "Is Member: $($result.IsMember)"
Write-Host "Status: $($result.Status)"

# Example 2: Batch processing with objects
Write-Host "`n📋 Example 2: Batch Processing" -ForegroundColor Yellow
$users = @("vidai-msft", "isra-fel", "msJinLei", "NickCandy")
$results = $users | ForEach-Object {
    .\Check-AzureOrgMembership.ps1 $_ -Quiet 2>$null
}

Write-Host "Batch Results:"
$results | Format-Table Username, IsMember, Status -AutoSize

# Example 3: Filtering and processing
Write-Host "`n📋 Example 3: Filter Members Only" -ForegroundColor Yellow
$members = $results | Where-Object { $_.IsMember }
Write-Host "Azure Members Found: $($members.Count)"
$members | ForEach-Object { Write-Host "  - $($_.Username)" -ForegroundColor Green }

# Example 4: JSON export
Write-Host "`n📋 Example 4: JSON Export" -ForegroundColor Yellow
$jsonResult = $results | ConvertTo-Json -Depth 2
Write-Host "Sample JSON (first result):"
$results[0] | ConvertTo-Json | Write-Host

# Example 5: Error handling
Write-Host "`n📋 Example 5: Error Handling" -ForegroundColor Yellow
$errorResult = $results | Where-Object { $_.Status -eq "Error" }
if ($errorResult.Count -gt 0) {
    Write-Host "Errors found:"
    $errorResult | ForEach-Object { Write-Host "  - $($_.Username): $($_.ErrorMessage)" -ForegroundColor Red }
} else {
    Write-Host "No errors detected" -ForegroundColor Green
}

# Example 6: Different organization
Write-Host "`n📋 Example 6: Different Organization" -ForegroundColor Yellow
$microsoftResult = .\Check-AzureOrgMembership.ps1 "vidai-msft" -Organization "microsoft" -Quiet 2>$null
Write-Host "Checking Microsoft org membership for vidai-msft:"
Write-Host "  Organization: $($microsoftResult.Organization)"
Write-Host "  Is Member: $($microsoftResult.IsMember)"
Write-Host "  Status: $($microsoftResult.Status)"

Write-Host "`n✨ Object-Based Advantages Demonstrated:" -ForegroundColor Cyan
Write-Host "  ✅ Type-safe property access" -ForegroundColor Green
Write-Host "  ✅ Easy filtering and processing" -ForegroundColor Green
Write-Host "  ✅ Pipeline-friendly operations" -ForegroundColor Green
Write-Host "  ✅ JSON serialization support" -ForegroundColor Green
Write-Host "  ✅ Structured error information" -ForegroundColor Green
Write-Host "  ✅ No exit code dependencies" -ForegroundColor Green
