using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Command
{
    public class ValidationError
    {
        public string Property { get; private set; }

        public string ErrorMessage { get; private set; }

        public ValidationError(string property, string errorMessage)
        {
            Property = property;
            ErrorMessage = errorMessage;
        }
    }
}
