using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ResetPasswordDto:IDto
    {
        public string ToEmail { get; set; }
    }
}
