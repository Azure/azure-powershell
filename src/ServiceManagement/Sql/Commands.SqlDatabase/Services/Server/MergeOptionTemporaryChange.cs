﻿// ----------------------------------------------------------------------------------
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
using System.Data.Services.Client;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server
{
    /// <summary>
    /// A class that will temporarily change the merge option on a <see cref="DataServiceContext"/>
    /// object.
    /// </summary>
    internal class MergeOptionTemporaryChange : IDisposable
    {
        /// <summary>
        /// The merge option before it gets changed.
        /// </summary>
        private MergeOption oldValue;

        /// <summary>
        /// The context we are adjusting.
        /// </summary>
        private DataServiceContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MergeOptionTemporaryChange"/> class.  This
        /// also sets the merge option to <paramref name="tempValue"/>.
        /// </summary>
        /// <param name="context">The context to do the change to</param>
        /// <param name="tempValue">the new temporary value for the context's merge option</param>
        public MergeOptionTemporaryChange(DataServiceContext context, MergeOption tempValue)
        {
            this.context = context;
            this.oldValue = context.MergeOption;
            context.MergeOption = tempValue;
        }

        /// <summary>
        /// Restore the MergeOption on the context
        /// </summary>
        public void Dispose()
        {
            this.context.MergeOption = this.oldValue;
        }
    }
}
