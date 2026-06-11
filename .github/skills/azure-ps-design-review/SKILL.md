---
name: azure-ps-design-review
license: MIT
metadata:
  version: "1.0.0"
description: "Conversational agent that guides developers through creating complete Azure PowerShell cmdlet design specifications. Walks through an interactive interview covering service release details, contacts, scenarios, cmdlet syntax, parameter sets, piping, test cases, and spec links. Validates against PowerShell design guidelines, pre-populates fields from TypeSpec, and files the design as a GitHub Issue in Azure/azure-powershell-cmdlet-review-pr. USE FOR: 'create PowerShell design', 'PS design review', 'cmdlet design', 'PowerShell cmdlet review', 'submit PS design'. DO NOT USE FOR: SDK generation, TypeSpec authoring, releasing packages."
compatibility:
  requires: "GitHub MCP Server for issue creation in Azure/azure-powershell-cmdlet-review-pr; TypeSpec files in the current repo for pre-population"
---

# Azure PowerShell Cmdlet Design Review

A conversational skill that guides developers through building a complete PowerShell cmdlet design specification and submitting it for review.

## MCP Tools

**Prerequisite:** The GitHub MCP server must be configured and running. If any MCP tool call fails with a connection or server error, instruct the developer to add the following to their VS Code MCP configuration file (`.vscode/mcp.json` or the workspace `.mcp.json`):

```json
{
  "servers": {
    "github": {
      "url": "https://api.githubcopilot.com/mcp/"
    }
  }
}
```

Then reload the VS Code window and retry.

| Tool                                  | Purpose                                                                                                                                                                 |
| ------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `github-mcp-server:get_file_contents` | **Primary tool for reading PR changes.** Read TypeSpec files from the PR branch (`refs/pull/{number}/head`) and base branch to diff and identify new/changed resources. |
| `github-mcp-server:create_issue`      | Create the design review issue in `Azure/azure-powershell-cmdlet-review-pr`                                                                                             |
| `github-mcp-server:search_code`       | Search for existing cmdlet patterns in `Azure/azure-powershell` for consistency                                                                                         |
| `github-mcp-server:list_issues`       | Check for existing design reviews to avoid duplicates                                                                                                                   |

## Constraints

- **Always follow the full interview workflow** — do not skip sections even if the developer says "just file it."
- **Validate every section** against the [design guidelines](references/design-guidelines-summary.md) before moving on.
- **Pre-populate from TypeSpec when possible** — read the developer's TypeSpec to extract resource models, operations, and parameter types.
- **Never file an incomplete issue** — all required fields must be populated before creating the GitHub Issue.
- **Label issues correctly** — apply the `needs-review` label and use the `{MODULE} - {FEATURE}` title format.
- **Always append the telemetry tag** — every issue body must end with `> _Created with help from PS design skill_` for tracking. Never omit this line.
- **Compute module focus** — this skill is initially scoped to Compute but the workflow generalizes to any module.
- **Use scratch files for multi-line input** — never ask for cmdlet syntax, piping examples, sample usage, feature descriptions, or business logic in the chat box. Always create a scratch `.md` file and open it in the editor. See [Scratch File Pattern](#scratch-file-pattern-for-long-form-input).
- **Use GitHub MCP Server for ALL GitHub operations** — do NOT use `gh` CLI, `git` commands, `curl`, PowerShell, shell commands, or any other workaround to read PR data, fetch file contents, list files, or create issues. The **only** way to interact with GitHub is through `github-mcp-server` tools. If a tool call fails, do NOT fall back to shell commands — instead display the MCP setup instructions above and ask the developer to configure the server.

---

## Scratch File Pattern for Long-Form Input

Several interview steps require multi-line input (cmdlet syntax blocks, piping examples, end-to-end samples) that is difficult to type in the Copilot Chat input box. For these steps, the agent **must** use a scratch file instead of asking the developer to paste into chat.

**How it works**:

1. The agent creates a temporary Markdown file at `.github/skills/azure-ps-design-review/scratch/design-input.md` (or a step-specific name like `cmdlet-syntax.md`).
2. The file is pre-populated with a template containing headings, placeholder text, and commented instructions so the developer knows exactly what to fill in.
3. The agent tells the developer: **"I've opened `design-input.md` in your editor. Please fill in the sections and let me know when you're done."**
4. Once the developer confirms, the agent reads the file back and extracts the responses.
5. After the design is submitted, the agent deletes the scratch files.

**When to use scratch files** (vs. chat input):

| Input type                                                                                                              | Method                                       |
| ----------------------------------------------------------------------------------------------------------------------- | -------------------------------------------- |
| Short answers (release type, date, module name, contacts)                                                               | Chat input — ask directly                    |
| Multi-line content (cmdlet syntax, piping examples, sample usage, business logic, test scenarios, feature descriptions) | **Scratch file** — create and open in editor |

**IMPORTANT**: Do **NOT** ask for multi-line content in the chat input box. Always create a scratch file for any response that would reasonably span more than 2–3 lines. This includes feature descriptions, piping scenarios, sample usage, cmdlet syntax blocks, business logic, and test scenarios. The chat input box is too small for formatted content.

**Scratch file conventions**:

- Location: `.github/skills/azure-ps-design-review/scratch/` (gitignored)
- Format: Markdown with `<!-- INSTRUCTION: ... -->` comments guiding the developer
- One file per step that needs it, or a single combined file — agent decides based on complexity
- Always delete scratch files after the design issue is created

---

## Workflow

> **PR Link First** → Ingest Changes → Interview → Validate → Generate → Submit

**CRITICAL**: The very first action when this skill is invoked is to ask the developer for their TypeSpec PR link. Do **not** ask about module names, release details, contacts, or anything else until the PR link has been provided and the changes have been ingested. The PR diff is used to pre-populate as much of the template as possible before starting the interview.

### Progress Checklist

Copy and update as you progress:

- [ ] Step 1: Collected TypeSpec PR link and ingested changes
- [ ] Step 2: Collected short answers (release details, contacts, links) via chat
- [ ] Step 3: Created pre-filled design draft — developer filling in long-form sections
- [ ] Step 4: Validated design against guidelines
- [ ] Step 5: Generated final design spec and presented for review
- [ ] Step 6: Created GitHub Issue in Azure/azure-powershell-cmdlet-review-pr

---

### Step 1: Collect TypeSpec PR Link & Ingest (Chat Follow-up)

> **This step MUST execute first.** Do not proceed to any other step until this is complete.

**Goal**: Get the TypeSpec PR link in a follow-up popup and ingest the diff to extract as much design data as possible.

**Initial message**: When the skill is first invoked, respond with a brief introduction and the workflow overview, with a popup PR link input request. Example:

> 👋 I'll help you create a PowerShell cmdlet design spec. Here's how this works:
>
> 1. You give me your TypeSpec PR link
> 2. I'll ask a few quick questions (release type, contacts, etc.)
> 3. I'll create a pre-filled design draft — you just fill in the long-form sections
> 4. I validate against design guidelines and file the review issue
>    In a follow-up popup, ask for the TypeSpec PR link with clear instructions. Example:
>    To get started, paste the link to your TypeSpec PR (e.g., `https://github.com/Azure/azure-rest-api-specs/pull/12345`).

**If the developer already provided the PR link in their initial message**, skip the introduction and proceed directly to ingesting the PR.

**Actions** (after receiving the PR link):

1. Extract the PR number from the link.
2. Use `github-mcp-server:get_file_contents` with `refs/pull/{number}/head` to read the TypeSpec files on the PR branch, and again with the base branch to read the prior versions.
3. Diff the PR branch against the base to extract:
   - PR title and description (use for feature description)
   - Which TypeSpec project / service namespace changed (use to infer PowerShell module, e.g., `Microsoft.Compute` → `Az.Compute`)
   - New resource models and properties
   - New or modified operations (GET, PUT, PATCH, DELETE, POST actions)
   - New parameters and constraints
   - Changed properties on existing resources
4. From the extracted operations, generate candidate cmdlet nouns (e.g., `Snapshot`, `VirtualMachine`).
5. **Look up existing cmdlets** — for each candidate noun, use `github-mcp-server:search_code` to search `Azure/azure-powershell` for existing cmdlets matching that noun. For example:
   - Search: `"AzSnapshot" language:cs path:src/Compute` in `repo:Azure/azure-powershell`
   - Search: `"AzSnapshot" language:ps1 path:src/Compute` in `repo:Azure/azure-powershell`
   - This returns existing cmdlet classes and scripts (e.g., `NewAzSnapshotCommand.cs`, `Get-AzSnapshot.ps1`)
6. **Inspect existing cmdlet details** — for each existing cmdlet found, use `github-mcp-server:get_file_contents` to read the cmdlet source file and extract:
   - Current parameter names, types, and whether they are mandatory
   - Current parameter sets (Interactive, ResourceId, InputObject, etc.)
   - Output type (`OutputType` attribute)
   - Whether `ShouldProcess`, `AsJob`, or `PassThru` are already implemented
     This gives the agent a baseline of what the cmdlet already supports.
7. **Classify each cmdlet as New, Changed, or Unchanged**:
   - **New Cmdlet**: No existing cmdlet matches the verb+noun combination (e.g., `Update-AzSnapshot` doesn't exist yet)
   - **Changed Cmdlet**: An existing cmdlet matches, AND the TypeSpec PR introduces parameters, properties, or operations that are **not already present** in the existing cmdlet source. Only include changes that are actually new — do not flag parameters or behaviors that the cmdlet already supports.
   - **Unchanged**: An existing cmdlet matches, and the TypeSpec PR changes do not introduce anything beyond what the cmdlet already has. **Exclude these from the design** — they do not need review.
   - Present the classification to the developer for confirmation: "I found these existing cmdlets and checked their current parameters: `Get-AzSnapshot` (has -ResourceGroupName, -Name, -ResourceId), `New-AzSnapshot` (has -Location, -Sku, ...). Based on your PR, `Update-AzSnapshot` is new, and `New-AzSnapshot` needs a new `-EncryptionType` parameter. Does that look right?"
8. Generate parameter tables and output types for each new/changed cmdlet.
9. Determine the spec link (the PR URL itself).

**Important**: Do **not** scan the local working tree for changes. All change detection must come from the PR. The developer may invoke this skill long after the TypeSpec changes were made.

**Output**: A structured set of pre-populated fields. Do NOT present this raw or create the scratch file yet — first collect the short answers in Step 2.

---

### Step 2: Collect Short Answers (Chat Follow-Ups)

**Goal**: Ask the developer for all short-form information in a the follow-up popup questionnaire. These are quick answers that don't need the editor.

**Present all questions together** in one message after ingesting the PR. Skip any the agent can already infer from the PR (and show the inferred values for confirmation). Example:

> I've read your PR and found 3 new operations. Before I create the design draft, I need a few details:
>
> 1. **Release type**: Embargoed Preview, Public Preview, or General Release?
> 2. **Expected release date**:
> 3. **PowerShell module**: (I'm guessing `Az.Compute` — correct?)
> 4. **Developer contacts**: (email + GitHub alias)
> 5. **PM contact**: (email + GitHub alias)
> 6. **Additional reviewers**: (optional)
> 7. **Related GitHub issues/PRs**: (optional)
> 8. **Feature flags or restrictions**: (optional)

**Rules**:

- Ask all questions in a list of follow-ups in the follow-up popup window so the developer can answer them all at once.
- Pre-fill any values the agent can infer from the PR and ask the developer to confirm or correct.
- The developer can answer in any format — numbered list, paragraph, etc. The agent parses the response.

---

### Step 3: Create Pre-Filled Design Draft (Scratch File)

**Goal**: Combine everything from the PR (Step 1) and the chat answers (Step 2) into a single scratch file. The developer only needs to fill in the **long-form sections** — everything else is already done.

**Input method**: **MUST use scratch file.** Create `scratch/design-draft.md` with all short answers and TypeSpec data already filled in. Only long-form sections that require multi-line formatted input should have `<!-- TODO -->` markers.

Use this template — `{...}` values are filled from Steps 1 and 2:

````markdown
# PowerShell Design Review Draft

<!-- Review the pre-filled sections and fill in the TODO sections.
     Only the long-form sections (scenarios, business logic, sample code) need your input.
     Everything else has been pre-filled from your PR and chat answers. -->

---

## Service Release Details

- **Release type**: {RELEASE_TYPE}
- **Expected release date**: {RELEASE_DATE}
- **PowerShell module**: {MODULE}

## Contact Information

- **Main developer contacts**: {DEV_CONTACTS}
- **PM contact**: {PM_CONTACT}
- **Additional reviewers**: {ADDITIONAL_CONTACTS}

## High-Level Scenarios

### Feature Description

{PR_DESCRIPTION_OR_TITLE}

<!-- TODO: Expand on the above if needed. Describe how this feature is intended to be used by customers. -->

### Piping Scenarios

<!-- TODO: Show how these cmdlets integrate with existing cmdlets.
     Example: Get-AzVM | Update-AzVM -Tag @{env="prod"}
     Example: Get-AzSnapshot -ResourceGroupName "rg1" | Remove-AzSnapshot -->

### End-to-End Sample Usage

<!-- TODO: Provide comprehensive examples that don't assume additional setup. -->

```powershell

```
````

## New Cmdlets

<!-- If no new cmdlets, write "N/A" -->

{FOR_EACH_NEW_CMDLET}

### {CMDLET_NAME} <!-- FROM TYPESPEC -->

**Parameters:** <!-- FROM TYPESPEC — verify and add descriptions -->

| Parameter | Type | Mandatory | Description |
| --------- | ---- | --------- | ----------- |

{PARAMETER_ROWS}

**Business Logic:**

<!-- TODO: Describe what this cmdlet does and any important behavioral details. -->

**Sample Syntax and Output:**

<!-- TODO: Add a PowerShell code block showing usage and expected output. -->

```powershell
PS C:\> {CMDLET_NAME} -ResourceGroupName "rg1" -Name "example"

```

{END_FOR_EACH}

## Changed Cmdlets

<!-- If no changed cmdlets, write "N/A" -->

{FOR_EACH_CHANGED_CMDLET}

### {CMDLET_NAME}

**New/Changed Parameters:**

<!-- TODO: List the new or changed parameters, types, and allowed values. -->

| Parameter | Type | Mandatory | Description |
| --------- | ---- | --------- | ----------- |
|           |      |           |             |

**Business Logic Changes:**

<!-- TODO: Describe what changed and why. -->

**Sample Syntax or Diff:**

<!-- TODO: Add a PowerShell code block or diff showing the change. -->

```powershell

```

**Affected Parameter Sets:**

<!-- TODO: Which parameter sets are affected by this change? -->

{END_FOR_EACH}

## Test Cases

<!-- TODO: List every test scenario for this feature.
     Focus on feature-specific behavior — do NOT include tests for standard PowerShell
     patterns like -WhatIf, -Confirm, -AsJob, -PassThru, or -Force (these are handled
     by the framework and do not need per-feature testing).
     Include: positive cases, negative/error cases, edge cases, and piping scenarios.
     Example:
     1. Create a new snapshot with all required parameters → succeeds, returns PSSnapshot object
     2. Create a snapshot without -ResourceGroupName → returns error
     3. Get snapshot by name → returns correct object with expected properties
     4. Get snapshot by ResourceId via pipeline → returns correct object
     5. List all snapshots in a resource group → returns collection
     6. Update snapshot with new -EncryptionType parameter → property is updated on server
     7. Remove snapshot that doesn't exist → returns 404 error
     8. Create snapshot with duplicate name in same RG → returns conflict error
-->

1.
2.
3.

## Additional Information

- **Link to TypeSpec / OpenAPI spec**: {PR_URL}
- **Related GitHub work**: {RELATED_LINKS}
- **Feature flags or restrictions**: {RESTRICTIONS}

---

> _Created with help from PS design skill_

````

**What should be pre-filled** (not TODO):
- All service release details (from Step 2 chat)
- All contact information (from Step 2 chat)
- Feature description seed text (from PR title/description)
- Cmdlet names and parameter tables (from TypeSpec diff)
- Related links, restrictions (from Step 2 chat)
- Spec link (the PR URL)

**What should be TODO** (long-form only):
- Expanded feature description (developer may want to add more detail)
- Piping scenarios (requires formatted PowerShell examples)
- End-to-end sample usage (requires formatted PowerShell code blocks)
- Business logic for each cmdlet (requires prose)
- Sample syntax and output for each cmdlet (requires formatted code blocks)
- Test cases (full list of every scenario to test — positive, negative, edge cases)

**Pre-population rules for cmdlets**:
- Cmdlet names: Derive from operations (PUT → `New-`/`Set-`, PATCH → `Update-`, DELETE → `Remove-`, GET → `Get-`, POST actions → approved verb). Mark each with `<!-- FROM TYPESPEC -->`.
- Parameters: Extract from resource model properties. Include type and mark as `<!-- FROM TYPESPEC -->`.

Tell the developer: **"I've created `design-draft.md` in your editor. All the info from your PR and our chat is already filled in — you just need to write the long-form sections (piping scenarios, sample usage, business logic, and test cases). Let me know when you're done."**

---

### Step 4: Validate Against Design Guidelines

**Goal**: Run a final validation pass over the complete design.

**Validation checks**:
- Verb is from the [approved PowerShell verbs list](https://learn.microsoft.com/en-us/powershell/scripting/developer/cmdlet/approved-verbs-for-windows-powershell-commands)
- Noun uses `Az` prefix and Pascal case
- PATCH operations use `Update-`, PUT operations use `Set-`
- Cmdlets that modify resources implement `ShouldProcess` (`-WhatIf` / `-Confirm`)
- Cmdlets returning no output implement `-PassThru`
- Long-running operations implement `-AsJob`
- Required parameter sets present: Interactive, ResourceId, InputObject
- Output types are specific (never `object`, `PSObject`, `PSCustomObject`, or `string`)
- Two-char acronyms fully capitalized; 3+ char acronyms Pascal-cased
- Piping examples use `-InputObject` or `-ResourceId` parameter sets

**Actions**:

1. Re-check all cmdlet names, parameters, output types, and piping scenarios against the [design guidelines summary](references/design-guidelines-summary.md).
2. Flag any issues found and present them to the developer with suggested fixes.
3. If issues exist, update the scratch file with corrections and re-open for the developer.
4. Once all validations pass, proceed to generation.

For edge cases or when the developer requests detailed rationale, fetch the full guidelines from `Azure/azure-powershell/documentation/development-docs/design-guidelines/` via the GitHub MCP Server.

---

### Step 5: Generate Design Spec

**Goal**: Produce the complete design document.

**Actions**:

1. Assemble all collected information into the [design review template format](references/issue-template.md).
2. Present the full Markdown document to the developer for review.
3. Ask: "Does this look correct? Would you like to make any changes before I submit it?"
4. If changes requested, apply them and re-present.

---

### Step 6: Create GitHub Issue

**Goal**: File the design as a GitHub Issue.

**Actions**:

1. Create an issue in `Azure/azure-powershell-cmdlet-review-pr` using `github-mcp-server:create_issue` with:
   - **Title**: `{MODULE} - {FEATURE}` (e.g., `Az.Compute - ManagedDisk Snapshot`)
   - **Body**: The generated design spec from Step 5
   - **Labels**: `needs-review`. If the module is `Az.Compute`, also apply the `Compute` label.
2. Display the created issue URL to the developer.
3. **Clean up scratch files** — delete all files in `.github/skills/azure-ps-design-review/scratch/` (except `.gitignore`).
4. Inform: "The Azure PowerShell team's SLA for initial reviews is 3 business days. Ping the team for urgent requests."

---

## Examples

- "Help me create a PowerShell design for my new Compute feature"
- "I need to submit a cmdlet design review for Az.Compute"
- "Create a PS design spec from my TypeSpec"
- "Guide me through a PowerShell design review submission"

## Troubleshooting

- **GitHub MCP Server not connected / tool calls fail**: The GitHub MCP server is required for this skill. If any `github-mcp-server` tool call fails, instruct the developer to add the following to their `.vscode/mcp.json` (or workspace `.mcp.json`), then reload VS Code:
  ```json
  {
    "servers": {
      "github": {
        "url": "https://api.githubcopilot.com/mcp/"
      }
    }
  }
````

Do NOT fall back to `gh` CLI, `git`, `curl`, or PowerShell commands. Wait for the developer to fix the MCP configuration and retry.

- **No TypeSpec PR available**: The PR link is required. If the developer doesn't have one yet, advise them to create and submit their TypeSpec PR first, then return to this skill.
- **GitHub issue creation fails**: Verify the developer has write access to `Azure/azure-powershell-cmdlet-review-pr`. If not, output the Markdown spec so they can file it manually.
- **Design guideline questions**: Fetch the full guideline document from `Azure/azure-powershell/documentation/development-docs/design-guidelines/` for detailed rationale.
