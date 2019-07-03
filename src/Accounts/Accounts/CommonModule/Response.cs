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
using System.Threading.Tasks;


namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Representing a response in EventData
    /// </summary>
    public class Response : EventData
    {
        public Response() : base()
        {
        }
    }

    /// <summary>
    /// Representing a typed response in eventdata - allows lazily expanding and caching a result delegate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : Response
    {
        private Func<Task<T>> _resultDelegate;
        private Task<T> _resultValue;

        /// <summary>
        /// Create a response from a pre-defined value
        /// </summary>
        /// <param name="value"></param>
        public Response(T value) : base() => _resultValue = Task.FromResult(value);

        /// <summary>
        /// Create a response from a synchronous value delegate
        /// </summary>
        /// <param name="value"></param>
        public Response(Func<T> value) : base() => _resultDelegate = () => Task.FromResult(value());

        /// <summary>
        /// Create a response from an asynchronous value delegate
        /// </summary>
        /// <param name="value"></param>
        public Response(Func<Task<T>> value) : base() => _resultDelegate = value;

        /// <summary>
        /// Return an awaitable response, using any previously cached response value, or creating one if it doesn't exxist
        /// </summary>
        public Task<T> Result => _resultValue ?? (_resultValue = this._resultDelegate());
    }
}