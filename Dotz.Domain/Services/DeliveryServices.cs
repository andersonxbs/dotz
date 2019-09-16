using Dotz.Domain.Entities;
using System;

namespace Dotz.Domain.Services
{
    public static class DeliveryServices
    {
        // TODO
        public static DateTime EstimateDueDateForAddress(Address address)
        {
            return DateTime.Now.AddDays(10);
        }
    }
}
