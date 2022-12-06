using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Exceptions
{
    public sealed class TitleBadRequestException : BadRequestException
    {
        public TitleBadRequestException(string title) : base($"Entity with this title: {title} already exists in database.")
        {
        }
    }
}
