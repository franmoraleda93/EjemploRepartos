using EjemploRepartos_repository.Interface;
using Nest;
using System;

namespace EjemploRepartos_repository.Repository
{
    public class GeoLocationRepository : IGeoLocationRepository
    {
        public GeoLocationRepository()
        {

        }

        public string GetRepartidorLocation()
        {
            var randomUb = new GeoCoordinate(52.520008, 13.404954); // degrees
            var earthRadius = 6378137.0; // meters
            var dx = 200.0; // meters
            var dy = 300.0; // meters
            var lat2 = randomUb.Latitude + (180 / Math.PI) * (dx / earthRadius);
            var lon2 = randomUb.Longitude + (180 / Math.PI) * (dy / earthRadius) / Math.Cos(randomUb.Latitude);
            var closeTorandom = new GeoCoordinate(lat2, lon2);
            return closeTorandom.Latitude.ToString("##.####") + ";" + closeTorandom.Longitude.ToString("##.####");
        }
    }
}
