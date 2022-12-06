﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Exceptions
{
    public sealed class CommentNotFoundException : NotFoundException
    {
        public CommentNotFoundException(int id) : base($"Comment with id: {id} doesnt exist in the database.")
        {

        }
    }
}
