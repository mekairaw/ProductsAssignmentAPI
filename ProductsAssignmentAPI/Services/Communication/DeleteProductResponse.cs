using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAssignmentAPI.Services.Communication
{
    public class DeleteProductResponse: BaseResponse
    {
        private DeleteProductResponse(bool success, string message) : base(success, message) { }
        public DeleteProductResponse():this(true, "El producto ha sido eliminado de la base de datos exitosamente.") { }
        public DeleteProductResponse(string message) : this(false, message) { }
    }
}
