using DoctorWho.Db;
using FluentValidation;

namespace DoctorWho.Web.Services
{
    public interface IDoctorManager
    {
        public Task Manage(tblDoctor doctor);
      
    }
}
