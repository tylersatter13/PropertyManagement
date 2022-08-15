using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementRepository.Interfaces;
using PropertyManagementRepository.Models;
using PropertyManagementServices.Interfaces;

namespace PropertyManagementServices.Services
{
    public class MaintenanceRequestService:IMaintenanceRequestService
    {
        private readonly IMaintenanceRequestRepository _repository;
        public MaintenanceRequestService(IMaintenanceRequestRepository repository )
        {
            _repository = repository;
        }
        public ActionResult<MaintenanceRequest> CreateMaintenanceRequest(MaintenanceRequest maintenanceRequest)
        {
            return _repository.CreateMaintenanceRequest(maintenanceRequest);
        }

        public ActionResult<IEnumerable<MaintenanceRequest>> GetAssignedMaintenanceRequest(int employeeId, bool completed)
        {
            return _repository.GetRequestByEmployeeId(employeeId,completed);
        }

        public ActionResult<MaintenanceRequest> UpdateMaintenanceRequest(MaintenanceRequest maintenanceRequest)
        {
            return _repository.UpdateMaintenanceRequest(maintenanceRequest);
        }

        public ActionResult<IEnumerable<MaintenanceRequest>> GetMaintenanceRequestByStatus(RequestStatus status)
        {
            return _repository.GetRequestByStatus(status);
        }
    }
}