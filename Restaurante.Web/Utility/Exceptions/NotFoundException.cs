﻿namespace Restaurante.Web.Utility.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
