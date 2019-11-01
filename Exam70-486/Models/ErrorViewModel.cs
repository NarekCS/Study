using Microsoft.AspNetCore.Mvc;
using System;

namespace Exam70_486.Models
{   
    public class ErrorViewModel
    {      
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
