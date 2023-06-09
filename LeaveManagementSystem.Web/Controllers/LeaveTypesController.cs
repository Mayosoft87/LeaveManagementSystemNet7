﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Data;
using AutoMapper;
using LeaveManagementSystem.Common.Models;
using LeaveManagementSystem.AppLogic.Contracts;
using LeaveManagementSystem.AppLogic.Repositories;
using Microsoft.AspNetCore.Authorization;
using LeaveManagementSystem.Common;
using System.Diagnostics.CodeAnalysis;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize(Roles =Roles.Administrator)]
    public class LeaveTypesController : Controller
    {
        
        //Dependecy Injection

        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILogger<LeaveTypesController> _logger;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepository, IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository,
            ILogger<LeaveTypesController> logger)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _logger = logger;
        }

        
        /// <summary>
        /// GET: LeaveTypes
        /// Get all the LeaveTypes that is on the table
        /// </summary>
        /// <returns>LeaveTypeVM</returns>
        public async Task<IActionResult> Index()
        {
            var leaveTypes = _mapper.Map<List<LeaveTypeVM>>(await _leaveTypeRepository.GetAllAsync());
            return View(leaveTypes);
         
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            var leaveTypeVM = _mapper.Map<LeaveTypeVM>(await _leaveTypeRepository.GetAsync(id));
            if (leaveTypeVM == null)
            {
                return NotFound();
            }
            return View(leaveTypeVM);
        }

        /// <summary>
        /// GET: LeaveTypes/Create
        /// Create the form.
        /// </summary>
        /// <returns>View()</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( LeaveTypeVM leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                await _leaveTypeRepository.AddAsync(_mapper.Map<LeaveType>(leaveTypeVM));
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveTypeVM = _mapper.Map<LeaveTypeVM>(await _leaveTypeRepository.GetAsync(id));
            if (leaveTypeVM == null)
            {
                return NotFound();
            }
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  LeaveTypeVM leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }
            var leaveType = await _leaveTypeRepository.GetAsync(id);

            if (leaveType == null)

            if (ModelState.IsValid)
            {
                    try
                    {
                        _mapper.Map(leaveType, leaveTypeVM);
                        await _leaveTypeRepository.UpdateAsync(leaveType);
                    }
                    catch(DbUpdateConcurrencyException ex)
                    {
                        if (!await _leaveTypeRepository.Exists(leaveTypeVM.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            _logger.LogError(ex, "Error Edit LeaveType Edit");
                            throw;
                        }
                    }
               
              
            }
            return View(leaveTypeVM);
        }

   
        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LeaveTypeExistsAsync(int id)
        {
          return await _leaveTypeRepository.Exists(id);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(int id)
        {
             await _leaveAllocationRepository.LeaveAllocation(id);
             return RedirectToAction(nameof(Index));
        }
    }
}
