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

using System;

namespace Microsoft.WindowsAzure.Commands.Common.Test
{
    public static class TestExecutionHelpers
    {
        /// <summary>
        /// Retry an action until it succeeds - use for flaky tests
        /// </summary>
        /// <param name="testAction">Action tor etry</param>
        /// <param name="maxTries">The maximum number of times to try the action</param>
        public static void RetryAction(Action testAction, int maxTries = 3)
        {
            var tries = 0;
            var succeeded = false;
            do
            {
                try
                {
                    testAction();
                    succeeded = true;
                }
                catch (Exception)
                {
                    if (++tries >= maxTries)
                    {
                        throw;
                    }
                }
            } while (!succeeded);
        }
    }
}
