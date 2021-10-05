using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions
{
    public class DomainServiceException : ApplicationException
    {
        public DomainServiceException(string message) : base(message)
        {

        }

        public DomainServiceException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
