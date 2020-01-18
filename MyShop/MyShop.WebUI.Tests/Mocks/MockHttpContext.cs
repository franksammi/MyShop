﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.WebUI.Tests.Mocks
{
    public class MockHttpContext : HttpContextBase
    {
        private MockRequset request;

        private MockResponse response;
        private HttpCookieCollection cookies;
        public MockHttpContext()
        {
            cookies = new HttpCookieCollection();
            this.response = new MockResponse(cookies);
            this.request = new MockRequset(cookies);
        }

        public override HttpRequestBase Request {
            get {
                return request;
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return response;
            }
        }
    }

    public class MockResponse : HttpResponseBase
    {
        private readonly HttpCookieCollection cookies;

        public MockResponse(HttpCookieCollection cookies)
        {
            this.cookies = cookies;


        }
        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }


    }

    public class MockRequset : HttpRequestBase
    {
        private readonly HttpCookieCollection cookies;
        public MockRequset(HttpCookieCollection cookies)
        {
            this.cookies = cookies;
        }
       
        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }


    }
}
