﻿using Obioha_VillaAPI.Models;
using System.Linq.Expressions;

namespace Obioha_VillaAPI.Repository.IRepository
{
    public interface IHouseRepository : IRepository<House>
    {
       

        Task<House> UpdateHouseAsync(House entity);


    }
}
