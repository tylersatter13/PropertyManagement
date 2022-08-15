using System;
using System.Collections.Generic;

namespace PropertyManagement.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MaintenanceRequest
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateCompleted { get; set; } 
        public DateTime AppointmentDate { get; set; }
        public int Cats { get; set; }
        public int Dogs { get; set; }
        public string JobDescription { get; set; }
        public string WorkPerformed { get; set; }
        public List<string> WorkComments { get; set; }
        public int HoursWorked { get; set; }
        public int RequestTypeId { get; set; }
        public int EmployeeId { get; set; }
        public int HouseId { get; set; }
        public RequestStatus Status { get; set; }
    }

    public enum RequestStatus
    {
        New,
        Investigating,
        Inprogress,
        Completed
    }
}