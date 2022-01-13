using EbolaApi.Core.Entities;
using EbolaApi.Core.Services;
using EbolaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EbolaApi.Services
{
    public class LocationService : ILocationService
    {
        private readonly IContext _context;

        public LocationService(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Add(Location location)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Location FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAll()
        {
            return _context.Locations.ToList();
        }

        public int Update(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
