using DoctorWho.Db;

namespace DoctorWho.Web.Services
{
    public interface IAuthorManager
    {
        public Task Manage(tblAuthor author);
    }
}
