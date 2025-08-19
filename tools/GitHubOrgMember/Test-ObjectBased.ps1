# Object-Based Test Runner for Azure Organization Membership Checker
# This script demonstrates the object-based approach

Write-Host "🧪 Testing Object-Based Azure Organization Membership Checker" -ForegroundColor Cyan
Write-Host "=" * 60 -ForegroundColor Cyan

# Test data
$AzureMembers = @("vidai-msft", "isra-fel", "wyunchi-ms")
$NonMembers = @("azure-powershell-bot", "msJinLei", "NickCandy")

# Test 1: Prerequisites
Write-Host "`n📋 Test 1: Prerequisites Check" -ForegroundColor Yellow
$prereqResult = .\Check-AzureOrgMembership.ps1 "test-user" -Quiet
if ($prereqResult.Status -eq "Error" -and $prereqResult.ErrorMessage -match "GitHub CLI") {
    Write-Host "  ❌ $($prereqResult.ErrorMessage)" -ForegroundColor Red
    exit 1
} else {
    Write-Host "  ✅ GitHub CLI is available and authenticated" -ForegroundColor Green
}

# Test 2: Azure Members
Write-Host "`n📋 Test 2: Azure Members Testing" -ForegroundColor Yellow
$memberResults = @()
foreach ($member in $AzureMembers) {
    $result = .\Check-AzureOrgMembership.ps1 $member -Quiet
    $memberResults += $result

    if ($result.IsMember -and $result.Status -eq "PublicMember") {
        Write-Host "  ✅ $member correctly identified as Azure member" -ForegroundColor Green
    } else {
        Write-Host "  ❌ $member test failed - IsMember: $($result.IsMember), Status: $($result.Status)" -ForegroundColor Red
    }
}

# Test 3: Non-Members
Write-Host "`n📋 Test 3: Non-Members Testing" -ForegroundColor Yellow
$nonMemberResults = @()
foreach ($nonMember in $NonMembers) {
    $result = .\Check-AzureOrgMembership.ps1 $nonMember -Quiet
    $nonMemberResults += $result

    if (-not $result.IsMember -and $result.Status -eq "NotMemberOrPrivate") {
        Write-Host "  ✅ $nonMember correctly identified as non-member" -ForegroundColor Green
    } else {
        Write-Host "  ❌ $nonMember test failed - IsMember: $($result.IsMember), Status: $($result.Status)" -ForegroundColor Red
    }
}

# Test 4: Object Structure Validation
Write-Host "`n📋 Test 4: Object Structure Validation" -ForegroundColor Yellow
$sampleResult = $memberResults[0]
$requiredProperties = @("Username", "Organization", "IsMember", "Status", "ErrorMessage", "CheckedAt")
$allPropertiesPresent = $true

foreach ($prop in $requiredProperties) {
    if ($sampleResult.PSObject.Properties.Name -contains $prop) {
        Write-Host "  ✅ Property present: $prop" -ForegroundColor Green
    } else {
        Write-Host "  ❌ Missing property: $prop" -ForegroundColor Red
        $allPropertiesPresent = $false
    }
}

if ($allPropertiesPresent) {
    Write-Host "  ✅ All required properties present in result objects" -ForegroundColor Green
} else {
    Write-Host "  ❌ Result object structure validation failed" -ForegroundColor Red
}

# Test 5: JSON Serialization
Write-Host "`n📋 Test 5: JSON Serialization Test" -ForegroundColor Yellow
try {
    $jsonOutput = $sampleResult | ConvertTo-Json
    $deserializedResult = $jsonOutput | ConvertFrom-Json

    if ($deserializedResult.Username -eq $sampleResult.Username) {
        Write-Host "  ✅ Objects properly serialize to/from JSON" -ForegroundColor Green
    } else {
        Write-Host "  ❌ JSON serialization test failed" -ForegroundColor Red
    }
} catch {
    Write-Host "  ❌ JSON serialization error: $($_.Exception.Message)" -ForegroundColor Red
}

# Summary
Write-Host "`n🎉 Object-Based Test Suite Complete!" -ForegroundColor Green
Write-Host "📊 Summary:" -ForegroundColor Cyan
Write-Host "  - Azure Members: $($AzureMembers.Count) tested" -ForegroundColor White
Write-Host "  - Non-Members: $($NonMembers.Count) tested" -ForegroundColor White
Write-Host "  - All results returned as structured PowerShell objects" -ForegroundColor White

# Display sample object
Write-Host "`n📄 Sample Result Object:" -ForegroundColor Cyan
$sampleResult | Format-List

Write-Host "✨ Benefits of Object-Based Approach:" -ForegroundColor Yellow
Write-Host "  - No exit code parsing required" -ForegroundColor White
Write-Host "  - Structured data easy to process" -ForegroundColor White
Write-Host "  - JSON serializable for APIs" -ForegroundColor White
Write-Host "  - Type-safe property access" -ForegroundColor White
Write-Host "  - Pipeable and filterable" -ForegroundColor White
