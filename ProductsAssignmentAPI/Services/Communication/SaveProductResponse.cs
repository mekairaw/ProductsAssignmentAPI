﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAssignmentAPI.Services.Communication
{
    public class SaveProductResponse : BaseResponse
    {
        private SaveProductResponse(bool success, string message) : base(success, message) { }

        //en caso de exito
        public SaveProductResponse() : this(true, "The product has been saved successfully.") { }

        //en caso de fallar en la creacion
        public SaveProductResponse(string message): this(false, message) { }
    }
}
