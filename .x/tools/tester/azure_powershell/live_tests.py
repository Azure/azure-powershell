# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Azure PowerShell changed test selection."""

import re

from repository_tools.settings import _PS_TEST_FILE_PATTERN

_PS_SERVICE_PATH = re.compile(r"(?:^|/)src/([A-Za-z0-9_.-]+)/[^/]+/")


def changed_ps_test_files(pr_files):
    """Return changed scenario tests under a PowerShell service test project."""
    return [
        path for path in (pr_files or [])
        if _PS_TEST_FILE_PATTERN.search(path)
    ]


def _live_test_plan(pr_files):
    """Plan selection and skip explanations without dispatching a workflow."""
    paths = changed_ps_test_files(pr_files)
    runnable = paths
    return {
        "paths": paths,
        "runnable": runnable,
        "skipped_reason": None if runnable else ('PR changes no <Service>.Test files (src/<Service>/<Service>.Test/**/*.cs|*.ps1)'),
        "comment": None if runnable else ('**Skipping the live test for this revision because no changed test file was found** under a `<Service>.Test` project (`src/<Service>/<Service>.Test/**/*.cs|*.ps1`).\n\nThe live-test pipeline runs only the scenario/xUnit test files a PR changes, so there is nothing to execute for this commit. This is informational — a regression test is encouraged where it makes sense, but not required. If a test file is added in a later commit, the live test will run automatically.'),
        "legacy_title": None,
    }


def _live_test_source_targets(pr_files):
    """Service module targets of the non-test changed files."""
    names = []
    for path in pr_files or []:
        if ".Test/" in path:
            continue
        match = _PS_SERVICE_PATH.search(path)
        if match and match.group(1) not in names:
            names.append(match.group(1))
    return ("psmodule" if names else None), names
