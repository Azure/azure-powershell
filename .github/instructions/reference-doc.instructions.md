---
applyTo: "**/help/*.md"
---

## Reference help documentation requirements

When writing reference documents for PowerShell cmdlets, please follow these guidelines to ensure readability and helpfulness:

1. **Avoid over-simplified description** - For parameters and cmdlets, avoid over-simplified description such as "Some help", or simply repeating the parameter name.
2. **Ignore placeholders for -ProgressAction in PRs** - temporary placeholder descriptions for the `-ProgressAction` parameter (for example, `{{ Fill ProgressAction Description }}`) are expected, and the build tooling automatically removes this entire parameter section before release, so do not leave review comments on them.
