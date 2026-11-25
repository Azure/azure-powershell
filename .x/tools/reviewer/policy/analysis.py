# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Review tool analyzers for pull request diffs.
"""
import os
import re
from urllib.parse import quote
from repository_tools.settings import AAZ_SOURCE_REPOSITORY, TOOL_TITLES, _AAZ_OUTPUT_PATTERN, _BEHAVIOR_SIGNAL, _GENERATED_FILE_PATTERNS, _GENERATION_SOURCE_PATTERNS, _GENERATION_SOURCE_PR, _HELP_COMMAND_PATTERNS, _PARAMETER_DECLARATION, _PATCH_HUNK_HEADER, _RELEASE_NOTE_NAMES, _REVIEW_TEST_PATTERNS, _RISK_CUSTOMER_PATTERN, _RISK_DEPENDENCY_PATTERN, _RISK_OPERATIONS_PATTERN, _RISK_RELIABILITY_PATTERN, _RISK_SECURITY_PATTERN, _RISK_SOVEREIGN_PATTERN, _SWAGGER_PATTERNS, _TAUTOLOGICAL_ASSERTIONS
from repository_tools.reviewer.azure_powershell.review import _is_powershell_production_file, _is_powershell_autorest_path, _powershell_review_component, _powershell_command_checks, _review_powershell_autorest

def _review_added_lines(change):
    """Yield visible added patch lines as ``(line_number, text)`` tuples."""
    line_number = None
    for raw_line in (change.get('patch') or '').splitlines():
        header = _PATCH_HUNK_HEADER.match(raw_line)
        if header:
            line_number = int(header.group(1))
            continue
        if line_number is None or raw_line.startswith('\\'):
            continue
        if raw_line.startswith('-'):
            continue
        if raw_line.startswith('+'):
            yield (line_number, raw_line[1:])
        line_number += 1

def _review_matches_any(path, patterns):
    return any((pattern.search(path) for pattern in patterns))

def _review_is_test(path):
    return _review_matches_any(path, _REVIEW_TEST_PATTERNS)

def _review_is_release_note(path):
    return os.path.basename(path).casefold() in _RELEASE_NOTE_NAMES

def _review_is_production_file(repo_full_name, path):
    if repo_full_name != 'Azure/azure-powershell':
        raise ValueError('Review policy belongs to a different repository')
    lower = path.casefold()
    if _review_is_test(path) or _review_is_release_note(path):
        return False
    if lower.startswith(('.github/', 'doc/', 'docs/', 'eng/', 'scripts/')):
        return False
    return _is_powershell_production_file(lower)
    return False

def _review_has_customer_visible_change(change):
    """Use strong patch signals as ambiguous implementation edits stay semantic."""
    path = change['filename']
    if _review_matches_any(path, _HELP_COMMAND_PATTERNS):
        return True
    for _, text in _review_added_lines(change):
        stripped = text.strip()
        if not stripped or stripped.startswith(('#', '//', '/*', '*')):
            continue
        if _BEHAVIOR_SIGNAL.search(stripped):
            return True
    return False

def _review_has_generated_history_marker(change):
    """Recognize generated file headers without matching release note prose."""
    marker = re.compile('^\\s*(?:<!--|[#;/*-]+)?\\s*(?:this\\s+file\\s+is\\s+)?(?:auto(?:matically)?[- ]?)?generated.{0,40}\\bdo\\s+not\\s+edit\\b', re.I)
    visible_lines = []
    for raw_line in (change.get('patch') or '').splitlines():
        if raw_line.startswith(('+++', '---', '@@')):
            continue
        visible_lines.append(raw_line[1:] if raw_line[:1] in ' +' else raw_line)
        if len(visible_lines) >= 20:
            break
    return any((marker.search(line) for line in visible_lines))

def _review_component(repo_full_name, path):
    if repo_full_name != 'Azure/azure-powershell':
        raise ValueError('Review policy belongs to a different repository')
    parts = path.split('/')
    return _powershell_review_component(parts)
    return None

def _review_first_added_line(change):
    return next((line for line, _ in _review_added_lines(change)), None)

def _review_location(change, line=None, head_repo=None, head_sha=None):
    path = change['filename']
    line = line if line is not None else _review_first_added_line(change)
    result = {'file': path}
    if line is not None:
        result['line'] = line
    if head_repo and head_sha:
        url = f"https://github.com/{head_repo}/blob/{head_sha}/{quote(path, safe='/')}"
        if line is not None:
            url += f'#L{line}'
        result['url'] = url
    return result

def _review_finding(tool, change, summary, remediation, verification, *, line=None, severity='blocking', head_repo=None, head_sha=None):
    finding = {'tool': tool, 'tool_title': TOOL_TITLES[tool], 'mode': 'deterministic', 'severity': severity, 'summary': summary, 'remediation': remediation, 'verification': verification}
    finding.update(_review_location(change, line=line, head_repo=head_repo, head_sha=head_sha))
    return finding

def _review_target(tool, files, checks):
    unique_files = sorted(dict.fromkeys(files))
    return {'tool': tool, 'tool_title': TOOL_TITLES[tool], 'mode': 'agent_review', 'files': unique_files[:50], 'file_count': len(unique_files), 'checks': checks}

def _release_artifact_check(repo_full_name, pr, changes, production_changes, head_repo, head_sha):
    if repo_full_name != 'Azure/azure-powershell':
        raise ValueError('Review policy belongs to a different repository')
    findings = []
    pr_title = str((pr or {}).get('title') or '').strip()
    is_azure_cli = False
    is_hotfix = False
    release_changes = [change for change in changes if _review_is_release_note(change['filename'])]
    for change in release_changes:
        if _review_has_generated_history_marker(change):
            findings.append(_review_finding('release-artifact', change, 'This aggregate history file is generated and must not be edited directly.', 'Move the customer-facing entry to the durable release-note source named by the generator and regenerate this artifact.', 'Regenerate release history and confirm this file changes only as generated output.', head_repo=head_repo, head_sha=head_sha))
    customer_visible_changes = [change for change in production_changes if _review_has_customer_visible_change(change)]
    if customer_visible_changes and (not release_changes):
        change = customer_visible_changes[0]
        findings.append(_review_finding('release-artifact', change, 'Customer-visible production behavior changed without a release note in the pull request.', "Add customer-facing release notes to the affected component's upcoming-release history source.", 'Run the repository release-note/history validation and confirm the new entry appears under the upcoming release.', head_repo=head_repo, head_sha=head_sha))
    production_components = {component for change in customer_visible_changes if (component := _review_component(repo_full_name, change['filename']))}
    release_components = {component for change in release_changes if (component := _review_component(repo_full_name, change['filename']))}
    component_scoped_history = True
    if production_components and release_changes:
        missing = sorted(production_components - release_components)
        if missing:
            change = release_changes[0]
            findings.append(_review_finding('release-artifact', change, 'Release notes are not placed with every affected component: ' + ', '.join(missing) + '.', "Move or add each entry to the matching component's durable history file.", 'Run history validation and confirm every changed public component has an upcoming-release entry.', head_repo=head_repo, head_sha=head_sha))
    files = [change['filename'] for change in production_changes + release_changes]
    target = None
    if files:
        release_checks = ['Confirm wording describes customer-visible behavior rather than implementation details.', 'Confirm all public behavior changes are represented exactly once and generated history artifacts are only regenerated.']
        release_checks.insert(0, 'Confirm each entry is under the upcoming release and version headers remain consistent.')
        target = _review_target('release-artifact', files, release_checks)
    return (findings, target)

def _generated_ownership_check(repo_full_name, pr, changes, production_changes, head_repo, head_sha, generation_source_prs=None):
    if repo_full_name != 'Azure/azure-powershell':
        raise ValueError('Review policy belongs to a different repository')
    findings = []
    paths = [change['filename'] for change in changes]
    autorest_target_files = []
    ps_findings, autorest_target_files = _review_powershell_autorest(changes, head_repo, head_sha, _review_finding)
    findings.extend(ps_findings)
    generated = [change for change in changes if _review_matches_any(change['filename'], _GENERATED_FILE_PATTERNS)]
    generation_sources = [path for path in paths if _review_matches_any(path, _GENERATION_SOURCE_PATTERNS)]
    if generation_source_prs is None:
        linked_generation_source = bool(_GENERATION_SOURCE_PR.search(str((pr or {}).get('body') or '')))
        linked_aaz_source = False
    else:
        linked_generation_source = any((source.get('valid') for source in generation_source_prs))
        linked_aaz_source = any((source.get('valid') and str(source.get('repository') or '').casefold() == AAZ_SOURCE_REPOSITORY.casefold() for source in generation_source_prs))
    for change in generated:
        if _is_powershell_autorest_path(change['filename']):
            continue
        is_aaz_output = bool(_AAZ_OUTPUT_PATTERN.search(change['filename']))
        source_is_valid = linked_aaz_source if is_aaz_output else linked_generation_source
        missing_source = not source_is_valid if is_aaz_output else not generation_sources and (not source_is_valid)
        if missing_source:
            if is_aaz_output:
                source_description = 'an open or merged `Azure/aaz` pull request containing the durable command-model change'
                remediation = 'Make the durable command-model change in Azure/aaz, link that PR in this description, then regenerate the downstream `aaz/<profile>` output.'
            else:
                source_description = 'its durable generation source'
                remediation = 'Make the change in the Swagger/specification, AutoRest configuration, template, or generator source and regenerate this file.'
            findings.append(_review_finding('generated-ownership', change, f'A generated file changed without {source_description}.', remediation, 'Regenerate from a clean checkout and confirm the resulting diff contains this change and the linked source PR is open or merged.', head_repo=head_repo, head_sha=head_sha))
    for change in changes:
        if not _review_is_test(change['filename']) and _review_matches_any(change['filename'], _SWAGGER_PATTERNS):
            findings.append(_review_finding('generated-ownership', change, 'REST API specification content is owned by Azure/azure-rest-api-specs, not this repository.', 'Move the specification change to Azure/azure-rest-api-specs and consume the resulting generated SDK here.', 'Link the specification PR and regenerate the client from the approved specification.', head_repo=head_repo, head_sha=head_sha))
    shared_test_files = [path for path in paths if '/tests/' in path.casefold() and _review_component(repo_full_name, path) is None and (os.path.basename(path).casefold() in {'conftest.py', 'base.py', 'common.py', 'utilities.py'})]
    target_files = autorest_target_files + [change['filename'] for change in generated]
    target_files.extend(shared_test_files)
    target_files = list(dict.fromkeys(target_files))
    target = None
    if target_files:
        target = _review_target('generated-ownership', target_files, ['Confirm generated output is reproducible from a durable source changed in this PR.', 'For Azure PowerShell AutoRest projects, confirm the approved Codegen flow produced the generation ID and complete diff; do not accept a hand-edited `generate-info.json`.', 'Confirm module-specific behavior was not added to shared test infrastructure.', 'Confirm each file belongs in this repository and ownership layer.'])
    return (findings, target)

def _test_strength_check(changes, production_changes, head_repo, head_sha):
    findings = []
    test_changes = [change for change in changes if _review_is_test(change['filename'])]
    for change in test_changes:
        for line, text in _review_added_lines(change):
            if any((pattern.search(text) for pattern in _TAUTOLOGICAL_ASSERTIONS)):
                findings.append(_review_finding('test-strength', change, 'This assertion is tautological and cannot detect a regression.', 'Assert the changed request, output, exception, or state against a concrete expected value.', 'Temporarily break the implementation and confirm the test fails for the intended reason.', line=line, head_repo=head_repo, head_sha=head_sha))
    target = None
    if production_changes or test_changes:
        target = _review_target('test-strength', [change['filename'] for change in test_changes + production_changes], ['Confirm assertions can fail when the implementation is wrong and validate request/output mappings.', 'Require relevant negative, empty/null, boundary, multiple-item and exception-propagation cases.', 'Prefer unit tests for deterministic behavior; require live tests only for external integration.'])
    return (findings, target)

def _semantic_targets(repo_full_name, pr, changes, production_changes):
    if repo_full_name != 'Azure/azure-powershell':
        raise ValueError('Review policy belongs to a different repository')
    targets = []
    command_files = [change['filename'] for change in changes if _review_matches_any(change['filename'], _HELP_COMMAND_PATTERNS)]
    if command_files:
        checks = ['Validate concise summaries, terminology, required fields, defaults, outputs, links and executable examples.']
        checks.append(_powershell_command_checks())
        targets.append(_review_target('command-help', command_files, checks))
    intent_files = []
    for change in changes:
        if any((_PARAMETER_DECLARATION.search(text) and (not text.lstrip().startswith(('#', '//', '/*', '*'))) for _, text in _review_added_lines(change))):
            intent_files.append(change['filename'])
    if intent_files:
        targets.append(_review_target('user-intent', intent_files + [change['filename'] for change in production_changes], ['Trace every accepted parameter, flag, field and token from declaration through request or behavior.', 'Flag inputs that are ignored, partially mapped or silently discarded; require honoring, explicit rejection, or a clear warning.']))
    changed_components = sorted({component for change in changes if (component := _review_component(repo_full_name, change['filename']))})
    if changes:
        targets.append(_review_target('scope-consistency', [change['filename'] for change in changes], ['Compare title and description with changed files, release notes, exported commands and actual behavior.', 'Flag unrelated changes, partial migrations and API-version changes whose blast radius exceeds the stated scope.', 'Changed components: ' + (', '.join(changed_components) or 'repository-wide')]))
    edge_files = [change['filename'] for change in production_changes]
    if edge_files:
        targets.append(_review_target('domain-edge-cases', edge_files, ['Inspect null, empty, missing, multiple-value and boundary paths plus request/response mapping loss.', 'Check misleading success/error messages, exception propagation and behavior parity.', 'Check API availability and compatibility, including sovereign clouds when endpoints or API versions change.']))
    return targets

def _deduplicate_findings(findings):
    grouped = {}
    for finding in findings:
        key = (finding['tool'], finding['summary'])
        location = {name: finding[name] for name in ('file', 'line', 'url') if name in finding}
        if key not in grouped:
            grouped[key] = dict(finding)
            grouped[key]['locations'] = [location]
            grouped[key]['occurrence_count'] = 1
            continue
        grouped[key]['occurrence_count'] += 1
        if location not in grouped[key]['locations']:
            grouped[key]['locations'].append(location)
    for finding in grouped.values():
        finding['locations'] = finding['locations'][:5]
    return list(grouped.values())

def analyze_review_tools(repo_full_name, pr, file_changes, *, head_repo=None, head_sha=None, generation_source_prs=None):
    """Run all review tools without exposing patch text in the result.
    """
    if repo_full_name != 'Azure/azure-powershell':
        raise ValueError('Review policy belongs to a different repository')
    changes = [change for change in file_changes or [] if change.get('filename')]
    production_changes = [change for change in changes if _review_is_production_file(repo_full_name, change['filename'])]
    findings = []
    targets = []
    release_findings, release_target = _release_artifact_check(repo_full_name, pr or {}, changes, production_changes, head_repo, head_sha)
    findings.extend(release_findings)
    if release_target:
        targets.append(release_target)
    generated_findings, generated_target = _generated_ownership_check(repo_full_name, pr or {}, changes, production_changes, head_repo, head_sha, generation_source_prs)
    findings.extend(generated_findings)
    if generated_target:
        targets.append(generated_target)
    test_findings, test_target = _test_strength_check(changes, production_changes, head_repo, head_sha)
    findings.extend(test_findings)
    if test_target:
        targets.append(test_target)
    targets.extend(_semantic_targets(repo_full_name, pr or {}, changes, production_changes))
    targeted_tools = {target['tool'] for target in targets}
    finding_tools = {finding['tool'] for finding in findings}
    checks = []
    for tool, title in TOOL_TITLES.items():
        if tool in finding_tools:
            status = 'finding'
        elif tool in targeted_tools:
            status = 'review'
        else:
            status = 'not_applicable'
        checks.append({'tool': tool, 'tool_title': title, 'status': status})
    deduplicated_findings = _deduplicate_findings(findings)
    return {'repository': repo_full_name, 'finding_count': len(deduplicated_findings), 'findings': deduplicated_findings, 'review_targets': targets, 'checks': checks, 'risk_assessment': _review_risk_assessment(repo_full_name, changes, production_changes)}

def _review_risk_assessment(repo_full_name, changes, production_changes):
    """Estimate merge risk from bounded reviewable PR diff signals."""
    if repo_full_name != 'Azure/azure-powershell':
        raise ValueError('Review policy belongs to a different repository')
    changed_tests = any((_review_is_test(change['filename']) for change in changes))
    added = sum((int(change.get('additions') or 0) for change in changes))
    deleted = sum((int(change.get('deletions') or 0) for change in changes))
    changed_lines = added + deleted
    evidence = '\n'.join(('\n'.join([change['filename'], *[text for _, text in _review_added_lines(change)][:100]]) for change in production_changes))
    signals = []
    paths = '\n'.join((change['filename'] for change in changes))

    def add_signal(pattern, points, label, review, path_only=False):
        if pattern.search(paths if path_only else evidence):
            signals.append({'label': label, 'points': points, 'review': review})
    add_signal(_RISK_SECURITY_PATTERN, 28, 'security-sensitive behavior', 'required')
    add_signal(_RISK_SOVEREIGN_PATTERN, 18, 'sovereign-cloud behavior', 'required')
    add_signal(_RISK_OPERATIONS_PATTERN, 22, 'delivery or infrastructure', 'required', True)
    add_signal(_RISK_CUSTOMER_PATTERN, 18, 'public CLI behavior', 'recommended')
    add_signal(_RISK_DEPENDENCY_PATTERN, 18, 'dependency or supply chain', 'required', True)
    add_signal(_RISK_RELIABILITY_PATTERN, 12, 'failure-handling behavior', 'recommended')
    if any((_review_matches_any(change['filename'], _GENERATED_FILE_PATTERNS) for change in changes)):
        signals.append({'label': 'generated output', 'points': 12, 'review': 'recommended'})
    components = sorted({component for change in production_changes if (component := _review_component(repo_full_name, change['filename']))})
    score = 3 if production_changes else 1
    score += min(15, len(changes) // 5 + changed_lines // 250)
    score += sum((signal['points'] for signal in signals))
    if len(components) > 1:
        cross_component_points = min(15, 5 * (len(components) - 1))
        score += cross_component_points
        signals.append({'label': 'cross-component scope', 'points': cross_component_points, 'review': 'recommended'})
    if production_changes and (not changed_tests):
        score += 10
        signals.append({'label': 'no changed regression test', 'points': 10, 'review': 'recommended'})
    elif changed_tests:
        score -= 5
    score = max(0, min(100, score))
    if score >= 75:
        level = 'Critical'
    elif score >= 50:
        level = 'High'
    elif score >= 25:
        level = 'Medium'
    else:
        level = 'Low'
    if any((signal['review'] == 'required' for signal in signals)):
        owner_review = 'required'
    elif score >= 25 or any((signal['review'] == 'recommended' for signal in signals)):
        owner_review = 'recommended'
    else:
        owner_review = 'not required'
    patch_count = sum((bool(change.get('patch')) for change in production_changes))
    if production_changes and patch_count == len(production_changes):
        confidence = 'High'
    elif patch_count:
        confidence = 'Medium'
    else:
        confidence = 'Low'
    return {'score': score, 'level': level, 'confidence': confidence, 'owner_review': owner_review, 'components': components, 'signals': [signal['label'] for signal in signals], 'signal_details': [{'label': signal['label'], 'points': signal['points']} for signal in signals], 'changed_files': len(changes), 'production_files': len(production_changes), 'changed_lines': changed_lines, 'additions': added, 'deletions': deleted, 'changed_tests': changed_tests, 'production_patches': patch_count}
