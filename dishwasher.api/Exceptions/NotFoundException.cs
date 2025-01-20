﻿namespace dishwasher.api.Exceptions
{
    public class NotFoundException : ArgumentException
    {
        public NotFoundException() { }

        public NotFoundException(string? message) : base(message) { }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
