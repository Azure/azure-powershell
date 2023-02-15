// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.OperationalInsights
{
    internal static class Constants
    {
        public const string LinkTargets = "AzureRmOperationalInsightsLinkTargets";

        public const string Workspace = "AzureRmOperationalInsightsWorkspace";

        public const string WorkspaceSharedKeys = "AzureRmOperationalInsightsWorkspaceSharedKeys";

        public const string WorkspaceManagementGroups = "AzureRmOperationalInsightsWorkspaceManagementGroups";

        public const string WorkspaceUsage = "AzureRmOperationalInsightsWorkspaceUsage";

        public const string StorageInsight = "AzureRmOperationalInsightsStorageInsight";

        public const string DataSource = "AzureRmOperationalInsightsDataSource";

        public const string IntelligencePack = "AzureRmOperationalInsightsIntelligencePack";

        public const string IntelligencePacks = "AzureRmOperationalInsightsIntelligencePacks";

        public const string SavedSearch = "AzureRmOperationalInsightsSavedSearch";

        public const string SavedSearchResults = "AzureRmOperationalInsightsSavedSearchResults";

        public const string Schema = "AzureRmOperationalInsightsSchema";

        public const string SearchResults = "AzureRmOperationalInsightsSearchResults";

        public const string ComputerGroup = "AzureRmOperationalInsightsComputerGroup";

        public const string ColumnsExample = "@{ ColName1 = Type; ColName2 = Type; ColName3 = Type}";

        public static string TableDoesNotExist = $"Not found: Workspace {{0}} under resourceGroup {{1}} does not contain the table:{{2}}, please use {CmdletName.NewAzOperationalInsightsTable}.";

        public static string TableAlreadyExist = $"Table: {{0}} under resourceGroup {{1}} and workspace {{2}} already exists, please use {CmdletName.UpdateAzOperationalInsightsTable}.";

        public static string CustomLogTable = "Table name {0} should end with {1}";
    }

    internal static class CmdletName
    {
        public const string NewAzOperationalInsightsTable = "New-AzOperationalInsightsTable";
        public const string UpdateAzOperationalInsightsTable = "Update-AzOperationalInsightsTable";
    }

    internal static class TableConsts
    {
        public const string CustomLogSuffix = "_CL";
        public const string SearchResultsSuffix = "_SRCH";
        public const string RestoredLogsSuffix = "_RST";
        public const string DateTimeExample = "Sat, 28 Aug 2021 05:29:18 GMT";
    }
}