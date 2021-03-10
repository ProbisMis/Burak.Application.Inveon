using System;

namespace Burak.Application.Inveon.Models.CustomExceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}