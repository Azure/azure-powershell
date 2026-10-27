# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Repository-owned PR title and description conventions."""

import re

from repository_tools.settings import COMPONENT_DISPLAY_NAMES, PR_FORMAT_DOC_URL, PR_TEMPLATE_URL
from x_engineering_agent.config import MAX_TITLE_CHARS


def _component_display_name(name):
    """Conventional `[Component]` display name for a module/extension token."""
    if not name:
        return "Component"
    key = name.strip().lower().replace("azext_", "")
    if key in COMPONENT_DISPLAY_NAMES:
        return COMPONENT_DISPLAY_NAMES[key]
    compact_key = re.sub(r"[-_ ]+", "", key)
    if compact_key in COMPONENT_DISPLAY_NAMES:
        return COMPONENT_DISPLAY_NAMES[compact_key]
    parts = re.split(r"[-_ ]+", key)
    return " ".join(p[:1].upper() + p[1:] for p in parts if p) or "Component"


def pr_title_for(component=None, issue_number=None, command=None,
                 summary=None, customer_facing=True, style="cli"):
    """Build the exact, format gate compliant PR title for Copilot to use
    verbatim.
    """
    if style == "powershell":
        comp = (component or "").strip()
        summary = (summary or "Fix reported bug").strip()
        title = f"[{comp}] {summary}" if comp else summary
        return title[:MAX_TITLE_CHARS]

    ob, cb = ("[", "]") if customer_facing else ("{", "}")
    comp = _component_display_name(component)
    fix_part = f"Fix #{issue_number}: " if issue_number else ""
    cmd_display = f"`{command or 'az <command>'}`: "
    summary = (summary or "Fix reported bug").strip()
    if summary and summary[0].islower():
        summary = summary[0].upper() + summary[1:]
    title = f"{ob}{comp}{cb} {fix_part}{cmd_display}{summary}"
    return title[:MAX_TITLE_CHARS]


def pr_format_guidance(component=None, issue_number=None, customer_facing=True,
                       command=None, issue_repo=None, summary=None, style="cli"):
    """Markdown block telling Copilot how to title and describe its PR so it
    passes the target repo's PR conventions.
    """
    exact_title = pr_title_for(component=component, issue_number=issue_number,
                               command=command, summary=summary,
                               customer_facing=customer_facing, style=style)
    issue_ref = ""
    if issue_number:
        issue_ref = (f"{issue_repo}#{issue_number}" if issue_repo
                     else f"#{issue_number}")

    if style == "powershell":
        # Raw PascalCase module name = exact src/<Service> dir (see pr_title_for).
        comp = (component or "").strip()
        ps_doc = 'https://github.com/Azure/azure-powershell/blob/main/CONTRIBUTING.md'
        link_line = (
            f"- **Link the issue** — include `Fixes {issue_ref}` in the "
            "description so the PR auto-closes it.\n" if issue_ref else ""
        )
        if comp:
            changelog_line = (
                "- **ChangeLog** — add a bullet describing the fix under the "
                f"`## Upcoming Release` header of "
                f"`src/{comp}/{comp}/ChangeLog.md`. Do **not** add a new version "
                "header.\n"
            )
            scope_line = ("- **Scope** — keep the change limited to the affected "
                          f"module (`src/{comp}/`).\n")
        else:
            changelog_line = (
                "- **ChangeLog** — add a bullet describing the fix under the "
                "`## Upcoming Release` header of the affected module's "
                "`src/<Module>/<Module>/ChangeLog.md`. Do **not** add a new "
                "version header.\n"
            )
            scope_line = ("- **Scope** — keep the change limited to the affected "
                          "`src/<Module>/`.\n")
        return (
            "### PR title & description (azure-powershell)\n"
            f"Follow [CONTRIBUTING.md]({ps_doc}). azure-powershell does **not** "
            "enforce a strict title gate — it requires a *clear, informative* "
            "title and a **fully filled-out PR template**.\n\n"
            "**Suggested PR title (clear & informative; `[Module]` prefix is the "
            "common convention):**\n\n"
            f"```\n{exact_title}\n```\n\n"
            "**Required (per CONTRIBUTING.md):**\n"
            "- **Fill out the PR template completely** — PRs are not reviewed "
            "without the completed checklist; do not delete it.\n"
            + link_line
            + changelog_line +
            "- **Target branch** — `main`.\n"
            "- **Tests** — add/adjust test coverage for the change. Tests must "
            "not contain hardcoded values (location, resource id, etc.) and must "
            "be re-recordable; do not skip existing tests.\n"
            "- **AutoRest/Codegen** — if the change touches a `*.Autorest` "
            "project, run the repository's approved Codegen flow and include "
            "all regenerated artifacts, including that project's changed "
            "`generate-info.json`. Do not submit only hand-edited AutoRest "
            "source or generated output.\n"
            + scope_line
        )

    ob, cb = ("[", "]") if customer_facing else ("{", "}")
    comp = _component_display_name(component)
    desc_link_line = (
        "- **Link the issue** — start the Description with a closing keyword "
        f"so the PR auto-links and closes it: `Fixes {issue_ref}`.\n"
        if issue_ref else ""
    )
    return (
        "### PR title & description format (required)\n"
        f"This repo enforces a PR format ([guide]({PR_FORMAT_DOC_URL})). "
        "Please author the PR exactly as follows or CI's "
        "*Check the Format of Pull Request Title and Content* will fail.\n\n"
        "**Use this EXACT PR title (copy verbatim, do not reword):**\n\n"
        f"```\n{exact_title}\n```\n\n"
        "Keep the backticks around the command and the `Fix #"
        f"{issue_number or '<issue>'}:` prefix. You may only adjust the wording "
        "*after* the command (the final summary) if the fix changes; the "
        f"`{ob}{comp}{cb}` prefix, issue link, and backticked command must stay.\n\n"
        "**Description** — follow the "
        f"[PR template]({PR_TEMPLATE_URL}) and fill in:\n"
        + desc_link_line +
        "- **Related command** — the `az ...` command this affects.\n"
        "- **Description** *(mandatory)* — why the bug happens, what you "
        "changed, and the resulting behavior.\n"
        "- **Testing Guide** — example command(s) showing the fix works.\n"
        "- **History Notes** — leave the title to drive the history note, or "
        "add extra lines in the same format (component in brackets + the "
        "command in backticks), e.g. "
        f"``{ob}{comp}{cb} `az <command>`: <note>``.\n"
        "- Keep the template checklist and tick the items you've satisfied.\n"
    )
