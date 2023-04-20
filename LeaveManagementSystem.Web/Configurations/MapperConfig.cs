using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models;

namespace LeaveManagementSystem.Web.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
        }
    }
}
