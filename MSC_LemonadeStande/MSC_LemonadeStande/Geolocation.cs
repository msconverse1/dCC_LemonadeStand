using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MSC_LemonadeStande
{
  static  class Geolocation
    {
        const string APPID = "AIzaSyDFU_AN2IpA1_u6gELnn1yAk01nutBHtcs";
      static  float latitude;
      static  float longitude;
        
      static  public float Latitude { get => latitude; set => latitude = value; }
      static  public float Longitude { get => longitude; set => longitude = value; }

     static public  void GetGeoLocation()
        {
            string url = " https://maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961452&key=AIzaSyDFU_AN2IpA1_u6gELnn1yAk01nutBHtcs";
            //look at string writer
         


        }


    }
}
