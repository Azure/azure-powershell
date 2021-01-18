using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    //Copy from Azure.Identity, do we really need it?
    internal static class TasksExtensions
    {
        public static WithCancellationTaskAwaitable<T> AwaitWithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
                => new WithCancellationTaskAwaitable<T>(task, cancellationToken);

        public static T EnsureCompleted<T>(this ValueTask<T> task)
        {
#if DEBUG
            VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            return task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }


        [Conditional("DEBUG")]
        private static void VerifyTaskCompleted(bool isCompleted)
        {
            if (!isCompleted)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                // Throw an InvalidOperationException instead of using
                // Debug.Assert because that brings down nUnit immediately
                throw new InvalidOperationException("Task is not completed");
            }
        }

        public static T EnsureCompleted<T>(this Task<T> task)
        {
#if DEBUG
            VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            return task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }

        public readonly struct WithCancellationTaskAwaitable<T>
        {
            private readonly CancellationToken _cancellationToken;
            private readonly ConfiguredTaskAwaitable<T> _awaitable;

            public WithCancellationTaskAwaitable(Task<T> task, CancellationToken cancellationToken)
            {
                _awaitable = task.ConfigureAwait(false);
                _cancellationToken = cancellationToken;
            }

            public WithCancellationTaskAwaiter<T> GetAwaiter() => new WithCancellationTaskAwaiter<T>(_awaitable.GetAwaiter(), _cancellationToken);
        }

        public readonly struct WithCancellationTaskAwaiter<T> : ICriticalNotifyCompletion
        {
            private readonly CancellationToken _cancellationToken;
            private readonly ConfiguredTaskAwaitable<T>.ConfiguredTaskAwaiter _taskAwaiter;

            public WithCancellationTaskAwaiter(ConfiguredTaskAwaitable<T>.ConfiguredTaskAwaiter awaiter, CancellationToken cancellationToken)
            {
                _taskAwaiter = awaiter;
                _cancellationToken = cancellationToken;
            }

            public bool IsCompleted => _taskAwaiter.IsCompleted || _cancellationToken.IsCancellationRequested;

            public void OnCompleted(Action continuation) => _taskAwaiter.OnCompleted(WrapContinuation(continuation));

            public void UnsafeOnCompleted(Action continuation) => _taskAwaiter.UnsafeOnCompleted(WrapContinuation(continuation));

            public T GetResult()
            {
                Debug.Assert(IsCompleted);
                if (!_taskAwaiter.IsCompleted)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }
                return _taskAwaiter.GetResult();
            }

            private Action WrapContinuation(in Action originalContinuation)
                => _cancellationToken.CanBeCanceled
                    ? new WithCancellationContinuationWrapper(originalContinuation, _cancellationToken).Continuation
                    : originalContinuation;
        }

        private class WithCancellationContinuationWrapper
        {
            private Action _originalContinuation;
            private readonly CancellationTokenRegistration _registration;

            public WithCancellationContinuationWrapper(Action originalContinuation, CancellationToken cancellationToken)
            {
                Action continuation = ContinuationImplementation;
                _originalContinuation = originalContinuation;
                _registration = cancellationToken.Register(continuation);
                Continuation = continuation;
            }

            public Action Continuation { get; }

            private void ContinuationImplementation()
            {
                Action originalContinuation = Interlocked.Exchange(ref _originalContinuation, null);
                if (originalContinuation != null)
                {
                    _registration.Dispose();
                    originalContinuation();
                }
            }
        }

    }
}
