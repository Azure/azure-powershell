# AutoRest README.md Files

When working with README.md files in AutoRest projects (*.Autorest directories), follow these specific guidelines for API specification references and directive documentation:

## API Specification References

### Always Use Commit Hash
- **Never reference API specifications using branch names** (e.g., `main`, `master`)
- **Always use specific commit hashes** to ensure reproducible builds
- This prevents breaking changes when the specification repository evolves

### Examples

#### Good - Commit Hash Reference
```yaml
# lock the commit
commit: 4442e8121686218ce2951ab4dc734e489aa5bc08
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/quota/resource-manager/Microsoft.Quota/stable/2023-02-01/quota.json
```

#### Avoid - Branch Reference
```yaml
# Don't do this - branch references can change
branch: main
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/quota/resource-manager/Microsoft.Quota/stable/2023-02-01/quota.json
```

### Updating Specifications
- When updating to a newer API specification, update the commit hash
- Document the reason for the specification update in commit messages
- Test thoroughly after specification updates

## Directive Documentation

### Write Comments for All Directives
- **Every directive should have a comment explaining its purpose**
- Comments should explain the "why" not just the "what"
- Help future maintainers understand the intention behind customizations

### Directive Comment Patterns

#### Model Modifications
```yaml
directive:
  # Remove cmdlets that are not supported in the current API version
  - where:
      verb: Set
    remove: true

  # Simplify parameter names for better PowerShell experience
  - where:
      subject: ConfigProfile
      parameter-name: ConfigurationProfileAssignmentName
    set:
      parameter-name: Name
```

#### Property Customizations
```yaml
directive:
  # Configure table formatting to show most relevant properties first
  - where:
      model-name: SupportTicketDetails
    set:
      format-table:
        properties:
          - Name
          - Title
          - SupportTicketId
          - Severity
          - ServiceDisplayName
          - CreatedDate
```

#### API Filtering
```yaml
directive:
  # Remove preview API operations that are not ready for public use
  - where:
      subject: ^ConfigProfileVersion$
    remove: true
    
  # Hide internal-only cmdlets from public interface
  - where:
      verb: Invoke
      subject: UploadFile
    hide: true
```

### Comment Guidelines

#### Be Specific About Purpose
```yaml
# Good - Explains the business reason
# Remove Set cmdlets because they are not supported in this API version
- where:
    verb: Set
  remove: true

# Avoid - Too generic
# Remove cmdlets
- where:
    verb: Set
  remove: true
```

#### Explain Complex Transformations
```yaml
# Good - Explains the technical reasoning
# Transform parameter validation to handle special case where top=0 disables pagination
- from: GetAzSupportTicket_List.cs
  where: $
  transform: $ = $.replace("!String.IsNullOrEmpty(_nextLink)" ,"!String.IsNullOrEmpty(_nextLink) && this._top <= 0");

# Better - More detailed explanation
# Fix pagination logic: when Top parameter is 0, disable automatic pagination
# This prevents infinite loops when users explicitly request no pagination
- from: GetAzSupportTicket_List.cs
  where: $
  transform: $ = $.replace("!String.IsNullOrEmpty(_nextLink)" ,"!String.IsNullOrEmpty(_nextLink) && this._top <= 0");
```

## README Structure Best Practices

### Standard Sections
Include these sections in AutoRest README.md files:

1. **Module Overview** - Brief description of the Azure service
2. **Module Requirements** - Az.Accounts version requirements
3. **Authentication** - How authentication is handled
4. **Development** - Link to how-to.md for development instructions
5. **AutoRest Configuration** - YAML configuration with well-commented directives

### Example Template
```markdown
# Az.ServiceName
This directory contains the PowerShell module for the [Azure Service Name].

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts.

## Development
For information on how to develop for `Az.ServiceName`, see [how-to.md](how-to.md).

### AutoRest Configuration

``` yaml
# Lock to specific commit for reproducible builds
commit: [commit-hash-here]
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/service/resource-manager/Microsoft.Service/stable/2023-01-01/service.json

directive:
  # [Well-commented directives explaining customizations]
```

## Maintenance Notes

### Regular Reviews
- Review commit hashes periodically for security updates
- Update API specification versions when new stable versions are available
- Keep directive comments up-to-date when making changes

### Documentation Links
- Ensure links to external documentation remain valid
- Update version numbers in requirements when Az.Accounts updates
- Verify that how-to.md files exist and are current