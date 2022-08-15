using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using PropertyManagementRepository.Models;

namespace PropertyManagementRepository.Interfaces
{
    public interface IMaintenanceRequestRepository
    {
        public ActionResult<IEnumerable<MaintenanceRequest>> GetRequestByEmployeeId(int employeeId, bool completed);
        public ActionResult<IEnumerable<MaintenanceRequest>> GetRequestByStatus(RequestStatus status);
        public ActionResult<MaintenanceRequest> CreateMaintenanceRequest(MaintenanceRequest maintenanceRequest);
        public ActionResult<MaintenanceRequest> UpdateMaintenanceRequest(MaintenanceRequest maintenanceRequest);
    }
}