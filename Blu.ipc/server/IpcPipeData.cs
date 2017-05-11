using System;
using System.IO.Pipes;

namespace Blu.ipc.server
{
    // Internal data associated with pipes
    struct IpcPipeData
    {
        public PipeStream Pipe;
        public Object State;
        public Byte[] Data;
    };
}
