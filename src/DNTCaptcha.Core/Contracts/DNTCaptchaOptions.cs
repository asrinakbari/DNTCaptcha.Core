using System;
using DNTCaptcha.Core.Providers;

namespace DNTCaptcha.Core.Contracts
{
    /// <summary>
    /// Defines DNTCaptcha's Options
    /// </summary>
    public class DNTCaptchaOptions
    {
        internal Type CaptchaStorageProvider { get; set; }
        internal Type CaptchaSerializationProvider { get; set; }

        /// <summary>
        /// You can introduce a custom ICaptchaStorageProvider to be used as an StorageProvider.
        /// </summary>
        /// <typeparam name="T">Implements ICaptchaStorageProvider</typeparam>
        public void UseCustomStorageProvider<T>() where T : ICaptchaStorageProvider
        {
            CaptchaStorageProvider = typeof(T);
        }

        /// <summary>
        /// Using the IDistributedCache
        /// Don't forget to configure your DistributedCache provider such as `services.AddStackExchangeRedisCache()` first.
        /// </summary>
        public void UseDistributedSerializationProvider()
        {
            CaptchaSerializationProvider = typeof(DistributedSerializationProvider);
        }

        /// <summary>
        /// Using the IMemoryCache
        /// </summary>
        public void UseInMemorySerializationProvider()
        {
            CaptchaSerializationProvider = typeof(InMemorySerializationProvider);
        }

        /// <summary>
        /// Introduces the built-in `SessionCaptchaStorageProvider` to be used as an StorageProvider.
        /// Don't forget to add `services.AddSession();` in ConfigureServices() method and `app.UseSession();` in Configure() method.
        /// </summary>
        public void UseSessionStorageProvider()
        {
            CaptchaStorageProvider = typeof(SessionCaptchaStorageProvider);
        }

        /// <summary>
        /// Introduces the built-in `CookieCaptchaStorageProvider` to be used as an StorageProvider.
        /// </summary>
        public void UseCookieStorageProvider()
        {
            CaptchaStorageProvider = typeof(CookieCaptchaStorageProvider);
        }

        /// <summary>
        /// Introduces the built-in `CookieCaptchaStorageProvider` to be used as an StorageProvider.
        /// </summary>
        public void UseMemoryCacheStorageProvider()
        {
            CaptchaStorageProvider = typeof(MemoryCacheCaptchaStorageProvider);
        }

        /// <summary>
        /// Introduces the built-in `DistributedCacheCaptchaStorageProvider` to be used as an StorageProvider.
        /// Don't forget to configure your DistributedCache provider such as `services.AddStackExchangeRedisCache()` first.
        /// </summary>
        public void UseDistributedCacheStorageProvider()
        {
            CaptchaStorageProvider = typeof(DistributedCacheCaptchaStorageProvider);
            CaptchaSerializationProvider = typeof(DistributedSerializationProvider);
        }
    }
}