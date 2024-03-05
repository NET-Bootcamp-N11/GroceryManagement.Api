using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Domain.Entities.Enums
{
    public enum Permissions
    {
        CreateProduct = 1,
        CreateOrder,
        GetAllProduct,
        GetAllOrder,
        GetByNameProduct,
        GetByNameOrder,
        GetPictureProduct,
        UpdateProduct,
        UpdateOrder,
        DeleteProduct,  
        DeleteOrder,
        

    }
}
