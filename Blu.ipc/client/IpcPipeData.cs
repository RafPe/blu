using System;
using System.IO.Pipes;

namespace Blu.ipc.client
{
    // Internal data associated with pipes
    internal struct IpcPipeData
    {
        public PipeStream Pipe;
        public Object State;
        public Byte[] Data;
    };
}
