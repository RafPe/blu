using System;
using System.IO.Pipes;

namespace Blu.ipc.server
{
    // Interface for user code to receive notifications regarding pipe messages
    public interface IIpcCallback
    {
        void OnAsyncMessage(PipeStream pipe, Byte[] data, Int32 bytes, Object state);
    }
}
