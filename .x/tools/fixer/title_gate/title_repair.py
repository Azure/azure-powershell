# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Repository-owned deterministic PR title/content gates."""

import re

from repository_tools.settings import _AUTO_TITLE_REPAIR_REPOS, _AZ_COMMAND_ACTIONS, _AZ_COMMAND_PROSE_BOUNDARIES, _BACKTICKED_AZ_COMMAND_PATTERN, _CLI_PARAMETER_PATTERN, _HISTORY_NOTES_HEADING_PATTERN, _MARKDOWN_SECTION_BREAK_PATTERN, _MODULE_PATH_PATTERN, _PLAIN_AZ_COMMAND_PATTERN, _TITLE_ISSUE_PATTERN, _TITLE_PREFIX_PATTERN, _TITLE_VERB_REPLACEMENTS
from x_engineering_agent.config import MAX_TITLE_CHARS
from repository_tools.fixer.formatting.guidance import _component_display_name, pr_title_for


def _extract_az_command(text):
    text = text or ""
    match = _BACKTICKED_AZ_COMMAND_PATTERN.search(text)
    if not match:
        match = _PLAIN_AZ_COMMAND_PATTERN.search(text)
    if not match:
        return None
    tokens = re.sub(r"\s+", " ", match.group(1)).strip().split()
    if match.re is _PLAIN_AZ_COMMAND_PATTERN:
        command_tokens = tokens[:2]
        for token in tokens[2:]:
            if token.casefold() in _AZ_COMMAND_PROSE_BOUNDARIES:
                break
            command_tokens.append(token)
            if token.casefold() in _AZ_COMMAND_ACTIONS:
                break
        tokens = command_tokens
    return " ".join(tokens)


def _normalize_title_summary(text):
    """Normalize title prose to the imperative form required by Azure CLI."""
    summary = re.sub(r"\s+", " ", text or "").strip(
        " \t:.,!?[]{}-\u2013\u2014"
    )
    if not summary:
        return "Fix reported bug"
    first, separator, remainder = summary.partition(" ")
    replacement = _TITLE_VERB_REPLACEMENTS.get(first.casefold())
    if replacement:
        summary = replacement + (separator + remainder if separator else "")
    words = summary.split()
    for index in range(1, len(words)):
        if words[index - 1].casefold() != "to":
            continue
        replacement = _TITLE_VERB_REPLACEMENTS.get(words[index].casefold())
        if replacement:
            words[index] = replacement.casefold()
    summary = " ".join(words)
    return summary[:1].upper() + summary[1:]


def _title_summary_candidate(title, command=None):
    summary = _TITLE_PREFIX_PATTERN.sub("", title or "", count=1)
    summary = _TITLE_ISSUE_PATTERN.sub("", summary, count=1)
    if command:
        command_pattern = re.compile(
            rf"`?{re.escape(command)}`?(?:\s*:\s*|\s*)", re.I,
        )
        summary = command_pattern.sub("", summary, count=1)
    return summary


def _changed_cli_modules(pr_files):
    root = "src/azure-cli/azure/cli/command_modules/"
    return sorted({
        match.group(1).casefold()
        for path in pr_files
        if (
            path.startswith(root)
            and path.endswith(".py")
            and "/tests/" not in path
        )
        if (match := _MODULE_PATH_PATTERN.search(path))
    })


def expected_cli_title_component(pr_files):
    """Use the production diff only when it identifies one command module."""
    modules = _changed_cli_modules(pr_files)
    return _component_display_name(modules[0]) if len(modules) == 1 else None


def cli_title_component_matches(title, pr_files):
    expected = expected_cli_title_component(pr_files)
    if expected is None:
        return True
    prefix = _TITLE_PREFIX_PATTERN.match(title or "")
    return bool(prefix and prefix.group(1).strip() == expected)


def _replace_history_note_component(body, current, expected):
    lines = (body or "").splitlines(keepends=True)
    in_notes = False
    for index, line in enumerate(lines):
        text = line.strip()
        if _HISTORY_NOTES_HEADING_PATTERN.fullmatch(text):
            in_notes = True
            continue
        if in_notes and _MARKDOWN_SECTION_BREAK_PATTERN.fullmatch(text):
            break
        if not in_notes:
            continue
        prefix = _TITLE_PREFIX_PATTERN.match(line)
        if prefix and prefix.group(1).strip() == current:
            lines[index] = line[:prefix.start(1)] + expected + line[prefix.end(1):]
    return "".join(lines)


def repaired_pr_title(repo_full_name, current_title, component=None,
                      issue_number=None, issue_title=None):
    """Build a deterministic gate compliant replacement for a failing title."""
    style = _AUTO_TITLE_REPAIR_REPOS.get(repo_full_name)
    if not style:
        raise ValueError(
            f"Automatic PR title repair is not enabled for {repo_full_name}"
        )

    prefix_match = _TITLE_PREFIX_PATTERN.match(current_title or "")
    current_component = prefix_match.group(1).strip() if prefix_match else None
    component = component or current_component
    title_without_prefix = _TITLE_PREFIX_PATTERN.sub(
        "", current_title or "", count=1,
    )
    issue_match = _TITLE_ISSUE_PATTERN.match(title_without_prefix)
    if issue_number is None and issue_match:
        issue_number = int(issue_match.group(1))

    source_text = " ".join(
        value for value in (current_title, issue_title) if value
    )
    command = _extract_az_command(source_text) if style == "cli" else None
    summary = _title_summary_candidate(current_title, command=command)
    if not summary:
        summary = _title_summary_candidate(issue_title or "", command=command)
    summary = _normalize_title_summary(summary)
    if style == "cli":
        summary = _CLI_PARAMETER_PATTERN.sub(r"`\1`", summary)
        if command and _CLI_PARAMETER_PATTERN.search(command):
            command = command[:_CLI_PARAMETER_PATTERN.search(command).start()].rstrip()
            if command == "az":
                command = None

    if style == "powershell":
        return pr_title_for(
            component=component, summary=summary, style="powershell",
        )

    customer_facing = not (current_title or "").lstrip().startswith("{")
    ob, cb = ("[", "]") if customer_facing else ("{", "}")
    component_display = _component_display_name(component)
    issue_part = f"Fix #{issue_number}: " if issue_number else ""
    command_part = f"`{command}`: " if command else ""
    return (
        f"{ob}{component_display}{cb} {issue_part}{command_part}{summary}"
    )[:MAX_TITLE_CHARS]


def _repaired_cli_history_notes(body, component=None):
    """Normalize populated Azure CLI History Notes without changing the template."""
    lines = (body or "").splitlines(keepends=True)
    in_history_notes = False
    updated_count = 0
    for index, line in enumerate(lines):
        stripped = line.strip()
        if _HISTORY_NOTES_HEADING_PATTERN.fullmatch(stripped):
            in_history_notes = True
            continue
        if not in_history_notes:
            continue
        if _MARKDOWN_SECTION_BREAK_PATTERN.fullmatch(stripped):
            break
        if (
            not stripped
            or stripped.startswith("<!--")
            or stripped.endswith("-->")
        ):
            continue

        prefix_match = _TITLE_PREFIX_PATTERN.match(stripped)
        note_component = (
            prefix_match.group(1).strip()
            if prefix_match else component
        )
        repaired = repaired_pr_title(
            "Azure/azure-cli",
            stripped,
            component=note_component,
        )
        newline = line[len(line.rstrip("\r\n")):]
        replacement = repaired + newline
        if replacement != line:
            lines[index] = replacement
            updated_count += 1
    return "".join(lines), updated_count
