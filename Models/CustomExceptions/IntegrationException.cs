using System;

namespace Burak.Application.Inveon.Models.CustomExceptions
{
    public class IntegrationException : Exception
    {
        public IntegrationException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}