# Design Review Issue Template

This is the target format for the GitHub Issue created in [`Azure/azure-powershell-cmdlet-review-pr`](https://github.com/Azure/azure-powershell-cmdlet-review-pr). The agent populates every field during the guided interview.

---

## Template

```markdown
<!-- Please note that the SLA for initial reviews is 3 business days. The response may be slow during the week before release. Please ping Azure PowerShell team for urgent request. -->

## Guidelines

The purpose of the Azure PowerShell design review is to ensure that the cmdlets follow the same pattern across the Azure modules. An early design review reduces the risk of unnecessary implementation changes caused by a cmdlet syntax design change.

Please ensure your cmdlets comply with the design guidelines outlined in the [PowerShell Design Guidelines document](https://github.com/Azure/azure-powershell/tree/master/documentation/development-docs/design-guidelines).

- Have you read above statement?
  - Yes

## Service Release Details

- Is this an Embargoed Preview, A Public Preview, or a General Release?
  - {RELEASE_TYPE}

- What is the expected service release date?
  - {RELEASE_DATE}

- Which [Powershell module](https://github.com/Azure/azure-powershell/blob/main/documentation/azure-powershell-modules.md) are these changes being made in?
  - {MODULE}

## Contact Information

- Main developer contacts (emails + github aliases)
  - {DEV_CONTACTS}

- PM contact (email + github alias)
  - {PM_CONTACT}

- Other people who should attend a design review (email)
  - {ADDITIONAL_CONTACTS}

## High Level Scenarios

- Describe how your feature is intended to be used by customers.
  - {FEATURE_DESCRIPTION}

- Piping scenarios / how these cmdlets are used with existing cmdlets
  - {PIPING_SCENARIOS}

- Sample of end-to-end usage
  - {SAMPLE_USAGE}

## Syntax changes

### New Cmdlets

<!-- If no new cmdlets, write "N/A" -->

{FOR_EACH_NEW_CMDLET}

#### {NEW_CMDLET_NAME}

**Parameters:**

{NEW_CMDLET_PARAMETERS}

**Business Logic:**

{NEW_CMDLET_LOGIC}

**Sample Syntax:**

{NEW_CMDLET_SYNTAX_BLOCK}
{END_FOR_EACH}

### Changed Cmdlets

<!-- If no changed cmdlets, write "N/A" -->

{FOR_EACH_CHANGED_CMDLET}

#### {CHANGED_CMDLET_NAME}

**New/Changed Parameters:**

{CHANGED_CMDLET_PARAMETERS}

**Business Logic Changes:**

{CHANGED_CMDLET_LOGIC}

**Sample Syntax or Diff:**

{CHANGED_CMDLET_SYNTAX}

**Affected Parameter Sets:**

{AFFECTED_PARAMETER_SETS}
{END_FOR_EACH}

## Specific test cases

Please list every test scenario that should be tested for this feature, including positive cases, negative/error cases, and edge cases.

{TEST_SCENARIOS}

## Additional information

- Link to the OpenAPI (swagger) spec
  - {SPEC_LINK}

- Link to any other Github work related to this request
  - {RELATED_LINKS}

- Indicate any feature flags or restrictions on the changes provided in this design specification.
  - {RESTRICTIONS}

---

> _Created with help from PS design skill_
```

---

## Field Reference

| Placeholder                   | Interview Step        | Source                                       |
| ----------------------------- | --------------------- | -------------------------------------------- |
| `{RELEASE_TYPE}`              | Step 2                | Developer input                              |
| `{RELEASE_DATE}`              | Step 2                | Developer input                              |
| `{MODULE}`                    | Step 2                | Developer input / TypeSpec path              |
| `{DEV_CONTACTS}`              | Step 3                | Developer input                              |
| `{PM_CONTACT}`                | Step 3                | Developer input                              |
| `{ADDITIONAL_CONTACTS}`       | Step 3                | Developer input (optional)                   |
| `{FEATURE_DESCRIPTION}`       | Step 4                | Developer input                              |
| `{PIPING_SCENARIOS}`          | Step 4                | Developer input                              |
| `{SAMPLE_USAGE}`              | Step 4                | Developer input                              |
| `{CHANGE_TYPE}`               | Step 5                | Developer input                              |
| `{NEW_CMDLET_NAMES}`          | Step 5                | Developer input + TypeSpec pre-population    |
| `{NEW_CMDLET_PARAMETERS}`     | Step 5                | Developer input + TypeSpec pre-population    |
| `{NEW_CMDLET_LOGIC}`          | Step 5                | Developer input                              |
| `{NEW_CMDLET_SYNTAX_BLOCK}`   | Step 5                | Developer input (PowerShell code block)      |
| `{CHANGED_CMDLET_NAMES}`      | Step 5                | Developer input                              |
| `{CHANGED_CMDLET_PARAMETERS}` | Step 5                | Developer input                              |
| `{CHANGED_CMDLET_LOGIC}`      | Step 5                | Developer input                              |
| `{CHANGED_CMDLET_SYNTAX}`     | Step 5                | Developer input                              |
| `{AFFECTED_PARAMETER_SETS}`   | Step 5                | Developer input                              |
| `{TEST_SCENARIOS}`            | Step 3 (scratch file) | Developer input — list of all test scenarios |
| `{SPEC_LINK}`                 | Step 6                | Developer input / TypeSpec PR link           |
| `{RELATED_LINKS}`             | Step 6                | Developer input                              |
| `{RESTRICTIONS}`              | Step 6                | Developer input                              |

## Issue Metadata

- **Repository**: `Azure/azure-powershell-cmdlet-review-pr`
- **Title format**: `{MODULE} - {FEATURE}` (e.g., `Az.Compute - ManagedDisk Snapshot`)
- **Labels**: `needs-review`
- **Assignees**: Leave empty (the PS team triages)
