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
//
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    /// <summary>
    /// Primitive that combines async lock and value cache
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class AsyncLockWithValue<T>
    {
        private readonly object _syncObj = new object();
        private Queue<TaskCompletionSource<Lock>> _waiters;
        private bool _isLocked;
        private bool _hasValue;
        private T _value;

        /// <summary>
        /// Method that either returns cached value or acquire a lock.
        /// If one caller has acquired a lock, other callers will be waiting for the lock to be released.
        /// If value is set, lock is released and all waiters get that value.
        /// If value isn't set, the next waiter in the queue will get the lock.
        /// </summary>
        /// <param name="async"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async ValueTask<Lock> GetLockOrValueAsync(bool async, CancellationToken cancellationToken = default)
        {
            TaskCompletionSource<Lock> valueTcs;
            lock (_syncObj)
            {
                // If there is a value, just return it
                if (_hasValue)
                {
                    return new Lock(_value);
                }

                // If lock isn't acquire yet, acquire it and return to the caller
                if (!_isLocked)
                {
                    _isLocked = true;
                    return new Lock(this);
                }

                // Check cancellationToken before instantiating waiter
                cancellationToken.ThrowIfCancellationRequested();

                // If lock is already taken, create a waiter and wait either until value is set or lock can be acquired by this waiter
                if(_waiters is null)
                {
                    _waiters = new Queue<TaskCompletionSource<Lock>>();
                }
                // if async == false, valueTcs will be waited only in this thread and only synchronously, so RunContinuationsAsynchronously isn't needed.
                valueTcs = new TaskCompletionSource<Lock>(async ? TaskCreationOptions.RunContinuationsAsynchronously : TaskCreationOptions.None);
                _waiters.Enqueue(valueTcs);
            }

            try
            {
                if (async)
                {
                    return await valueTcs.Task.AwaitWithCancellation(cancellationToken);
                }

#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
#pragma warning disable AZC0111 // DO NOT use EnsureCompleted in possibly asynchronous scope.
                valueTcs.Task.Wait(cancellationToken);
                return valueTcs.Task.EnsureCompleted();
#pragma warning restore AZC0111 // DO NOT use EnsureCompleted in possibly asynchronous scope.
#pragma warning restore AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
            }
            catch (OperationCanceledException)
            {
                // Throw OperationCanceledException only if another thread hasn't set a value to this waiter
                // by calling either Reset or SetValue
                if (valueTcs.TrySetCanceled(cancellationToken))
                {
                    throw;
                }

                return valueTcs.Task.Result;
            }
        }

        /// <summary>
        /// Set value to the cache and to all the waiters
        /// </summary>
        /// <param name="value"></param>
        private void SetValue(T value)
        {
            Queue<TaskCompletionSource<Lock>> waiters;
            lock (_syncObj)
            {
                _value = value;
                _hasValue = true;
                _isLocked = false;
                if (_waiters == default)
                {
                    return;
                }

                waiters = _waiters;
                _waiters = default;
            }

            while (waiters.Count > 0)
            {
                waiters.Dequeue().TrySetResult(new Lock(value));
            }
        }

        /// <summary>
        /// Try to reset value and fail if value is locked.
        /// </summary>
        /// <returns></returns>
        public bool TryClearValue()
        {
            lock (_syncObj)
            {
                if (!_isLocked)
                {
                    _value = default(T);
                    _hasValue = false;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Release the lock and allow next waiter acquire it
        /// </summary>
        private void Reset()
        {
            TaskCompletionSource<Lock> nextWaiter = UnlockOrGetNextWaiter();
            while (nextWaiter != default && !nextWaiter.TrySetResult(new Lock(this)))
            {
                nextWaiter = UnlockOrGetNextWaiter();
            }
        }

        private TaskCompletionSource<Lock> UnlockOrGetNextWaiter()
        {
            lock (_syncObj)
            {
                if (!_isLocked)
                {
                    return default;
                }

                if (_waiters == default)
                {
                    _isLocked = false;
                    return default;
                }

                while (_waiters.Count > 0)
                {
                    var nextWaiter = _waiters.Dequeue();
                    if (!nextWaiter.Task.IsCompleted)
                    {
                        // Return the waiter only if it wasn't canceled already
                        return nextWaiter;
                    }
                }

                _isLocked = false;
                return default;
            }
        }

        public readonly struct Lock : IDisposable
        {
            private readonly AsyncLockWithValue<T> _owner;
            public bool HasValue => _owner == default;
            public T Value { get; }

            public Lock(T value)
            {
                _owner = default;
                Value = value;
            }

            public Lock(AsyncLockWithValue<T> owner)
            {
                _owner = owner;
                Value = default;
            }

            public void SetValue(T value) => _owner.SetValue(value);

            public void Dispose() => _owner?.Reset();
        }
    }
}
