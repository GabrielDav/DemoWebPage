using AutoMapper;
using BusinessLogic.DTO;
using WebPage.Models;

namespace WebPage
{
    /// <summary>
    /// Service model mapping class
    /// </summary>
    public static class Mappings
    {
        /// <summary>
        /// Initialize service mappings
        /// </summary>
        public static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<UserTicket, UserTicketResponseModel>();
            config.CreateMap<UserTicketRequestModel, UserTicket>();
        }
    }
}
