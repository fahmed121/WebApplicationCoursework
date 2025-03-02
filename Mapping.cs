using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using WebApplicationCourseWork.DTO;
using WebApplicationCourseWork.Models;
namespace WebApplicationCourseWork // mapper configuration
{
    public class Mapping : Profile
    {   
        public Mapping()
        {
        CreateMap<Customer, CustomerDTO>().ReverseMap(); // reverse map allows for the mapping to be two ways
        CreateMap<Order, OrderDTO>().ReverseMap();
        CreateMap<Item, ItemDTO>().ReverseMap();
        CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
        CreateMap<Staff, StaffDTO>().ReverseMap();
        }
    }
}