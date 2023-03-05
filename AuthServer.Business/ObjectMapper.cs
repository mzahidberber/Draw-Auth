using AutoMapper;

namespace AuthServer.Business
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTOMapper>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;

    }
}
