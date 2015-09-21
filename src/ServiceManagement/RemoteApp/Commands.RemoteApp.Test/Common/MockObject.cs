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

namespace Microsoft.WindowsAzure.Commands.RemoteApp.Test.Common
{
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using System;
    using System.Collections.Generic;

    public static class ExtensionMethodsClass
    {
        public static MockCommandRuntime runTime<T>(this T MockCmdlet) where T : RdsCmdlet
        {
            return ((MockCommandRuntime)MockCmdlet.CommandRuntime);
        }

        public static void ResetPipelines<T>(this T MockCmdlet) where T : RdsCmdlet
        {
            ((MockCommandRuntime)MockCmdlet.CommandRuntime).ResetPipelines();
        }

        public static string[] ToArray(IList<string> list)
        {
            return MockObject.ConvertList<string>(list).ToArray();
        }
    }

    public partial class MockObject
    {
        internal static IList<Collection> mockCollectionList { get; set; }

        internal static IList<RemoteAppVm> mockVmList { get; set; }

        internal static IList<Region> mockRegionList {get; set;}

        internal static IList<VNet> mockVNetList { get; set; }

        internal static IList<LocalModels.ConsentStatusModel> mockUsersConsents { get; set; }

        internal static IList<SecurityPrincipal> mockUsers { get; set; }

        internal static IList<SecurityPrincipalOperationsResult> mockSecurityPrincipalResult { get; set; }

        internal static IList<TemplateImage> mockTemplates { get; set; }

        internal static IList<PublishedApplicationDetails> mockApplicationList { get; set; }

        internal static IList<StartMenuApplication> mockStartMenuList { get; set; }

        internal static IList<Vendor> mockVpnList { get; set; }

        internal static IList<VNetOperationStatus> mockVNetStatusList { get; set; }

        internal static IList<OperationResult> mockOperationResult { get; set; }

        internal static IList<TrackingResult> mockTrackingId { get; set; }

        internal static IList<Workspace> mockWorkspace { get; set; }

        internal static string mockTemplateScript { get; set; }

        internal delegate bool Comparer<T>(List<T> list, T o);

        internal static List<T> ConvertList<T>(IEnumerable<Object> listOfObjects)
        {
            List<T> retVal = new List<T>();

            foreach (Object o in listOfObjects)
            {
                retVal.Add((T)o);
            }

            return retVal;
        }

        internal static List<VNetOperationStatus> ConvertEnumList(IEnumerable<VNetOperationStatus> listOfObjects)
        {
            List<VNetOperationStatus> retVal = new List<VNetOperationStatus>();

            foreach (Object o in listOfObjects)
            {
                retVal.Add((VNetOperationStatus)o);
            }

            return retVal;
        }

        private static List<T> ExpectedResult<T>()
        {
            List<T> expectedResults = null;
            if (typeof(T) == typeof(Collection))
            {
                expectedResults = ConvertList<T>(mockCollectionList);
            }
            else if (typeof(T) == typeof(RemoteAppVm))
            {
                expectedResults = ConvertList<T>(mockVmList);
            }
            else if (typeof(T) == typeof(Region))
            {
                expectedResults = ConvertList <T>(mockRegionList);
            }
            else if (typeof(T) == typeof(TemplateImage))
            {
                expectedResults = ConvertList<T>(mockTemplates);
            }
            else if (typeof(T) == typeof(VNet))
            {
                expectedResults = ConvertList<T>(mockVNetList);
            }
            else if (typeof(T) == typeof(Vendor))
            {
                expectedResults = ConvertList<T>(mockVpnList);
            }
            else if (typeof(T) == typeof(LocalModels.ConsentStatusModel))
            {
                expectedResults = ConvertList<T>(mockUsersConsents);
            }
            else if (typeof(T) == typeof(SecurityPrincipalOperationsResult))
            {
                expectedResults = ConvertList<T>(mockSecurityPrincipalResult);
            }
            else if (typeof(T) == typeof(PublishedApplicationDetails))
            {
                expectedResults = ConvertList<T>(mockApplicationList);
            }
            else if (typeof(T) == typeof(StartMenuApplication))
            {
                expectedResults = ConvertList<T>(mockStartMenuList);
            }
            else if (typeof(T) == typeof(OperationResult))
            {
                expectedResults = ConvertList<T>(mockOperationResult);
            }
            else if (typeof(T) == typeof(Workspace))
            {
                expectedResults = ConvertList<T>(mockWorkspace);
            }
            else if (typeof(T) == typeof(TrackingResult))
            {
                expectedResults = ConvertList<T>(mockTrackingId);
            }

            return expectedResults;
        }

        internal static bool HasExpectedResults<T>(List<T> actualResults, Comparer<T> contains)
        {
            bool fRet = true;
            List<T> expectedResults = ExpectedResult<T>();

            foreach (T result in actualResults)
            {
                if (!contains(expectedResults, result))
                {
                    fRet = false;
                    break;
                }
            }

            return fRet;
        }

        public static bool ContainsExpectedTrackingId(List<TrackingResult> expectedResult, TrackingResult actual)
        {
            bool isIdentical = false;
            foreach (TrackingResult expected in expectedResult)
            {
                isIdentical = expected.TrackingId == actual.TrackingId;
                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }
    }
}
