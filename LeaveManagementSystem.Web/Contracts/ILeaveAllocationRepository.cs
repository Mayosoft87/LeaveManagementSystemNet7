﻿using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models;

namespace LeaveManagementSystem.Web.Contracts
{
    public interface ILeaveAllocationRepository: IGenericRepository<LeaveAllocation>
    {
      Task LeaveAllocation(int leaveTypeId);
      Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);
      Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId);
      Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id);
      Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId,int Id);
      Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model);
    }
}
