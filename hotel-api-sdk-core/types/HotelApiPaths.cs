﻿using System;
using System.Collections.Generic;
using System.Net.Http;

namespace com.hotelbeds.distribution.hotel_api_sdk_core.types
{
    public class HotelApiPaths
    {
        public class HotelApiPathsBase
        {
            protected string urlTemplate = "${path}/${version}/";
            protected HttpMethod httpMethod;
            protected string endpoint;

            public string getUrl(string basePath, HotelApiVersion version)
            {
                string versionString = "1.0";
                if(version.version == HotelApiVersion.versions.V0_2)
                {
                    versionString = "0.2";
                }
                else if (version.version == HotelApiVersion.versions.V1)
                {
                    versionString = "1.0";
                }
                else if (version.version == HotelApiVersion.versions.V1_1)
                {
                    versionString = "1.1";
                }
                else if (version.version == HotelApiVersion.versions.V1_2)
                {
                    versionString = "1.2";
                }
                return urlTemplate.Replace("${path}", basePath).Replace("${version}", versionString);
            }            

            public HttpMethod getHttpMethod()
            {
                return httpMethod;
            }

            public string getEndPoint()
            {
                return endpoint;
            }

            public string getEndPoint(List<Tuple<string, string>> param)
            {
                if  (param != null)
                {
                    for (int i = 0; i < param.Count; i++)
                        endpoint = endpoint.Replace(param[i].Item1, param[i].Item2);
                }
                return (param!= null) ? endpoint : endpoint + "/";
            }
        }

        /// <summary>
        /// Clase para poder comprobar el estado del servidor rest
        /// </summary>
        public class STATUS : HotelApiPathsBase
        {
            public STATUS()
            {
                httpMethod = new HttpMethod("GET");
                endpoint = "status";
            }
        }

        /// <summary>
        /// Clase para poder lanzar peticiones AVAIL
        /// </summary>
        public class AVAILABILITY : HotelApiPathsBase
        {
            public AVAILABILITY()
            {
                httpMethod = new HttpMethod("POST");
                endpoint = "hotels";
            }
        }

        public class CHECKRATE : HotelApiPathsBase
        {
            public CHECKRATE()
            {
                httpMethod = new HttpMethod("GET");
                endpoint = "checkrates";
            }
        }

        public class CHECK_AVAIL : HotelApiPathsBase
        {
            public CHECK_AVAIL()
            {
                httpMethod = new HttpMethod("POST");
                endpoint = "checkrates";
            }
        }

        public class BOOKING_CONFIRM : HotelApiPathsBase
        {
            public BOOKING_CONFIRM()
            {
                
                httpMethod = new HttpMethod("POST");
                endpoint = "bookings";
            }
        }

        public class BOOKING_CANCEL : HotelApiPathsBase
        {
            public BOOKING_CANCEL()
            {
                httpMethod = new HttpMethod("DELETE");
                endpoint = "bookings/${bookingId}?cancellationFlag=${flag}";
            }
        }

        public class BOOKING_DETAIL : HotelApiPathsBase
        {
            public BOOKING_DETAIL()
            {
                httpMethod = new HttpMethod("GET");
                endpoint = "bookings/${bookingId}";
            }
        }

        public class BOOKING_LIST : HotelApiPathsBase
        {
            public BOOKING_LIST()
            {
                httpMethod = new HttpMethod("GET");                
                endpoint = "bookings?start=${start}&end=${end}&filterType=${filterType}&includeCancelled=${includeCancelled}&from=${from}&to=${to}";
            }
        }
        

    }
}
