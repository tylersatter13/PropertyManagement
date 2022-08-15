using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementRepository.Models;

namespace PropertyManagementServices.Interfaces
{
    public interface IMaintenanceRequestService
    {
        public ActionResult<MaintenanceRequest> CreateMaintenanceRequest(MaintenanceRequest maintenanceRequest);
        public ActionResult<IEnumerable<MaintenanceRequest>> GetAssignedMaintenanceRequest(int employeeId, bool completed);
        public ActionResult<MaintenanceRequest> UpdateMaintenanceRequest(MaintenanceRequest maintenanceRequest);
        public ActionResult<IEnumerable<MaintenanceRequest>> GetMaintenanceRequestByStatus(RequestStatus status);
    }
}