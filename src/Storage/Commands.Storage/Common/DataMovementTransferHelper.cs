using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.DataMovement;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    internal class DataMovementTransferHelper
    {
        static public async Task DoTransfer(Func<Task> doTransfer, ProgressRecord record, TaskOutputStream outputStream)
        {
            try
            {
                await doTransfer();

                if (record != null)
                {
                    record.PercentComplete = 100;
                    record.StatusDescription = Resources.TransmitSuccessfully;
                    outputStream.WriteProgress(record);
                }
            }
            catch (OperationCanceledException)
            {
                if (record != null)
                {
                    record.StatusDescription = Resources.TransmitCancelled;
                    outputStream.WriteProgress(record);
                }
            }
            catch (TransferException e)
            {
                // DMLib wrappers StorageException in its InnerException but didn't expose any detailed error messages, 
                // here throw its inner exception out to show more readable error messages.
                StorageException se = e.InnerException as StorageException;

                if (null != se)
                {
                    HandleTransferException(se, record, outputStream);
                    throw se;
                }
                else
                {
                    HandleTransferException(e, record, outputStream);
                    throw;
                }
            }
            catch (Exception e)
            {
                HandleTransferException(e, record, outputStream);
                throw;
            }
        }

        static private void HandleTransferException(Exception e, ProgressRecord record, TaskOutputStream outputStream)
        {
            if (record != null)
            {
                record.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.TransmitFailed, e.Message);
                outputStream.WriteProgress(record);
            }
        }
    }
}
