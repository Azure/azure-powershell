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
namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation
{
    /// <summary>
    ///     Test Mocking Levels, which control how the service locator should work in
    ///     a test environment.
    /// </summary>
    internal enum ServiceLocationMockingLevel
    {
        /// <summary>
        ///     Apply Full Mocking, All mocking levels should be respected.
        /// </summary>
        ApplyFullMocking,

        /// <summary>
        ///     Apply Individual Test Mocking only.  Only individual test overrides
        ///     should be respected.
        /// </summary>
        ApplyIndividualTestMockingOnly,

        /// <summary>
        ///     Apply Test Run Mocking Only.  Only full test run overrides should
        ///     be respected.
        /// </summary>
        ApplyTestRunMockingOnly,

        /// <summary>
        ///     Apply No Mocking.  No mocking should be respected and only runtime
        ///     objects should be utilized.
        /// </summary>
        ApplyNoMocking
    }
}
