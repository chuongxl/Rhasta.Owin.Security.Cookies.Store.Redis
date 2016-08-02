# Rhasta.Owin.Security.Cookies.Store.Redis
 Cookie-Store Redis  is a library that includes the implementation for storing cookies in redis.
### Installation :
PM> Install-Package Rhasta.Owin.Security.Cookies.Store.Redis
### Configuration :
  ```
    <configSections>
    <section name="redisCacheClient" type="StackExchange.Redis.Extensions.Core.Configuration.RedisCachingSectionHandler, StackExchange.Redis.Extensions.Core" />
  </configSections>
  
  <redisCacheClient allowAdmin="true" ssl="false" connectTimeout="5000" database="0">
    <hosts>
      <add host="127.0.0.1" cachePort="6379" />
    </hosts>
  </redisCacheClient>
  
  <appSettings>
    <add key="Cache:KeyPrefix" value="AppName" />
  </appSettings>
  
  ```
### Example :
  
  ```
 public void Configuration(IAppBuilder app)
        {

            IDataProtector dataProtector = app.CreateDataProtector(typeof(RedisAuthenticationTicket).FullName);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                SessionStore = new RedisSessionStore(new TicketDataFormat(dataProtector)),
                LoginPath = new PathString("/Auth/LogOn"),
                LogoutPath = new PathString("/Auth/LogOut"),

            });


        }
  ```
