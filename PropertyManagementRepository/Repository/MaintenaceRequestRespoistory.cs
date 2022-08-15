using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropertyManagementRepository.Interfaces;
using PropertyManagementRepository.Models;

namespace PropertyManagement
{
    public class MaintenanceRequestRepository: IMaintenanceRequestRepository
    {
        private readonly EFDBContext _dbContext;
        private readonly ILogger<MaintenanceRequestRepository> _logger;
        public MaintenanceRequestRepository(
            EFDBContext dbContext,
            ILogger<MaintenanceRequestRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public ActionResult<IEnumerable<MaintenanceRequest>> GetRequestByEmployeeId(int employeeId, bool completed)
        {
            var results = _dbContext.MaintenanceRequests.Where(request => request.EmployeeId == employeeId);
            return new OkObjectResult(results);
        }

        public ActionResult<IEnumerable<MaintenanceRequest>> GetRequestByStatus(RequestStatus status)
        {
           var results = _dbContext.MaintenanceRequests.Where(request => request.Status == status);
           return new OkObjectResult(results);
        }

        public ActionResult<MaintenanceRequest> CreateMaintenanceRequest(MaintenanceRequest maintenanceRequest)
        {
            try
            {
                _dbContext.Add(maintenanceRequest);
                var result = _dbContext.SaveChanges();
                return new OkObjectResult(maintenanceRequest);
            }
            catch
            {
                return new BadRequestResult();
            }
            
        }

        public ActionResult<MaintenanceRequest> UpdateMaintenanceRequest(MaintenanceRequest maintenanceRequest)
        {
            var result =
                _dbContext.MaintenanceRequests.FirstOrDefault(request =>
                    request.RequestId == maintenanceRequest.RequestId);
            if (result != null)
            {
                result = maintenanceRequest;
                _dbContext.SaveChanges();
                return new OkObjectResult(maintenanceRequest);
            }

            return new NotFoundResult();
        }
    }
}