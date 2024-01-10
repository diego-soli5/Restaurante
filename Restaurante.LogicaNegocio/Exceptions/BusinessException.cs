using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.LogicaNegocio.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public int? StatusCode { get; set; }
    }
}
