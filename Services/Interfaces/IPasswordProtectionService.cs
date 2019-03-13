using System;
using System.Collections.Generic;
using System.Text;

namespace Programming_Reference_Website.Services.Interfaces
{
    public interface IPasswordProtectionService
    {
        Tuple<byte[], byte[]> Encrypt(string password);

        bool Check(string passwordEntered, byte[] passwordToCheck, byte[] salt);
        
    }
}
    