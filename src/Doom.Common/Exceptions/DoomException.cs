using System;

namespace Doom.Common.Exceptions
{
    public class DoomException : Exception
    {
        //additional fiedl to pass special error code that app will handle
        public string Code { get; }

        public DoomException()
        {
        }

        public DoomException(string code)
        {
            Code = code;
        }

        public DoomException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public DoomException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public DoomException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public DoomException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}