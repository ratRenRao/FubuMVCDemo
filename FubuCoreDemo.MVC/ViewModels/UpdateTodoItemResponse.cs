﻿using System.Net;

namespace FubuMVCTODO.Todo
{
    public class UpdateTodoItemResponse
    {
        //QUESTION: is there a way to just return the HttpStatusCode instead of puting it into an object
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}