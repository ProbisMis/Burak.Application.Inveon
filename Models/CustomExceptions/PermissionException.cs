using System;

namespace Burak.Application.Inveon.Models.CustomExceptions
{
    public class PermissionException : Exception
    {
        public PermissionException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}