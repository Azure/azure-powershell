# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Azure PowerShell changed test selection."""

from repository_tools.settings import _PS_TEST_FILE_PATTERN


def changed_ps_test_files(pr_files):
    """Return changed scenario tests under a PowerShell service test project."""
    return [
        path for path in (pr_files or [])
        if _PS_TEST_FILE_PATTERN.search(path)
    ]