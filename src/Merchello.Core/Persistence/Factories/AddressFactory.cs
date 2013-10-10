﻿using System;
using Merchello.Core.Models;
using Merchello.Core.Models.Rdbms;

namespace Merchello.Core.Persistence.Factories
{
    internal class AddressFactory : IEntityFactory<IAddress, CustomerAddressDto>
    {

        public IAddress BuildEntity(CustomerAddressDto dto)
        {
            var address = new Address(dto.CustomerKey, dto.Label)
            {
                Id = dto.Id, 
                FullName = dto.FullName,
                Company =  dto.Company,
                AddressTypeFieldKey = dto.AddressTfKey,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                Locality = dto.Locality,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                CountryCode = dto.CountryCode,
                Phone = dto.Phone,
                CreateDate = dto.CreateDate,
                UpdateDate = dto.UpdateDate
            };

            address.ResetDirtyProperties();

            return address;
        }

        public CustomerAddressDto BuildDto(IAddress entity)
        {
            var dto = new CustomerAddressDto()
            {
                Id = entity.Id,
                CustomerKey = entity.CustomerKey,
                Label = entity.Label,
                FullName = entity.FullName,
                Company = entity.Company,
                AddressTfKey = entity.AddressTypeFieldKey,
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                Locality = entity.Locality,
                Region = entity.Region,
                PostalCode = entity.PostalCode,
                CountryCode = entity.CountryCode,
                Phone = entity.Phone,
                UpdateDate = entity.UpdateDate,
                CreateDate = entity.CreateDate
            };

            return dto;
        }
    }
}
