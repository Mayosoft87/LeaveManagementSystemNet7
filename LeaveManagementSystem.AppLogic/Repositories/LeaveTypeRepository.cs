using LeaveManagementSystem.AppLogic.Contracts;
using LeaveManagementSystem.Data;

namespace LeaveManagementSystem.AppLogic.Repositories
{
    public class LeaveTypeRepository: GenericRepository<LeaveType>,ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
