using LeaveManagementSystem.Web.Contracts;
using LeaveManagementSystem.Web.Data;

namespace LeaveManagementSystem.Web.Repositories
{
    public class LeaveTypeRepository: GenericRepository<LeaveType>,ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
