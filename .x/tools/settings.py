# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Repository-owned domain patterns and integration declarations."""
import re

AAZ_SOURCE_REPOSITORY = 'Azure/aaz'
COMPONENT_DISPLAY_NAMES = {'vm': 'VM', 'vmss': 'VMSS', 'acr': 'ACR', 'acs': 'AKS', 'aks': 'AKS', 'keyvault': 'KeyVault', 'appservice': 'AppService', 'cosmosdb': 'Cosmos DB', 'sql': 'SQL', 'mysql': 'MySQL', 'postgres': 'PostgreSQL', 'rdbms': 'RDBMS', 'network': 'Network', 'storage': 'Storage', 'role': 'Role', 'resource': 'Resource', 'backup': 'Backup', 'batch': 'Batch', 'monitor': 'Monitor', 'iot': 'IoT', 'cdn': 'CDN', 'dns': 'DNS', 'eventhubs': 'Event Hubs', 'servicebus': 'Service Bus', 'eventgrid': 'Event Grid', 'containerapp': 'Container Apps', 'apim': 'API Management', 'appconfig': 'App Config', 'hdinsight': 'HDInsight', 'signalr': 'SignalR', 'search': 'Search', 'redis': 'Redis', 'advisor': 'Advisor', 'profile': 'Profile', 'identity': 'Identity', 'core': 'Core'}
PR_FORMAT_DOC_URL = 'https://github.com/Azure/azure-cli/tree/dev/doc/authoring_command_modules#submitting-pull-requests'
PR_TEMPLATE_URL = 'https://github.com/Azure/azure-cli/blob/dev/.github/pull_request_template.md'
TOOL_TITLES = {'release-artifact': 'Release artifact validator', 'generated-ownership': 'Generated code ownership checker', 'command-help': 'Command and help convention checker', 'test-strength': 'Test semantic-strength reviewer', 'user-intent': 'No-silent-user-intent reviewer', 'scope-consistency': 'Scope-consistency reviewer', 'domain-edge-cases': 'Domain edge-case reviewer'}
_AAZ_OUTPUT_PATTERN = re.compile('(?:^|/)aaz/[^/]+/', 34)
_AUTO_TITLE_REPAIR_REPOS = {'Azure/azure-cli': 'cli', 'Azure/azure-powershell': 'powershell'}
_AZ_COMMAND_ACTIONS = {'add', 'apply', 'approve', 'cancel', 'check-name', 'create', 'delete', 'disable', 'download', 'enable', 'export', 'get', 'invoke', 'list', 'login', 'logout', 'open', 'remove', 'reset', 'restart', 'restore', 'set', 'show', 'start', 'stop', 'sync', 'update', 'upgrade', 'upload', 'validate', 'wait'}
_AZ_COMMAND_PROSE_BOUNDARIES = {'does', 'fails', 'for', 'is', 'returns', 'should', 'when', 'with'}
_BACKTICKED_AZ_COMMAND_PATTERN = re.compile('`(az\\s+[^`]+)`', 34)
_BEHAVIOR_SIGNAL = re.compile('(?:add_argument|register_command|command_group|custom_command|generic_update_command|AAZ|Cmdlet\\(|\\[Parameter\\b|\\b(?:GET|POST|PUT|PATCH|DELETE)\\b|api[_-]?version)', 34)
_CLI_PARAMETER_PATTERN = re.compile('(?<![`A-Za-z0-9])(--[a-z0-9][a-z0-9-]*)(?![`A-Za-z0-9-])', 34)
_GENERATED_FILE_PATTERNS = (re.compile('(?:^|/)generated(?:/|$)', re.IGNORECASE), re.compile('(?:^|/)aaz/[^/]+/', re.IGNORECASE), re.compile('(?:^|/)vendored_sdks?/.*(?:_client|_configuration|_serialization)\\.py$', re.IGNORECASE), re.compile('(?:^|/)vendored_sdks?/.*/models/_models.*\\.py$', re.IGNORECASE), re.compile('(?:^|/)vendored_sdks?/.*/operations/_.*\\.py$', re.IGNORECASE), re.compile('(?:^|/)(?:autorest|generated)[^/]*\\.cs$', re.IGNORECASE), re.compile('\\.generated\\.cs$', re.IGNORECASE))
_GENERATION_SOURCE_PATTERNS = (re.compile('(?:^|/)(?:swagger|specification|specs?)(?:/|$)', re.IGNORECASE), re.compile('(?:^|/)(?:codegen|generation)(?:/|$)', re.IGNORECASE), re.compile('(?:^|/)(?:swagger|specification|codegen|generation)/.*(?:readme|autorest)\\.(?:md|ya?ml)$', re.IGNORECASE), re.compile('(?:^|/)_meta\\.(?:json|ya?ml)$', re.IGNORECASE))
_GENERATION_SOURCE_PR = re.compile('https://github\\.com/Azure/(?:azure-rest-api-specs|aaz|aaz-dev-tools|azure-cli|azure-cli-extensions)/pull/\\d+', 34)
_HELP_COMMAND_PATTERNS = (re.compile('(?:^|/)_help\\.py$', re.IGNORECASE), re.compile('(?:^|/)(?:commands|parameters)\\.py$', re.IGNORECASE), re.compile('(?:^|/)help/.*\\.(?:md|txt)$', re.IGNORECASE), re.compile('\\.(?:psd1|psm1)$', re.IGNORECASE), re.compile('(?:cmdlet|commands?)\\.cs$', re.IGNORECASE))
_HISTORY_NOTES_HEADING_PATTERN = re.compile('^\\s*\\*\\*History Notes\\*\\*\\s*$', 34)
_MARKDOWN_SECTION_BREAK_PATTERN = re.compile('^\\s*---\\s*$', 32)
_MODULE_PATH_PATTERN = re.compile('command_modules/([a-z0-9_-]+)', 34)
_PARAMETER_DECLARATION = re.compile('(?:add_argument|(?:^|\\.)argument\\(|(?:^|\\.)parameter\\(|(?:^|\\.)option\\(|ArgumentMetadata|\\[Parameter\\b|SwitchParameter)', 34)
_PATCH_HUNK_HEADER = re.compile('^@@ -\\d+(?:,\\d+)? \\+(\\d+)(?:,\\d+)? @@', 32)
_PLAIN_AZ_COMMAND_PATTERN = re.compile('\\b(az\\s+[a-z0-9-]+(?:\\s+[a-z0-9-]+)*)', 34)
_PS_CMDLET_PATTERN = re.compile('\\b(?:Get|Set|New|Remove|Update|Add|Start|Stop|Restart|Restore|Invoke|Test|Enable|Disable|Import|Export|Register|Unregister|Connect|Disconnect|Move|Copy|Rename|Resize|Switch|Publish|Reset|Revoke|Grant|Approve|Deny)-Az([A-Za-z][A-Za-z0-9]+)', 34)
_PS_PATH_PATTERN = re.compile('(?:^|[\\s/])src/([A-Za-z][A-Za-z0-9.]+)', 32)
_PS_TEST_FILE_PATTERN = re.compile('(?:^|/)src/[^/]+/[^/]+\\.Test/.*\\.(?:cs|ps1)$', 34)
_RELEASE_NOTE_NAMES = {'changelog.md', 'changelog.rst', 'history.rst', 'release-notes.md', 'releasenotes.md'}
_REVIEW_TEST_PATTERNS = (re.compile('(?:^|/)tests?(?:/|$)', re.IGNORECASE), re.compile('\\.tests?(?:/|$)', re.IGNORECASE), re.compile('(?:^|/)test_[^/]+\\.py$', re.IGNORECASE), re.compile('(?:^|/)[^/]*tests?\\.cs$', re.IGNORECASE))
_RISK_CUSTOMER_PATTERN = re.compile('(?:commands?\\.py$|custom\\.py$|_params\\.py$|_help\\.py$|aaz/latest|output|formatter|api[_ -]?version|breaking)', 42)
_RISK_DEPENDENCY_PATTERN = re.compile('(?:requirements[^/]*\\.txt$|pyproject\\.toml$|setup\\.py$|package-lock\\.json$|pom\\.xml$|packages\\.lock\\.json$)', 42)
_RISK_OPERATIONS_PATTERN = re.compile('(?:^|/)(?:\\.x|\\.github/workflows|\\.pipelines|eng/pipelines|deploy|infra)(?:/|$)|(?:azure-pipelines|dockerfile|helm|terraform|bicep)', 42)
_RISK_RELIABILITY_PATTERN = re.compile('(?:retry|timeout|concurren|lock|thread|async|cache|rollback|exception|error[_ -]?handling|resource[_ -]?leak)', 34)
_RISK_SECURITY_PATTERN = re.compile('(?:auth(?:entication|orization)?|rbac|managed[_ -]?identity|token|secret|credential|encrypt|network|tenant|role[_ -]?assignment|command[_ -]?injection|supply[_ -]?chain)', 34)
_RISK_SOVEREIGN_PATTERN = re.compile('(?:AzureChinaCloud|AzureUSGovernment|AzureStack|sovereign|cloud[_ -]?profile)', 34)
_SWAGGER_PATTERNS = (re.compile('(?:^|/)swagger(?:/|$)', re.IGNORECASE), re.compile('(?:^|/)specification(?:/|$)', re.IGNORECASE), re.compile('(?:^|/)(?:openapi|swagger)[^/]*\\.(?:json|ya?ml)$', re.IGNORECASE))
_TAUTOLOGICAL_ASSERTIONS = (re.compile('^\\s*assert\\s+True\\s*(?:#.*)?$', re.IGNORECASE), re.compile('\\bself\\.assertTrue\\(\\s*True\\s*\\)', re.IGNORECASE), re.compile('\\bAssert\\.(?:True|AreEqual)\\(\\s*true(?:\\s*,\\s*true)?\\s*\\)', re.IGNORECASE), re.compile('\\bShould\\(\\)\\.Be\\(\\s*true\\s*\\)', re.IGNORECASE))
_TITLE_ISSUE_PATTERN = re.compile('^\\s*Fix(?:es|ed|ing)?\\s+#(\\d+)\\s*:?\\s*', 34)
_TITLE_PREFIX_PATTERN = re.compile('^\\s*[\\[{]([^\\]}]+)[\\]}]\\s*', 32)
_TITLE_VERB_REPLACEMENTS = {'added': 'Add', 'adding': 'Add', 'adds': 'Add', 'allowed': 'Allow', 'allowing': 'Allow', 'allows': 'Allow', 'changed': 'Change', 'changing': 'Change', 'changes': 'Change', 'collected': 'Collect', 'collecting': 'Collect', 'collects': 'Collect', 'deprecated': 'Deprecate', 'deprecating': 'Deprecate', 'deprecates': 'Deprecate', 'disabled': 'Disable', 'disabling': 'Disable', 'disables': 'Disable', 'enabled': 'Enable', 'enabling': 'Enable', 'enables': 'Enable', 'fixed': 'Fix', 'fixing': 'Fix', 'fixes': 'Fix', 'improved': 'Improve', 'improving': 'Improve', 'improves': 'Improve', 'made': 'Make', 'making': 'Make', 'makes': 'Make', 'moved': 'Move', 'moving': 'Move', 'moves': 'Move', 'renamed': 'Rename', 'renaming': 'Rename', 'renames': 'Rename', 'replaced': 'Replace', 'replacing': 'Replace', 'replaces': 'Replace', 'removed': 'Remove', 'removing': 'Remove', 'removes': 'Remove', 'supported': 'Support', 'supporting': 'Support', 'supports': 'Support', 'updated': 'Update', 'updating': 'Update', 'updates': 'Update', 'upgraded': 'Upgrade', 'upgrading': 'Upgrade', 'upgrades': 'Upgrade'}
