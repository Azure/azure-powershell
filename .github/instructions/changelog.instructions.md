---
applyTo: "**/ChangeLog.md"
---

# ChangeLog.md Files

When working with ChangeLog.md files in the Azure PowerShell repository, follow these specific guidelines:

## Target Audience
- The primary audience is **Azure PowerShell users**, not developers
- Write entries from the user's perspective, focusing on impact and functionality
- Explain what changed and how it affects their usage

## Content Guidelines

### Acronym Usage
- **Always explain less-obvious acronyms** on first use in a release section
- Examples:
  - "ARM (Azure Resource Manager)" 
  - "RBAC (Role-Based Access Control)"
  - "VM (Virtual Machine)"
- Common acronyms like "API", "URL", "CLI" may be used without explanation

### Issue References
- **Always reference related GitHub issues** when applicable
- Use the format: `[#12345]` or `Fixed issue [#12345]`
- Include issue references for bug fixes, feature implementations, and breaking changes

### Character Restrictions
- **Avoid special characters** that could cause issues in PowerShell module manifests (.psd1 files)
- Problematic characters to avoid: `@`, `$`, backticks (`` ` ``), unescaped quotes
- Use simple punctuation: periods, commas, hyphens, parentheses
- When referencing PowerShell code, use simple quotes: 'Get-AzVM' instead of `Get-AzVM`

## Entry Format
Follow this structure for changelog entries:
```
## Version X.Y.Z
* Description of change that impacts users
    - Additional context or technical details
    - Reference to issue: [#12345]
```

## Examples

### Good Examples
```markdown
## Version 1.2.0
* Added support for Private Link in 'New-AzStorageAccount'
    - Users can now create storage accounts with private endpoints
    - Fixed issue [#23456]
* Fixed parameter validation in 'Set-AzVirtualMachine'
    - VM (Virtual Machine) size parameter now properly validates against available SKUs
    - Resolves authentication errors reported in [#23457]
```

### Avoid
```markdown
## Version 1.2.0  
* Fixed `Get-AzVM` cmdlet @parameter issue with $null values
* Added PL support (unclear acronym)
* Various bug fixes (not specific enough)
```

## Version Ordering
- Always add new entries under "## Upcoming Release" at the top
- Maintain reverse chronological order (newest first)
- Follow semantic versioning format: Major.Minor.Patch