using System;

namespace Burak.Application.Inveon.Models.CustomExceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}