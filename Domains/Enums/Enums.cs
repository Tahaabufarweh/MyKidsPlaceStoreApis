using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Enums
{

    public enum GlobalStatusEnum {
        Active = 1,
        InActive = 2,
        InCart = 3,
        NotifyIfAvailable = 4,
        InMyOrders = 5,
        InSale = 6
    }
    public enum CartItemStatusEnum
    {
        InCart = 1,
        NotifyIfAvailable = 2
    }

}
