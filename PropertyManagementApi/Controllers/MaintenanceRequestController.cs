using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropertyManagementRepository.Models;
using PropertyManagementServices.Interfaces;

namespace PropertyManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaintenanceRequestController:ControllerBase
    {
        private readonly ILogger<MaintenanceRequestController> _logger;
        private readonly IMaintenanceRequestService _service;
        public MaintenanceRequestController(ILogger<MaintenanceRequestController> logger, IMaintenanceRequestService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet("GetByStatus")]
        public ActionResult<IEnumerable<MaintenanceRequest>> GetMaintenanceRequestByStatus(RequestStatus status)
        {
            return _service.GetMaintenanceRequestByStatus(status);
        }
        [HttpGet("GetAssignedRequests")]
        public ActionResult<IEnumerable<MaintenanceRequest>> GetAssignedMaintenanceRequest(int employeeId, bool completed)
        {
            return _service.GetAssignedMaintenanceRequest(employeeId, completed);
        }

        [HttpPost( "AddMaintenanceRequest")]
        public ActionResult<MaintenanceRequest> CreateMaintenanceRequest(MaintenanceRequest maintenanceRequest)
        {
            return _service.CreateMaintenanceRequest(maintenanceRequest);
        }

        [HttpPatch("UpdateMaintenanceRequest")]
        
        public ActionResult<MaintenanceRequest> UpdateMaintenanceRequest(MaintenanceRequest maintenanceRequest)
        {
            return _service.UpdateMaintenanceRequest(maintenanceRequest);
        }
    }
    
}