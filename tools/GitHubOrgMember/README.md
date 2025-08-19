# GitHub Azure Organization Membership Checker

PowerShell script to check if a GitHub user is a member of the Azure GitHub organization using the GitHub CLI. Returns structured PowerShell objects for easy processing and integration.

## Prerequisites

1. **GitHub CLI**: Install from [https://cli.github.com/](https://cli.github.com/)
2. **Authentication**: Run `gh auth login` to authenticate with GitHub

## Script

### Check-AzureOrgMembership.ps1 (Object-Based)

A PowerShell script that returns structured objects with membership information.

**Usage:**
```powershell
# Basic usage - returns object
$result = .\Check-AzureOrgMembership.ps1 "username"

# Quiet mode - suppresses console output
$result = .\Check-AzureOrgMembership.ps1 "username" -Quiet

# Different organization
$result = .\Check-AzureOrgMembership.ps1 "username" -Organization "microsoft"

# Check result
if ($result.IsMember) {
    Write-Host "$($result.Username) is a member!"
}
```

**Features:**
- Returns structured PowerShell objects
- JSON serializable
- Pipeline-friendly
- Comprehensive error handling
- Configurable organization
- Quiet mode support
- Type-safe property access

## Object Structure

The script returns a `PSCustomObject` with the following properties:

```powershell
@{
    Username = "string"           # The checked username
    Organization = "string"       # The organization that was checked
    IsMember = $true/$false      # Boolean indicating if user is a public member
    Status = "string"            # Detailed status (see below)
    ErrorMessage = "string"      # Error details if Status is Error
    CheckedAt = [DateTime]       # Timestamp of when the check was performed
}
```

### Status Values

- **`PublicMember`**: User is a confirmed public member
- **`NotMemberOrPrivate`**: User is either not a member or has private membership
- **`UserNotFound`**: The specified username doesn't exist on GitHub
- **`Error`**: An error occurred (see ErrorMessage for details)

## Important Notes

1. **Privacy**: GitHub organization membership can be set to private. If a user is a private member, the API will return the same response as if they're not a member.

2. **Authentication**: The GitHub CLI must be authenticated to make API calls. Some organization information may require different permission levels.

3. **Rate Limiting**: GitHub API has rate limits. For bulk checking, consider implementing delays between requests.

## Examples

### Example 1: Basic Object-Based Check

```powershell
$result = .\Check-AzureOrgMembership.ps1 "vidai-msft"
Write-Host "User: $($result.Username)"
Write-Host "Is Member: $($result.IsMember)"
Write-Host "Status: $($result.Status)"
```

**Output:**
```
🔍 Checking if 'vidai-msft' is a member of 'Azure' organization...
✅ vidai-msft is a PUBLIC member of the Azure organization!
User: vidai-msft
Is Member: True
Status: PublicMember
```

### Example 2: Quiet Mode Processing

```powershell
$result = .\Check-AzureOrgMembership.ps1 "vidai-msft" -Quiet
if ($result.IsMember) {
    Write-Host "Welcome, Azure team member!" -ForegroundColor Green
} else {
    Write-Host "Access denied." -ForegroundColor Red
}
```

### Example 3: Batch Processing Multiple Users

```powershell
$users = @("vidai-msft", "isra-fel", "msJinLei", "NickCandy")
$results = $users | ForEach-Object {
    .\Check-AzureOrgMembership.ps1 $_ -Quiet
}

# Display results in a table
$results | Format-Table Username, IsMember, Status -AutoSize

# Filter to show only members
$members = $results | Where-Object { $_.IsMember }
Write-Host "Azure Members: $($members.Count)"
```

**Sample Output:**
```
Username   IsMember Status
--------   -------- ------
vidai-msft     True PublicMember
isra-fel       True PublicMember
msJinLei      False NotMemberOrPrivate
NickCandy     False NotMemberOrPrivate

Azure Members: 2
```

### Example 4: JSON Export for APIs

```powershell
$result = .\Check-AzureOrgMembership.ps1 "vidai-msft" -Quiet
$jsonOutput = $result | ConvertTo-Json
Write-Host $jsonOutput
```

**Sample JSON Output:**
```json
{
  "Username": "vidai-msft",
  "Organization": "Azure",
  "IsMember": true,
  "Status": "PublicMember",
  "ErrorMessage": null,
  "CheckedAt": "2025-08-18T14:05:32.1234567-07:00"
}
```

### Example 5: Error Handling

```powershell
$result = .\Check-AzureOrgMembership.ps1 "non-existent-user" -Quiet
if ($result.Status -eq "Error") {
    Write-Warning "Error: $($result.ErrorMessage)"
} elseif ($result.Status -eq "UserNotFound") {
    Write-Host "User not found on GitHub"
}
```

### Example 6: Different Organization

```powershell
$result = .\Check-AzureOrgMembership.ps1 "vidai-msft" -Organization "microsoft" -Quiet
Write-Host "$($result.Username) is a member of $($result.Organization): $($result.IsMember)"
```

## Troubleshooting

### GitHub CLI Not Found
```
Install GitHub CLI from: https://cli.github.com/
```

### Not Authenticated
```powershell
gh auth login
```

### Permission Issues
If you get permission errors, ensure your GitHub token has the necessary scopes for reading organization membership.

## Testing

This project includes comprehensive testing for the object-based script.

### Running Tests

```powershell
# Run comprehensive object-based tests
.\Test-ObjectBased.ps1
```

### Quick Test

The object-based approach makes testing much simpler:

```powershell
# Test multiple users and validate results
$testUsers = @{
    "vidai-msft" = $true      # Should be member
    "msJinLei" = $false       # Should not be member
}

foreach ($user in $testUsers.Keys) {
    $result = .\Check-AzureOrgMembership.ps1 $user -Quiet
    $expected = $testUsers[$user]

    if ($result.IsMember -eq $expected) {
        Write-Host "✅ $user test passed" -ForegroundColor Green
    } else {
        Write-Host "❌ $user test failed" -ForegroundColor Red
    }
}
```

## Object-Based Advantages

### ✅ **Structured Data**
- Type-safe property access
- No string parsing required
- Consistent object structure

### ✅ **Pipeline Friendly**
```powershell
# Easy filtering and processing
$results | Where-Object { $_.IsMember } | Select-Object Username, Status
```

### ✅ **JSON Serializable**
```powershell
# Perfect for APIs and data storage
$results | ConvertTo-Json | Out-File "membership-results.json"
```

### ✅ **Error Handling**
```powershell
# Structured error information
if ($result.Status -eq "Error") {
    Write-Warning $result.ErrorMessage
}
```

### ✅ **No Exit Codes**
- No dependency on `$LASTEXITCODE`
- Works naturally with PowerShell objects
- Easier debugging and testing

## Important Notes

1. **Privacy**: GitHub organization membership can be set to private. If a user is a private member, the API will return the same response as if they're not a member.

2. **Authentication**: The GitHub CLI must be authenticated to make API calls. Some organization information may require different permission levels.

3. **Rate Limiting**: GitHub API has rate limits. For bulk checking, consider implementing delays between requests.

## Exit Codes

- `0`: User is a confirmed public member
- `1`: User is not a member, has private membership, doesn't exist, or an error occurred
