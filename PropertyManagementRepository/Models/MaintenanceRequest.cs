using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PropertyManagementRepository.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MaintenanceRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateCompleted { get; set; } 
        public DateTime AppointmentDate { get; set; }
        public int Cats { get; set; }
        public int Dogs { get; set; }
        [Required]
        public string JobDescription { get; set; }
        public string WorkPerformed { get; set; }
        public int HoursWorked { get; set; }
        public int RequestTypeId { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        public int HouseId { get; set; }
        [Required]
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