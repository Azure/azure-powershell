﻿// ----------------------------------------------------------------------------------
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

using System;
using System.Linq;
using System.Web;

namespace Microsoft.Azure.Commands.MachineLearning.Utilities
{
    public abstract class MachineLearningClientBase
    {
        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        protected static string GetSkipTokenFromLink(string nextLink)
        {
            string skipToken = null;
            if (!string.IsNullOrWhiteSpace(nextLink))
            {
                var linkAsUri = new Uri(nextLink, UriKind.Absolute);
                var queryParameters = HttpUtility.ParseQueryString(linkAsUri.Query);
                skipToken = (queryParameters.GetValues("$skiptoken") ??
                                                Enumerable.Empty<string>()).FirstOrDefault();
            }

            return skipToken;
        }
    }
}