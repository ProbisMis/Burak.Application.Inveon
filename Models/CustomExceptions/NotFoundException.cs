using System;

namespace Burak.Application.Inveon.Models.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, Exception innerEx = null) : base(message, innerEx)
        {
            //TODO: Handle errors here? Challenge: Many exceptinos all needs to implemented
            
        }
    }
}