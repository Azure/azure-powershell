// ----------------------------------------------------------------------------------
//
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

namespace Microsoft.Azure.Commands.SecurityInsights.Common
{
    public static class ParameterSetNames
    {
        # region General
        public const string InputObject = "InputObject";
        public const string WorkspaceScope = "WorkspaceScope";
        public const string ResourceId = "ResourceId";
        public const string GeneralScope = "GeneralScope";
        #endregion

        #region Actions
        public const string ActionId = "ActionId";
        #endregion

        #region AlertRules
        public const string AlertRuleId = "AlertRuleId";
        public const string FusionAlertRule = "FusionAlertRule";
        public const string MicrosoftSecurityIncidentCreationRule = "MicrosoftSecurityIncidentCreationRule";
        public const string ScheduledAlertRule = "ScheduledAlertRule";

        #endregion

        #region Bookmarks
        public const string BookmarkId = "BookmarkId.";
        #endregion


        #region IncidentComments
        public const string IncidentCommentId = "IncidentCommentId";
        #endregion

        #region Incidents
        public const string IncidentId = "IncidentId";
        #endregion



    }
}
