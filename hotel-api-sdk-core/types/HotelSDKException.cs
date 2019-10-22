﻿using com.hotelbeds.distribution.hotel_api_model.auto.messages;
using System;
using System.Collections.Generic;
using System.Text;


namespace com.hotelbeds.distribution.hotel_api_sdk_core.types
{
    class HotelSDKException : Exception
    {
        public const long serialVersionUID = 1L;
        private readonly HotelbedsError error;

        HotelSDKException( HotelbedsError error ) : base()
        {
            this.error = error;
        }

        HotelSDKException( HotelbedsError error, String message, Exception innerEx ) : base( message, innerEx )
        {
            this.error = error;
        }
    }
}
